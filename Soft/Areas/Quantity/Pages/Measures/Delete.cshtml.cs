using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;
using Microsoft.AspNetCore.Mvc;

namespace VL1.Soft.Areas.Quantity.Pages.Measures
{
    public class DeleteModel : MeasuresPage
    {
        public DeleteModel(IMeasuresRepository r, IMeasureTermsRepository t) : base(r, t) { }
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