using System.Collections;

namespace PimcoTest.FilteringFramework
{
    public sealed class FilteringEnumerator : IEnumerator
    {
        private readonly IEnumerator enumerator;
        private readonly IObjectTest objectTest;

        /// <summary>
        /// Constructs the filtered enumerator
        /// </summary>
        /// <param name="enumerator">Original enumerator to filter.</param>
        /// <param name="objectTest">Test to perform on each object.</param>
        public FilteringEnumerator(IEnumerator enumerator, IObjectTest objectTest)
        {
            this.enumerator = enumerator;
            this.objectTest = objectTest;
        }

        public object Current
        {
            get
            {
                return enumerator.Current;
            }
        }

        public bool MoveNext()
        {
            return TryFindingNextPassing();
        }

        public void Reset()
        {
            enumerator.Reset();
        }

        private bool TryFindingNextPassing()
        {
            while (enumerator.MoveNext())
            {
                if (objectTest.Test(enumerator.Current))
                {
                    return true;
                }                    
            }

            // End of the original iterator, and no more matching elements
            return false;
        }
    }
}
