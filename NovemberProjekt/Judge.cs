using System;

namespace NovemberProjekt
{
    public class Judge
    {
        private static Random generator = new Random();//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) slumpgenerator.

        public int amount = 5;//Skapar en siffra (5) i namnet amount.

        // private int hunger = generator.Next(10);

        private bool isDead = false;//Skapar en privat (inte tillgänglig för ändringar utanför måsvingarna) bool (true/false) som sparar om någon "judge" är död eller ej.

        public void JudgeStats()
        {
            if(generator.Next(100) >= 50)
            {
                amount = 4;
                Console.WriteLine("Test4");
            }

            else if (generator.Next(100) <= 25)
            {
                amount = 3;
                Console.WriteLine("Test3");
            }

            else
            {
                amount = 5;
                Console.WriteLine("Test5");
            }
        }

        private void Eat(Food food)
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
