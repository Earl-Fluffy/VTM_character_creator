using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Advantages
{
    class AdvantageCategory
    {
        private string name;
        private string description;
        private bool unique;

        private LinkedList<Advantage> choice;

        private LinkedList<Advantage> secondaryChoices;

        public AdvantageCategory(string name, string description, bool unique, LinkedList<Advantage> choice, LinkedList<Advantage> secondaryChoices)
        {
            this.name = name;
            this.description = description;
            this.unique = unique;
            this.choice = choice;
            this.secondaryChoices = secondaryChoices;
        }

        public Advantage GetChoiceFromString(string choiceName)
        {
            foreach(Advantage advantage in choice)
            {
                if(advantage.Name == choiceName)
                {
                    return advantage;
                }
            }
            return null;
        }
    }
}
