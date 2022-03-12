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
    [TestCase(1000000000000)]
    public void PhoneNumber_InvalidValue(long value)
    {
        if (value is < 800000000000 or >= 900000000000)
        {
            Assert.Throws<InvalidValueException>(() => PhoneNumber.Create(value),
                $"Неправильное значение номера телефона " +
                $"({nameof(PhoneNumber)}).");
            return;
        }

        Assert.Fail("Значение НЕ должно быть в диапазоне от 10000000000 до 100000000000");
    }

    [Test]
    [TestCase(89180000000L)]
    [TestCase(81000030000L)]
    [TestCase(81000032000L)]
    [TestCase(89000032000L)]
    public void PhoneNumber_ValidValue(long value)
    {
        Assert.GreaterOrEqual(value, 80000000000);
        Assert.Less(value, 90000000000);

        var number = PhoneNumber.Create(value);
        
        Assert.AreEqual(value, number.Number);
    }
}