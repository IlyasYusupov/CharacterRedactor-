using CharacterRedactor;
using Microsoft.VisualBasic.ApplicationServices;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;


namespace CharacterCreator
{
    internal class Mongo
    {
        public static void AddToDB(Character character)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            collection.InsertOne(character);
        }

        public static void FindAll(ComboBox box)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            var list = collection.Find(x => true).ToList();
            foreach (var item in list)
            {
                box.Items.Add($"{item.Name}");
            }
        }
        public static Character Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
        }

        public static void Replace(string name, Character character)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            collection.ReplaceOne(z => z.Name == name, character);
        }

        public static void UpgradeOne(string name, Character character)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            //var update = Builders<Character>.Update.Set("Inventory", character.Inventory);
            //collection.UpdateOne(x => x.Name == name, update);
        }
    }
}
