using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.PlayerSpecs
{
    class Skill : Spec
    {
        private readonly bool freeSpeciality;
        public Skill(string name, string description, uint maxLevel, bool freeSpeciality = false) : base(name, description, maxLevel)
        {
            this.freeSpeciality = freeSpeciality;
        }

        public bool FreeSpeciality => freeSpeciality;

        public override string getType()
        {
            return "Skill";
        }
    }
}
