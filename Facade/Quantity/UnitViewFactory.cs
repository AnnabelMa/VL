using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static  class UnitViewFactory
    {
        public static Unit Create(UnitView v) //v-view
        {
            var d = new UnitData();
            Copy.Members(v, d);
           
            return new Unit(d);
        }
        public static UnitView Create(Unit o) //o-object
        {
            var v = new UnitView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            
            return v;
        }
    }
}
