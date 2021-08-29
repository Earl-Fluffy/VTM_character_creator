using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.PlayerSpecs
{
    class Skill : Spec
    {
        public Skill(string name, string description, uint maxLevel) : base(name, description, maxLevel)
        {
        }

        public override string getType()
        {
            return "Skill";
        }
    }
}
