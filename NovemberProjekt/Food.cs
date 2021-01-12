using System;
using System.Linq;
using System.Collections.Generic;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredientsAvailable = new List<string>()
        {"tomato", "potato", "carrot", "garlic", "avocado", "lemon", "mango",
        "olives", "turkey", "fish", "beef", "chicken", "egg"};

        private List<string> insoup = new List<string>();

        private List<string> poisoned = new List<string>();

        private static Random generator = new Random();

        private bool isPoisonous = false;

        private bool ismoldy = false;

        // public int filling = generator.Next(1,11);

        // private int rarity = generator.Next(1,6);

        // private int taste = generator.Next(1,6);

        public bool foodpoisoned;

        private string choice = Console.ReadLine().ToLower();

        private string input = Console.ReadLine().ToLower();

        private bool Burnt()
        {
            if(generator.Next(100) >= 75)
            {
                Console.WriteLine("You didn't take the soup of the stove in time, there for it got burnt.");
                return true;
            }

            else
            {
                Console.WriteLine("You took the soup of the stove before it got burnt.");
                return false;
            }
        }

        public void PickIngredients()
        {
            while (input != "no")
            {
                Console.WriteLine("In your soup: " + String.Join(", ", insoup));
                Console.WriteLine("Would you like to add more?");

                string[] WantMore = {"yes", "no"};

                input = Console.ReadLine().ToLower();

                while (!WantMore.Contains(input))
                {
                    Console.WriteLine("Not a valid choice, try again");
                    Console.WriteLine("Only accepting " + String.Join(", ",WantMore) + " as answers.");

                    input = Console.ReadLine().ToLower();
                }

                while(insoup.Count == 0 && input == "no")
                {
                    Console.WriteLine("You have to pick atleast one ingredient.");
                    Console.WriteLine("Only accepting " + String.Join(", ",WantMore) + " as answers.");

                    input = Console.ReadLine().ToLower();
                }

                if(input == "yes")
                {
                    Console.WriteLine("You have " + String.Join(", ", ingredientsAvailable) + " avalible." +
                    "What do you want to use for your soup?");

                    choice = CheckAnswer();

                    insoup.Add(choice);

                    CheckIngredient();
                }

                else if(input == "no" && insoup.Count >= 1)
                {
                    Soup();
                }
            }
        }

        private void CheckIngredient()
        {
            FoodPoisonous();

            if (FoodPoisonous() == true)
            {
                Console.WriteLine("This food item is poisinous, but you realiced it after using it...");

                poisoned.Add(choice);
            }

            else
            {
                Console.WriteLine("This food item is not poisinous.");
            }
        }

        private bool Moldy()
        {
            if(generator.Next(10) >= 5)
            {
                ismoldy = true;
                return true;
            }

            else
            {
                ismoldy = false;
                return false;
            }
        }

        private bool Poisonous()
        {
            if(generator.Next(10) >= 5)
            {
                isPoisonous = true;
                return true;
            }

            else
            {
                isPoisonous = false;
                return false;
            }
        }

        public bool FoodPoisonous()
        {
            Moldy();
            Poisonous();
            
            int poisonChance = generator.Next(100);

            if(isPoisonous == false && ismoldy == false)
            {
                return false;
            }

            else if(ismoldy == true && isPoisonous == false)
            {
                if(poisonChance >= 90)
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
                if(poisonChance >= 70)
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

        private void Soup()
        {
            Console.WriteLine("You cook your soup.");
            Burnt();
            PrintStats();
        }

        public void PrintStats()
        {
            if(poisoned.Count >= insoup.Count && Burnt() == true)
            {
                foodpoisoned = true;

                Console.WriteLine("Your soup is mostly poisoned, " +
                "due to the amount of ingredients that was poisoned.");

                Console.WriteLine("You also burn the soup.");
            }

            else if(poisoned.Count >= insoup.Count && Burnt() == false)
            {
                foodpoisoned = true;

                Console.WriteLine("Your soup is mostly poisoned, " +
                "due to the amount of ingredients that was poisoned.");

                Console.WriteLine("You did managed not to burn the soup tho.");
            }

            else if(poisoned.Count <= insoup.Count && Burnt() == true)
            {
                foodpoisoned = true;

                Console.WriteLine("Your soup is good, " +
                "it is not poisoned.");

                Console.WriteLine("You did managed to burn the soup tho.");
            }

            else
            {
                Console.WriteLine("Your soup is good, " +
                "it is not poisoned.");

                Console.WriteLine("You managed not to burn the soup.");
            }
        }

        static string CheckAnswer()
        {
            string[] ans = {"tomato", "potato", "carrot", "garlic", "avocado","lemon",
            "mango", "olives", "turkey", "fish", "beef", "chicken", "egg"};

            string input = Console.ReadLine().ToLower();

            while (!ans.Contains(input))
            {
                Console.WriteLine("Not a valid choice, try again");
                Console.WriteLine("Only accepting " + String.Join(", ", ans) + " as an answer.");

                input = Console.ReadLine();
            }

            return input;
        }

    }
}
