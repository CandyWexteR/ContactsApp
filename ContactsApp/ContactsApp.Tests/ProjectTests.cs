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
        // Setup
        _date = DateTime.Now;
        _project = new Project(new List<Contact>());
        var number = 87485746352;
        var expected = Contact.Create(itemsCount, surname, name, number, _date, null, null);
        for (var i = 0; i < itemsCount; i++)
        {
            _project.AddContact("surname" + i, "name" + i, number, date, email, idVk);
        }

        // Act
        _project.AddContact(surname, name, number, _date, null, null);
        var actual = _project.Contacts.First(f => f.Id == itemsCount);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase("", 8)]
    [TestCase("2", 6)]
    public void GetSortedTest(string nameFilter, int count)
    {
        // Setup
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;

        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        var project = new Project(list);

        var upperFilter = nameFilter.ToUpper();
        var expected = list
            .Where(c => $"{c.Surname.ToUpper()} {c.Name.ToUpper()}".Contains(upperFilter)
                        || $"{c.Name.ToUpper()} {c.Surname.ToUpper()}".Contains(upperFilter)
                        || c.Name.ToUpper().Contains(upperFilter)
                        || c.Surname.ToUpper().Contains(upperFilter))
            .OrderBy(c => $"{c.Surname} {c.Name}").ToList();

        // Act
        var actual = project.GetSortedContacts(nameFilter);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(3)]
    public void GetById_Valid(int count)
    {
        // Setup
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
            // Act
            var actual = _project.GetContact(expected.Id);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }

    [Test]
    [TestCase(3, 4)]
    public void GetById_Invalid(int count, int id)
    {
        // Setup
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        // Act
        var actual = _project.GetContact(id);

        // Assert
        Assert.Null(actual);
    }

    [Test]
    [TestCase(3, 2)]
    public void ContactRemove_Valid(int count, int removingId)
    {
        // Setup
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        var expectedRemovedContact = list.First(f => f.Id == removingId);
        _project = new Project(list);

        // Act
        TestDelegate testDelegate = () => _project.RemoveContact(removingId);

        // Assert
        Assert.DoesNotThrow(testDelegate);
        Assert.IsFalse(list.Contains(expectedRemovedContact));
    }

    [Test]
    [TestCase(3, 4)]
    [TestCase(0, 4)]
    public void ContactRemove_InvalidId(int count, int removingIndex)
    {
        // Setup
        _date = DateTime.Now;
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, _date, null, null));
        }

        _project = new Project(list);

        // Act
        TestDelegate testDelegate = () => _project.RemoveContact(removingIndex);
        // Assert
        Assert.Throws<InvalidEditOperationException>(testDelegate);
    }

    [Test]
    [TestCase(2, 1, "2332", "2323", "mail@example.com", "232323", null)]
    public void ContactEdit_Valid(int count, int id, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        // Setup
        var list = new List<Contact>();
        var number = 87485746352;
        var expected = Contact.Create(id, surname, name, number, birthday, email, idVk);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        // Act
        _project.EditContact(id, surname, name, number, birthday, email, idVk);

        // Assert
        var actual = _project.Contacts.First(f => f.Id == id);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(1, 2, "132", "321", "2323", "323", null)]
    public void ContactEdit_Invalid(int count, int id, string surname, string name, string email, string idVk,
        DateTime birthday)
    {
        // Setup
        var list = new List<Contact>();
        var number = 87485746352;
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, birthday, null, null));
        }

        _project = new Project(list);

        // Act
        TestDelegate actual = () => _project.EditContact(id, surname, name, number, birthday, email, idVk);

        // Assert
        Assert.Throws<InvalidEditOperationException>(actual);
    }
}