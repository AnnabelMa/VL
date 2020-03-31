using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
   public class SystemOfUnitsViewFactoryTests: BaseTests
   {
   [TestInitialize]
   public virtual void TestInitialize()
   {
       type = typeof(SystemOfUnitsViewFactory);
   }
   [TestMethod]
   public void CreateTest() { }

   [TestMethod]
   public void CreateObjectTest()
   {
       var view = GetRandom.Object<SystemOfUnitsView>();
       var data = SystemOfUnitsViewFactory.Create(view).Data;

       TestArePropertyValuesEqual(view, data);
   }
   [TestMethod]
   public void CreateViewTest()
   {
       var data = GetRandom.Object<SystemOfUnitsData>();
       var view = SystemOfUnitsViewFactory.Create(new SystemOfUnits(data));

       TestArePropertyValuesEqual(view, data);
   }
   }
}
