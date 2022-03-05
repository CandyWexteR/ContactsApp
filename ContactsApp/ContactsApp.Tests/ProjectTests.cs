﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ContactsApp.Exceptions;
using NUnit.Framework;

namespace ContactsApp.Tests;

public class ProjectTests
{
    private Project _project;

    [Test]
    [TestCase("SuRName", "Naaameee")]
    public void Project_AddFirstOnly(string surname, string name)
    {
        _project = new Project(new List<Contact>());
        var number = PhoneNumber.Create(7463728499);
        _project.AddContact(surname, name, number, null, null, null);

        AssertContact(0, surname, name, number, null, null, null);
    }

    [Test]
    [TestCase(3, "SuRRRnaaameEEE", "Nameeeeee")]
    public void Project_AddSecondOrGreater(int currentListItemsCount, string surname, string name)
    {
        _project = new Project(new List<Contact>());
        for (int i = 0; i < currentListItemsCount; i++)
        {
            _project.AddContact("surname" + i, "name" + i, PhoneNumber.Create(6467462364), null, null, null);
        }

        var number = PhoneNumber.Create(7463728499);
        _project.AddContact(surname, name, number, null, null, null);

        AssertContact(currentListItemsCount, surname, name, number, null, null, null);
    }

    [Test]
    [TestCase(3)]
    public void ExistingContactsAssers(int count)
    {
        var list = new List<Contact>();
        var number = PhoneNumber.Create(7485746352);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, null, null, null));
        }

        _project = new Project(list);

        for (var i = 0; i < count; i++)
        {
            AssertContact(i, $"Surname {i}", $"Name {i}", number, null, null, null);
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
        var number = PhoneNumber.Create(7485746352);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, null, null, null));
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
        var number = PhoneNumber.Create(7485746352);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, null, null, null));
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
    [TestCase(2, 1, "2332", "2323", "2323", "232323", null)]
    public void ContactEdit_Valid(int count, int id, string surname, string name, string? email, string? idVk,
        DateTime? birthday)
    {
        Assert.Positive(count);
        Assert.Positive(id);
        Assert.Greater(count, id);

        var list = new List<Contact>();
        var number = PhoneNumber.Create(7485746352);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, null, null, null));
        }

        _project = new Project(list);

        _project.EditContact(id, surname, name, number, birthday, email, idVk);
        
        AssertContact(id, surname, name, number, birthday, email, idVk);
    }

    [Test]
    [TestCase(1, 2, "132", "321", "2323", "323", null)]
    public void ContactEdit_Invalid(int count, int index, string surname, string name, string? email, string? idVk,
        DateTime? birthday)
    {
        Assert.Positive(count);
        Assert.Positive(index);
        Assert.Greater(index, count);

        var list = new List<Contact>();
        var number = PhoneNumber.Create(7485746352);
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, null, null, null));
        }

        _project = new Project(list);

        Assert.Throws<InvalidEditOperationException>(() => _project.EditContact(index, surname, name, number, birthday, email, idVk));
    }

    private void AssertContact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
        string? email, string? idVk)
    {
        var contact = _project.Contacts.FirstOrDefault(c => c.Id == id);
        if(contact is null)
            Assert.Fail();
        
        Assert.AreEqual(email, _project.Contacts[id].Email);
        Assert.AreEqual(idVk, _project.Contacts[id].IdVk);
        Assert.AreEqual(birthday, _project.Contacts[id].BirthDay);
        Assert.AreEqual(id, _project.Contacts[id].Id);
        Assert.AreEqual(name, _project.Contacts[id].Name);
        Assert.AreEqual(surname, _project.Contacts[id].Surname);
        Assert.AreEqual(phoneNumber, _project.Contacts[id].PhoneNumber);
    }
}