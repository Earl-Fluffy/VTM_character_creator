using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.Vampire
{
    class BloodTableRow
    {
        private readonly uint bloodSurge;
        private readonly uint mend;
        private readonly uint powerBonus;
        private readonly uint disciplineReRoll;
        private readonly uint bane;
        private readonly string feedingPenalty;

        public BloodTableRow(JObject jsonRow)
        {
            this.bloodSurge = Convert.ToUInt32(jsonRow["Blood Surge"].ToString());
            this.mend = Convert.ToUInt32(jsonRow["Mend"].ToString());
            this.powerBonus = Convert.ToUInt32(jsonRow["Power Bonus"].ToString());
            this.disciplineReRoll = Convert.ToUInt32(jsonRow["Discipline Re-Roll"].ToString());
            this.bane = Convert.ToUInt32(jsonRow["Bane"].ToString());
            this.feedingPenalty = jsonRow["Feeding Penalty"].ToString();
        }
    }
}
