using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    [BsonKnownTypes(typeof(Helmet), typeof(Armor), typeof(Weapon))]
    public class Item
    {
        public Item(string itemName, string itemClass, int itemLVL, double physicalDef)
        {
            ItemName = itemName;
            ItemClass = itemClass;
            ItemLVL = itemLVL;
            PhysicalDef = physicalDef;
        }
        public Item(string itemName, string itemClass, double damage, int itemLVL)
        {
            ItemName = itemName;
            ItemClass = itemClass;
            ItemLVL = itemLVL;
            Damage = damage;
        }
        public Item(string itemName, double magicalDamage, string itemClass, int itemLVL)
        {
            ItemName = itemName;
            ItemClass = itemClass;
            ItemLVL = itemLVL;
            MagicalDamage = magicalDamage;
        }

        [BsonIgnoreIfNull]
        public string ItemName { get; set; }

        [BsonIgnoreIfNull]
        public string ItemClass { get; set; }

        [BsonIgnoreIfDefault]
        public int ItemLVL { get; set; }
        [BsonIgnoreIfDefault]
        public double PhysicalDef { get; set; }

        [BsonIgnoreIfDefault]
        public double Damage { get; set; }

        [BsonIgnoreIfDefault]
        public double MagicalDamage { get; set; }

    }
}
