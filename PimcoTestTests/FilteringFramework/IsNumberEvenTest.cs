using PimcoTest.FilteringFramework;

namespace PimcoTestTests.FilteringFramework
{
    internal sealed class IsNumberEvenTest : IObjectTest
    {
        public bool Test(object o)
        {
            return (o is int) && (int)o % 2 == 0;
        }
    }
}
