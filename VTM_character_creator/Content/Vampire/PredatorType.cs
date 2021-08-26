using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.Dice;
using VTM_character_creator.Content.PlayerSpecs;

namespace VTM_character_creator.Content.Vampire
{
    class PredatorType
    {
        private LinkedList<LinkedList<Skill>> bonusSpecialities;
        private LinkedList<LinkedList<DisciplineFamily>> bonusDisciplineLevel;
        private LinkedList<LinkedList<Advantage>> bonusAdvantages;
        private LinkedList<LinkedList<Advantage>> bonusFlaws;
        private string name;
        private string description;
        private Roll huntingPool;
        private int bonusHumanity;
        private int bonusPotency;

        public PredatorType(LinkedList<LinkedList<Skill>> bonusSpecialities, LinkedList<LinkedList<DisciplineFamily>> bonusDisciplineLevel, LinkedList<LinkedList<Advantage>> bonusAdvantages, LinkedList<LinkedList<Advantage>> bonusFlaws, string name, string description, Roll huntingPool, int bonusHumanity, int bonusPotency)
        {
            this.bonusSpecialities = bonusSpecialities;
            this.bonusDisciplineLevel = bonusDisciplineLevel;
            this.bonusAdvantages = bonusAdvantages;
            this.bonusFlaws = bonusFlaws;
            this.name = name;
            this.description = description;
            this.huntingPool = huntingPool;
            this.bonusHumanity = bonusHumanity;
            this.bonusPotency = bonusPotency;
        }
    }
}
