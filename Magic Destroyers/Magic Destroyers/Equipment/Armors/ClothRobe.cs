using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Destroyers.Equipment.Armors
{
    public class ClothRobe
    {
        private int armorPoints;
        public int ArmorPoints
        {
            get { return armorPoints; }
            set
            {
                if (value > 0)
                {
                    armorPoints = value;
                }
                else
                {
                    throw new Exception("Value should be Positive");

                }
            }
        }
        public ClothRobe()
        {

        }
    }
}
