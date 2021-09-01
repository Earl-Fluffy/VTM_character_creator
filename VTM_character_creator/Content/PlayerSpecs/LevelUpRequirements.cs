using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM_character_creator.Content.PlayerSpecs
{
    class LevelUpRequirements
    {
        private readonly uint specialityXP;
        private readonly uint skillXP;
        private readonly uint attributeXP;
        private readonly uint ownDisciplineXP;
        private readonly uint otherDisciplineXP;
        private readonly uint exceptionDisciplineXP;
        private readonly uint potencyXP;
        private readonly uint humanityXP;
        private readonly uint ritualXP;
        private readonly uint advantageXP;

        public LevelUpRequirements(uint specialityXP, uint skillXP, uint attributeXP, uint ownDisciplineXP, uint otherDisciplineXP, uint exceptionDisciplineXP, uint potencyXP, uint humanityXP, uint ritualXP, uint advantageXP)
        {
            this.specialityXP = specialityXP;
            this.skillXP = skillXP;
            this.attributeXP = attributeXP;
            this.ownDisciplineXP = ownDisciplineXP; 
            this.otherDisciplineXP = otherDisciplineXP;
            this.exceptionDisciplineXP = exceptionDisciplineXP;
            this.potencyXP = potencyXP;
            this.humanityXP = humanityXP;
            this.ritualXP = ritualXP;
            this.advantageXP = advantageXP;
        }
    }
}
