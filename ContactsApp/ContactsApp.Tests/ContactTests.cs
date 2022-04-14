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
    [TestCase(-1, "someName", "someSurname", null, null, null)]
    [TestCase(1, "", "someSurname", null, null, null)]
    [TestCase(1, "", "", null, null, null)]
    [TestCase(1, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", "", null, null, null)]
    [TestCase(1, "", "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", null, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", null)]
    [TestCase(1, "", "", null, null, null)]
    [TestCase(1, "", "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", null, null, "sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
    public void Contact_Invalid(int id,string surname, string name, DateTime birthday, string email, string idVk)
    {
        // Setup
        var phoneNumber = 82569234220;

        //Act
        TestDelegate testDelegate = () => Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);
        
        // Assert
        Assert.Catch<AggregateException>(testDelegate);
    }
}