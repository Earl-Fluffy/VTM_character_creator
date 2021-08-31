using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content
{
    class SkillDistribution
    {
        private readonly LinkedList<(uint, uint)> skillsDistribution;
        private readonly string name;

        public SkillDistribution(LinkedList<(uint, uint)> skillsDistribution, string name)
        {
            this.skillsDistribution = skillsDistribution;
            this.name = name;
        }
    }
}
