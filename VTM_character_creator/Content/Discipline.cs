using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.Dice;
using VTM_character_creator.Content.PlayerSpecs;

namespace VTM_character_creator.Content
{
    class Discipline
    {
        private DisciplineFamily family;
        private string name;
        private string fluff;
        private string system;
        private uint level;
        private uint cost;
        private string duration;
        private Roll roll;
        private Roll opposingRoll;

        public Discipline(DisciplineFamily family, string name, string fluff, string system, uint level, Roll roll, Roll opposingRoll, uint cost, string duration)
        {
            this.family = family;
            this.name = name;
            this.fluff = fluff;
            this.system = system;
            this.level = level;
            this.roll = roll;
            this.opposingRoll = opposingRoll;
            this.cost = cost;
            this.duration = duration;
        }
    }
}
