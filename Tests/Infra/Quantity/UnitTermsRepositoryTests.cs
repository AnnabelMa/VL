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
    public class UnitTermsRepositoryTests : RepositoryTests<UnitTermsRepository, UnitTerm, UnitTermData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).UnitTerms;
            obj = new UnitTermsRepository((QuantityDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(PaginatedRepository<UnitTerm, UnitTermData>);
        }
        protected override string getId(UnitTermData d) => $"{d.MasterId}.{d.TermId}";

        protected override UnitTerm getObject(UnitTermData d) => new UnitTerm(d);

        protected override void setId(UnitTermData d, string id)
        {
            var masterId = GetString.Head(id);
            var termId = GetString.Tail(id);
            d.MasterId = masterId;
            d.TermId = termId;
        }
    }
}
