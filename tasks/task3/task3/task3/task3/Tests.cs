using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task3
{
    [TestFixture]
    class Testprogram
    {
        [Test]
        public void test(){
            int a = 1;
            int b = 1;
            Assert.IsTrue(a == b);
        }
    }
}
