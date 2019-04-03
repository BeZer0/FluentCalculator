using NUnit.Framework;

namespace Fluent.Calculator.Test
{
    [TestFixture]
    public class FluentCalculatorTests
    {
        [Test]
        public static void BasicAddition()
        {
            var calculator = new FluentCalculator();
            Assert.AreEqual(3, calculator.One.Plus.Two.Result());
            Assert.AreEqual(19, calculator.Ten.Plus.Nine.Result());
            Assert.AreEqual(8, calculator.Five.Plus.Three.Result());
            Assert.AreEqual(12, calculator.Four.Plus.Eight.Result());
        }

        [Test]
        public static void MultipleInstances()
        {
            var calculatorOne = new FluentCalculator();
            var calculatorTwo = new FluentCalculator();
            Assert.AreNotEqual((double)calculatorOne.Five.Plus.Five, (double)calculatorTwo.Seven.Times.Three);
        }

        [Test]
        public static void MultipleCalls()
        {
            //Testing that the expression or reference clears between calls
            var calculator = new FluentCalculator();
            Assert.AreEqual(4, calculator.One.Plus.One.Result() + calculator.One.Plus.One.Result());
            Assert.AreEqual(64, 2 * calculator.Two.Times.Two * 2 * calculator.Two.Times.Two);
        }

        [Test]
        public static void AllOperators()
        {
            var calculator = new FluentCalculator();
            Assert.AreEqual(10, (double)calculator.Seven.Times.Six.DividedBy.Three.Minus.Four);
        }

        [Test]
        public static void Bedmas()
        {
            //Testing Order of Operations
            var calculator = new FluentCalculator();
            Assert.AreEqual(58, (double)calculator.Six.Times.Six.Plus.Eight.DividedBy.Two.Times.Two.Plus.Ten.Times.Four.DividedBy.Two.Minus.Six);
            Assert.AreEqual(-11.972, calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine, 0.01);
        }

        [Test]
        public static void StaticCombinationCalls()
        {
            //Testing Implicit Conversions
            var calculator = new FluentCalculator();
            Assert.AreEqual(5, calculator.Seven.Times.Six.DividedBy.Three.Minus.Four - 5);
            Assert.AreEqual(177.5, 10 * calculator.Six.Plus.Four.Times.Three.Minus.Two.DividedBy.Eight.Times.One.Minus.Five.Times.Zero);
            Assert.AreEqual(8, 5 + calculator.Eight.Times.Four.Times.Zero.Minus.Two.Plus.Eight.Result() / 2);
        }
    }
}