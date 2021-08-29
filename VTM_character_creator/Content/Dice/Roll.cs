using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Dice
{
    class Roll
    {
        private Spec stat1;
        private Spec stat2;

        public Roll(Spec stat1, Spec stat2)
        {
            this.stat1 = stat1;
            this.stat2 = stat2;
        }
    }
}
