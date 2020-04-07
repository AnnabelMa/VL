using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public abstract class MeasuresPage : CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {
        protected internal MeasuresPage(IMeasuresRepository r) : base(r)
        {
            PageTitle = "Measures";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Quantity/Measures";

        protected internal override Measure toObject(MeasureView view)
        {
            return MeasureViewFactory.Create(view);
        }

        protected internal override MeasureView toView(Measure obj)
        {
            return MeasureViewFactory.Create(obj);
        }

    }
}
