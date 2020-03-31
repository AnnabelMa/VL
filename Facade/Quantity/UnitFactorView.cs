using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VL1.Facade.Common;

namespace VL1.Facade.Quantity
{
    public sealed class UnitFactorView: PeriodView
    {
        [Required]
        [DisplayName("Unit")]
        public string UnitId { get; set; }
        [Required]
        [DisplayName("SystemOfUnits")]
        public string SystemOfUnitsId { get; set; }
        public double Factor { get; set; }
    }
}
