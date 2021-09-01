using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Vampire
{
    class BloodTable
    {
        List<BloodTableRow> bloodTableRows;

        public BloodTable(List<BloodTableRow> bloodTableRows)
        {
            this.bloodTableRows = bloodTableRows;
        }
    }
}
