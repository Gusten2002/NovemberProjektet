using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Linq.Expressions;
using System;

namespace NovemberProjekt
{
    public class ingredient
    {
        private List<string> ingredients = new List<string>();

        private static Random generator = new Random();

        private int amount = generator.next(0,10);

        private int boredom = 10;

        private bool isPoisonous = false;

        private bool ismoldy = false;

        private int rarity = generator.next(0,5);

        private int taste = generator.next(0,5);

        public string name = ("");
    }
}
