using PimcoTest.FilteringFramework;
using System.Collections;

namespace PimcoTest.Tests
{
    internal sealed class FilteringEnumerable : IEnumerable
    {
        private readonly IEnumerable originalEnumerable;
        private readonly IObjectTest objectTest;

        public FilteringEnumerable(IEnumerable originalEnumerable, IObjectTest objectTest)
        {
            this.originalEnumerable = originalEnumerable;
            this.objectTest = objectTest;
        }

        public IEnumerator GetEnumerator()
        {
            return new FilteringEnumerator(originalEnumerable.GetEnumerator(), objectTest);
        }
    }
}
