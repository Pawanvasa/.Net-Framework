using Magic_Destroyers.Characters.Equipment.Armors;
using Magic_Destroyers.Equipment.Weapons.SharpWeapons;
using Magic_Destroyers.Equipment.Weapons.Strong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Magic_Destroyers.Characters.Melee
{
    public class Knight
    {
        private int abilityPoints;
        private int healthPoints;
        private int level;
        private string faction;
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3 && value.Length <= 12)
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Name leght should be greater than 2 and less than 13");
                }
            }
        }
        public string Faction
        {
            get { return faction; }
            set
            {
                if (value == "Melee" || value == "SpellCasters")
                {
                    faction = value;
                }
                else
                {
                    throw new Exception("Inavlid Faction it should be malee or spellcasters");
                }

            }
        }

        public int AbilityPoints
        {
            get { return abilityPoints; }
            set
            {
                if (value >= 0)
                {
                    abilityPoints = value;
                }
                else
                {
                    throw new Exception("Value should be Positive");

                }
            }
        }
        public int HealthPoints
        {
            get { return healthPoints; }
            set
            {
                if (value >= 0)
                {
                    abilityPoints = value;
                }
                else
                {
                    throw new Exception("Value should be Positive");

                }
            }
        }
        public int Level
        {
            get { return level; }
            set
            {
                if (value >= 0)
                {
                    abilityPoints = value;
                }
                else
                {
                    throw new Exception("Value should be Positive");
                }
            }
        }

        private Chainlink bodyArmor;
        private Hammer weapon;
        public Chainlink BodyArmor
        {
            get { return this.bodyArmor; }
            set
            {
                this.bodyArmor = BodyArmor;
            }
        }

        public Hammer Weapon
        {
            get { return this.weapon; }
            set { this.weapon = Weapon; }
        }
        public Knight():this("rem",2)
        {
        }
        public Knight(string name, int level):this(name, level,120)
        {

        }
        public Knight(string name, int level, int healthPoints) 
        {
            this.Name = name!;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.AbilityPoints = 110;
            this.Faction = "Melee";
            this.BodyArmor = new Chainlink();
            this.Weapon = new Hammer();
        }

        public void Raze()
        {

        }
        public void BleedToDeath()
        {

        }
        public void Survival()
        {

        }
    }
}
