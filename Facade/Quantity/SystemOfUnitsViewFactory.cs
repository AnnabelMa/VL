using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static class SystemOfUnitsViewFactory
    {
        public static SystemOfUnits Create(SystemOfUnitsView view)
        {
            var d= new SystemOfUnitsData();
            Copy.Members(view, d);
            return new SystemOfUnits(d);
        }

        public static SystemOfUnitsView Create(SystemOfUnits obj)
        {
            var v = new SystemOfUnitsView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
