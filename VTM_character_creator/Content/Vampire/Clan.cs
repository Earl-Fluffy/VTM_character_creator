using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.PlayerSpecs;

namespace VTM_character_creator.Content.Vampire
{
    class Clan
    {
        private string clanName;
        private LinkedList<DisciplineFamily> discplines;
        private BaneCompulsion bane;

        public Clan(string clanName, LinkedList<DisciplineFamily> discplines, BaneCompulsion bane)
        {
            this.clanName = clanName;
            this.discplines = discplines;
            this.bane = bane;
        }
    }
}
