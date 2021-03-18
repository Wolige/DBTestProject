using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DBTestProject
{
    class Program
    {
        private static void Main(string[] args)
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
                                Console.WriteLine($"Write {Commands.UpdateSongCommand} if you want to update some song data");
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
                                Console.Clear();
                                break;
                        }
                        case Commands.GetAllGroupsCommand:
                        {
                                DisplayCollectionChilds(db.Groups);
                                break;
                        }
                        case Commands.UpdateGroupCommand:
                        {
                                DisplayCollectionChilds(db.Groups);
                                Console.Write("Write the group id that you want to change: ");
                                int id = int.Parse(Console.ReadLine());
                                var selectedGroup = db.Groups.FirstOrDefault(item => item.Id == id);
                                Console.Write("Write the updated group name: ");
                                string updatedName = Console.ReadLine();
                                Console.Write("Write the updated group year: ");
                                int updatedYear = int.Parse(Console.ReadLine());
                                selectedGroup.Name = updatedName;
                                selectedGroup.Year = updatedYear;
                                break;
                        }

                        case Commands.AddNewSongCommand:
                        {
                                DisplayCollectionChilds(db.Groups);
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
                                Console.Clear();
                                break;
                        }
                        case Commands.GetAllSongsCommand:
                        {
                                DisplayCollectionChilds(db.Songs);
                                break;
                        }
                        
                        case Commands.UpdateSongCommand:
                        {
                                DisplayCollectionChilds(db.Songs);
                                Console.Write("Write the song id");
                                int writedId = int.Parse(Console.ReadLine());
                                Song selectedSong = db.Songs.FirstOrDefault(item => item.Id == writedId);
                                Console.WriteLine(selectedSong);
                                Console.Write("Write the updated name: ");
                                string updatedName = Console.ReadLine();
                                Console.Write("Write the updated year: ");
                                int? updatedYear = int.Parse(Console.ReadLine());
                                Console.Write("Write the updated groupID: ");
                                int groupId = int.Parse(Console.ReadLine());
                                selectedSong.Name = updatedName;
                                selectedSong.Year = updatedYear;
                                selectedSong.GroupId = groupId;
                                break;
                        }
                        case Commands.SaveAllChangesCommand:
                        {
                                db.SaveChanges();
                                Console.WriteLine("Saved successfully");
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
        private static void DisplayCollectionChilds(IEnumerable<object> ts)
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
