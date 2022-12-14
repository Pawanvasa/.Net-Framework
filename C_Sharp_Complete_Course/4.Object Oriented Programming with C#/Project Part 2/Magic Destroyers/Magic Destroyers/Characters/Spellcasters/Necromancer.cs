using Magic_Destroyers.Characters.Equipment.Armors;
using Magic_Destroyers.Equipment.Weapons.SharpWeapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Destroyers.Characters.Spellcasters
{
    public class Necromancer
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

        private LightLeatherVest bodyAromr;
        private Sword weapon;

        public LightLeatherVest BodyArmor
        {
            get { return this.bodyAromr; }
            set
            {
                this.bodyAromr = BodyArmor;
            }
        }

        public Sword Weapon
        {
            get { return this.weapon; }
            set { this.weapon = Weapon; }
        }

        public Necromancer()
        {

        }
        public Necromancer(string Name, string Level)
        {

        }
        public Necromancer(string Name, string Level, int HealthPoints)
        {

        }

        public void ShadowRage()
        {

        }
        public void VampireTouch()
        {

        }
        public void BoneShield()
        {

        }
    }
}
