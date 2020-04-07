using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Infra;
using VL1.Infra.Quantity;

namespace VL1.Tests.Infra.Quantity
{
    [TestClass]
    public class UnitFactorsRepositoryTests : RepositoryTests<UnitFactorsRepository, UnitFactor, UnitFactorData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).UnitFactors;
            obj = new UnitFactorsRepository((QuantityDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(PaginatedRepository<UnitFactor, UnitFactorData>);
        }
        protected override string getId(UnitFactorData d) => $"{d.SystemOfUnitsId}.{d.UnitId}";

        protected override UnitFactor getObject(UnitFactorData d) => new UnitFactor(d);

        protected override void setId(UnitFactorData d, string id)
        {
            var systemOfUnitsId = GetString.Head(id);
            var unitId = GetString.Tail(id);
            d.SystemOfUnitsId = systemOfUnitsId;
            d.UnitId = unitId;
        }
    }
}
