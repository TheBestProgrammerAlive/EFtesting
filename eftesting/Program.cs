// See https://aka.ms/new-console-template for more information

using eftesting;
using PublisherData;
using PublisherDomain;

TestingFacade test = new();
using var context = new PubContext();
var author = context.Authors.Find(10);
Console.WriteLine(context.Entry(author).DebugView.LongView);

context.Entry(author).Collection(b => b.Books).Load();
Console.WriteLine(context.Entry(author).DebugView.LongView);

//var author = context.Authors.Find(1);
//var authors = context.Authors.Include(a => a.Books).ToList();
//test.AddAuthorWithBook();
//test.GetAuthorsWithBooks();



