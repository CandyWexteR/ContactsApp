using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ContactsApp.Exceptions;
using NUnit.Framework;

namespace ContactsApp.Tests;

[TestFixture]
public class ProjectTests
{
    private Project _project;
    private DateTime _date;

    [SetUp]
    public void SetUp()
    {
        _date = DateTime.Now;
    }

    [Test]
    [TestCase("SuRName", "Naaameee")]
    public void Project_AddFirstOnly(string surname, string name)
    {
        _project = new Project(new List<Contact>());
        var number = 87485746352L;
        _project.AddContact(surname, name, number, _date, null, null);

        AssertContact(0, surname, name, number, _date, null, null);
    }

    [Test]
    [TestCase(3, "SuRRRnaaameEEE", "Nameeeeee", null, null, null)]
    public void Project_AddSecondOrGreater(int currentListItemsCount, string surname, string name, DateTime date, string email, string idVk)
    {
        _project = new Project(new List<Contact>());
        for (int i = 0; i < currentListItemsCount; i++)
        {
            _project.AddContact("surname" + i, "name" + i, 86467462364, date, email, idVk);
        }

        var number = 87485746352;
        _project.AddContact(surname, name, number, date, email, idVk);

        AssertContact(currentListItemsCount, surname, name, number, date, email, idVk);
    }

    [Test]
    [TestCase(3)]
    public void ExistingContactsAssers(int count)
    {
        var list = new List<Contact>();
        var number = 87485746352;
        
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        for (var i = 0; i < count; i++)
        {
            AssertContact(i, $"Surname {i}", $"Name {i}", number, _date, null, null);
        }
    }

    [Test]
    [TestCase(3, 2)]
    public void ContactRemove_Valid(int count, int removingIndex)
    {
        Assert.Positive(count);
        Assert.Positive(removingIndex);
        Assert.Greater(count, removingIndex);

        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        Assert.DoesNotThrow(() => _project.RemoveContact(removingIndex));
    }

    [Test]
    [TestCase(3, 4)]
    public void ContactRemove_InvalidId(int count, int removingIndex)
    {
        Assert.Positive(count);
        Assert.Positive(removingIndex);
        Assert.GreaterOrEqual(removingIndex, count);

        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        Assert.Throws<InvalidEditOperationException>(() => _project.RemoveContact(removingIndex));
    }

    [Test]
    [TestCase(3)]
    public void ContactRemove_InvalidId(int removingIndex)
    {
        Assert.Positive(removingIndex);

        _project = new Project(new List<Contact>());

        Assert.Throws<InvalidEditOperationException>(() => _project.RemoveContact(removingIndex));
    }

    [Test]
    [TestCase(2, 1, "2332", "2323", "mail@example.com", "232323", null)]
    public void ContactEdit_Valid(int count, int id, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        Assert.Positive(count);
        Assert.Positive(id);
        Assert.Greater(count, id);

        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        _project.EditContact(id, surname, name, number, birthday, email, idVk);
        
        AssertContact(id, surname, name, number, birthday, email, idVk);
    }

    [Test]
    [TestCase(1, 2, "132", "321", "2323", "323", null)]
    public void ContactEdit_Invalid(int count, int index, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        Assert.Positive(count);
        Assert.Positive(index);
        Assert.Greater(index, count);

        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        Assert.Throws<InvalidEditOperationException>(() => _project.EditContact(index, surname, name, number, birthday, email, idVk));
    }

    private void AssertContact(int id, string surname, string name, long phoneNumber, DateTime birthday,
        string email, string idVk)
    {
        var contact = _project.GetContact(id);
        if(contact is null)
            Assert.Fail();
        
        Assert.AreEqual(email, contact.Email);
        Assert.AreEqual(idVk, contact.IdVk);
        Assert.AreEqual(birthday, contact.BirthDay);
        Assert.AreEqual(id, contact.Id);
        Assert.AreEqual(name, contact.Name);
        Assert.AreEqual(surname, contact.Surname);
        Assert.AreEqual(phoneNumber, contact.PhoneNumber.Number);
    }
}