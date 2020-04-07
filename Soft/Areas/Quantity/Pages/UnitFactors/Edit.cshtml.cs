using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.UnitFactors
{
    public class EditModel : UnitFactorsPage
    {
        public EditModel(IUnitFactorsRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await updateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
