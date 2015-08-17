/****************************************************************************
**
** Copyright (C) 2012 Denis Shienkov <denis.shienkov@gmail.com>
** Copyright (C) 2012 Laszlo Papp <lpapp@kde.org>
** Contact: http://www.qt-project.org/legal
**
** This file is part of the QtSerialPort module of the Qt Toolkit.
**
** $QT_BEGIN_LICENSE:LGPL21$
** Commercial License Usage
** Licensees holding valid commercial Qt licenses may use this file in
** accordance with the commercial license agreement provided with the
** Software or, alternatively, in accordance with the terms contained in
** a written agreement between you and Digia. For licensing terms and
** conditions see http://qt.digia.com/licensing. For further information
** use the contact form at http://qt.digia.com/contact-us.
**
** GNU Lesser General Public License Usage
** Alternatively, this file may be used under the terms of the GNU Lesser
** General Public License version 2.1 or version 3 as published by the Free
** Software Foundation and appearing in the file LICENSE.LGPLv21 and
** LICENSE.LGPLv3 included in the packaging of this file. Please review the
** following information to ensure the GNU Lesser General Public License
** requirements will be met: https://www.gnu.org/licenses/lgpl.html and
** http://www.gnu.org/licenses/old-licenses/lgpl-2.1.html.
**
** In addition, as a special exception, Digia gives you certain additional
** rights. These rights are described in the Digia Qt LGPL Exception
** version 1.1, included in the file LGPL_EXCEPTION.txt in this package.
**
** $QT_END_LICENSE$
**
****************************************************************************/

#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "settingsdialog.h"

#include <QMessageBox>
#include <QtSerialPort>
#include <QDebug>
#include <QIntValidator>
#include <QTextCursor>
#include <QSplitterHandle>
#include <QInputDialog>
#include <QFile>
#include <QTextStream>

#define MAXLINES 500

QString send;
int TextBrowserLines = 0;
int PWMtemp;
int stepperDir = 1  ;
double VDivider = 4.3;

//! [0]
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
//! [0]
    ui->setupUi(this);

//    QByteArray datra = "QByteArray(myArray)";
//    QString dat(datra);
//    qDebug() << dat;

//! [1]
    serial = new QSerialPort(this);
//! [1]
    settings = new SettingsDialog;

    QIntValidator* Move_Validator = new QIntValidator(-99999, 99999, this);
    QIntValidator* MoveTo_Validator = new QIntValidator(-999999, 999999, this);
    ui->Move_Edit->setValidator(Move_Validator);
    ui->MoveTo_Edit->setValidator(MoveTo_Validator);

    QSplitterHandle* hnd = ui->splitter->handle(0);
    hnd->setEnabled(false);

    ui->actionConnect->setEnabled(true);
    ui->actionDisconnect->setEnabled(false);
    ui->actionQuit->setEnabled(true);
    ui->actionConfigure->setEnabled(true);

    initActionsConnections();
    initialize();

    connect(serial, SIGNAL(error(QSerialPort::SerialPortError)), this,
            SLOT(handleError(QSerialPort::SerialPortError)));

//! [2]
    connect(serial, SIGNAL(readyRead()), this, SLOT(readData()));
//! [3]
}
//! [3]

MainWindow::~MainWindow()
{
    QString filename = QDir::currentPath() + "/sett.cfg";
    QFile file(filename);
    if (!file.open(QIODevice::WriteOnly)) QMessageBox::information(0, "error", file.errorString());
    QTextStream out(&file);
    out << ui->Pos1_Button->text() << endl;
    out << P1 << endl;
    out << ui->Pos2_Button->text() << endl;
    out << P2 << endl;
    out << ui->Pos3_Button->text() << endl;
    out << P3 << endl;
    out << ui->Pos4_Button->text() << endl;
    out << P4 << endl;
    out << ui->Pos5_Button->text() << endl;
    out << P5 << endl;
    out << ui->Motor_Display->value() << endl;
    out << stepperDir << endl;
    out << VDivider;

    delete settings;
    delete ui;
}

//! [4]
void MainWindow::openSerialPort()
{
    SettingsDialog::Settings p = settings->settings();
    serial->setPortName(p.name);
    if (serial->open(QIODevice::ReadWrite)) {
            ui->actionConnect->setEnabled(false);
            ui->actionDisconnect->setEnabled(true);
            ui->actionConfigure->setEnabled(false);
            ui->statusBar->showMessage(tr("Connected to %1 : %2, %3, %4, %5, %6")
                                       .arg(p.name).arg(p.stringBaudRate).arg(p.stringDataBits)
                                       .arg(p.stringParity).arg(p.stringStopBits).arg(p.stringFlowControl));
    } else {
        QMessageBox::critical(this, tr("Error"), serial->errorString());

        ui->statusBar->showMessage(tr("Open error"));
    }
    serial->setBaudRate(p.baudRate);
    serial->setDataBits(p.dataBits);
    serial->setParity(p.parity);
    serial->setStopBits(p.stopBits);
    serial->setFlowControl(p.flowControl);

    send = "I:";
    send.append(QString::number(tempDisp));
    send.append('\n');
    serial->write(send.toLocal8Bit());
}

void MainWindow::closeSerialPort()
{
    if (serial->isOpen())
        serial->close();
    ui->actionConnect->setEnabled(true);
    ui->actionDisconnect->setEnabled(false);
    ui->actionConfigure->setEnabled(true);
    ui->statusBar->showMessage(tr("Disconnected"));
}
//! [5]

void MainWindow::about()
{
    QMessageBox::about(this, tr("AstroHub"),
                       tr("AstroHub v1.0<br>"
                          "Designed and created by Iluvatar"));
}

void MainWindow::clear()
{
    ui->textBrowser->clear();
    TextBrowserLines = 0;
}

void MainWindow::nightMode()
{
    if (ui->actionNight_mode->isChecked())
    {
        ui->centralWidget->setStyleSheet("");
        this->setStyleSheet("background-color: black;");
        ui->centralWidget->setStyleSheet("background-color: #222222; color: red;");
        ui->menuBar->setStyleSheet("QMenuBar {background-color: #222222; color: red; selection-background-color: #444444;}"
                                   "QMenuBar::item {background-color: #222222; color: red;}"
                                   "QMenuBar::item:selected {background-color: #444444;}");
        ui->menuCalls->setStyleSheet("QMenu {background-color: #222222; color: red; selection-background-color: #444444;}"
                                     "QMenu::item {background-color: #222222; color: red;}"
                                     "QMenu::item:selected {background-color: #444444;}");
        ui->menuTools->setStyleSheet("QMenu {background-color: #222222; color: red; selection-background-color: #444444;}"
                                     "QMenu::item {background-color: #222222; color: red;}"
                                     "QMenu::item:selected {background-color: #444444;}");
        ui->menuHelp->setStyleSheet("QMenu {background-color: #222222; color: red; selection-background-color: #444444;}"
                                     "QMenu::item {background-color: #222222; color: red;}"
                                     "QMenu::item:selected {background-color: #444444;}");
        ui->mainToolBar->setStyleSheet("background-color: #222222; color: red; border-top-color: black");
        ui->Stop_Button->setStyleSheet("background-color: red; color: black");
        ui->Move_Edit->setStyleSheet("border: 1px solid #828790; background: #222222;");
        ui->MoveTo_Edit->setStyleSheet("border: 1px solid #828790; background: #222222;");
    }
    else
    {
        ui->centralWidget->setStyleSheet("");
        this->setStyleSheet("");
        ui->menuBar->setStyleSheet("");
        ui->menuCalls->setStyleSheet("");
        ui->menuTools->setStyleSheet("");
        ui->menuHelp->setStyleSheet("");
        ui->mainToolBar->setStyleSheet("");
        ui->textBrowser->setStyleSheet("background-color: rgb(0, 0, 0); color: rgb(0, 255, 0);");
        ui->Stop_Button->setStyleSheet("background-color: red;");
        ui->Move_Edit->setStyleSheet("");
        ui->MoveTo_Edit->setStyleSheet("");
    }
}

//! [6]
void MainWindow::writeData(const QByteArray &data)
{
    serial->write(data);
}
//! [6]

//! [7]
void MainWindow::readData()
{
    while (serial->canReadLine())
    {
        QByteArray data = serial->readLine();
        QString temp(data);
        QString val = temp.mid(2);

        switch (data[0])
        {
        case 'T':
            ui->Temperature_Display->display(val.toDouble());
            break;
        case 'N':
            ui->Temperature2_Display->display(val.toDouble());
            break;
        case 'W':
            ui->Humidity_Display->display(val.toDouble());
            updateHeaters();
            break;
        case 'D':
            ui->DewPoint_Display->display(val.toDouble());
            break;
        case 'V':
            ui->Vcc_Display->display((val.toDouble()/1023)*5*VDivider);
            break;
        case 'C':
            ui->Vreg_Display->display((val.toDouble()/1023)*5*VDivider);
            break;
        case 'O':
            ui->Motor_Display->display(val.toInt());
            break;
        default:
            break;
        }

        //if (data[0] == 'T') /*qDebug() << "T = " << val << endl;*/ui->Temp->display(val.toDouble());
        //qDebug() << temp << endl;
    }
}
//! [7]

//! [8]
void MainWindow::handleError(QSerialPort::SerialPortError error)
{
    if (error == QSerialPort::ResourceError) {
        QMessageBox::critical(this, tr("Critical Error"), serial->errorString());
        closeSerialPort();
    }
}
//! [8]

void MainWindow::initActionsConnections()
{
    connect(ui->actionConnect, SIGNAL(triggered()), this, SLOT(openSerialPort()));
    connect(ui->actionDisconnect, SIGNAL(triggered()), this, SLOT(closeSerialPort()));
    connect(ui->actionQuit, SIGNAL(triggered()), this, SLOT(close()));
    connect(ui->actionConfigure, SIGNAL(triggered()), settings, SLOT(show()));
    connect(ui->actionAbout, SIGNAL(triggered()), this, SLOT(about()));
    connect(ui->actionClear, SIGNAL(triggered()), this, SLOT(clear()));
    connect(ui->actionNight_mode, SIGNAL(triggered()), this, SLOT(nightMode()));
}

void MainWindow::initialize()
{
    ui->PWM1_Heater->setDisabled(true);
    ui->PWM1_Slider->setDisabled(true);
    ui->PWM2_Heater->setDisabled(true);
    ui->PWM2_Slider->setDisabled(true);
    ui->PWM3_Heater->setDisabled(true);
    ui->PWM3_Slider->setDisabled(true);
    ui->PWM4_Heater->setDisabled(true);
    ui->PWM4_Slider->setDisabled(true);

    int it = 1;
    QString filename = QDir::currentPath() + "/sett.cfg";
    QFile file(filename);
    if (!file.open(QIODevice::ReadOnly)) QMessageBox::information(0, "error", file.errorString());
    QTextStream in(&file);

    while (!in.atEnd())
    {
        QString line = in.readLine();
        //qDebug() << line << endl;
        switch (it)
        {
        case 1: ui->Pos1_Button->setText(line); break;
        case 2: P1 = line.toInt(); break;
        case 3: ui->Pos2_Button->setText(line); break;
        case 4: P2 = line.toInt(); break;
        case 5: ui->Pos3_Button->setText(line); break;
        case 6: P3 = line.toInt(); break;
        case 7: ui->Pos4_Button->setText(line); break;
        case 8: P4 = line.toInt(); break;
        case 9: ui->Pos5_Button->setText(line); break;
        case 10: P5 = line.toInt(); break;
        case 11: tempDisp = line.toInt(); break;
        case 12:
            if (line.toInt() == 0) stepperDir = -1;
            else stepperDir = line.toInt();
            break;
        case 13: VDivider = line.toDouble(); break;
        case 14: break;
        }

        it++;
    }

    file.close();

    ui->Pos1_Button->setToolTip("go to " + QString::number(P1));
    ui->Pos1_Button->setToolTip("go to " + QString::number(P2));
    ui->Pos1_Button->setToolTip("go to " + QString::number(P3));
    ui->Pos1_Button->setToolTip("go to " + QString::number(P4));
    ui->Pos1_Button->setToolTip("go to " + QString::number(P5));
}

void MainWindow::updateHeaters()
{
    PWMtemp = (ui->Humidity_Display->value()-50)*2;
    if (PWMtemp < 0) PWMtemp = 0;
    if (PWMtemp > 100) PWMtemp = 100;

    if (ui->PWM1_Heater->isChecked())
    {
        send = "P:1:";
        send.append(QString::number(PWMtemp));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
        ui->PWM1_Display->display(QString::number(PWMtemp));
        ui->PWM1_Slider->setValue(PWMtemp);
    }

    if (ui->PWM2_Heater->isChecked())
    {
        send = "P:2:";
        send.append(QString::number(PWMtemp));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
        ui->PWM2_Display->display(QString::number(PWMtemp));
        ui->PWM2_Slider->setValue(PWMtemp);
    }

    if (ui->PWM3_Heater->isChecked())
    {
        send = "P:3:";
        send.append(QString::number(PWMtemp));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
        ui->PWM3_Display->display(QString::number(PWMtemp));
        ui->PWM3_Slider->setValue(PWMtemp);
    }

    if (ui->PWM4_Heater->isChecked())
    {
        send = "P:4:";
        send.append(QString::number(PWMtemp));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
        ui->PWM4_Display->display(QString::number(PWMtemp));
        ui->PWM4_Slider->setValue(PWMtemp);
    }
}

void MainWindow::textBrowserAppend(QString send)
{
    QTextCursor cursor = ui->textBrowser->textCursor();

    ui->textBrowser->append(send);
    TextBrowserLines++;
    if (TextBrowserLines > MAXLINES)
    {
        cursor.movePosition(QTextCursor::Start, QTextCursor::MoveAnchor);
        cursor.movePosition(QTextCursor::Down, QTextCursor::KeepAnchor);
        cursor.removeSelectedText();
        cursor.movePosition(QTextCursor::End);
        ui->textBrowser->setTextCursor(cursor);
        TextBrowserLines--;
    }
}

void MainWindow::on_PWM1_Check_toggled(bool checked)
{
    ui->PWM1_Slider->setEnabled(checked);
    ui->PWM1_Heater->setEnabled(checked);
    if (!checked)
    {
        ui->PWM1_Slider->setValue(0);
        ui->PWM1_Heater->setChecked(false);
        send = "P:1:0";
        textBrowserAppend(send);
        send.append('\n');
        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_PWM2_Check_toggled(bool checked)
{
    ui->PWM2_Slider->setEnabled(checked);
    ui->PWM2_Heater->setEnabled(checked);
    if (!checked)
    {
        ui->PWM2_Slider->setValue(0);
        ui->PWM2_Heater->setChecked(false);
        send = "P:2:0";
        textBrowserAppend(send);
        send.append('\n');
        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_PWM3_Check_toggled(bool checked)
{
    ui->PWM3_Slider->setEnabled(checked);
    ui->PWM3_Heater->setEnabled(checked);
    if (!checked)
    {
        ui->PWM3_Slider->setValue(0);
        ui->PWM3_Heater->setChecked(false);
        send = "P:3:0";
        textBrowserAppend(send);
        send.append('\n');
        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_PWM4_Check_toggled(bool checked)
{
    ui->PWM4_Slider->setEnabled(checked);
    ui->PWM4_Heater->setEnabled(checked);
    if (!checked)
    {
        ui->PWM4_Slider->setValue(0);
        ui->PWM4_Heater->setChecked(false);
        send = "P:4:0";
        textBrowserAppend(send);
        send.append('\n');
        serial->write(send.toLocal8Bit());

    }
}

void MainWindow::on_PWM1_Slider_sliderReleased()
{
    send = "P:1:";
    send.append(QString::number(ui->PWM1_Slider->value()));
    textBrowserAppend(send);
    send.append('\n');

    //qDebug() << "P = " << send << endl;
    serial->write(send.toLocal8Bit());
}

void MainWindow::on_PWM2_Slider_sliderReleased()
{
    send = "P:2:";
    send.append(QString::number(ui->PWM2_Slider->value()));
    textBrowserAppend(send);
    send.append('\n');

    //qDebug() << "P = " << send << endl;
    serial->write(send.toLocal8Bit());
}

void MainWindow::on_PWM3_Slider_sliderReleased()
{
    send = "P:3:";
    send.append(QString::number(ui->PWM3_Slider->value()));
    textBrowserAppend(send);
    send.append('\n');

    //qDebug() << "P = " << send << endl;
    serial->write(send.toLocal8Bit());
}

void MainWindow::on_PWM4_Slider_sliderReleased()
{
    send = "P:4:";
    send.append(QString::number(ui->PWM4_Slider->value()));
    textBrowserAppend(send);
    send.append('\n');

    //qDebug() << "P = " << send << endl;
    serial->write(send.toLocal8Bit());
}

void MainWindow::on_P1000_Button_clicked()
{
    moveStepper(1000);
}

void MainWindow::on_P100_Button_clicked()
{
    moveStepper(100);
}

void MainWindow::on_P10_Button_clicked()
{
    moveStepper(10);
}

void MainWindow::on_P1_Button_clicked()
{
    moveStepper(1);
}

void MainWindow::on_Stop_Button_clicked()
{
    send = "H:1";
    textBrowserAppend(send);
    send.append('\n');

    serial->write(send.toLocal8Bit());
}

void MainWindow::on_M1_Button_clicked()
{
    moveStepper(-1);
}

void MainWindow::on_M10_Button_clicked()
{
    moveStepper(-10);
}

void MainWindow::on_M100_Button_clicked()
{
    moveStepper(-100);
}

void MainWindow::on_M1000_Button_clicked()
{
    moveStepper(-1000);
}

void MainWindow::on_Move_Button_clicked()
{
    if (ui->Move_Edit->text() != "" && ui->Move_Edit->text() != "0")
        moveStepper(ui->Move_Edit->text().toInt());
    ui->Move_Edit->clear();
}

void MainWindow::on_MoveTo_Button_clicked()
{
    send = "S:";
    if (ui->MoveTo_Edit->text() != "")
    {
        send.append(ui->MoveTo_Edit->text());
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }

    ui->Motor_Display->display(ui->MoveTo_Edit->text().toInt());
    ui->MoveTo_Edit->clear();
}

void MainWindow::moveStepper(int steps)
{
    send = "M:";
    send.append(QString::number(steps * stepperDir));
    textBrowserAppend(send);
    send.append('\n');

    serial->write(send.toLocal8Bit());
}

void MainWindow::on_Pos1_Button_clicked()
{
    if (QApplication::keyboardModifiers().testFlag(Qt::ControlModifier))
    {
        P1Name = QInputDialog::getText(this, tr("Position 1"), tr("Set name:"), QLineEdit::Normal, tr("1"), &ok);
        ui->Pos1_Button->setText(P1Name);
        P1 = ui->Motor_Display->value();
        ui->Pos1_Button->setToolTip("go to " + QString::number(P1));
    }
    else
    {
        send = "S:";
        send.append(QString::number(P1));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_Pos2_Button_clicked()
{
    if (QApplication::keyboardModifiers().testFlag(Qt::ControlModifier))
    {
        P2Name = QInputDialog::getText(this, tr("Position 2"), tr("Set name:"), QLineEdit::Normal, tr("2"), &ok);
        ui->Pos2_Button->setText(P2Name);
        P2 = ui->Motor_Display->value();
        ui->Pos1_Button->setToolTip("go to " + QString::number(P2));
    }
    else
    {
        send = "S:";
        send.append(QString::number(P2));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_Pos3_Button_clicked()
{
    if (QApplication::keyboardModifiers().testFlag(Qt::ControlModifier))
    {
        P3Name = QInputDialog::getText(this, tr("Position 3"), tr("Set name:"), QLineEdit::Normal, tr("3"), &ok);
        ui->Pos3_Button->setText(P3Name);
        P3 = ui->Motor_Display->value();
        ui->Pos1_Button->setToolTip("go to " + QString::number(P3));
    }
    else
    {
        send = "S:";
        send.append(QString::number(P3));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_Pos4_Button_clicked()
{
    if (QApplication::keyboardModifiers().testFlag(Qt::ControlModifier))
    {
        P4Name = QInputDialog::getText(this, tr("Position 4"), tr("Set name:"), QLineEdit::Normal, tr("4"), &ok);
        ui->Pos4_Button->setText(P4Name);
        P4 = ui->Motor_Display->value();
        ui->Pos1_Button->setToolTip("go to " + QString::number(P4));
    }
    else
    {
        send = "S:";
        send.append(QString::number(P4));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }
}

void MainWindow::on_Pos5_Button_clicked()
{
    if (QApplication::keyboardModifiers().testFlag(Qt::ControlModifier))
    {
        P5Name = QInputDialog::getText(this, tr("Position 5"), tr("Set name:"), QLineEdit::Normal, tr("5"), &ok);
        ui->Pos5_Button->setText(P5Name);
        P5 = ui->Motor_Display->value();
        ui->Pos1_Button->setToolTip("go to " + QString::number(P5));
    }
    else
    {
        send = "S:";
        send.append(QString::number(P5));
        textBrowserAppend(send);
        send.append('\n');

        serial->write(send.toLocal8Bit());
    }
}
