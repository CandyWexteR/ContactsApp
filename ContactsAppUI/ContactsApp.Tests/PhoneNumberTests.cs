using ContactsApp.Exceptions;
using NUnit.Framework;

namespace ContactsApp.Tests;

public class PhoneNumberTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(10000)]
    [TestCase(100000)]
    [TestCase(1000000)]
    [TestCase(10000000)]
    [TestCase(100000000)]
    [TestCase(1000000000)]
    [TestCase(100000000000L)]
    [TestCase(10000000000000L)]
    public void PhoneNumber_InvalidValue(long value)
    {
        if (value is < 10000000000 or >= 100000000000)
        {
            Assert.Throws<InvalidValueException>(() => PhoneNumber.Create(value),
                $"Неправильное значение номера телефона " +
                $"({nameof(PhoneNumber)}).");
            return;
        }

        Assert.Fail("Значение НЕ должно быть в диапазоне от 10000000000 до 100000000000");
    }

    [Test]
    [TestCase(10000000000L)]
    [TestCase(10000300000L)]
    [TestCase(10000320000L)]
    [TestCase(90000320000L)]
    public void PhoneNumber_ValidValue(long value)
    {
        if (value is < 10000000000 or >= 100000000000)
        {
            Assert.Fail("Значение НЕ должно быть в диапазоне от 10000000000 до 100000000000");
            return;
        }

        var number = PhoneNumber.Create(value);
        
        Assert.AreEqual(value, number.Number);
    }
}