using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Common;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitFactorViewTests: SealedClassTests<UnitFactorView, PeriodView>
    {
        [TestMethod]
        public void UnitIdTest() =>
            IsNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        [TestMethod]
        public void SystemOfUnitsIdTest() => 
            IsNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);
        [TestMethod]
        public void FactorTest() => 
            IsProperty(() => obj.Factor, x => obj.Factor = x);
    }
}
