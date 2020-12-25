//Five infrared sensors
#define LMS 15 //Leftmost sensor
#define LS 16 //Left Sensor
#define MS 17 //Middle sensor
#define RS 18 //Right sensor
#define RMS 19 //Rightmost sensor

//For L298N Motor Driver
#define LM1 6 //IN4
#define LM2 7 //IN3
#define RM2 8 //IN2
#define RM1 9 //IN1
#define enR 10 //ENA
#define enL 11 //ENB

#define FORWARD_POWER 120
#define TURNING_POWER 90

void setup() {
 
//Sensor pins
pinMode(LMS, INPUT);
pinMode(LS, INPUT);
pinMode(MS, INPUT);
pinMode(RS, INPUT);
pinMode(RMS, INPUT);
//Motor pins
pinMode(LM2, OUTPUT);
pinMode(LM1, OUTPUT);
pinMode(RM2, OUTPUT);
pinMode(RM1, OUTPUT);
pinMode(enR, OUTPUT); //Left motor enable
pinMode(enL, OUTPUT); //Right motor enable

}

void loop() {

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the middle sensor see black, move forward
     moveForward();
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the right and the middle sensor see black turn right
     turnRight();
  }
  
  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the right sensor see black turn right
     turnRight();
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 0){  // When the right and rightmost sensor see black, turn right
    turnRight();
  }
  
   if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 0){  // When the rightmost sensor see black turn right
     turnRight();
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the left and the middle sensor see black, turn left
     turnLeft();
  }

  if(digitalRead(LMS) == 1 && digitalRead(LS) == 0 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the left sensor see black, turn left
     turnLeft();
  }
  
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 0 && digitalRead(MS) == 1 && digitalRead(RS) == 0 && digitalRead(RMS) == 1){  // When the left and leftmost sensor see black, turn left
     turnLeft(); 
  }
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When the leftmost sensor see black, turn left
     turnLeft(); 
  }
  
  if(digitalRead(LMS) == 0 && digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 0 && digitalRead(RMS) == 0){  // When all of them see black stop  
     stopping();
  }
  
  if(digitalRead(LMS) == 1 && digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1 && digitalRead(RMS) == 1){  // When all of them see white stop
     stopping();
  }

}

void moveForward(){
  
  digitalWrite(RM1, HIGH);// For right motor, moving forward is on
  digitalWrite(RM2, LOW); // For right motor, moving backward is off
  analogWrite(enR, FORWARD_POWER);  //  Right motor speed

  digitalWrite(LM1, HIGH); //For left motor, moving forward is on
  digitalWrite(LM2, LOW);  //For left motor, moving backward is off
  analogWrite(enL, FORWARD_POWER);    //Right motor, motor speed
    
}

void turnRight(){ 

  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, TURNING_POWER); 
     
}

void turnLeft(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, 0);

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, TURNING_POWER);
  
}

void stopping(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, LOW);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL, LOW);
  
}
