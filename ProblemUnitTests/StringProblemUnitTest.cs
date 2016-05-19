using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Problems;

namespace ProblemUnitTests
{   
    [TestClass] 
    public class StringProblemUnitTest
    { 
        [TestMethod]
        public void Test_String_ToInt()
        {
            StringProblem sp = new StringProblem();
            Assert.AreEqual(sp.InterConvertStringToInterger("-1526"), -1526);
        }
    }
}
