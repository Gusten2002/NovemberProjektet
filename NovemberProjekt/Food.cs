using System;
using System.Linq;
using System.Collections.Generic;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredientsAvailable = new List<string>()
        {"tomato", "potato", "carrot", "garlic", "avocado", "lemon", "mango",
        "olives", "Turkey", "Fish", "beef", "chicken", "egg"};

        public List<string> insoup = new List<string>();

        private static Random generator = new Random();

        private bool isPoisonous = false;

        private bool ismoldy = false;

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
                Console.WriteLine("You burnt your food :C");
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
            while (ingredientsAvailable.Count >= 1)
            {
                Console.WriteLine("In your soup: " + insoup);
                Console.WriteLine("Would you like to add more?");

                string[] WantMore = {"yes", "no"};

                string input = Console.ReadLine().ToLower();

                while (!WantMore.Contains(input))
                {
                    Console.WriteLine("Not a valid choice, try again");
                    Console.WriteLine("Only accepting " + WantMore + " as answers.");

                    input = Console.ReadLine();
                }

                if(input == "yes")
                {
                    Console.WriteLine("You have " + ingredientsAvailable + " avalible." +
                    "What do you want to use for your soup?");

                    choice = CheckAnswer();

                    insoup.Add(choice);

                    CheckIngredient();
                }

                else
                {
                    Soup();
                }

            }

            Console.WriteLine("You have " + ingredientsAvailable + " avalible." +
            "What do you want to use for your soup?");

            choice = CheckAnswer();

            insoup.Add(choice);

            CheckIngredient();
        }

        private void CheckIngredient()
        {
            Poisonous();

            if (Poisonous() == true)
            {
                Console.WriteLine("This food item is poisinous, but you realiced it after using it...");
            }
        }

        private bool Poisonous()
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

        public void Soup()
        {
            Console.WriteLine("You cook your soup now.");
            Burnt();
        }

        static string CheckAnswer()
        {
            string[] ans = {"tomato", "potato", "carrot", "garlic", "avocado","lemon",
            "mango", "olives", "Turkey", "Fish", "beef", "chicken", "egg"};

            string input = Console.ReadLine().ToLower();

            while (!ans.Contains(input))
            {
                Console.WriteLine("Not a valid choice, try again");
                Console.WriteLine("Only accepting " + ans + " as an answer.");

                input = Console.ReadLine();
            }

            return input;
        }

    }
}
