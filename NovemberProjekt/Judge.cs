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
            if(generator.Next(100) >= 50)//Om det slumpade talet är större eller lika med 50 så körs detta.
            {
                amount = 4;//Ändrar på variabeln amount till 4.
                Console.WriteLine("There are 4 judges");//Skriver ut att det är 4st judges.
            }

            else if (generator.Next(100) <= 25)
            {
                amount = 3;
                Console.WriteLine("There are 3 judges");
            }

            else
            {
                amount = 5;
                Console.WriteLine("There are 5 judges");
            }
        }

        void Eat(Food food)
        {
            System.Console.WriteLine("The judges eat your soup.");

            if (food.foodpoisoned == true)
            {
                Console.WriteLine("Halp halp im dying");
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

