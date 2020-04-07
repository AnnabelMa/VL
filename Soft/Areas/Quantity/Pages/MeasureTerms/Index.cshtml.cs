using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.MeasureTerms
{
    public class IndexModel : MeasureTermsPage
    {
        public IndexModel(IMeasureTermsRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await getList( sortOrder,  currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
