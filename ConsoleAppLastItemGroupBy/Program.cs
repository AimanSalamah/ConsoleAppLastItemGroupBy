using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppLastItemGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineNumber = string.Empty;
            ShowOptions();
            lineNumber = Console.ReadLine();
            while (lineNumber != string.Empty)
            {
                switch (lineNumber)
                {
                    case "1":
                        using (var db = new DBcon())
                        {
                            db.Users.AddRange(new List<Users>
                            {
                                new Users{Name = "Aiman"},
                                new Users{Name = "Alaa"},
                                new Users{Name = "Montaser"},
                                new Users{Name = "Mustafa"},
                            });
                            var result = db.SaveChanges();
                            Console.WriteLine($"{result} users saved");
                        }
                        break;
                    case "2":
                        using (var db = new DBcon())
                        {
                            db.Messages.AddRange(new List<Messages>
                            {
                                new Messages{CreateDate = DateTime.Now, UserID = 1, Message = "message1"},
                                new Messages{CreateDate = DateTime.Now, UserID = 1, Message = "message2"},
                                new Messages{CreateDate = DateTime.Now, UserID = 1, Message = "message3"},
                                new Messages{CreateDate = DateTime.Now, UserID = 1, Message = "message4"},
                                new Messages{CreateDate = DateTime.Now, UserID = 2, Message = "message1"},
                                new Messages{CreateDate = DateTime.Now, UserID = 2, Message = "message2"},
                                new Messages{CreateDate = DateTime.Now, UserID = 2, Message = "message3"},
                                new Messages{CreateDate = DateTime.Now, UserID = 2, Message = "message4"},
                                new Messages{CreateDate = DateTime.Now, UserID = 3, Message = "message1"},
                                new Messages{CreateDate = DateTime.Now, UserID = 3, Message = "message2"},
                                new Messages{CreateDate = DateTime.Now, UserID = 3, Message = "message3"},
                                new Messages{CreateDate = DateTime.Now, UserID = 3, Message = "message4"},
                                new Messages{CreateDate = DateTime.Now, UserID = 4, Message = "message1"},
                                new Messages{CreateDate = DateTime.Now, UserID = 4, Message = "message2"},
                                new Messages{CreateDate = DateTime.Now, UserID = 4, Message = "message3"},
                                new Messages{CreateDate = DateTime.Now, UserID = 4, Message = "message4"},
                            });
                            var result = db.SaveChanges();
                            Console.WriteLine($"{result} messages saved");
                        }
                        break;
                    case "3":
                        using (var db = new DBcon())
                        {
                            foreach (var item in db.Messages.OrderByDescending(c => c.CreateDate).AsEnumerable().GroupBy(p => p.UserID).Select(c => c.First()).ToList())
                            {
                                Console.WriteLine($"{item.ID}:{item.Message}:{item.CreateDate}:userId={item.UserID}");
                            }
                        }
                        break;
                    case "4":
                        using (var db = new DBcon())
                        {
                            db.Database.EnsureDeleted();
                            Console.WriteLine($"Data base deleted");
                        }
                        break;
                    case "5":
                        using (var db = new DBcon())
                        {
                            db.Database.EnsureCreated();
                            Console.WriteLine($"Data base created");
                        }
                        break;
                }
                lineNumber = Console.ReadLine();
            }
            Console.ReadLine();
        }
        static void ShowOptions()
        {
            Console.WriteLine("1- Add user");
            Console.WriteLine("2- Add messages");
            Console.WriteLine("3- show last");
            Console.WriteLine("4- Delete databse");
            Console.WriteLine("5- Create Databse");
            Console.WriteLine("0- exit");
        }
    }
}
