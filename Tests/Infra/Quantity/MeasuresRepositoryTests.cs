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
    public class MeasuresRepositoryTests: RepositoryTests<MeasuresRepository, Measure, MeasureData>
    {
        private QuantityDbContext db;
        private int count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            db = new QuantityDbContext(options);
            obj = new MeasuresRepository(db);
            count = GetRandom.UInt8(20, 40);
            CleanDbSet();
            addItems();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanDbSet();
        }

        private void CleanDbSet()
        {
            foreach (var p in db.Measures)
                db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private void addItems()
        {
            for (var i = 0; i < count; i++)
                obj.Add(new Measure(GetRandom.Object<MeasureData>())).GetAwaiter();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<Measure, MeasureData>);
        }

        protected override void testGetList()
        {
            obj.PageIndex = GetRandom.Int32(2, obj.TotalPages - 1);
            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.PageSize, l.Count);
        }

        protected override string getId(MeasureData d)=> d.Id;

        protected override Measure getObject(MeasureData d)=> new Measure(d);

        protected override void setId(MeasureData d, string id) => d.Id = id;
    }
}
