using System;
using System.Collections.Generic;
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

        Assert.AreEqual(null,_project.Contacts[0].Email);
        Assert.AreEqual(null,_project.Contacts[0].IdVk);
        Assert.AreEqual(null,_project.Contacts[0].BirthDay);
        Assert.AreEqual(1,_project.Contacts[0].Id);
        Assert.AreEqual(name,_project.Contacts[0].Name);
        Assert.AreEqual(surname,_project.Contacts[0].Surname);
        Assert.AreEqual(number,_project.Contacts[0].PhoneNumber);
    }
    [Test]
    [TestCase(3, "SuRRRnaaameEEE", "Nameeeeee")]
    public void Project_AddSecondOrGreater(int currentListItemsCount, string surname, string name)
    {
        _project = new Project(new List<Contact>());
        for (int i = 0; i < currentListItemsCount; i++)
        { 
            _project.AddContact("surname" + i, "name" + i,PhoneNumber.Create(6467462364),null,null,null);
        }
        var number = PhoneNumber.Create(7463728499);
        _project.AddContact(surname, name, number, null, null, null);
        
        Assert.AreEqual(null,_project.Contacts[currentListItemsCount].Email);
        Assert.AreEqual(null,_project.Contacts[currentListItemsCount].IdVk);
        Assert.AreEqual(null,_project.Contacts[currentListItemsCount].BirthDay);
        Assert.AreEqual(currentListItemsCount+1,_project.Contacts[currentListItemsCount].Id);
        Assert.AreEqual(name,_project.Contacts[currentListItemsCount].Name);
        Assert.AreEqual(surname,_project.Contacts[currentListItemsCount].Surname);
        Assert.AreEqual(number,_project.Contacts[currentListItemsCount].PhoneNumber);
    }
}