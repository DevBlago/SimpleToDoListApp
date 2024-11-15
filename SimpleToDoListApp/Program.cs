using System;
using System.Collections.Generic;

namespace SimpleToDoListApp
{
    class Program
    {
        // Список для хранения задач
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            string command;
            Console.WriteLine("Добро пожаловать в консольный To-Do List!");

            do
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Добавить задачу");
                Console.WriteLine("2 - Удалить задачу");
                Console.WriteLine("3 - Показать все задачи");
                Console.WriteLine("4 - Выйти");
                Console.Write("Введите команду: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        ShowTasks();
                        break;
                    case "4":
                        Console.WriteLine("Выход...");
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Пожалуйста, попробуйте снова.");
                        break;
                }
            } while (command != "4");
        }

        // Метод для добавления задачи
        static void AddTask()
        {
            Console.Write("Введите описание задачи: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Задача добавлена.");
        }

        // Метод для удаления задачи
        static void RemoveTask()
        {
            Console.Write("Введите номер задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("Задача удалена.");
            }
            else
            {
                Console.WriteLine("Неверный номер задачи.");
            }
        }

        // Метод для отображения всех задач
        static void ShowTasks()
        {
            Console.WriteLine("Список задач:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }
    }
}
