﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Infra;
using VL1.Infra.Quantity;

namespace VL1.Tests.Infra.Quantity
{
    [TestClass]
    public class MeasuresRepositoryTests: RepositoryTests<MeasuresRepository, Measure, MeasureData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<QuantityDbContext>()
                .UseInMemoryDatabase("TestDb")//loob mälus andmebaasi
                .Options;
            db = new QuantityDbContext(options);
            dbSet = ((QuantityDbContext)db).Measures;
            obj = new MeasuresRepository((QuantityDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<Measure, MeasureData>);
        }
        protected override string getId(MeasureData d)=> d.Id;

        protected override Measure getObject(MeasureData d)=> new Measure(d);

        protected override void setId(MeasureData d, string id) => d.Id = id;
    }
}
