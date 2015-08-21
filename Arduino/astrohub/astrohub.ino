#include <OneWire.h>
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

void setup()
{
  //Serial init
  Serial.begin(9600);
  Serial.setTimeout(2000);
  inputString = "";
  
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
  timer.every(1000, readVoltage);
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
  Serial.println("T:" + formatFloat(currentTemp, 6, 2));
  Serial.println("W:" + formatLong(currentHum, 3));
  Serial.println("D:" + formatFloat(currentDewpoint, 6, 2));
  
  //readNTC();
}

void readVoltage()
{
  int sensorVcc, sensorVreg;
  
  sensorVcc = analogRead(AKUCHK);
  sensorVreg = analogRead(REGCHK);
  Serial.println("V:" + formatLong(sensorVcc, 3));
  Serial.println("C:" + formatLong(sensorVreg, 3));
}

void readPosition()
{
  focuserPosition = stepper.currentPosition();
  Serial.println("O:" + formatLong(focuserPosition, 7));
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
//  NTCres = 1023/NTCres-1;
//  NTCres = 10000/NTCres;
//  
//  NTCtemperature = NTCres/10000;     // (R/Ro)
//  NTCtemperature = log(NTCtemperature); // ln(R/Ro)
//  NTCtemperature /= BCOEFFICIENT;                   // 1/B * ln(R/Ro)
//  NTCtemperature += 1.0/(25+273.15); // + (1/To)
//  NTCtemperature = 1.0/NTCtemperature;                 // Invert the value
//  NTCtemperature -= 273.15;
//  
//  Serial.println("N:" + formatFloat(NTCtemperature, 6, 2));
  Serial.println("N:" + formatFloat(Temp, 6, 2));
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
      //Serial.println(val);
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
    
    default: Serial.println("error");
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

