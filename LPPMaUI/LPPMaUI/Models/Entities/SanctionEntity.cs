using LPPMaUI.Models.Entities.Enum;
using SQLite;

namespace LPPMaUI.Models.Entities
{
    [Table("sanction")]
    public class SanctionEntity : BaseEntity
    {

        public SanctionDuration Duration { get; set; }

        public SanctionType Type { get; set; }

        public SanctionEntity(SanctionDuration duration, SanctionType type)
        {
            Duration = duration;
            Type = type;
        }
    }
}
