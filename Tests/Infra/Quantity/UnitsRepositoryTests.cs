using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Infra;
using VL1.Infra.Quantity;

namespace VL1.Tests.Infra.Quantity
{ 
    [TestClass]
    public class UnitsRepositoryTests: RepositoryTests<UnitsRepository, Unit, UnitData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).Units;
            obj = new UnitsRepository((QuantityDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType() => typeof(UniqueEntityRepository<Unit, UnitData>);

        protected override string getId(UnitData d) => d.Id;

        protected override Unit getObject(UnitData d) => new Unit(d);

        protected override void setId(UnitData d, string id) => d.Id = id;
    }
}
