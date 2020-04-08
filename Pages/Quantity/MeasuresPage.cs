using System.Collections;
using System.Collections.Generic;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Pages.Quantity
{
    public abstract class MeasuresPage : CommonPage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {
        protected internal readonly IMeasureTermsRepository terms;

        protected internal MeasuresPage(IMeasuresRepository r, IMeasureTermsRepository t) : base(r)
        {
            PageTitle = "Measures";
            Terms = new List<MeasureTermView>();
            terms = t;
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

        public IList<MeasureTermView> Terms { get; }

        public void LoadDetails(MeasureView item)
        {
            Terms.Clear();

            if (item is null) return;
            terms.FixedFilter = GetMember.Name<MeasureTermData>(x => x.MasterId);
            terms.FixedValue = item.Id;
            var list = terms.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                Terms.Add(MeasureTermViewFactory.Create(e));
            }
        }
    }
}
