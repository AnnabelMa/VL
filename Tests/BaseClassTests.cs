using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;

namespace VL1.Tests
{
    public abstract class BaseClassTests<TClass, TBaseClass>: BaseTests
    {
        protected TClass obj;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);
        }
        [TestMethod]
        public void InheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), type.BaseType);
        }
        protected static void IsNullableProperty<T>(Func<T> get, Action<T> set)
        {
            IsProperty(get, set);
            set(default);
            Assert.IsNull(get());
        }

        protected static void IsNullableProperty(object o, string name, Type type)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.AreEqual(type, property.PropertyType);
            Assert.IsTrue(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            property.SetValue(o, null);
            var actual = property.GetValue(o);
            Assert.AreEqual(null, actual);
        }

        protected static void IsProperty<T>(Func<T> get, Action<T> set) //kontrollib, kas saan võtta juhusliku värtuse ja sellega testida
        {
            var d = (T)GetRandom.Value(typeof(T));
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected static void IsPropertyTypeOf(object o, string name, Type expected)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.AreEqual(expected, property.PropertyType);
        }
        protected static void isReadOnlyProperty(object o, string name, object expected)
        {//kui objekt on olemas, objekti järgi saan nime ja property.
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            var actual = property.GetValue(o);
            Assert.AreEqual(expected, actual);
        }
    }
}