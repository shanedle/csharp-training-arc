using Xunit;

namespace CalculationLibrary.Tests
{
    public class CalculationsTest
    {
        [Theory]
        [InlineData(5,5,10)]
        public void AddShouldReturnExpectedValue(double x, double y, double expected)
        {
            // arrange
            Calculations calc = new Calculations();

            // act
            double actual = calc.Add(x, y);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15, 5, 10)]
        public void SubtractShouldReturnExpectedValue(double x, double y, double expected)
        {
            // arrange
            Calculations calc = new Calculations();

            // act
            double actual = calc.Subtract(x, y);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 5, 25)]
        public void MultiplyShouldReturnExpectedValue(double x, double y, double expected)
        {
            // arrange
            Calculations calc = new Calculations();

            // act
            double actual = calc.Multiply(x, y);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 0, 0)]
        public void DivideShouldReturnExpectedValue(double x, double y, double expected)
        {
            // arrange
            Calculations calc = new Calculations();

            // act
            double actual = calc.Divide(x, y);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
