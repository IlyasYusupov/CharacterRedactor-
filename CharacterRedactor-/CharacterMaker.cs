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

namespace CharacterRedactor
{
    internal class CharacterMaker
    {
        public List<CharacterSkills> skills = new List<CharacterSkills>();
        public List<Item> Inventory = new List<Item>();

        public CharacterMaker()
        {
            skills = new List<CharacterSkills>();
            Inventory = new List<Item>();
        }

        public Character Make(string characterClass, string[] paraparameters)
        {
            Character character = null;
            if (paraparameters[0] != "")
            {
                var client = new MongoClient();
                var database = client.GetDatabase("CharactersBase");
                var collection = database.GetCollection<Character>("Character");
                var list = collection.Find(x => true).ToList();
                foreach (var item in list)
                {
                    if (item.Name == paraparameters[0])
                    {
                        MessageBox.Show("Такой ник уже есть!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                double[] result = DoubleParse(paraparameters);
                double[] calcParam = CalcParams(characterClass, result);
                switch (characterClass)
                {
                    case "Warrior":

                        character = new Warrior(paraparameters[0], result[0], result[1], result[2], result[3], calcParam[0], calcParam[1], calcParam[2],
                                                calcParam[3], calcParam[4], int.Parse(paraparameters[10]), result[4], int.Parse(paraparameters[12]), int.Parse(paraparameters[13]));
                        break;
                    case "Rogue":
                        character = new Rogue(paraparameters[0], result[0], result[1], result[2], result[3], calcParam[0], calcParam[1], calcParam[2],
                                               calcParam[3], calcParam[4], int.Parse(paraparameters[10]), result[4], int.Parse(paraparameters[12]), int.Parse(paraparameters[13]));
                        break;
                    case "Wisard":
                        character = new Wisard(paraparameters[0], result[0], result[1], result[2], result[3], calcParam[0], calcParam[1], calcParam[2],
                                                calcParam[3], calcParam[4], int.Parse(paraparameters[10]), result[4], int.Parse(paraparameters[12]), int.Parse(paraparameters[13]));
                        break;
                }
                AddSkills(character);
                Mongo.AddToDB(character);
            }
            return character;
        }

        public void AddSkills(Character character)
        {
            foreach(var skill in skills)
                character.Skills.Add(skill);
        }

        public double[] DoubleParse(string[] str)
        {
            double[] res = new double[5];
            res[0] = double.Parse(str[1]);
            res[1] = double.Parse(str[2]);
            res[2] = double.Parse(str[3]);
            res[3] = double.Parse(str[4]);
            res[4] = double.Parse(str[11]);
            return res;
        }

        public double[] CalcParams(string characterClass, double[] paraparameters)
        {
            double[] res = new double[5];
            switch (characterClass)
            {
                case "Warrior":
                    res[0] = paraparameters[0] * WarriorBoosts["Strength"][1] + paraparameters[2] * WarriorBoosts["Constitution"][0];
                    res[1] = paraparameters[1] * WarriorBoosts["Dexterity"][0] + paraparameters[0] * WarriorBoosts["Strength"][0];
                    res[2] = paraparameters[1] * WarriorBoosts["Dexterity"][1] + paraparameters[2] * WarriorBoosts["Constitution"][1];
                    res[3] = paraparameters[3] * WarriorBoosts["Intelligence"][1];
                    res[4] = paraparameters[3] * WarriorBoosts["Intelligence"][0];
                    break;
                case "Rogue":
                    res[0] = paraparameters[0] * RogueBoosts["Strength"][1] + paraparameters[2] * RogueBoosts["Constitution"][0];
                    res[1] = paraparameters[1] * RogueBoosts["Dexterity"][0] + paraparameters[0] * RogueBoosts["Strength"][0];
                    res[2] = paraparameters[1] * RogueBoosts["Dexterity"][1] + paraparameters[2] * RogueBoosts["Constitution"][1];
                    res[3] = paraparameters[3] * RogueBoosts["Intelligence"][1];
                    res[4] = paraparameters[3] * RogueBoosts["Intelligence"][0];
                    break;
                case "Wisard":
                    res[0] = paraparameters[0] * WisardBoosts["Strength"][1] + paraparameters[2] * WisardBoosts["Constitution"][0];
                    res[1] = paraparameters[1] * WisardBoosts["Dexterity"][0] + paraparameters[0] * WisardBoosts["Strength"][0];
                    res[2] = paraparameters[1] * WisardBoosts["Dexterity"][1] + paraparameters[2] * WisardBoosts["Constitution"][1];
                    res[3] = paraparameters[3] * WisardBoosts["Intelligence"][1];
                    res[4] = paraparameters[3] * WisardBoosts["Intelligence"][0];
                    break;
            }
            return res;
        }

        public string GetValue(string key, string dictionary)
        {
            double value = 0;
            switch (dictionary)
            {
                case "Warrior":
                    value = Warrior[key];
                    break;
                case "Rogue":
                    value = Rogue[key];
                    break;
                case "Wisard":
                    value = Wisard[key];
                    break;
            }
            return value.ToString();
        }

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double> Warrior = new Dictionary<string, double>()
        {
            {"MinStrength", 30},
            {"MinDexterity", 15},
            {"MinConstitution", 20},
            {"MinIntelligence", 10},

            {"MaxStrength", 250},
            {"MaxDexterity", 70},
            {"MaxConstitution", 100},
            {"MaxIntelligence", 50}
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double> Rogue = new Dictionary<string, double>()
        {
            {"MinStrength", 15},
            {"MinDexterity", 30},
            {"MinConstitution", 20},
            {"MinIntelligence", 15},

            {"MaxStrength", 55},
            {"MaxDexterity", 260},
            {"MaxConstitution", 80},
            {"MaxIntelligence", 70}
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double> Wisard = new Dictionary<string, double>()
        {
            {"MinStrength", 10},
            {"MinDexterity", 20},
            {"MinConstitution", 15},
            {"MinIntelligence", 35},

            {"MaxStrength", 45},
            {"MaxDexterity", 70},
            {"MaxConstitution", 60},
            {"MaxIntelligence", 250}
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double[]> WarriorBoosts = new Dictionary<string, double[]>()
        {
            {"Strength", new double[] {5, 2}},
            {"Dexterity",  new double[] {1, 1}},
            {"Constitution", new double[] {10, 2}},
            {"Intelligence", new double[] {1, 1}},
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double[]> RogueBoosts = new Dictionary<string, double[]>()
        {
            {"Strength", new double[] {2, 1}},
            {"Dexterity",  new double[] {4, 1.5}},
            {"Constitution", new double[] {6, 0}},
            {"Intelligence", new double[] {1.5, 2}},
        };

        [BsonIgnoreIfDefault]
        public static Dictionary<string, double[]> WisardBoosts = new Dictionary<string, double[]>()
        {
            {"Strength", new double[] {2, 1}},
            {"Dexterity",  new double[] {0, 0.5}},
            {"Constitution", new double[] {3, 1}},
            {"Intelligence", new double[] {2, 5}},
        };
    }
}
