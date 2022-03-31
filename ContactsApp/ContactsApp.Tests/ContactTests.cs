﻿using System;
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
        var expectedDateTime = DateTime.Now;
        var expectedPhoneNumber = 82569234220;
        
        var actualContact = Contact.Create(expectedId, expectedSurname, expectedName, expectedPhoneNumber, expectedDateTime, expectedEmail, expectedIdVk);
        
        Assert.AreEqual(expectedId, actualContact.Id);
        Assert.AreEqual(expectedSurname, actualContact.Surname);
        Assert.AreEqual(expectedName, actualContact.Name);
        Assert.AreEqual(expectedDateTime, actualContact.BirthDay);
        Assert.AreEqual(expectedEmail, actualContact.Email);
        Assert.AreEqual(expectedPhoneNumber, actualContact.PhoneNumber.Number);
        Assert.AreEqual(expectedIdVk, actualContact.IdVk);
    }
    
    [Test]
    [TestCase(-1, "someName", "someSurname", null, null, null)]
    [TestCase(-1, "", "someSurname", null, null, null)]
    [TestCase(-1, "", "", null, null, null)]
    public void Contact_Invalid(int id,string surname, string name, DateTime birthday, string email, string idVk)
    {
        var phoneNumber = 82569234220;
        
        Assert.Catch<AggregateException>(() => Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk));
    }
}