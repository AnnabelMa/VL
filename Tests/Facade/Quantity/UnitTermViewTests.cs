using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitTermViewTests : SealedClassTests<UnitTermView, CommonTermView>
    {
        [TestMethod]
        public void MasterIdTest() =>
            IsNullableProperty(() => obj.MasterId, x => obj.MasterId = x);
    }
}
