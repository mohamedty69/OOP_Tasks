using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Sys
{
    public class Library
    {
        public string name {  get; set; }
        public List<Book> books { get; set; }
        public List<Member> members { get; set; }
        public Library(string name)
        {
            this.name = name;
            this.books = new List<Book>();
            this.members = new List<Member>();
        }
        public void addBook(Book book)
        {
            books.Add(book);
        }
        public void addMember(Member member)
        {
            members.Add(member);
        }
        public string lenBook(Member member, string isbn)
        {
            foreach(var book in books)
            {
                if(book.isbn == isbn && book.isAvaliable == true)
                {
                    book.isAvaliable = false;
                    return $"{member.name} borrowed : {book.title}";
                }
            }
            return "This book is unavailable";
        }
        public string revieveBook(Member member,string isbn)
        {
            foreach(var book in books)
            {
                if(book.isbn == isbn && book.isAvaliable == false)
                {
                    book.isAvaliable = true;
                    return $"{member.name} retuen {book.title}";
                }
            }
            return "This book is already returned";
        }
        public void displayAvailablebooks()
        {
            Console.WriteLine($"Available books in {name} :");
            var count = 0;
            foreach(var book in books)
            {
                count++;
                if(book.isAvaliable == true)
                Console.WriteLine($"{book.title} by {book.author} (ISBN: {book.isbn})");
            }
            if (count == 0) Console.WriteLine("There isn`t available books");
        }
    }
}
