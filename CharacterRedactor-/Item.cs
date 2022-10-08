using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    public class Item
    {
        public Item(string itemName, string itemClass, int itemLVL, double physicalDef)
        {
            ItemName = itemName;
            ItemClass = itemClass;
            ItemLVL = itemLVL;
            PhysicalDef = physicalDef;
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
        public double ItemDamage { get; set; }

        [BsonIgnoreIfDefault]
        public double ItemMagDamage { get; set; }

    }
}
