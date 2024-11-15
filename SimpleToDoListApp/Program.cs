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
                command = Console.ReadLine()?.Trim();

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
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Пожалуйста, выберите число от 1 до 4.");
                        break;
                }
            } while (command != "4");
        }

        // Метод для добавления задачи
        static void AddTask()
        {
            Console.Write("Введите описание задачи: ");
            string task = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Задача добавлена.");
            }
            else
            {
                Console.WriteLine("Ошибка: описание задачи не может быть пустым.");
            }
        }

        // Метод для редактирования задачи
        static void EditTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст. Редактирование невозможно.");
                return;
            }

            Console.Write("Введите номер задачи для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                Console.WriteLine($"Текущая задача: \"{tasks[taskNumber - 1]}\"");
                Console.Write("Введите новое описание задачи: ");
                string newTask = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(newTask))
                {
                    tasks[taskNumber - 1] = newTask;
                    Console.WriteLine("Задача успешно обновлена.");
                }
                else
                {
                    Console.WriteLine("Ошибка: описание задачи не может быть пустым.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: неверный номер задачи.");
            }
        }


        // Метод для удаления задачи
        static void RemoveTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст. Удаление невозможно.");
                return;
            }

            Console.Write("Введите номер задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                Console.WriteLine($"Задача \"{tasks[taskNumber - 1]}\" удалена.");
                tasks.RemoveAt(taskNumber - 1);
            }
            else
            {
                Console.WriteLine("Ошибка: неверный номер задачи.");
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
