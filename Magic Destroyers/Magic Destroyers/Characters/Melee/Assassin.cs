using Magic_Destroyers.Characters.Equipment.Armors;
using Magic_Destroyers.Equipment.Weapons.SharpWeapons;
using Magic_Destroyers.Equipment.Weapons.Strong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Destroyers.Characters.Melee
{
    public class Assassin
    {
        private int abilityPoints;
        private int healthPoints;
        private int level;
        private string name;
        private string faction;

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
                if(value== "Melee" || value== "SpellCasters")
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
                    throw new Exception("Value should be Positive");

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

        private LightLeatherVest bodyArmor;
        private Sword weapon;

        public LightLeatherVest BodyArmor
        {
            get { return this.bodyArmor; }
            set
            {
                this.bodyArmor = BodyArmor;
            }
        }

        public Sword Weapon
        {
            get { return this.weapon; }
            set { this.weapon = Weapon; }
        }

        public Assassin():this("Jam",3)
        {
           
        }
        public Assassin(string Name, int level) : this(Name, level, 120)
        {

        }
        public Assassin(string name, int Level, int healthPoints)
        {
            this.Name = name!;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.AbilityPoints = 90;
            this.Faction = "Melee";
            this.BodyArmor = new LightLeatherVest();
            this.Weapon = new Sword();
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
