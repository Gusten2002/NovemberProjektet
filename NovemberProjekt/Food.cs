using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace NovemberProjekt
{
    public class Food
    {
        private List<string> ingredientsAvailable = new List<string>()
        {"tomato", "potato", "carrot", "garlic", "avocado", "lemon", "mango",
        "olives", "turkey", "fish", "beef", "chicken", "egg"};//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) lista med de här orden i.

        private List<string> insoup = new List<string>();//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) lista för grejerna i soppan.

        private List<string> poisoned = new List<string>();//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) lista för de grejer som sedan är giftiga.

        private static Random generator = new Random();//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) slumpgenerator.

        private bool isPoisonous = false;//skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool som sparar om ingrediensen är giftig eller ej.

        private bool ismoldy = false;//skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool som sparar om ingrediensen är möglig eller ej.

        // public int filling = generator.Next(1,11);

        // private int rarity = generator.Next(1,6);

        // private int taste = generator.Next(1,6);

        public bool foodpoisoned;//skapar en publik (öppen för ändringar utanför måsvingarna) bool (true/false) som sparar om soppan är giftig eller ej.

        private string choice = Console.ReadLine().ToLower();//sparar det som skrivs i chatten och förvandlar det till småbokstäver i variabeln "choice"; privat (inte tillgänglig för ändringar utanför måsvingarna).

        private string input = Console.ReadLine().ToLower();//sparar det som skrivs i chatten och förvandlar det till småbokstäver i variabeln "input"; privat (inte tillgänglig för ändringar utanför måsvingarna).

        private bool Burnt()//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som kollar om soppan brändes på spisen eller ej.
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

        public void PickIngredients()//Skapar ett publik (öppen för ändringar utanför måsvingarna) kodblock.
        {
            while (input != "no")//När input inte är no så händer detta.
            {
                Console.WriteLine("In your soup: " + String.Join(", ", insoup));//Skriver ut det som finns i ens soppa.
                Console.WriteLine("Would you like to add more?");//frågar om man vill läggga i mer.

                string[] WantMore = {"yes", "no"};//skapar en yes, no kontrolltext.

                input = Console.ReadLine().ToLower();//Sparar det man skriver i små bokstäver.

                while (!WantMore.Contains(input))//kollar om och körs medans "input" är ett svar som finns med i "WantMore".
                {
                    Console.WriteLine("Not a valid choice, try again");//Skriver ut detta.
                    Console.WriteLine("Only accepting " + String.Join(", ",WantMore) + " as answers.");//Skriver ut att bara "yes or no" accepteras.

                    input = Console.ReadLine().ToLower();//Sparar det man skriver i små bokstäver.
                }

                while(insoup.Count == 0 && input == "no")//kollar om och körs medans det inte finns något i soppan och "input" är "no".
                {
                    Console.WriteLine("You have to pick atleast one ingredient.");//skriver ut att man måste ha åtminstonne en ingrediens.
                    Console.WriteLine("Only accepting " + String.Join(", ",WantMore) + " as answers.");//Skriver ut att bara "yes or no" accepteras.

                    input = Console.ReadLine().ToLower();//Sparar det man skriver i små bokstäver.
                }

                if(input == "yes")//Om "input" är "yes" då körs denna.
                {
                    Console.Clear();//Rensar "chatten/konsollen"
                    Console.WriteLine("You have " + String.Join(", ", ingredientsAvailable) + " avalible." +
                    "What do you want to use for your soup?");//Skriver ut det som man kan ha i sin soppa.

                    choice = CheckAnswer();//kör "CheckAnswer"-koden.

                    insoup.Add(choice);//Lägger till ingrediensen till insoup-listan

                    CheckIngredient();//Kör "CheckIngredient"-koden.
                }

                else if(input == "no" && insoup.Count >= 1)//Om "input" är "no" och det finns något i soppan så körs detta.
                {
                    Console.Clear();//Rensar "chatten/konsollen"
                    
                    Soup();//Kör "Soup"-koden.

                    Console.WriteLine("Press Enter to precede");//skriver att man måste klicka enter för att gå vidare.

                    Console.ReadLine();//väntar tills man klickat enter, då den läser vad som skrivits men sparar det ej.

                    Console.Clear();//Rensar "chatten/konsollen"
                }
            }
        }

        private void CheckIngredient()//Skapar ett privat (inte tillgänglig för ändringar utanför måsvingarna) kodblock.
        {
            FoodPoisonous();//Kör "FoodPoisonous"-koden.

            if (FoodPoisonous() == true)//Om "FoodPoisonous returnerar true så körs detta.
            {
                Console.WriteLine("This food item is poisinous, but you realiced it after using it...");//Skriver ut att ingrediensen var giftig.

                poisoned.Add(choice);//Lägger till den giftiga ingrediensen i giftiga-ingredienser listan "poisoned".
            }

            else//Om "FoodPoisonous inte returnerar true så körs detta.
            {
                Console.WriteLine("This food item is not poisinous.");//Skriver ut att ingrediensen inte är giftig.
            }
        }

        private bool Moldy()//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som kollar om ingrediensen är möglig eller ej.
        {
            if(generator.Next(10) >= 5)//Om det slumpade talet är större eller lika med 5 så körs detta.
            {
                ismoldy = true;//Ändrar ismoldy till true.
                return true;//Returnerar true.
            }

            else//Om det slumpade talet inte är större eller lika med 5 så körs detta.
            {
                ismoldy = false;//Ändrar ismoldy till false.
                return false;//Returnerar false.
            }
        }

        private bool Poisonous()//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som kollar om ingrediensen är giftig eller ej.
        {
            if(generator.Next(10) >= 5)//Om det slumpade talet är större eller lika med 5 så körs detta.
            {
                isPoisonous = true;//Ändrar ispoisonous till true.
                return true;//Returnerar true.
            }

            else//Om det slumpade talet inte är större eller lika med 5 så körs detta.
            {
                isPoisonous = false;//Ändrar ispoisonous till false.
                return false;//Returnerar false.
            }
        }

        public bool FoodPoisonous()//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som kollar om ingrediensen är giftig eller ej.
        {
            Moldy();//kör "Moldy"-koden.
            Poisonous();//kör "Poisonous"-koden.
            
            int poisonChance = generator.Next(100);//Skapar en slumpgenerator med namn "poisonChance".

            if(isPoisonous == false && ismoldy == false)//Om isPoisonous och ismoldy båda är false så körs detta.
            {
                return false;//Returnerar false
            }

            else if(ismoldy == true && isPoisonous == false)//Om isPoisonous är false och ismoldy är true så körs detta.
            {
                if(poisonChance >= 90)//Om det slumpade talet är större eller lika med 90 så körs denna.
                {
                    return true;//Returnerar true
                }

                else//Om det slumpade talet inte är större eller lika med 90 så körs denna.
                {
                    return false;//Returnerar false
                }
            }

            else if(ismoldy == false && isPoisonous == true)//Om isPoisonous är true och ismoldy är false så körs detta.
            {
                if(poisonChance >= 70)//Om det slumpade talet är större eller lika med 70 så körs denna.
                {

                    return true;//Returnerar true
                }

                else//Om det slumpade talet inte är större eller lika med 70 så körs denna.
                {
                    return false;//Returnerar false
                }
            }

            else return true;//Om ingen av de ovanstående ifsatserna har körts så returneras true. Då båda är true
        }

        private void Soup()//Skapar ett privat (inte tillgänglig för ändringar utanför måsvingarna) kodblock.
        {
            Console.WriteLine("You cook your soup.");//Skriver ut att soppan är kokt
            Burnt();//Kör "Brunt"-koden.
            PrintStats();//Kör "PrintStats"-koden.
        }

        public void PrintStats()//Skapar ett "publik" (öppen för ändringar utanför måsvingarna) kodblock.
        {
            if(poisoned.Count >= insoup.Count && Burnt() == true)//Om antalet giftiga ingredienser i soppan är fler än eller lika med hälften av alla ingredienser, och om soppan är bränd så körs detta.
            {
                foodpoisoned = true;//Ändrar "foodpoisoned" till "true".

                Console.WriteLine("Your soup is mostly poisoned, " +
                "due to the amount of ingredients that was poisoned.");//Skriver ut att soppan är mestadels giftig.

                Console.WriteLine("You also burn the soup.");//Skriver även ut att soppan brändes.
            }

            else if(poisoned.Count >= insoup.Count && Burnt() == false)//Om antalet giftiga ingredienser i soppan är fler än eller lika med hälften av alla ingredienser, och om soppan inte är bränd så körs detta.
            {
                foodpoisoned = true;//Ändrar "foodpoisoned" till "true".

                Console.WriteLine("Your soup is mostly poisoned, " +
                "due to the amount of ingredients that was poisoned.");//Skriver ut att soppan är mestadels giftig.

                Console.WriteLine("You did managed not to burn the soup tho.");//Skriver även ut att soppan inte brändes.
            }

            else if(poisoned.Count < insoup.Count && Burnt() == true)//Om antalet giftiga ingredienser i soppan är färre än eller lika med hälften av alla ingredienser, och om soppan är bränd så körs detta.
            {
                foodpoisoned = false;//Ändrar "foodpoisoned" till "false".

                Console.WriteLine("Your soup is good, " +
                "it is not poisoned.");//Skriver ut att soppan är mestadels icke-giftig.

                Console.WriteLine("You did managed to burn the soup.");//Skriver även ut att soppan brändes.
            }

            else//Om ingen av de tidigare if-satserna körts så körs denna.
            {
                foodpoisoned = false;//Ändrar "foodpoisoned" till "false".

                Console.WriteLine("Your soup is good, " +
                "it is not poisoned.");//Skriver ut att soppan är mestadels icke-giftig.

                Console.WriteLine("You managed not to burn the soup.");//Skriver även ut att soppan inte brändes.
            }
        }

        static string CheckAnswer()//Skapar en "statisk" (En enda variant av detta kodblock som alla instanser/anrop delar på) string.
        {
            string[] ans = {"tomato", "potato", "carrot", "garlic", "avocado","lemon",
            "mango", "olives", "turkey", "fish", "beef", "chicken", "egg"};//Skapar en string array med alla ingredienser.

            string input = Console.ReadLine().ToLower();//Sparar det man skriver i små bokstäver.

            while (!ans.Contains(input))//kollar om och körs medans "input" är ett svar som finns med i "ans".
            {
                Console.WriteLine("Not a valid choice, try again");//Skriver ut att det som skrevs inte accepteras.
                Console.WriteLine("Only accepting " + String.Join(", ", ans) + " as an answer.");//Skriver ut att bara de ingredienserna man har accepteras.

                input = Console.ReadLine();//sparar det man skriver i "input".
            }

            return input;//Returnerar input.
        }

    }
}
