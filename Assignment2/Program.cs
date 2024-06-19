using Core.Entities;
using Infrastructure;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestDatabase();
        }
        public static void TestDatabase()
        {
            var Repo = new Repo();
            while (true)
            {
                Console.WriteLine("List of users");
                UserList();
                Console.WriteLine("Choose 1 to insert User, 2 to update, 3 to delete, 4 to update");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Enter Details");
                    var user = new User()
                    {
                        username = ReadInput("Name", null),
                        phonenumber = ReadInput("Phone Number", null),
                        email = ReadInput("email", null),
                    };
                    Repo.create(user);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter Id to Update");
                    int id = int.Parse(Console.ReadLine());
                    var userUpdated = Repo.Read<User>(id);
                    if (userUpdated != null)
                    {
                        userUpdated.username = ReadInput("name:", userUpdated.username);
                        userUpdated.phonenumber = ReadInput("phone number:", userUpdated.phonenumber);
                        userUpdated.email = ReadInput("email:", userUpdated.email);
                        Repo.update(userUpdated);
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("enter id to delete");
                    int id = int.Parse(Console.ReadLine());
                    Repo.delete<User>(id);

                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice, Try Again");
                }
            }
        }

        private static string ReadInput(string writeline, string defaultData)
        {
            Console.Write(writeline);
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input.Trim();

            }
            else
            {
                return defaultData;
            }
        }

        private static void UserList()
        {
            var dbContext = new DataContext();
            var users = dbContext.Users.Where(u => !u.IsDeleted).ToList();
            if (users.Count == 0)
            {
                Console.WriteLine("no users found");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"id: {user.Id}, name :{user.username}, email: {user.email}");

                    }
            }

        }
    }
}