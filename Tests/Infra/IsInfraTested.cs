using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests.Infra
{
    [TestClass]
   public class IsInfraTested: AssemblyTests
    {
        private const string assembly = "VL1.Infra";

        protected override string Namespace(string name) { return $"{assembly}.{name}"; }

        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(base.Namespace("Infra")); }
    }
}
