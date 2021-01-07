#include <SoftwareSerial.h>
#include <Servo.h>

Servo servo01;
Servo servo02;
Servo servo03;
Servo servo04;
Servo servo05;
Servo servo06;

short dataIn = 0;
int servo1Pos, servo2Pos, servo3Pos, servo4Pos, servo5Pos, servo6Pos; // current position
int servo1PPos, servo2PPos, servo3PPos, servo4PPos, servo5PPos, servo6PPos; // previous position

void setup() {
  Serial.begin(9600);
  servo01.attach(5);
  servo02.attach(6);
  servo03.attach(7);
  servo04.attach(8);
  servo05.attach(9);
  servo06.attach(10);
  Serial.begin(9600);
  Serial.println("enter 1 for grab the object (for initial position enter 0)");
  //with the black tape in front
  //Waist-01
  //250-200 135 degrees right of the tape
  //150 90 degrees right of the tape
  //100 45 degrees right of the tape
  //50 tape alignment
  //0-10 45 degrees left of the band
  servo1PPos = 100;
  servo01.write(servo1PPos);
  delay(500);
  //shoulder-02
  //200 Parallel to the ground, leaning back
  //150 45 degrees tilted back
  //100 upright
  //45 degrees forward leaning
  //0-10 parallel to the floor, tilted forward
  servo2PPos = 120;
  servo02.write(servo2PPos);
  delay(500);
  //Elbow-03
  //200-150 vertical down
  //120 45 degrees downward
  //90 parallel to the ground
  //40 45 degrees upwards
  //0 vertical up
  servo3PPos = 115;
  servo03.write(servo3PPos);
  delay(500);
  //wrist roll-04
  //250-200 right up
  //150 parallel to the ground
  //100 45 degrees to the right
  //60 perpendicular to the ground
  //0 45 degrees towards left ground
  servo4PPos = 60;
  servo04.write(servo4PPos);
  delay(500);
  //Bilek pitch-05(Shoulder is vertical when elbow is parallel to floor)
  //250-200 vertical up
  //120 up 45 degrees
  //80 parallel to the ground
  //40 down 45 degrees
  //0 vertical down
  servo5PPos = 80;
  servo05.write(servo5PPos);
  delay(500);
  //gripper-06
  //250-200-150-100 fully open
  //50 half open
  //0-10 fully closed
  servo6PPos = 50;
  servo06.write(servo6PPos);
  delay(500);
}
void loop()
{
  if (Serial.available())
  {
    dataIn = Serial.read();
    Serial.println(char(dataIn));
    
    if (dataIn == '251')
    {
      Serial.println("ahere");
      MotionCarry();
    }

        if (dataIn == '252')
    {
      Serial.println("bhere");
      MotionRed();
      InitialPosition();
    }

        if (dataIn == '253')
    {
      Serial.println("bhere");
      MotionGreen();
      InitialPosition();
    }

        if (dataIn == '254')
    {
      Serial.println("bhere");
      MotionBlue();
      InitialPosition();
    }
  }
}

void MotionCarry ()
{
  Serial.println("aahere");
  servo2PPos=servoMotion(100, 20, 2);
  servo3PPos=servoMotion(120, 20, 3);
  servo6PPos=servoMotion(70, 20, 6);
  servo5PPos=servoMotion(20, 20, 5);
  servo6PPos=servoMotion(20, 40, 6);
  servo5PPos=servoMotion(80, 40, 5);
  servo3PPos=servoMotion(90, 40, 3);
  servo1PPos=servoMotion(170, 40, 1);
  servo3PPos=servoMotion(120, 20, 3);
  servo5PPos=servoMotion(10, 20, 5);
  servo6PPos=servoMotion(50, 20, 6);
}



void InitialPosition()
{
  Serial.println("bbhere");
  servo5PPos=servoMotion(80, 20, 5);
  servo1PPos=servoMotion(100, 20, 1);
  servo2PPos=servoMotion(120, 20, 2);
  servo3PPos=servoMotion(115, 20, 3);
  servo4PPos=servoMotion(60, 20, 4);
  servo6PPos=servoMotion(50, 20, 6);
}

void MotionRed(){
}

void MotionGreen(){
}

void MotionBlue(){
}

int servoMotion(int posS, int dlyTime, int servoNbr )
{
  int prevPos;
  Servo servo00;
  if (servoNbr == 1)
  {
    prevPos = servo1PPos;
    servo00 = servo01;
  }
  if (servoNbr == 2)
  {
    prevPos = servo2PPos;
    servo00 = servo02;
  }
  if (servoNbr == 3)
  {
    prevPos = servo3PPos;
    servo00 = servo03;
  }
  if (servoNbr == 4)
  {
    prevPos = servo4PPos;
    servo00 = servo04;
  }
  if (servoNbr == 5)
  {
    prevPos = servo5PPos;
    servo00 = servo05;
  }
  if (servoNbr == 6)
  {
    prevPos = servo6PPos;
    servo00 = servo06;
  }

   if (prevPos > posS) {
        for ( int i = prevPos; i >= posS; i--) {   // Run servo down
          servo00.write(i);
          delay(dlyTime);    // defines the speed at which the servo rotates
        }
      }
      // If previous position is smaller then current position
      if (prevPos < posS) {
        for ( int i = prevPos; i <= posS; i++) {   // Run servo up
          servo00.write(i);
          delay(dlyTime);
        }
      }
      prevPos=posS;   // set current position as previous position
      return prevPos;

  
}
