using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
   public static class UnitFactorViewFactory
    {
        public static UnitFactor Create(UnitFactorView view)
        {
            var d = new UnitFactorData();
            Copy.Members(view, d);
            return new UnitFactor(d);
        }

        public static UnitFactorView Create(UnitFactor obj)
        {
            var v= new UnitFactorView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
