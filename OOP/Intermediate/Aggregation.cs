using System;

namespace Intermediate;

public class Book
{
    public string Title { get; set; }
    public Book(string title)
    {
        Title = title;
    }
}
public class Library
{
    private List<Book> books;
    public Library()
    {
        books = new List<Book>();
    }
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void ShowBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book.Title);
        }
    }
}

/****
 //In Aggregation,the child class can exist independently of the parent class.
//The destruction of the parent has no effect on the child class.
//The child class can be shared among multiple parent classes.
//It is mainly useful for cases where the child class can be shared among multiple parent classes like a library and a book.
Library library = new Library();
library.AddBook(new Book("The Great Gatsby"));
library.AddBook(new Book("1984"));
library.ShowBooks();
 ****/