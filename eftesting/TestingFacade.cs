using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eftesting
{
    public class TestingFacade
    {
       public void GetAuthors()
        {
            using var context = new PubContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        public void AddAuthor()
        {
            var author = new Author { FirstName = "qwerty", LastName = "lolo" };
            using var context = new PubContext();
            context.Authors.Add(author);

            context.SaveChanges();
        }
        public void AddAuthorWithBook()
        {
            var author = new Author { FirstName = "Julie", LastName = "Lerman" };
            author.Books.Add(new Book { Title = "cośtma", PublishDate = new DateTime(2009, 1, 1) });
            author.Books.Add(new Book { Title = "inneksienszkei", PublishDate = new DateTime(2008, 10, 1) });
            using var context = new PubContext();
            context.Authors.Add(author);
            context.SaveChanges();

        }

        public void GetAuthorsWithBooks()
        {
            using var context = new PubContext();
            var authors = context.Authors.Include(a => a.Books).ToList();
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($"*{book}");
                }
            }

        }

        public void SeedDb()
        {
            string[] names = File.ReadAllLines(@"C:\Users\Z6OJG\Desktop\private\testin\New folder\eftesting\names.txt");
            string[] bookNames = File.ReadAllLines(@"C:\Users\Z6OJG\Desktop\private\testin\New folder\eftesting\bookNames.txt");
            using var context = new PubContext();
            int i = 0;
            while (i < 1000)
            {
                var author = CreateRandomAuthor(names, bookNames);
                context.Add(author);
                i++;
            }
            context.SaveChanges();
        }

        public Author CreateRandomAuthor(string[] names, string[] bookNames)
        {
            Random rng = new();
            List<Book> books = new();

            for (int i = 0; i < rng.Next(5); i++)
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                start.AddDays(rng.Next(range));
                books.Add(new Book() { Title = bookNames[rng.Next(bookNames.Length - 1)], PublishDate = start, BasePrice = rng.Next(300) });
            }

            return new Author { FirstName = names[rng.Next(names.Length - 1)], LastName = names[rng.Next(names.Length - 1)], Books = books };
        }
    }
}
