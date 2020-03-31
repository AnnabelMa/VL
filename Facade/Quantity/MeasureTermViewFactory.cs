using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static class MeasureTermViewFactory
    {
        public static MeasureTerm Create(MeasureTermView view)
        {
            var d= new MeasureTermData();
            Copy.Members(view, d);
            return new MeasureTerm(d);
        }

        public static MeasureTermView Create(MeasureTerm obj)
        {
            var v= new MeasureTermView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
