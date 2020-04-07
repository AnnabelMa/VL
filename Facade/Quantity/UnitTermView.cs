using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VL1.Facade.Quantity
{
   public sealed class UnitTermView : CommonTermView
    {
        [Required]
        [DisplayName("Unit")]
        public string MasterId { get; set; }
        public string GetId()
        {
            return $"{MasterId}.{TermId}";
        }
    }
}
