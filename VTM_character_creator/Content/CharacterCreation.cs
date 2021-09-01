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
        private string description;
        private LinkedList<(uint, uint)> attributeDistribution;
        private LinkedList<SkillDistribution> skillDistributions;
        private LinkedList<(uint, uint)> disciplineDistribution;
        private uint advantagePool;
        private uint flawPool;
        private uint baseHumanity;
        private uint baseXP;

        public CharacterCreation(string name, string description, LinkedList<(uint, uint)> attributeDistribution, LinkedList<SkillDistribution> skillDistributions, LinkedList<(uint, uint)> disciplineDistribution, uint advantagePool, uint flawPool, uint baseHumanity, uint baseXP)
        {
            this.name = name;
            this.description = description;
            this.attributeDistribution = attributeDistribution;
            this.skillDistributions = skillDistributions;
            this.disciplineDistribution = disciplineDistribution;
            this.advantagePool = advantagePool;
            this.flawPool = flawPool;
            this.baseHumanity = baseHumanity;
            this.baseXP = baseXP;
        }
    }
}
