using NUnit.Framework;
using Romans2;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(3000, "MMM")]
        [TestCase(2000, "MM")]
        [TestCase(1500, "MD")]
        [TestCase(1000, "M")]
        [TestCase(600, "DC")]
        [TestCase(500, "D")]
        [TestCase(400, "CD")]
        [TestCase(300, "CCC")]
        [TestCase(200, "CC")]
        [TestCase(100, "C")]
        [TestCase(50, "L")]
        [TestCase(49, "XLIX")]
        [TestCase(45, "XLV")]
        [TestCase(40, "XL")]
        [TestCase(30, "XXX")]
        [TestCase(20, "XX")]
        [TestCase(19, "XIX")]
        [TestCase(15, "XV")]
        [TestCase(11, "XI")]
        [TestCase(10, "X")]
        [TestCase(9, "IX")]
        [TestCase(8, "VIII")]
        [TestCase(5, "V")]
        [TestCase(4, "IV")]
        [TestCase(3, "III")]
        [TestCase(2, "II")]
        [TestCase(1, "I")]
        [TestCase(0, "")]
        public void ToArabic_PositiveValue_ReturnedExpectedValue(int value, string expected)
        {
            var actual = Convert.ToArabic(value);
            Assert.AreEqual(expected, actual);
        }
    }
}