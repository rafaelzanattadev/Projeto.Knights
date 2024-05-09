using System;
using System.Collections.Generic;

namespace Projeto.Knights
{
    public class Knight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Attributes Attributes { get; set; }
        public string KeyAttribute { get; set; }

        public int Attack
        {
            get
            {
                int keyAttributeMod = CalculateAttributeMod(Attributes.GetAttributeValue(KeyAttribute));
                int equippedWeaponMod = 0;
                foreach (var weapon in Weapons)
                {
                    if (weapon.Equipped)
                    {
                        equippedWeaponMod += weapon.Mod;
                    }
                }
                return 10 + keyAttributeMod + equippedWeaponMod;
            }
        }

        public int Exp
        {
            get
            {
                int age = CalculateAge(Birthday);
                if (age <= 7)
                {
                    return 0;
                }
                return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
            }
        }

        private int CalculateAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        private int CalculateAttributeMod(int attributeValue)
        {
            if (attributeValue >= 0 && attributeValue <= 8)
            {
                return -2;
            }
            else if (attributeValue >= 9 && attributeValue <= 10)
            {
                return -1;
            }
            else if (attributeValue >= 11 && attributeValue <= 12)
            {
                return 0;
            }
            else if (attributeValue >= 13 && attributeValue <= 15)
            {
                return 1;
            }
            else if (attributeValue >= 16 && attributeValue <= 18)
            {
                return 2;
            }
            else // attributeValue is 19-20
            {
                return 3;
            }
        }

        public int CalculateAttack()
        {
            int keyAttributeMod = CalculateAttributeMod(Attributes.GetAttributeValue(KeyAttribute));
            int equippedWeaponMod = 0;
            foreach (var weapon in Weapons)
            {
                if (weapon.Equipped)
                {
                    equippedWeaponMod += weapon.Mod;
                }
            }
            return 10 + keyAttributeMod + equippedWeaponMod;
        }

        public int CalculateExperience()
        {
            int age = CalculateAge(Birthday);
            if (age <= 7)
            {
                return 0;
            }
            return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
        }
    }

    public class Weapon
    {
        public string Name { get; set; }
        public int Mod { get; set; }
        public string Attr { get; set; }
        public bool Equipped { get; set; }
    }

    public class Attributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int GetAttributeValue(string attributeName)
        {
            switch (attributeName.ToLower())
            {
                case "strength":
                    return Strength;
                case "dexterity":
                    return Dexterity;
                case "constitution":
                    return Constitution;
                case "intelligence":
                    return Intelligence;
                case "wisdom":
                    return Wisdom;
                case "charisma":
                    return Charisma;
                default:
                    throw new ArgumentException($"Invalid attribute name: {attributeName}");
            }
        }
    }
}
    
