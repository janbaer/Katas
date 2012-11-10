using System.Collections.Generic;

namespace Kata.TowersOfHanoi
{
    public class Tower
    {
        public Tower(string name)
        {
            this.Name = name;
            this.Disks = new Stack<int>();
        }

        protected string Name { get; set; }

        public Stack<int> Disks { get; set; }

        public override string ToString()
        {
            return "Tower" + this.Name;
        }
    }
}