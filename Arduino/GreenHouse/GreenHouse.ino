#include <dht.h>
#include <SoftwareSerial.h>

SoftwareSerial bt(A12, A13); // TX/RX pins
#define apin1 A1
#define apin2 A2
#define apin3 A3
#define apin4 A4

#define Motor1 22
#define Motor2 23
#define Motor3 24
#define Motor4 25

#define DHT11_PIN 7

float sensorValue = 0;
float sensorpercentage = 0;

float line1;
float line2;
float line3;
float line4;

const int max_mois = 640;
const  float divide = 3.25;

float line1_avg;
int line_no;
int water_count_l1 = 4;
int water_count_l2;
int water_count_l3;
int water_count_l4;

dht DHT;

void setup() {
  Serial.begin(9600);
  bt.begin(9600);
}

void loop() {
  String command = getCommand();

  if ( command == "s")
  {
    bt.println("Test S");
  }

  if ( command == "p")
  {
    bt.println(line1);
    bt.println(line2);
    bt.println(line3);
    bt.println(line4);
  }

  if ( command == "m")
  {
    bt.println((( max_mois - l1_avg() ) / divide));
    bt.println(l1_avg());
  }

  if ( command == "t")
  {
    int chk = DHT.read11(DHT11_PIN);
    bt.println(DHT.temperature);
  }

  if ( command.substring(0, 3) == "val")
  {
    switch (command.substring(3, 6).toInt())
    {
      case 1: line1 = command.substring(6).toFloat();
        break;
      case 2: line2 = command.substring(6).toFloat();
        break;
      case 3: line3 = command.substring(6).toFloat();
        break;
      case 4: line4 = command.substring(6).toFloat();
        break;
    }
  }

  if ( command == "w1")
  {
    bt.println(water_count_l1);
    water_count_l1 = 0;
  }

  if ( command == "l1")
  {
    if (line1 != 0.00)
    {
      int chk = DHT.read11(DHT11_PIN);
      bt.println("T" + String(DHT.temperature) + ",H" + String(DHT.humidity) + ",M" + String(( max_mois - l1_avg() ) / divide) + ",W" + water_count_l1 );
      water_count_l1 = 0;
      delay(500);
    }
    else
    {
      bt.println("Not Configured");
    }
  }

  if ( command == "l2" )
  {
    if (line2 != 0.00)
    {
      int chk = DHT.read11(DHT11_PIN);
      bt.println("T" + String(DHT.temperature) + ",H" + String(DHT.humidity) + ",M" + String(( max_mois - analogRead(apin2) ) / divide) + ",W" + water_count_l2 );
    }
    else
    {
      bt.println("Not Configured");
    }
  }

  if ( command == "l3")
  {
    if (line3 != 0.00)
    {
      int chk = DHT.read11(DHT11_PIN);
      bt.println("T" + String(DHT.temperature) + ",H" + String(DHT.humidity) + ",M" + String(( max_mois - analogRead(apin3) ) / divide) + ",W" + water_count_l3 );
    }
    else
    {
      bt.println("Not Configured");
    }
  }

  if ( command == "l4" )
  {
    if (line4 != 0.00)
    {
      int chk = DHT.read11(DHT11_PIN);
      bt.println("T" + String(DHT.temperature) + ",H" + String(DHT.humidity) + ",M" + String(( max_mois - analogRead(apin4) ) / divide) + ",W" + water_count_l4 );
    }
    else
    {
      bt.println("Not Configured");
    }
  }

  watering();
}

void watering()
{
  if (line1 != 0.00)
  {
    if ( line1 > ( ( max_mois - l1_avg() ) / divide) )
    {
      digitalWrite(Motor1, HIGH);
      delay(80);
      digitalWrite(Motor1, LOW);
      delay(500);

      water_count_l1 = water_count_l1 + 1;
    }
  }

  if (line2 != 0.00)
  {
    if ( line2 > ( ( max_mois - analogRead(apin2) ) / divide) )
    {
      digitalWrite(Motor2, HIGH);
      delay(80);
      digitalWrite(Motor2, LOW);
      delay(500);

      water_count_l2 = water_count_l2 + 1;
    }
  }

  if (line3 != 0.00)
  {
    if ( line3 > ( ( max_mois - analogRead(apin3) ) / divide) )
    {
      digitalWrite(Motor3, HIGH);
      delay(80);
      digitalWrite(Motor3, LOW);
      delay(500);

      water_count_l3 = water_count_l3 + 1;
    }
  }

  if (line4 != 0.00)
  {
    if ( line4 > ( ( max_mois - analogRead(apin4) ) / divide) )
    {
      digitalWrite(Motor4, HIGH);
      delay(80);
      digitalWrite(Motor4, LOW);
      delay(500);

      water_count_l4 = water_count_l4 + 1;
    }
  }
}

float l1_avg()
{
  line1_avg = 0;
  for ( int x = 0; x < 10; x++ )
  {
    line1_avg = line1_avg + analogRead(apin1);
    delay(50);
  }
  return (line1_avg / 10);
}

String getCommand()
{
  String val;
  while (bt.available())
  {
    val = bt.readString();
  }
  return val;
}
