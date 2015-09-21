//#include <OneWire.h>
//#include <DallasTemperature.h>
#include <dht.h>
//#include <Stepper.h>
#include <AccelStepper.h>
#include <Timer.h>

//INITS
/*
//DS1820
#define TEMP_SENSOR_PIN 4
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature tempSensor(&oneWire);
DeviceAddress insideThermometer;
*/
//DHT22
#define DHTPIN 2
#define DHTTYPE DHT22
dht DHT;
#define BCOEFFICIENT 3988

#define PWM1 3
#define PWM2 5
#define PWM3 9
#define PWM4 6
#define NTC A7
#define REGCHK A6
#define AKUCHK A0

const int stepsPerRevolution = 1600;  // change this to fit the number of steps per revolution
// for your motor


// initialize the stepper library on pins 8 through 11:
//Stepper myStepper(stepsPerRevolution, 7,);

AccelStepper stepper (1,7,8);
Timer timer;

//GLOBAL
String inputString;                  // Serial input command string (terminated with \n)
long focuserPosition;
int voltageIterator, sensorVcc, sensorVreg;

void setup()
{
  //Serial init
  Serial.begin(9600);
  Serial.setTimeout(2000);
  inputString = "";
  voltageIterator = 0;
  sensorVcc = 0;
  sensorVreg = 0;
  
  //pinMode(PWM1, OUTPUT);
  analogWrite(PWM1, 0);
  //pinMode(PWM2, OUTPUT);
  analogWrite(PWM2, 0);
  //pinMode(PWM3, OUTPUT);
  analogWrite(PWM3, 0);
  //pinMode(PWM4, OUTPUT);
  analogWrite(PWM4, 0);
  pinMode(NTC, INPUT);
  pinMode(REGCHK, INPUT);
  pinMode(AKUCHK, INPUT);

  int chk = DHT.read22(DHTPIN);
  //tempSensor.begin(); 
  
  stepper.setMaxSpeed(400);
  stepper.setAcceleration(1600);
  stepper.setCurrentPosition(0);
  //initializeProperties();
    
  timer.every(500, readPosition);
  timer.every(100, readVoltage);
  //timer.every(1000, readNTC);
  if (chk == DHTLIB_OK) timer.every(3000, readSensors);
}

void loop()
{
  stepper.run();
  timer.update();
}

void readSensors()
{
  float currentTemp, currentHum, currentDewpoint; 

  DHT.read22(DHTPIN);
  currentTemp = DHT.temperature;
  currentHum = DHT.humidity;
  currentDewpoint = dewPoint(currentTemp, currentHum);
  Serial.print("T:");
  Serial.println(currentTemp);
  Serial.print("W:");
  Serial.println(currentHum);
  Serial.print("D:");
  Serial.println(currentDewpoint);
  
  //readNTC();
}

void readVoltage()
{
  sensorVcc += analogRead(AKUCHK);
  sensorVreg += analogRead(REGCHK);
  voltageIterator++;
  
  if (voltageIterator > 9)
  {
    Serial.print("V:");
    Serial.println(sensorVcc/10);
    Serial.print("C:");
    Serial.println(sensorVreg/10);
    sensorVcc = 0 ;
    sensorVreg = 0;
    voltageIterator = 0;
  }
}

void readPosition()
{
  focuserPosition = stepper.currentPosition();
  Serial.print("O:");
  Serial.println(focuserPosition);
}

void readNTC()
{
  int i, NTCtmp;
  float NTCres, NTCtemperature;
  double Temp;
    
  NTCtmp = 0;
  for (i = 0; i < 5; i++)
  {
    NTCtmp += analogRead(NTC);
    delay(10);
  }
  
  NTCres = NTCtmp/5;
  Temp = log(((10240000/NTCres) - 10000));
  Temp = 1 / (0.001129148 + (0.000234125 * Temp) + (0.0000000876741 * Temp * Temp * Temp));
  Temp = Temp - 273.15;           // Convert Kelvin to Celcius

  Serial.print("N:");
  Serial.println(Temp);
}

void serialEvent()
{
  while (Serial.available() > 0)
  {
    char inChar = (char)Serial.read(); 
    if (inChar == '\n')
    {
      serialCommand(inputString); 
      inputString = "";
    } 
    else inputString += inChar;
  }  
}


void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";
  long val;

// P - set PWM
// M - move x steps
// H - hold stepper
// S - set position
// I - initialize position
// T - get temperature
// N - get temperature 2
// W - get humidity
// D - get dew point
// V - get Vcc
// C - get Vreg
// O - get position

// ASCOM driver
// i - is moving
// p - position

  switch(command.charAt(0)) {
    case 'P': 
      val = param.substring(2).toInt();
      //Serial.println(val);     
      switch(param.charAt(0))
      {
        case '1': analogWrite(PWM1, map(val, 0, 100, 0, 255)); break;
        case '2': analogWrite(PWM2, map(val, 0, 100, 0, 255)); break;
        case '3': analogWrite(PWM3, map(val, 0, 100, 0, 255)); break;
        case '4': analogWrite(PWM4, map(val, 0, 100, 0, 255)); break;
        default: break;
      }
      break;     
    case 'M':
      val = param.substring(0).toInt();
      stepper.move(val);
      break;  
    case 'H': 
      stepper.stop();
      break;
    case 'S': 
      val = param.substring(0).toInt();
      stepper.moveTo(val);
      break;
    case 'I':
      val = param.substring(0).toInt(); 
      focuserPosition = val;
      stepper.setCurrentPosition(focuserPosition);
      readPosition();
      break;
    case 'i': 
      answer += (stepper.distanceToGo() != 0) ? "1" : "0"; 
      Serial.println(answer);
      break;      
    case 'p':
      answer += stepper.currentPosition();
      Serial.println(answer);
      break;  
    default: 
      Serial.println("error");
  }
}

double dewPoint(double celsius, double humidity)
{
  // (1) Saturation Vapor Pressure = ESGG(T)
  double RATIO = 373.15 / (273.15 + celsius);
  double RHS = -7.90298 * (RATIO - 1);
  RHS += 5.02808 * log10(RATIO);
  RHS += -1.3816e-7 * (pow(10, (11.344 * (1 - 1/RATIO ))) - 1) ;
  RHS += 8.1328e-3 * (pow(10, (-3.49149 * (RATIO - 1))) - 1) ;
  RHS += log10(1013.246);

  // factor -3 is to adjust units - Vapor Pressure SVP * humidity
  double VP = pow(10, RHS - 3) * humidity;

  // (2) DEWPOINT = F(Vapor Pressure)
  double T = log(VP/0.61078);   // temp var
  return (241.88 * T) / (17.558 - T);
}

String formatFloat(float value, byte length, byte precision)
{
  char tmp [length + 1];
  dtostrf(value, length, precision, tmp);  
  return String(tmp);
}

String formatLong(long value, byte length)
{
  char tmp [length + 1];
  dtostrf(value, length, 0, tmp);  
  return String(tmp);
}

