/*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fridge
{
    class Fridge
    {
        public bool Door = true; //признак открытой двери
        public int type_of_fridge = 0; //текущий режим работы
        public readonly string Brand = "Nord";
        public readonly string Model = "FRB 539";
   
        public void OpenDoor()
        {
            Door = !Door;
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            Fridge FR = new Fridge();
            for (;;)
            {
                Console.Write("{0} ", FR.Brand);
                Console.WriteLine(FR.Model);
                Console.WriteLine("Состояние холодильника: ");
                if (FR.Door)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Дверь закрыта. Все в норме");
                    switch (FR.type_of_fridge)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Температура 0: режим Cold");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Температура 5: режим Normal");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Температура 10: режим Cool");
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Температура 15: режим Fresh");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Дверь открыта! Закройте для обеспечения охлаждения");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" f - открыть/закрыть дверь\n h - повысить температуру\n d - понизить температуру\n e - выйти из программы");
                string key;
                ConsoleKeyInfo ex;
                ex = Console.ReadKey(true);
                key = ex.Key.ToString();
                if(key == "F") FR.OpenDoor();
                if (FR.Door)
                {
                    switch (key)
                    {
                        case "D":
                            FR.type_of_fridge--;
                            break;
                        case "H":
                            FR.type_of_fridge++;
                            break;
                    }
                    if (FR.type_of_fridge < 0) FR.type_of_fridge = 0;
                    if (FR.type_of_fridge > 3) FR.type_of_fridge = 3;
                   
                }
                if (key == "E") Environment.Exit(0);
                Console.Clear();
            }
        }
    }
}