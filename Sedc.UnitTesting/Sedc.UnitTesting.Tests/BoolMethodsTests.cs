using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

        [TestCase(1996,true)]
        [TestCase(1997, false)]
        [TestCase(1998, false)]
        [TestCase(1999, false)]
        [TestCase(2000, true)]
        public void IsLeapYear_WithGivenTestCases_TheResultShouldBeCorrect(int year, bool expectedResult)
        {
            //arrange
            var bm = new BoolMethods();
            //act
            var result = bm.IsLeapYear(year);
            //assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestCase(1996, ExpectedResult = true)]
        [TestCase(1997, ExpectedResult = false)]
        [TestCase(1998, ExpectedResult = false)]
        [TestCase(1999, ExpectedResult = false)]
        [TestCase(2000, ExpectedResult = true)]
        public bool IsLeapYear_WithGivenTestCasesExpectedResult_TheResultShouldBeCorrect(int year)
        {
            //arrange
            var bm = new BoolMethods();
            //assert
            return bm.IsLeapYear(year);
        }

        [TestCaseSource(typeof(BoolCaseData),"TestCases")]
        public void IsLeapYear_WithGivenTestCasesSourceClass_TheResultShouldBeCorrect(int year, bool expectedResult)
        {
            //arrange
            var bm = new BoolMethods();
            //act
            var result = bm.IsLeapYear(year);
            //assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestCaseSource("CsvData")]
        public bool IsLeapYear_WithGivenTestCasesInCSVFile_TheResultShouldBeCorrect(int year)
        {
            //arrange
            var bm = new BoolMethods();
            //assert
            return bm.IsLeapYear(year);
        }

        public static List<TestCaseData> CsvData
        {
            get
            {
                var testCases = new List<TestCaseData>();

                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"04/test.csv");

                using (var fs = File.OpenRead(path))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            int year = Convert.ToInt32(split[0]);
                            bool expected = Convert.ToBoolean(split[1]);

                            var testCase = new TestCaseData(year).Returns(expected);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
    }
}
