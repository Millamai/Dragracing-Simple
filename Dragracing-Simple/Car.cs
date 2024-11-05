using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dragracing_Simple
{
    internal class Car
    {
        public int Number { get; set; }
        public double Speed { get; private set; } // Meter per sekund
        public double Distance { get; private set; } // Meter

        public long Time { get; private set; }    

        public event Action<Car> OnFinish; // Event for at signalere, når bilen er færdig
    
        public Car(int number)
        {
            Number = number;
            Speed = 0;
            Distance = 0;
        }

        public void StartRace()
        {
            long starttid = (long)(DateTime.Now.TimeOfDay.TotalMilliseconds);
            while (Distance < 400) // Løb indtil 400 meter
            {
                // Øg hastigheden med 5 m/s
                Speed += 5;
                // Beregn den tilbagelagte afstand
                Distance += Speed * 0.5; // 0.5 sekunder

                // Skriv hastighed og afstand til konsollen
                Console.WriteLine($"Nummer: {Number} Hastighed: {Speed} m/s, Tilbagelagt afstand: {Distance} meter");

                // Vent i 500 ms
                Thread.Sleep(500);
            }
            Time = (long)(DateTime.Now.TimeOfDay.TotalMilliseconds)-starttid;
            
            OnFinish?.Invoke(this);
           
           
        }
    }

}

