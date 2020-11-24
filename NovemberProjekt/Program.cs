using System;

namespace NovemberProjekt
{           
    // Ett matlagningsspel där man har en viss summa att spendera, och ska välja ingredienser att lägga i en gryta.
    // Sedan finns det en jury som gillar olika ingredienser.
    
    class Program
    {
        static void Main(string[] args)
        {
             Food flod = new Food();
            Console.WriteLine("Hello chef!");
            flod.Burnt();
            Console.ReadLine();
        }
    }
}
