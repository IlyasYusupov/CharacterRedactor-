using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    public class Armor : Item
    {
        public Armor(string itemName, string itemClass, int itemLVL, double itemArmor) : base(itemName, itemClass, itemLVL, itemArmor)
        {  }


        public string ToString()
        {
            return $"Name - {ItemName} \nLVL - {ItemLVL} \nClass - {ItemClass} \nPhysical def - {PhysicalDef}";
        }

        [BsonIgnoreIfDefault]
        public static Dictionary<int, double[]> ArmorBufs = new Dictionary<int, double[]>()
        {
            {1, new double[] {0, 0}},
            {2,  new double[] {25, 0}},
            {3, new double[] {40, 20}},
        };
    }
}
