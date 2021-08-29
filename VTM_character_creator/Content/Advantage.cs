using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content
{
    class Advantage
    {
        private string advantageName;
        private uint cost;
        private bool positive;
        private string requiredAdvantage;
        private string exclusionCategory;
        private string description;

        public Advantage(string advantageName, uint cost, bool positive, string requiredAdvantage, string exclusionCategory, string description)
        {
            this.advantageName = advantageName;
            this.cost = cost;
            this.positive = positive;
            this.requiredAdvantage = requiredAdvantage;
            this.exclusionCategory = exclusionCategory;
            this.description = description;
        }
    }
}
