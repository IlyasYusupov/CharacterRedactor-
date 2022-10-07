using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactor_
{
    internal class CharacterSkills
    {
        public CharacterSkills(string skillName)
        {
            SkillName = skillName;
        }
        public string SkillName { get; set; }
    }
}
