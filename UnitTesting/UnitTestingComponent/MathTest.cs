using System.Runtime.CompilerServices;

namespace UnitTestingComponent
{
    //All test methods should be public,return Void and have the[TestMethod] attribute and no parameters.
    [TestClass]
    public sealed class MathTest
    {
        [TestMethod] //Attribute to indicate that this method is a unit test
        public void AddPositiveNumbersTest()
        {
            //Arrange 
            var component = new UnitTesting.MathClass();
            var num1 = 5;
            var num2 = 10;
            var expected = 15;
            //var expected = num1<0 && num2<0 ? 1 :0;

            //Act 
            var result = component.Addfunc(num1, num2);

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddNegativeNumbersTest()
        {
            var component = new UnitTesting.MathClass();
            var num1 = -5;
            var num2 = -10;
            var expected = -15;
            //Act
            var result = component.Addfunc(num1, num2);
            Assert.AreEqual(expected, result);

            //test for negative numbers 
            //Test for zero
        }

        [TestMethod]
        public void AddZeroNumbersTest()
        {
            var component = new UnitTesting.MathClass();
            var num1 = 5;
            var num2 = 0;
            var expected = 5;

            //Act 
            var result = component.Subfunc(num1, num2);

            Assert.AreEqual(expected, result);

        }
    }
}
