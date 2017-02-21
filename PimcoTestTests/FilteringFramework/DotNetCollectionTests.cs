using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PimcoTest.Tests;
using System.Collections.Generic;

namespace PimcoTestTests.FilteringFramework
{
    [TestClass]
    public class FrameworkCollectionTests
    {
        [TestMethod]
        public void GetEvenNumbers()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            var resultingList = new FilteringEnumerable(numbers, new IsNumberEvenTest())
                .OfType<int>()
                .ToList();

            Assert.IsTrue(resultingList.Count == 2 && resultingList[0] == 2 && resultingList[1] == 4);
        }

        [TestMethod]
        public void TestEmptyCollection()
        {
            var numbers = new int[] { };

            foreach (var num in new FilteringEnumerable(numbers, new IsNumberEvenTest()))
            {
                // We have no business here
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestAllOdds()
        {
            var numbers = new int[] { 1, 3, 5, 7 };

            foreach (var num in new FilteringEnumerable(numbers, new IsNumberEvenTest()))
            {
                // We have no business here, fail the test
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestAllEvens()
        {
            var numbers = new int[] { 2, 4, 6 };
            List<int> resultingList = new List<int>();

            // We test on purpose with foreach here
            foreach (var num in new FilteringEnumerable(numbers, new IsNumberEvenTest()))
            {
                resultingList.Add((int)num);
            }

            Assert.IsTrue(resultingList.Count == 3 && resultingList[0] == 2 && resultingList[1] == 4 && resultingList[2] == 6);
        }
    }
}
