using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimcoTest.FilteringFramework
{
    /// <summary>
    /// Implemented by the condition checker.
    /// </summary>
    public interface IObjectTest
    {
        /// <summary>
        /// Tests the specified object to see if it needs to be included in the filtering.
        /// </summary>
        /// <param name="o">Object to be tested</param>
        /// <returns>true if the object is to be included into the filtered result set, false otherwise.</returns>
        bool Test(object o);
    }
}
