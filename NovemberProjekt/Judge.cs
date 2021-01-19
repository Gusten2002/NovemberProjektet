using System;

namespace NovemberProjekt
{
    public class Judge
    {
        private static Random generator = new Random();//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) slumpgenerator.

        public int amount = 5;//Skapar en siffra (5) i namnet amount.

        // private int hunger = generator.Next(10);

        private bool isDead = false;//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som sparar om någon "judge" är död eller ej.

        public void JudgeStats()//Skapar ett publik (öppen för ändringar utanför måsvingarna) kodblock.
        {
            if (generator.Next(100) >= 50)//Om det slumpade talet är större eller lika med 50 så körs detta.
            {
                amount = 4;//Ändrar på variabeln amount till 4.
                Console.WriteLine("There are " + amount + " judges");//Skriver ut att det är 4st judges.
            }

            else if(generator.Next(100) <= 25)//Om det slumpade talet är mindre eller lika med 25 så körs detta.
            {
                amount = 3;//Ändrar på variabeln amount till 3.
                Console.WriteLine("There are " + amount +" judges");//Skriver ut att det är 3st judges.
            }

            else//Om inte någon av de övre if-satserna körts så körs denna.
            {
                amount = 5;//Ändrar på variabeln amount till 5.
                Console.WriteLine("There are " + amount +" judges");//Skriver ut att det är 5st judges.
            }
        }

        void Eat(Food food)//Skapar ett kodblock.
        {
            Console.WriteLine("The judges eat your soup.");//Skriver ut att judges äter din soppa.

            if (food.foodpoisoned == true && generator.Next(100) >= 50)
            {
                Console.WriteLine("2 of the judges falls to the ground.");
                amount--;
                amount--;
            }

            else if (food.foodpoisoned == true && generator.Next(100) <= 49)
            {
            Console.WriteLine("The judges falls to the ground.");
            }
        }

        // private void Taste()
        // {

        // }

        // public int Score()
        // {

        // }

        // private bool Dead()
        // {
        //     if(foodPoisoned != true)
        //     {
        //         return false;
        //     }

        //   else return true;
        // }
    }
}

