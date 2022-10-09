using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator;
using MongoDB.Driver;
using System.Xml.Linq;
using CharacterRedactor_;

namespace CharacterRedactor_
{
    internal class ItemMaker
    {
        public Item Make(string[] itemParams)
        {
            Item item = null;
            switch(itemParams[1])
            {
                case "Helmet":
                    item = new Helmet(itemParams[0], itemParams[1], int.Parse(itemParams[2]), double.Parse(itemParams[3]));
                    break;
                    item = new Armor(itemParams[0], itemParams[1], int.Parse(itemParams[2]), double.Parse(itemParams[3]));
                    break;
                    item = new Weapon(itemParams[0], itemParams[1], double.Parse(itemParams[3]),int.Parse(itemParams[2]));
                    break;
            }
            return item;
        }
    }
}
