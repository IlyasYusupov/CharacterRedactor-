using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    internal class Weapon : Item
    {
        public Weapon(string itemName, string itemClass, double Damage, int itemLVL) : base(itemName, itemClass, Damage ,itemLVL)
        { }
        public Weapon(string itemName, double MagicalDamage, string itemClass,  int itemLVL) : base(itemName, MagicalDamage, itemClass, itemLVL)
        { }

        public string ToString()
        {
            return $"Class - {ItemClass} \nName - {ItemName}  \nLVL - {ItemLVL} \nDamage - {Damage}";
        }

        [BsonIgnoreIfDefault]
        public static Dictionary<int, double[]> WeaponBufs = new Dictionary<int, double[]>()
        {
            {1, new double[] {0, 0}},
            {2,  new double[] {10, 0}},
            {3, new double[] {20, 10}},
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<int, double[]> MagWeaponBufs = new Dictionary<int, double[]>()
        {
            {1, new double[] {0, 0}},
            {2,  new double[] {10, 0}},
            {3, new double[] {20, 10}},
        };
    }
}
