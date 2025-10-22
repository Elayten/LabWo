using JonDou9000.TaskPlanner.Domain.Logic;
using JonDou9000.TaskPlanner.Domain.Models;
using JonDou9000.TaskPlanner.Domain.Models.Enums;
using System;

internal static class Program
{
    public static void Main(string[] args)
    {
        var items = new WorkItem[]
        {
            new WorkItem { Title = "Зробити домашнє завдання", DueDate = new DateTime(2025, 9, 25), Priority = Priority.Medium },
            new WorkItem { Title = "Купити продукти", DueDate = new DateTime(2025, 9, 23), Priority = Priority.Low },
            new WorkItem { Title = "Погуляти з собакою", DueDate = new DateTime(2025, 9, 22), Priority = Priority.High },
            new WorkItem { Title = "ПРибрати кімнату", DueDate = new DateTime(2025, 1, 5), Priority = Priority.Medium },
            new WorkItem { Title = "приготувати їсти", DueDate = new DateTime(2026, 3, 6), Priority = Priority.None},
            new WorkItem { Title = "Вмитись", DueDate = new DateTime(2025, 3, 12), Priority = Priority.Urgent },
        };

        var planner = new SimpleTaskPlanner();
        var plan = planner.CreatePlan(items);

        Console.WriteLine("Список завдань у правильному порядку:");
        foreach (var item in plan)s
        {
            Console.WriteLine($"- {item.Title} (Пріоритет {item.Priority}, дедлайн {item.DueDate:dd.MM.yyyy})");
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
