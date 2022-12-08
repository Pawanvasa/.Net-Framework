using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Characters.Warriors
{
    public class Warrior
    {
        //Fields are only to use inside the class
        private int height;
        private int weight;

        //Properties can be used out side the class
        public int Height { get; set; }
        public int Weight { get; set; }
        public string? Name { get; set; }

        //Constructor
        public Warrior(int height, int weight, string? name)
        {
            Height = height;
            Weight = weight;
            Name = name;
        }

        //Greeting method which will greet tha warrior
        public void Greetings(Warrior warrior)
        {
            Console.WriteLine($"Greetings {warrior.Name}!");
        }
    }
}
