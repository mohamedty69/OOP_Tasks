using System;

namespace Library_Sys
{
    class program
    {
        static void Main (string[] args)
        {
            var lib = new Library("City Central Library");
            var book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
            var book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
            var book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");
            lib.addBook(book1);
            lib.addBook(book2);
            lib.addBook(book3);
            var member1 = new Member("Alice Johnson", "M001");
            var member2 = new Member("Bob Smith", "M002");
            lib.addMember(member1);
            lib.addMember(member2);
            lib.displayAvailablebooks();
            Console.WriteLine(lib.lenBook(member1, "978-0201633610"));
            lib.displayAvailablebooks();
            Console.WriteLine(lib.revieveBook(member1, "978-0201633610"));
        }
    }
}
