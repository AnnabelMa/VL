using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Common;
using VL1.Facade.Quantity;
using VL1.Tests.Facade.Common;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class CommonTermViewTests: AbstractClassTests<CommonTermView, PeriodView>
    {
        private class testClass : CommonTermView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void TermIdTest() => IsNullableProperty(
            () => obj.TermId, x => obj.TermId = x);
        [TestMethod]
        public void PowerTest() => IsProperty(
            () => obj.Power, x => obj.Power = x);
    }
}
