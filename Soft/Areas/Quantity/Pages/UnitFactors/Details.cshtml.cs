﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VL1.Domain.Quantity;
using VL1.Pages.Quantity;

namespace VL1.Soft.Areas.Quantity.Pages.UnitFactors
{
    public class DetailsModel : UnitFactorsPage
    {
        public DetailsModel(IUnitFactorsRepository r) : base(r) { }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}