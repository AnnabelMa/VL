using System.Threading.Tasks;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.UnitFactors
{
    public class IndexModel : UnitFactorsPage
    {
        public IndexModel(IUnitFactorsRepository r) : base(r) { }

        public async Task OnGetAsync(string sortOrder, string currentFilter, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await getList( sortOrder,  currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
