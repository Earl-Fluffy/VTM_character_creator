using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Advantages
{
    class Advantage
    {
        private readonly string name;
        private string description;
        private uint cost;
        private bool positive;
        private string required;

        public Advantage(string name, string description, uint cost, bool positive = true, string required = null)
        {
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.positive = positive;
            this.required = required;
        }

        public string Name => name;
    }
}
