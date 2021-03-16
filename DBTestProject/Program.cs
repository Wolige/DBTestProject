using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DBTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestDbContext db = new TestDbContext())
            {
                Console.WriteLine($"Write {Commands.HelpCommand} to get instruction");
                while (true)
                {
                    Console.Write(">");
                    switch (Console.ReadLine())
                    {
                        case Commands.HelpCommand:
                        {
                                Console.WriteLine($"Write {Commands.AddNewSongCommand} if you want add new song");
                                Console.WriteLine($"Write {Commands.AddNewGroupCommand} if you want add new group");
                                Console.WriteLine($"Write {Commands.GetAllSongsCommand} if you want to get all users");
                                Console.WriteLine($"Write {Commands.GetAllGroupsCommand} if you want to get all groups");
                                Console.WriteLine($"Write {Commands.SaveAllChangesCommand} if you want to save all changes");
                                Console.WriteLine($"Write {Commands.ExitCommand} if you want to exit the app");
                                break;
                        }
                        case Commands.AddNewGroupCommand:
                        {
                                Console.WriteLine("Name of the group: ");
                                string groupName = Console.ReadLine();
                                Console.WriteLine("Year of the group: ");
                                int year = int.Parse(Console.ReadLine());
                                db.Groups.Add(new Group()
                                {
                                    Name = groupName,
                                    Year = year,
                                });
                                break;
                        }
                        case Commands.AddNewSongCommand:
                        {
                                foreach (var item in db.Groups)
                                {
                                    Console.WriteLine($"Group ID: {item.Id}, Group Name: {item.Name}");
                                }
                                Console.Write("Write song name: ");
                                string songName = Console.ReadLine();
                                Console.Write("Write song year: ");
                                int songYear = int.Parse(Console.ReadLine());
                                Console.Write("Write song group Id, you can get it from first line: ");
                                int groupID = int.Parse(Console.ReadLine());
                                db.Songs.Add(new Song()
                                {
                                    Name = songName,
                                    Year = songYear,
                                    GroupId = groupID,
                                });
                                break;
                        }
                        
                        case Commands.GetAllSongsCommand:
                        {
                                foreach (var item in db.Songs)
                                {
                                    Console.WriteLine($"{item.Id}, {item.Name}, {item.Year}, {item.Group.Id}");
                                    Console.WriteLine(new string('-', 30));
                                }
                                break;
                        }
                        case Commands.GetAllGroupsCommand:
                        {
                                foreach (var item in db.Groups)
                                {
                                    Console.WriteLine($"{item.Id}, {item.Name}, {item.Year}");
                                    Console.WriteLine(new string('-', 30));
                                }
                                break;
                        }
                        case Commands.SaveAllChangesCommand:
                        {
                                db.SaveChanges();
                                break;
                        }
                        case Commands.ExitCommand:
                        {
                                Environment.Exit(0);
                                break;
                        }

                        default:
                            {
                                Console.WriteLine("Wrong command");
                                break;
                            }

                    }
                }
            }
        }
    }
}
