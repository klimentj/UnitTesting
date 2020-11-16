using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.UnitTesting.Tests
{
    [TestFixture]
    public class BoolMethodsTests
    {
        [Test]
        public void IsLeapYear_YearIsLeap_TheResultShouldBeTrue()
        {
            //arrange
            var bm = new BoolMethods();
            var year = 1996;

            //act
            var result = bm.IsLeapYear(year);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsLeapYear_YearIsNotLeap_TheResultShouldBeFalse()
        {
            //arrange
            var bm = new BoolMethods();
            var year = 1997;

            //act
            var result = bm.IsLeapYear(year);

            //assert
            Assert.IsFalse(result);
        }
        [Test]
        public void IsLeapYear_YearIsZero_ShouldThrowException()
        {
            //arrange
            var bm = new BoolMethods();
            var year = 0;

            //act
            //assert
            Assert.Catch<Exception>(() => bm.IsLeapYear(year));
        }

        [Test]
        public void IsLeapYear_YearIsZero_ShouldThrowArgumentException()
        {
            //arrange
            var bm = new BoolMethods();
            var year = 0;

            //act
            //assert
            Assert.Throws<ArgumentException>(() => bm.IsLeapYear(year));
        }

        [Test,Sequential]
        public void IsLeapYear_SequentialValuesYear_TheResultShouldBeCorrect([Values(1996,1997,1998)] int year,[Values(true,false,false)] bool expectedResult)
        {
            //arrange
            var bm = new BoolMethods();

            //act
            var result = bm.IsLeapYear(year);
            //assert
            Assert.AreEqual(result, expectedResult);
        }

    }
}
