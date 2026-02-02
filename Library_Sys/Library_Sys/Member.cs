using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Sys
{
    public class Member
    {
        public string name {  get; set; }
        public string memberId { get; set; }
        public List<Book> books { get; set; }
        public Member(string name, string memberId)
        {
            this.name = name;
            this.memberId = memberId;
            this.books = new List<Book>();
        }
        public void getInfo()
        {
            Console.WriteLine($"Name : {name}, Member ID : {memberId}");
            foreach (var book in books)
            {
                Console.WriteLine($"Title : {book.title} ,Author : {book.author}, ISBN : {book.isbn}, Is Available : {book.isAvaliable}");
            }
        }
        public void borrowBook(Book book)
        {
            if (book.isAvaliable == true)
            {
                books.Add(book);
                book.isAvaliable = false;
            }
            else Console.WriteLine("The book isn`t avaliable");
        }
        public void removeBook(Book book) {
            books.Remove(book);
            book.isAvaliable = true;
        }
    }
    
}
