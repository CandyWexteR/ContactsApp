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

    [Test]
    [TestCase(3, "SuRRRnaaameEEE", "Nameeeeee", null, null, null)]
    [TestCase(0, "SuRRRnaaameEEE", "Nameeeeee", null, null, null)]
    public void Project_AddContact(int itemsCount, string surname, string name, DateTime date,
        string email, string idVk)
    {
        _date = DateTime.Now;
        _project = new Project(new List<Contact>());
        var number = 87485746352;
        var expected = Contact.Create(itemsCount, surname, name, number, _date, null, null);
        for (var i = 0; i < itemsCount; i++)
        {
            _project.AddContact("surname" + i, "name" + i, number, date, email, idVk);
        }

        _project.AddContact(surname, name, number, _date, null, null);
        var actual = _project.Contacts.First(f => f.Id == itemsCount);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(3)]
    public void GetById_Valid(int count)
    {
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;

        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        foreach (var expected in list)
        {
            var actual = _project.GetContact(expected.Id);
            Assert.AreEqual(expected, actual);
        }
    }

    [Test]
    [TestCase(3, 4)]
    public void GetById_Invalid(int count, int id)
    {
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }
        _project = new Project(list);

        var actual = _project.GetContact(id);
        
        Assert.Null(actual);
    }

    [Test]
    [TestCase(3, 2)]
    public void ContactRemove_Valid(int count, int removingId)
    {
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        var expectedRemovedContact = list.First(f => f.Id == removingId);
        _project = new Project(list);

        Assert.DoesNotThrow(() => _project.RemoveContact(removingId));
        Assert.IsFalse(list.Contains(expectedRemovedContact));
    }

    [Test]
    [TestCase(3, 4)]
    [TestCase(0, 4)]
    public void ContactRemove_InvalidId(int count, int removingIndex)
    {
        _date = DateTime.Now;
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
    [TestCase(2, 1, "2332", "2323", "mail@example.com", "232323", null)]
    public void ContactEdit_Valid(int count, int id, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        var list = new List<Contact>();
        var number = 87485746352;
        var expected = Contact.Create(id, surname, name, number, birthday, email, idVk);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        _project.EditContact(id, surname, name, number, birthday, email, idVk);
        var actual = _project.Contacts.First(f => f.Id == id);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(1, 2, "132", "321", "2323", "323", null)]
    public void ContactEdit_Invalid(int count, int id, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        Assert.Throws<InvalidEditOperationException>(() =>
            _project.EditContact(id, surname, name, number, birthday, email, idVk));
    }
}