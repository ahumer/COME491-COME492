/*
 * Changing HC05 module's default device name using AT Command
 *
 * Pinout:
 * Key --> pin 9
 * VCC --> 5 volt
 * RXD --> pin 11
 * TXD --> pin 10
 * GND --> GND
 *
 * AT Command : AT+NAME=<new device name>
 *
 */

#include <SoftwareSerial.h>

SoftwareSerial BTSerial(10, 11);   // RX | TX

void setup() 
{
  pinMode(0,INPUT);   
  pinMode(1,INPUT);
  pinMode(9, OUTPUT);
  digitalWrite(9, HIGH); 
  Serial.begin(9600);
  Serial.println("Enter AT commands:");
  BTSerial.begin(38400);  // HC-05 default speed in AT command mode
}

void loop()
{
  // Read from HC05 and send to Arduino
  if (BTSerial.available())
    Serial.write(BTSerial.read());

  // Read from serial monitor and send to HC05
  if (Serial.available())
    BTSerial.write(Serial.read());
}
