#include <SoftwareSerial.h>
#include <Servo.h>

Servo servo01;
Servo servo02;
Servo servo03;
Servo servo04;
Servo servo05;
Servo servo06;

char dataArray[4]; //Initialized variable to store received data
String message = "";
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
  Serial.println("enter 212 for grab the object ( enter 0 for initial position)");

  setUpPosition();

}
void loop()
{
    message = serialReading();
    if(message!="000")
     Serial.println(message);

    if (message == "200"){
      Serial.write('#');
      serialWriting("202");
    }
    
    if (message == "212"){
      MotionCarry();
      Serial.write('#');
      serialWriting("203");
    }

    if (message == "251"){
      Motion1();
      Serial.write('#');
      serialWriting("204");
      InitialPosition();
    }

    if (message == "252")
    {
      Motion2();
      Serial.write('#');
      serialWriting("204");
      InitialPosition();
    }

    if (message == "253"){
        
      Motion3();
      Serial.write('#');
      serialWriting("204");
      InitialPosition();
    }

    if (message == "224"){
      Serial.write('#');
      serialWriting("204");
      InitialPosition();
    }
   
    if (message == "0"){
      InitialPosition();
    }
}


/***************************************/
String serialReading(){
  String messageIn;
  char messageArray[3]="000";
  if(Serial.available()){
    while(Serial.read()!='#'){}
        Serial.readBytes(messageArray,3);            
  }
  messageIn = String(messageArray);
  return messageIn;
}
/***************************************/
void serialWriting(String message){
  for(short i=0; i<3;i++){
    Serial.write(message.charAt(i));
  }
  Serial.write("\n");
}
/*
 * I couldn't use Serial.write() like this:
 * String myString="abc";
 * Serial.write(mystring);
 * It didn't work.
 * I can send string only like this:
 * Serial.write("abc");
*/
/***************************************/
void MotionCarry ()
{
  servo2PPos=servoMotion(80, 20, 2);
  servo3PPos=servoMotion(120, 20, 3);
  servo6PPos=servoMotion(70, 20, 6);
  servo5PPos=servoMotion(50, 20, 5);
  servo6PPos=servoMotion(25, 40, 6);
  servo3PPos=servoMotion(90, 40, 3);
  servo1PPos=servoMotion(10, 40, 1);

}



void InitialPosition()
{
  servo1PPos=servoMotion(60, 20, 1);
  servo2PPos=servoMotion(130, 40, 2);
  servo3PPos=servoMotion(120, 20, 3);
  servo4PPos=servoMotion(60, 20, 4);
  servo5PPos=servoMotion(80, 20, 5);
  servo6PPos=servoMotion(50, 20, 6);
}

void Motion1(){
  servo1PPos=servoMotion(60, 40, 1);
  servo3PPos=servoMotion(70, 40, 3);
  servo1PPos=servoMotion(110, 40, 1);
  servo6PPos=servoMotion(50, 20, 6);

}

void Motion2(){
  servo1PPos=servoMotion(60, 40, 1);
  servo3PPos=servoMotion(70, 40, 3);
  servo1PPos=servoMotion(140, 40, 1);
  servo6PPos=servoMotion(50, 20, 6);
}

void Motion3(){
  servo1PPos=servoMotion(60, 40, 1);
  servo3PPos=servoMotion(70, 40, 3);
  servo1PPos=servoMotion(220, 40, 1);
  servo6PPos=servoMotion(50, 20, 6);
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
   // If previous position is greater then current position
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

void setUpPosition(){
  servo1PPos = 60;
  servo01.write(servo1PPos);
  delay(500);

  servo2PPos = 130;
  servo02.write(servo2PPos);
  delay(500);

  servo3PPos = 120;
  servo03.write(servo3PPos);
  delay(500);

  servo4PPos = 60;
  servo04.write(servo4PPos);
  delay(500);

  servo5PPos = 80;
  servo05.write(servo5PPos);
  delay(500);

  servo6PPos = 50;
  servo06.write(servo6PPos);
  delay(500);
}
