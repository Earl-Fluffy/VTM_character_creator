using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content
{
    abstract class Spec
    {
        private readonly string name;
        private readonly string description;
        private readonly uint maxLevel;

        protected Spec(string name, string description, uint maxLevel)
        {
            this.name = name;
            this.description = description;
            this.maxLevel = maxLevel;
        }

        public string Name => name;

        public string Description => description;

        public uint MaxLevel => maxLevel;

        abstract public string getType();
    }
}
