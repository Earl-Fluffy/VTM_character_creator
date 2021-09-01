using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.Advantages;
using VTM_character_creator.Content.Dice;
using VTM_character_creator.Content.PlayerSpecs;

namespace VTM_character_creator.Content.Vampire
{
    class PredatorType
    {
        private LinkedList<LinkedList<(Skill, string)>> bonusSpecialities;
        private LinkedList<LinkedList<(DisciplineFamily,Clan)>> bonusDisciplineLevel;
        private LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> bonusFlaws;
        private LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> bonusAdvantages;
        private string name;
        private string description;
        private int bonusHumanity;
        private int bonusPotency;

        public PredatorType(LinkedList<LinkedList<(Skill, string)>> bonusSpecialities, LinkedList<LinkedList<(DisciplineFamily, Clan)>> bonusDisciplineLevel, LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> bonusFlaws, LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> bonusAdvantages, string name, string description, int bonusHumanity, int bonusPotency)
        {
            this.bonusSpecialities = bonusSpecialities;
            this.bonusDisciplineLevel = bonusDisciplineLevel;
            this.bonusFlaws = bonusFlaws;
            this.bonusAdvantages = bonusAdvantages;
            this.name = name;
            this.description = description;
            this.bonusHumanity = bonusHumanity;
            this.bonusPotency = bonusPotency;
        }
    }
}
