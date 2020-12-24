//Three infrared sensor
#define LS 2 //Left sensor
#define MS 3 //Middle Sensor
#define RS 4 //Right sensor
//For L298N Motor Driver
#define LM1 6 //IN4
#define LM2 7 //IN3
#define RM2 8 //IN2
#define RM1 9 //IN1
#define enR 10 //ENA
#define enL 11 //ENB

void setup() {
pinMode(LS, INPUT);
pinMode(MS, INPUT);
pinMode(RS, INPUT);
pinMode(LM2, OUTPUT);
pinMode(LM1, OUTPUT);
pinMode(RM2, OUTPUT);
pinMode(RM1, OUTPUT);
pinMode(enR, OUTPUT); //Left motor enable
pinMode(enL, OUTPUT); //Right motor enable

}

void loop() {

  if(digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 1){  // When the middle sensor see black, move forward
    moveForward();
  }

   if(digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1){  // When three of them see white, stop.
    stopping();
  }
  
  if(digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 0){  // When the right sensor see black, turn right
    turnRight();
  }

  if(digitalRead(LS) == 1 && digitalRead(MS) == 0 && digitalRead(RS) == 0){  // When the right sensor see black, turn right
    turnRight();
  }

  if(digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 1){  // When the left sensor see black, turn left.
    turnLeft();
  }
  
  if(digitalRead(LS) == 0 && digitalRead(MS) == 1 && digitalRead(RS) == 1){  // When the left sensor see black, turn left.
    turnLeft();
  }
  if(digitalRead(LS) == 0 && digitalRead(MS) == 0 && digitalRead(RS) == 0){  // When three of them see black, stop.
    stopping();
  }
  if(digitalRead(LS) == 1 && digitalRead(MS) == 1 && digitalRead(RS) == 1){  // When three of them see white, stop.
    stopping();
  }

}

void moveForward(){

  digitalWrite(RM1, HIGH);// For right motor, moving forward is on
  digitalWrite(RM2, LOW); // For right motor, moving backward is off
  analogWrite(enR, 80);  // Right motor speed

  digitalWrite(LM1, HIGH); // For left motor, moving forward is on
  digitalWrite(LM2, LOW);  //For left motor, moving backward is off
  analogWrite(enL, 80);  // Right motor, motor speed
    
}

void turnRight(){ 

  digitalWrite(RM1, HIGH); 
  digitalWrite(RM2, LOW); 
  analogWrite(enR, 0); 

  digitalWrite(LM1, HIGH); 
  digitalWrite(LM2, LOW); 
  analogWrite(enL, 60); 
    
}

void turnLeft(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  analogWrite(enR, 60);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  analogWrite(enL, 0);
  
}

void stopping(){

  digitalWrite(RM1, HIGH);
  digitalWrite(RM2, LOW);
  digitalWrite(enR, LOW);

  digitalWrite(LM1, HIGH);
  digitalWrite(LM2, LOW);
  digitalWrite(enL, LOW);
  
}
