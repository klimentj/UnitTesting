using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.UnitTesting.Tests
{
    [TestFixture]
    public class StringMethodsTest
    {
        [SetUp]
        public void Init()
        {

        }

        [Test]
        [Repeat(2)]
        public void Reverse_StringNotEmpty_ResultShouldBeAsExpected()
        {
            //arrange
            var sm = new StringMethods();
            var str = "SEDC";
            var expectedResult = "CDES";

            //act
            var result = sm.Reverse(str);
            
            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [Author("Kliment")]
        [Ignore("Reverse method should be refactored")]
        public void Reverse_StringNull_ShouldThrowException()
        {
            //arrange
            var sm = new StringMethods();
            string str = null;
            
            //act            
            //assert
            Assert.Catch<Exception>(() => sm.Reverse(str));
        }

        [Test]
        [MaxTime(15000)]
        [Category("ReverseLong")]
        public void ReverseLong_StringNotEmpty_ResultShouldBeAsExpected()
        {
            //arrange
            var sm = new StringMethods();
            var str = "SEDC";
            var expectedResult = "CDES";

            //act
            var result = sm.ReverseLong(str);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
