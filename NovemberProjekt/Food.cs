using System;
using System.Linq;
using System.Collections.Generic;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredientsAvailable = new List<string>()
        {"tomato", "potato", "carrot", "garlic", "avocado", "lemon", "mango",
        "olives", "turkey", "fish", "beef", "chicken", "egg"};//Skapar en lista med de här orden i.

        private List<string> insoup = new List<string>();//Skapar en lista för grejerna i soppan.

        private List<string> poisoned = new List<string>();//Skapar en lista för de grejer som sedan är giftiga.

        private static Random generator = new Random();//Skapar en slumpgenerator.

        private bool isPoisonous = false;//skapar en bool som sparar om ingrediensen är giftig eller ej.

        private bool ismoldy = false;//skapar en bool som sparar om ingrediensen är möglig eller ej.

        // public int filling = generator.Next(1,11);

        // private int rarity = generator.Next(1,6);

        // private int taste = generator.Next(1,6);

        public bool foodpoisoned;//skapar en bool som sparar om soppan är giftig eller ej.

        private string choice = Console.ReadLine().ToLower();//sparar det som skrivs i chatten och förvandlar det till småbokstäver i variabeln "choice".

        private string input = Console.ReadLine().ToLower();//sparar det som skrivs i chatten och förvandlar det till småbokstäver i variabeln "input".

        private bool Burnt()//Skapar en privat bool (true/false) som kollar om soppan brändes på spisen eller ej.
        {
            if(generator.Next(100) >= 75)//Slumpar fram ett tal mellan 0-100 och kollar om det är större eller lika med och/eller större än 75.
            {
                Console.WriteLine("You didn't take the soup of the stove in time, there for it got burnt.");//Ifall det slumpade talet var större än eller lika med 75 så skrivs detta ut, annars skippas det.
                return true;//Returnerar true.
            }

            else//Om det slumpade talet inte var större än eller lika med 75 så körs detta.
            {
                Console.WriteLine("You took the soup of the stove before it got burnt.");//skriver ut detta.
                return false;//Returnerar true.
            }
        }

        public void PickIngredients()//Skapar en "publik" (öppen för ändringar utanför måsvingarna) grej...
        {
            while (input != "no")//När input inte är no så händer detta.
            {
                Console.WriteLine("In your soup: " + String.Join(", ", insoup));//Skriver ut det som finns i ens soppa.
                Console.WriteLine("Would you like to add more?");//frågar om man vill läggga i mer.

                string[] WantMore = {"yes", "no"};//skapar en yes, no kontrolltext.

                input = Console.ReadLine().ToLower();//Sparar det man skriver.

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
