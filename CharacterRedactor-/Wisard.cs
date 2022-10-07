using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor
{
    internal class Wisard : Character
    {
        public Wisard(string Name, double strength, double dexterity, double constitution, double intelligence, double healthPoint, double physicalAttake,
                      double magicalAttake, double physicalDef, double manaPool, int LVL, double XP, int skillPoints, int straPoints) : base(Name, strength, dexterity, constitution,
                             intelligence, healthPoint, physicalAttake, magicalAttake, physicalDef, manaPool, LVL, XP, skillPoints, straPoints)
        {
            characterClass = "Wisard";
        }
    }
}