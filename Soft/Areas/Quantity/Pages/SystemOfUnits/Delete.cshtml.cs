using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.SystemOfUnits
{
    public class DeleteModel : SystemsOfUnitsPage
    {
        public DeleteModel(ISystemsOfUnitsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            await deleteObject(id, fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}