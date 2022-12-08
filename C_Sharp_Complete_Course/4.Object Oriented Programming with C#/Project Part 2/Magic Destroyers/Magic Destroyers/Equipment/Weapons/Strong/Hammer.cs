using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Destroyers.Equipment.Weapons.Strong
{
    public class Hammer
    {
        private int damage;
        public int Damage
        {
            get { return damage; }
            set
            {
                if (value > 0)
                    damage = value;
                else
                    throw new Exception("Value should be Positive");

            }
        }
        public Hammer()
        {

        }
       public void Stun()
        {

        }
    }
}
