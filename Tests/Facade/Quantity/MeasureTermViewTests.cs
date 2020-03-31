using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class MeasureTermViewTests: SealedClassTests<MeasureTermView, CommonTermView>
    {
        [TestMethod]
        public void MasterIdTest() =>
            IsNullableProperty(() => obj.MasterId, x => obj.MasterId = x);
    }
}
