using System;
using System.Collections.Generic;
using System.Text;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;

namespace VL1.Facade.Quantity
{
    public static class UnitTermViewFactory
    {
        public static UnitTerm Create(UnitTermView view)
        {
            var d= new UnitTermData();
            Copy.Members(view, d);
            return new UnitTerm(d);
        }

        public static UnitTermView Create(UnitTerm obj)
        {
            var v= new UnitTermView();
            Copy.Members(obj.Data,v);
            return v;
        }
    }
}
