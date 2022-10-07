using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    internal class Helmet : Item
    {
        public Helmet(string itemName, string itemClass, int itemLVL, double itemArmor) : base(itemName, itemClass, itemLVL, itemArmor)
        { 


        }


        public string ToString()
        {
            return $"Name - {ItemName} \nLVL - {ItemLVL} \nClass - {ItemClass} \nPhysical def - {PhysicalDef} \nDamage - {ItemDamage}";
        }
    }
}
