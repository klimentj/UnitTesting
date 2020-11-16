using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.UnitTesting.Tests
{
    [TestFixture]
    public class IntegerMethodsTests
    {
        [Test]
        public void IntegerMethods_GivenListWithValue_ShouldReturnCorrectResult()
        {
            //Arrange
            var im = new IntegerMethods();
            var listNumber = new List<int> { 1, 2, 3, 4, 5 };
            var nthLargestNumber = 2;
            var expectedResult = 4;

            //Act
            var result = im.FindNthLargestNumber(listNumber, nthLargestNumber);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IntegerMethods_GivenEmptyList_ShouldReturnException()
        {
            //arrange
            var im = new IntegerMethods();
            var list = new List<int>();
            //act
            //assert
            Assert.Catch<Exception>(() => im.FindNthLargestNumber(list, 2));
        }
    }
}
