using System.Xml.Linq;

namespace Dragracing_Simple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car raceCar1 = new Car(1);
            Thread raceThread = new Thread(raceCar1.StartRace);

            Car raceCar2 = new Car(2);
            Thread raceThread1 = new Thread(raceCar2.StartRace);

            raceCar2.OnFinish += RaceCar_OnFinish;
            raceCar1.OnFinish += RaceCar_OnFinish;

            // Start racet
            raceThread.Start();
            // Vent på, at racet afsluttes
           

            raceThread1.Start();
            // Vent på, at racet afsluttes
            raceThread1.Join();


            raceThread.Join();
            Console.WriteLine("Løbet er afsluttet");
            Console.ReadKey();
        }

        private static void RaceCar_OnFinish(Car c)
        {
            Console.WriteLine($"{c.Number} har gennemført løbet på: "+c.Time +" ms.");
        }
    }
}
