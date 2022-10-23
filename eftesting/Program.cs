// See https://aka.ms/new-console-template for more information
using eftesting;
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System.Text;

TestingFacade test = new();
using var context = new PubContext();

context.Add(new Author() {FirstName = "Tester"});
context.SaveChanges();

//test.GetAuthorsWithBooks();



