using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.UnitTesting.Tests
{
    [TestFixture]
    public class IntegerMetehodTestSetupOneTime
    {
        IntegerMethods im;
        List<int> listNumber;

        [OneTimeSetUp]
        public void Init()
        {
            im = new IntegerMethods();
            listNumber = new List<int>();
        }

        [TearDown]
        public void TearDown()
        {
            listNumber.Clear();
        }

        [Test]
        [Order(1)]
        public void IntegerMethods_GivenListWithValue_ShouldReturnCorrectResult()
        {
            //Arrange            
            listNumber = new List<int> { 1, 2, 3, 4, 5 };
            var nthLargestNumber = 2;
            var expectedResult = 4;

            //Act
            var result = im.FindNthLargestNumber(listNumber, nthLargestNumber);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [Order(2)]
        public void IntegerMethods_GivenEmptyList_ShouldReturnException()
        {
            //arrange                        
            //act
            //assert
            Assert.Catch<Exception>(() => im.FindNthLargestNumber(listNumber, 2));
        }
    }
}
