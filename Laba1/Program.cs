using ConsoleApp.PostgreSQL;
using Laba1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте!");
            while (true)
            {
            Console.WriteLine("Выберите функцию:");
            Console.WriteLine("1-Создать");
            Console.WriteLine("2-Удалить");
            Console.WriteLine("3-Обновить");
            Console.WriteLine("4-Проверить");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите имя:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    int a = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                        context.Profiles.Add(new Profile() { Name = n, Age = a });
                        context.SaveChanges();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите ID профиля:");
                    int i = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                        var userToDelete = context.Profiles.Find(i);
                        if (userToDelete != null)
                        {
                            Console.WriteLine($"Вы действительно хотите удалить пользователя {userToDelete.Name}? (Y/N)");
                            var key = Console.ReadKey().Key;
                            if (key == ConsoleKey.Y)
                            {
                                context.Profiles.Remove(userToDelete);
                                    context.SaveChanges();
                                Console.WriteLine( $"\nПользователь {userToDelete.Name} удален из базы данных.");
                            }
                            else
                            {
                                Console.WriteLine($"Удаление пользователя {userToDelete.Name} отменено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Пользователь с идентификатором {i} не найден в базе данных.");
                        }
                    }
                    break;
                    case 3:
                    Console.WriteLine("Введите ID профиля:");
                    int i1 = Int32.Parse(Console.ReadLine());
                    using (BloggingContext context = new BloggingContext())
                    {
                            var userToUpdate = context.Profiles.Find(i1);
                            if (userToUpdate != null)
                            {
                                Console.WriteLine($"Введите новое имя для пользователя {userToUpdate.Name}:");
                                userToUpdate.Name = Console.ReadLine();
                                Console.WriteLine($"Введите новое имя для пользователя {userToUpdate.Age}:");
                                userToUpdate.Age = Int32.Parse(Console.ReadLine());
                                context.SaveChanges();
                                Console.WriteLine($"Данные пользователя {userToUpdate.Name} успешно обновлены.");
                                Console.WriteLine($"Данные пользователя {userToUpdate.Age} успешно обновлены.");
                            }
                            else
                            {
                                Console.WriteLine($"Пользователь с идентификатором {i1} не найден в базе данных.");
                            }
                        
                        break;
                    }
                    case 4:
                    using (BloggingContext context = new BloggingContext())
                    {
                        var users = context.Profiles.ToList();
                        Console.WriteLine("Список пользователей:");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.Id}: {user.Name} {user.Age}");
                        }
                    }
                    break;
            }

                Console.WriteLine("Хотите запустить программу заново? (Y/N)");
                var input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break; 
                }
            }
        }
    }
}