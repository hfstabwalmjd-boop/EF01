using EF01.Data;
using EF01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookStoreContext())
            {
                db.Database.Migrate();

                if (!db.Authors.Any())
                {
                    Author author = new Author()
                    {
                        FirstName = "Mohamed",
                        LastName = "Mohamoud",
                        Email = "mohamed@gmail.com",
                        Biography = "Egyptian Writer",
                        DateOfBirth = new DateTime(1995, 1, 7)
                    };

                    db.Authors.Add(author);
                    db.SaveChanges();
                }

                if (!db.Categories.Any())
                {
                    Category category = new Category()
                    {
                        Name = "Science",
                        Description = "Science Books",
                        IsActive = true
                    };

                    db.Categories.Add(category);
                    db.SaveChanges();
                }

                if (!db.Books.Any())
                {
                    Author author = db.Authors.First();
                    Category category = db.Categories.First();

                    Book book = new Book()
                    {
                        Title = "C# Fundamentals",
                        ISBN = "9781234567890",
                        Price = 150,
                        NumberOfPages = 250,
                        PublishedYear = 2024,
                        IsInStock = true,
                        AuthorId = author.Id,
                        CategoryId = category.Id
                    };

                    db.Books.Add(book);
                    db.SaveChanges();
                }

                Console.WriteLine("Data inserted successfully!");

                Console.WriteLine("Authors: " + db.Authors.Count());
                Console.WriteLine("Categories: " + db.Categories.Count());
                Console.WriteLine("Books: " + db.Books.Count());
            }
        }
    }
}

