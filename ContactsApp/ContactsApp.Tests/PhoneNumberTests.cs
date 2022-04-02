using ContactsApp.Exceptions;
using NUnit.Framework;

namespace ContactsApp.Tests;

[TestFixture]
public class PhoneNumberTests
{
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
        // Act
        TestDelegate testDelegate = () => PhoneNumber.Create(value);
        
        //Assert
        Assert.Throws<InvalidValueException>(testDelegate);
    }

    [Test]
    [TestCase(89180000000L)]
    [TestCase(81000030000L)]
    [TestCase(81000032000L)]
    [TestCase(89000032000L)]
    public void PhoneNumber_ValidValue(long expected)
    {
        // Act
        var actual = PhoneNumber.Create(expected);
        
        //Assert
        Assert.AreEqual(expected, actual.Number);
    }
}