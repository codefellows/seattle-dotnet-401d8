using System;
using Xunit;
using d8Day2Demo;

namespace FizzBuzzTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanReturn1()
        {
            Assert.Equal("1", Program.FizzBuzz(1));

        }

        [Fact]
        public void CanReturn2()
        {
            Assert.Equal("2", Program.FizzBuzz(2));

        }

        [Fact]
        public void CanReturnFizzfor3()
        {
            Assert.Equal("Fizz", Program.FizzBuzz(3));
        }

        [Fact]
        public void CanReturnBuzzfor5()
        {
            Assert.Equal("Buzz", Program.FizzBuzz(5));

        }

        [Fact]
        public void CanReturnFizzFor6()
        {
            Assert.Equal("Fizz", Program.FizzBuzz(6));

        }

        [Theory]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(21)]
        public void CanReturnFizzForAllDivisibleBy3(int number)
        {
            Assert.Equal("Fizz", Program.FizzBuzz(number));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void CanReturnBuzzForAllDivisibleBy5(int number)
        {
            Assert.Equal("Buzz", Program.FizzBuzz(number));

        }

        [Fact]
        public void CanReturnFizzBuzzFor15()
        {
            Assert.Equal("FizzBuzz", Program.FizzBuzz(15));
        }

        [Theory]
        [InlineData("Fizz", 3)]
        [InlineData("Fizz", 6)]
        [InlineData("Fizz", 9)]
        [InlineData("Buzz", 5)]
        [InlineData("Buzz", 10)]
        [InlineData("Buzz", 20)]
        [InlineData("FizzBuzz", 15)]
        [InlineData("FizzBuzz", 30)]
        [InlineData("FizzBuzz", 45)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("97", 97)]
        public void CanPlayFizzBuzzGame(string expected, int number)
        {
            Assert.Equal(expected, Program.FizzBuzz(number));
        }
    }
}
