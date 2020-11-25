using System;
using System.Collections.Generic;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredientsAvailable = new List<string>()
        {"tomato", "potato", "carrot", "garlic", "avocado", "lemon", "mango",
        "olives", "Turkey", "Fish", "beef", "chicken", "egg"};

        public List<string> ingredients = new List<string>();

        private static Random generator = new Random();

        private bool isPoisonous = false;

        private bool ismoldy = false;

        private int amount = generator.Next(1,11);

        public int filling = generator.Next(1,11);

        private int rarity = generator.Next(1,6);

        private int taste = generator.Next(1,6);
        
        private int chance = generator.Next(100);

        private int chanced = generator.Next(100);
        
        public string name = "";

        private string choice = Console.ReadLine().ToLower();

        public bool Burnt()
        {
            if(chance >= 75)
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

        public void PickIngredients()
        {
            Console.WriteLine("You have " + ingredientsAvailable + " avalible.");
            //choice;
        }

        private void CheckIngredients()
        {
            
        }

        public bool Poisonous()
        {
            if(isPoisonous == false && ismoldy == false)
            {
                return false;
            }

            else if(ismoldy == true && isPoisonous == false)
            {
                if(chanced >= 90)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else if(ismoldy == false && isPoisonous == true)
            {
                if(chanced >= 70)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else return true;
        }
    }
}
