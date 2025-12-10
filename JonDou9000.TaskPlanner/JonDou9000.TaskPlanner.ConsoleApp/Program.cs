using JonDou9000.TaskPlanner.DataAccess;
using JonDou9000.TaskPlanner.Domain.Logic;
using JonDou9000.TaskPlanner.Domain.Models;
using JonDou9000.TaskPlanner.Domain.Models.Enums;
using System;
using System.Linq;

internal static class Program
{
    public static void Main(string[] args)
    {
        var repository = new WorkItemsRepository();
        var planner = new SimpleTaskPlanner(repository);

        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine()?.ToUpper();

            switch (choice)
            {
                case "A":
                    AddWorkItem(repository);
                    break;

                case "B":
                    BuildPlan(planner);
                    break;

                case "M":
                    MarkWorkItemCompleted(repository);
                    break;

                case "R":
                    RemoveWorkItem(repository);
                    break;

                case "Q":
                    ExitProgram(repository);
                    return;

                default:
                    Console.WriteLine("❗ Невідома команда. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\nОберіть дію:");
        Console.WriteLine("[A] — Додати завдання");
        Console.WriteLine("[B] — Створити план");
        Console.WriteLine("[M] — Відмітити завдання як виконане");
        Console.WriteLine("[R] — Видалити завдання");
        Console.WriteLine("[Q] — Вихід");
    }

    private static void ExitProgram(WorkItemsRepository repository)
    {
        Console.WriteLine("Вихід з програми...");
        repository.SaveChanges();
    }

    private static void AddWorkItem(WorkItemsRepository repository)
    {
        Console.Write("Введіть назву завдання: ");
        var title = Console.ReadLine();

        Console.Write("Введіть дату дедлайну (yyyy-MM-dd): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);

        Console.WriteLine("Оберіть пріоритет: 1 - High, 2 - Medium, 3 - Low");
        Priority priority = Console.ReadLine() switch
        {
            "1" => Priority.High,
            "2" => Priority.Medium,
            _ => Priority.Low
        };

        var workItem = new WorkItem
        {
            Title = title,
            DueDate = dueDate,
            Priority = priority,
            Status = WorkStatus.New
        };

        repository.Add(workItem);
        repository.SaveChanges();

        Console.WriteLine("✅ Завдання додано!");
    }

    private static void BuildPlan(SimpleTaskPlanner planner)
    {
        var plan = planner.CreatePlan();

        Console.WriteLine("\n📋 Список завдань у правильному порядку:");

        foreach (var item in plan)
        {
            Console.WriteLine(
                $"- {item.Title} (Пріоритет: {item.Priority}, дедлайн: {item.DueDate:dd.MM.yyyy}, статус: {item.Status})");
        }
    }

    private static void MarkWorkItemCompleted(WorkItemsRepository repository)
    {
        Console.Write("Введіть назву завдання, яке виконано: ");
        var title = Console.ReadLine();

        var item = repository.GetAll()
            .FirstOrDefault(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (item == null)
        {
            Console.WriteLine("❌ Завдання не знайдено.");
            return;
        }

        item.Status = WorkStatus.Completed;
        repository.Update(item);
        repository.SaveChanges();

        Console.WriteLine("✅ Завдання відмічено як виконане!");
    }

    private static void RemoveWorkItem(WorkItemsRepository repository)
    {
        Console.Write("Введіть назву завдання для видалення: ");
        var title = Console.ReadLine();

        var item = repository.GetAll()
            .FirstOrDefault(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (item == null)
        {
            Console.WriteLine("❌ Завдання не знайдено.");
            return;
        }

        repository.Remove(item.Id);
        repository.SaveChanges();

        Console.WriteLine("🗑️ Завдання видалено!");
    }
}
