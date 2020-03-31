using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VL1.Facade.Common;

namespace VL1.Facade.Quantity
{
    public abstract class CommonTermView: PeriodView
    {
        [Required]
        [DisplayName("Term")]
        public string TermId { get; set; }
        public int Power { get; set; }
    }
}