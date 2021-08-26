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
        private LinkedList<Advantage> subAdvantages;
        private string exclusionCategory;
        private string description;
    }
}
