using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterRedactor_;

namespace CharacterRedactor
{
    [BsonKnownTypes(typeof(Warrior), typeof(Rogue), typeof(Wisard))]
    internal class Character
    {
        protected string characterClass;
        protected string name;
        protected double strength;
        protected double dexterity;
        protected double constitution;
        protected double intelligence;
        protected int lvl;
        protected double xp;
        protected int skillPoints;
        protected int starPoints;

        protected double healthPoint;
        protected double physicalAttake;
        protected double physicalDef;
        protected double magicalAttake;
        protected double manaPool;

        public Character(string Name, double strength, double dexterity, double constitution, double intelligence, double healthPoint,
                        double physicalAttake, double magicalAttake, double physicalDef, double manaPool, int LVL, double XP, int skillPoints, int starPoints)
        {
            this.name = Name;
            this.lvl = LVL;
            this.xp = XP;
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.healthPoint = healthPoint;
            this.physicalAttake = physicalAttake;
            this.magicalAttake = magicalAttake;
            this.physicalDef = physicalDef;
            this.manaPool = manaPool;
            this.skillPoints = skillPoints;
            this.starPoints = starPoints;
            Inventory = new List<Item>();
            Skills = new List<CharacterSkills>();
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void AddSkill(CharacterSkills skill)
        {
            Skills.Add(skill);
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;


        public List<Item> Inventory { get; set; }

        [BsonIgnoreIfNull]
        public List<CharacterSkills> Skills { get; set; }

        [BsonIgnoreIfNull]
        public string CharacterClass { get => characterClass; set => characterClass = value; }

        [BsonIgnoreIfNull]
        public string Name { get => name; set => name = value; }

        [BsonIgnoreIfDefault]
        public int LVL { get => lvl; set => lvl = value; }

        [BsonIgnoreIfDefault]
        public double XP { get => xp; set => xp = value; }

        [BsonIgnoreIfDefault]
        public double Strength { get => strength; set => strength = value; }

        [BsonIgnoreIfDefault]
        public double Dexterity { get => dexterity; set => dexterity = value; }

        [BsonIgnoreIfDefault]
        public double Constitution { get => constitution; set => constitution = value; }

        [BsonIgnoreIfDefault]
        public double Intelligence { get => intelligence; set => intelligence = value; }

        [BsonIgnoreIfDefault]
        public double HealthPoint { get => healthPoint; set => healthPoint = value; }

        [BsonIgnoreIfDefault]
        public double PhysicalAttake { get => physicalAttake; set => physicalAttake = value; }

        [BsonIgnoreIfDefault]
        public double MagicalAttake { get => magicalAttake; set => magicalAttake = value; }

        [BsonIgnoreIfDefault]
        public double PhysicalDef { get => physicalDef; set => physicalDef = value; }

        [BsonIgnoreIfDefault]
        public double ManaPool { get => manaPool; set => manaPool = value; }

        [BsonIgnoreIfDefault]
        public int SkillPoints { get => skillPoints; set => skillPoints = value; }

        [BsonIgnoreIfDefault]
        public int StarPoints { get => starPoints; set => starPoints = value; }
    }
}
