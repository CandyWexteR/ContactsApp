using System;
using System.Linq;
using ContactsApp.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ContactsApp.Tests;

[TestFixture]
public class ContactTests
{
    
    [Test]
    [TestCase(1, "someName", "someSurname", null, null)]
    public void Contact_Valid(int expectedId,string expectedSurname, string expectedName, string expectedEmail, string expectedIdVk)
    {
        // Setup
        var expectedDateTime = DateTime.Now;
        var expectedPhoneNumber = 82569234220;
        
        // Act
        var actual = Contact.Create(expectedId, expectedSurname, expectedName, expectedPhoneNumber, expectedDateTime, 
            expectedEmail, expectedIdVk);
        
        // Assert
        Assert.AreEqual(expectedId, actual.Id);
        Assert.AreEqual(expectedSurname, actual.Surname);
        Assert.AreEqual(expectedName, actual.Name);
        Assert.AreEqual(expectedDateTime, actual.BirthDay);
        Assert.AreEqual(expectedEmail, actual.Email);
        Assert.AreEqual(expectedPhoneNumber, actual.PhoneNumber.Number);
        Assert.AreEqual(expectedIdVk, actual.IdVk);
    }
    
    [Test]
    [TestCase(-1, "someName", "someSurname", 82569234220, null,  null)]
    [TestCase(1, "", "someSurname", 82569234220,  null, null)]
    [TestCase(1, "", "someSurname", 82569234220,  "asd@msdasd", null)]
    [TestCase(1, "", "", 82569234220, null,  null)]
    [TestCase(1, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", "", 82569234220, null, null)]
    [TestCase(1, "", "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", 82569234220, null, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
    [TestCase(1, "", "", 82569234220, null,  null)]
    [TestCase(1, "", "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", 82569234220, null, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
    [TestCase(1, "", "sdsdsd", 82569232224220, null,  "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
    [TestCase(1, "", "sdsdsd", 82569232224220, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", null)]
    public void Contact_Invalid(int id,string surname, string name, long phoneNumber, string email, string idVk)
    {
        //Setup
        var invalidDate = DateTime.Now.AddMonths(1);
        
        //Act
        TestDelegate testDelegate = () => Contact.Create(id, surname, name, phoneNumber, invalidDate, email, idVk);
        
        // Assert
        Assert.Catch<AggregateException>(testDelegate);
    }
}