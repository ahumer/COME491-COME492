int LED = 13;
int obstaclePin = 8;
int hasObstacle = HIGH;

void setup()
{
  pinMode(LED, OUTPUT);
  pinMode(obstaclePin, INPUT);
}

void loop()
{
  hasObstacle = digitalRead(obstaclePin);
  
    if (hasObstacle == LOW)
    {
      digitalWrite(LED, HIGH);
    }
    
    else
    {
      digitalWrite(LED,LOW);
    }
  delay(200);
}
