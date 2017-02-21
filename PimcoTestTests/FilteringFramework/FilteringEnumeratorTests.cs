using Microsoft.VisualStudio.TestTools.UnitTesting;
using PimcoTestTests.FilteringFramework;
using System;

namespace PimcoTest.FilteringFramework.Tests
{
    [TestClass()]
    public class FilteringEnumeratorTests
    {
        private IObjectTest numberTest = new IsNumberEvenTest();

        [TestMethod()]
        public void MoveNextFirstCallTest()
        {
            var enumerator = new[] { 2, 4, 6 }.GetEnumerator();
            var filter = new FilteringEnumerator(enumerator, new IsNumberEvenTest());

            Assert.IsTrue(filter.MoveNext());

            // Current element must be 2
            Assert.AreEqual((int)filter.Current, 2);
        }

        [TestMethod()]
        public void IncludesLastOnly()
        {
            var enumerator = new[] { 1, 3, 6 }.GetEnumerator();
            var filter = new FilteringEnumerator(enumerator, new IsNumberEvenTest());

            Assert.IsTrue(filter.MoveNext());

            // Current element must be 6
            Assert.AreEqual((int)filter.Current, 6);
        }

        [TestMethod()]
        public void MoveNextPastEndTests()
        {
            var enumerator = new[] { 2, 4, 6 }.GetEnumerator();
            var filter = new FilteringEnumerator(enumerator, new IsNumberEvenTest());

            Assert.IsTrue(filter.MoveNext());
            Assert.IsTrue(filter.MoveNext());
            Assert.IsTrue(filter.MoveNext());
            Assert.IsFalse(filter.MoveNext());
            Assert.IsFalse(filter.MoveNext());
        }

        [TestMethod()]
        public void LastCurrentThrows()
        {
            var filter = new[] { 2 }.GetEnumerator();
            var exceptionThrown = false;
            try
            {
                Assert.IsTrue(filter.MoveNext());
                Assert.IsFalse(filter.MoveNext());
                var current = filter.Current;
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod()]
        public void ResetTest()
        {
            var enumerator = new[] { 2, 4, 6 }.GetEnumerator();
            var filter = new FilteringEnumerator(enumerator, new IsNumberEvenTest());

            Assert.IsTrue(filter.MoveNext());
            Assert.IsTrue(filter.MoveNext());
            filter.Reset();

            Assert.IsTrue(filter.MoveNext() && (int)filter.Current == 2);
        }
    }
}