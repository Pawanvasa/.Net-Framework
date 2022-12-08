using Magic_Destroyers.Characters.Equipment.Armors;
using Magic_Destroyers.Equipment.Weapons.SharpWeapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Destroyers.Characters.Melee
{
    public class Warrior
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
        private Axe weapon;

        public Chainlink BodyArmor
        {
            get { return this.bodyArmor; }
            set
            {
                this.bodyArmor = BodyArmor;
            }
        }

        public Axe Weapon
        {
            get { return this.weapon; }
            set { this.weapon = Weapon; }
        }

        public Warrior() : this("Bob", 1)
        {

        }
        public Warrior(string Name,int Level) : this(Name, Level, 120)
        {

        }
        public Warrior(string name, int level,int ealthPoints)
        {
            this.Name = name!;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.AbilityPoints = 100;
            this.Faction = "Melee";
            this.BodyArmor = new Chainlink();
            this.Weapon = new Axe();
        }

        public void Strike()
        {

        }
        public void Execute()
        {

        }
        public void SkinHarden()
        {

        }
    }
}
