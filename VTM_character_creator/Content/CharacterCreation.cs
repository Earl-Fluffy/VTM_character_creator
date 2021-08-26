using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content
{
    class CharacterCreation
    {
        private string name;
        private (uint, uint)[] attributeDistribution;
        private (uint, uint)[] skillsDistribution;
        private (uint, uint)[] disciplineDistribution;
        private uint advantagePool;
        private uint flawPool;

        public CharacterCreation(string name, (uint, uint)[] attributeDistribution, (uint, uint)[] skillsDistribution, (uint, uint)[] disciplineDistribution, uint advantagePool, uint flawPool)
        {
            this.name = name;
            this.attributeDistribution = attributeDistribution;
            this.skillsDistribution = skillsDistribution;
            this.disciplineDistribution = disciplineDistribution;
            this.advantagePool = advantagePool;
            this.flawPool = flawPool;
        }
    }
}
