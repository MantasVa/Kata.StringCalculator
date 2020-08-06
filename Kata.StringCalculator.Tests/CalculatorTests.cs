using Kata.StringCalculator.Infrastructure.Interfaces;
using System;
using Xunit;

namespace Kata.StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("0",0)]
        [InlineData("5",5)]
        [InlineData("2,5", 7)]
        [InlineData("2,5,7", 14)]
        [InlineData("2,5,7,6", 20)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3,4\n5,6", 21)]
        [InlineData("//;\n1;2",3)]
        [InlineData("//;\n1;2;5", 8)]
        [InlineData("//.\n1.2.8", 11)]
        [InlineData("//a\n1a2", 3)]
        public void Add_ValidArgument_CorrectTotalReturned(string argument, int expected)
        {
           int number = new StringCalculator().Add(argument);

            Assert.Equal(expected, number);
        }

        [Fact]
        public void Add_InvalidArgument_ThrowsException()
        {
            string argument = "//a\n1a-2a-4a-5";
            IStringCalculator calculator = new StringCalculator();

            Assert.Throws<ArgumentException>(() => calculator.Add(argument));
        }

    }
}
