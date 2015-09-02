using StringCalculatorKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorKataTests
{
    [TestClass]
    public class StringCalculatorKataTests
    {
        private StringCalculator calculator;

        [TestInitialize]
        public void SetUp()
        {
            calculator = new StringCalculator();
        }

        [TestMethod]
        public void EmptyStringInputReturnsZero()
        {
            Assert.AreEqual(0, calculator.Add(""));
        }

        [TestMethod]
        public void OneAsInputStringForOutputOne()
        {
            Assert.AreEqual(1, calculator.Add("1"));
        }

        [TestMethod]
        public void TwoInputsOfThreeAndFourToOutputSeven()
        {
            Assert.AreEqual(7, calculator.Add("3,4"));
        }

        [TestMethod]
        public void FiveInputsOfAllOnesThatOutputFive()
        {
            Assert.AreEqual(5, calculator.Add("1,1,1,1,1"));
        }

        [TestMethod]
        public void FiveInputsOfAllTensThatOutputFifty()
        {
            Assert.AreEqual(50, calculator.Add("10,10,10,10,10"));
        }

        [TestMethod]
        public void TwoInputsOfOnesWithNewlineDelimiter()
        {
            Assert.AreEqual(2, calculator.Add("1\n1"));
        }

        [TestMethod]
        public void SetDelimiterToSemicolonWithNormalListThatEqualsSeven()
        {
            Assert.AreEqual(10, calculator.Add("//;\n3;7"));
        }

        [TestMethod]
        public void SetDelimiterToMultiCharLengthWithNormalListThatEqualsSeven()
        {
            Assert.AreEqual(10, calculator.Add("//:)\n3:)7"));
        }

        [TestMethod]
        public void NegativesNotAllowedExceptionThrownWithNegativeInInputString()
        {
            try
            {
                calculator.Add("//;\n3;-7");
            }
            catch (StringCalculator.NegativesNotAllowedException exception)
            {
                Assert.AreEqual("negatives not allowed: -7 ", exception.Message);
            }
        }

        [TestMethod]
        public void NegativesNotAllowedExceptionThrownWithMultipleNegativeInInputString()
        {
            try
            {
                calculator.Add("//;\n-3;-7;-89");
            }
            catch (StringCalculator.NegativesNotAllowedException exception)
            {
                Assert.AreEqual("negatives not allowed: -3 -7 -89 ", exception.Message);
            }
        }

        [TestMethod]
        public void SingleNumberLargerThanAThousandAndTwoReturnsTwo()
        {
            Assert.AreEqual(2, calculator.Add("//;\n2;9001"));
        }

        [TestMethod]
        public void MultipleNumberLargerThanAThousandAndTwoReturnsTwo()
        {
            Assert.AreEqual(2, calculator.Add("//;\n2;9001;1001"));
        }

        [TestMethod]
        public void OnlyNumbersLargerThanOneThousandThatReturnsZero()
        {
            Assert.AreEqual(0, calculator.Add("//;\n9001;1001"));
        }

        [TestMethod]
        public void SetDelimiterToLengthFIveWithNormalListThatEqualsSeven()
        {
            Assert.AreEqual(7, calculator.Add("//:):(t\n2:):(t2:):(t3"));
        }

        [TestMethod]
        public void SetMultipleDelimitersForNormalListThatEqualsSeven()
        {
            Assert.AreEqual(7, calculator.Add("//[ლ(ಠ益ಠლ)][(ノಠ益ಠ)ノ彡]\n2(ノಠ益ಠ)ノ彡4ლ(ಠ益ಠლ)1"));
        }

        [TestMethod]
        public void SetCustomBracketDelimiterForNormalListThatEqualsTen()
        {
            Assert.AreEqual(10, calculator.Add("//[\n3[7"));
        }

        [TestMethod]
        public void CustomDelimiterBracketInBracketString()
        {
            Assert.AreEqual(10, calculator.Add("//[]]\n3[]]7"));
        }

        [TestMethod]
        public void DelimitersAsBracketsUsingCustomBracketNotation()
        {
            Assert.AreEqual(10, calculator.Add("//[[][]][[][]]\n4[1]4[1"));
        }

        [TestMethod]
        public void DelimitersAsBracketsUsingCustomBracketNotationForMoreThanThreeDelimiters()
        {
            Assert.AreEqual(10, calculator.Add("//[[][]][a][[a]\n4[1]3a1[a1"));
        }
    }
}
