﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Common;
using VL1.Domain.Common;

namespace VL1.Tests.Infra
{
    [TestClass]
    public abstract class RepositoryTests<TRepository, TObject, TData> :
        BaseTests
    where TRepository: IRepository<TObject>
    where TObject: Entity<TData>
    where TData: PeriodData, new()
    {
        private TData data;
        protected TRepository obj;

        public virtual void TestInitialize()
        {
            type =typeof(TRepository);
            data = GetRandom.Object<TData>();
        }

        [TestMethod]
        public void IsSealed() => Assert.IsTrue(type.IsSealed);

        [TestMethod]
        public void IsInherited()=> Assert.AreEqual(getBaseType().Name,type?.BaseType?.Name);

        protected abstract Type getBaseType();

        [TestMethod]
        public void GetTest()=>testGetList();

        protected abstract void testGetList();

        [TestMethod]
        public void GetByIdTest()=>AddTest();

        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var id = getId(data);
            var expected = obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(data, expected.Data);
            obj.Delete(id).GetAwaiter();
            expected = obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        protected abstract string getId(TData d);

        [TestMethod]
        public void AddTest()
        {
            var id = getId(data);
            var expected = obj.Get(id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            obj.Add(getObject(data)).GetAwaiter();
            expected = obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(data, expected.Data);
        }

        protected abstract TObject getObject(TData d);

        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var id = getId(data);
            var newData = GetRandom.Object<TData>();
            setId(newData, id);
            obj.Update(getObject(newData)).GetAwaiter();
            var expected = obj.Get(id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData, expected.Data);
        }
        protected abstract void setId(TData d, string id);
    }
}