
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VL1.Facade.Quantity
{
    public sealed class MeasureTermView: CommonTermView
    {
        [Required]
        [DisplayName("Measure")]
        public string MasterId { get; set; }
    }
}
