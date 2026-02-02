using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Sys
{
    public class Book
    {
        public string title {  get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
       
        public bool isAvaliable = true;
        public Book(string title , string author , string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
        }
        public string getInfo()
        {
            return $"Title : {title}" +
                $"Author : {author} "+
                $"ISBN : {isbn}"+
                $"Is Available : {isAvaliable}";
        }
        public void borrow()
        {
            isAvaliable = false; 
        }
        public void returnBooks()
        {
            isAvaliable = true;
        }
    }
}
