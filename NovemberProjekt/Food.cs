using System;
using System.Collections.Generic;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredients = new List<string>() {"tomato", "potato", "carrot", "beef", "chicken", "garlic", "avocado", "olives", "Turkey", "Fish"};

        private static Random generator = new Random();

        private int amount = generator.Next(1,11);

        private bool isPoisonous = false;

        private bool ismoldy = false;

        public int filling = generator.Next(1,11);

        private int rarity = generator.Next(1,6);

        private int taste = generator.Next(1,6);
        
        private int chanse = generator.Next(100);
        
        public string name = "";

        public bool Burnt()
        {
            if(chanse >= 75)
            {
                Console.WriteLine("HH");
                return true;
            }

            else
            {
                Console.WriteLine("BB");
                return false;
            }
        }
    }
}
