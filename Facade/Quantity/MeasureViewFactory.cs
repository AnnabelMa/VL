using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static class MeasureViewFactory
    {
        public static Measure Create(MeasureView v) //v-view
        {
            var d = new MeasureData();
            Copy.Members(v,d);

            return new Measure(d);
        }
        public static MeasureView Create(Measure o) //o-object
        {
            var v = new MeasureView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        }
    }
}
