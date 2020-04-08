using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public class MeasureTermsPage : CommonPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData>
    {

        protected internal MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) : base(r)
        {
            PageTitle = "Measure Terms";
            Measures = createSelectList<Measure, MeasureData>(m);
        }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();

        protected internal override string getPageUrl() => "/Quantity/MeasureTerms";

        protected internal override MeasureTerm toObject(MeasureTermView view) =>MeasureTermViewFactory.Create(view);

        protected internal override MeasureTermView toView(MeasureTerm obj)=> MeasureTermViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Measures { get; }

        public string GetMeasureName(string measureId)
        {
            foreach (var m in Measures)
            {
                if (m.Value == measureId)
                    return m.Text;
            }
            return "Unspecified";
        }

        protected internal override string getPageSubTitle()
        {
            return FixedValue is null
                ? base.getPageSubTitle()
                : $"For {GetMeasureName(FixedValue)}";
        }

    }
}

