using System;
using System.Linq;
using JonDou9000.TaskPlanner.Domain.Models;

namespace JonDou9000.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            return items
                .Where(x => x != null)                // Захист від null у масиві
                .Where(x => !x.IsCompleted)           // Ігноруємо виконані задачі (аналог Done)
                .OrderByDescending(x => x.Priority)   // 1. Пріоритет (High > Medium > Low)
                .ThenBy(x => x.DueDate)               // 2. Дедлайн (раніше → перше)
                .ThenBy(x => x.Title)                 // 3. Алфавітний порядок
                .ToArray();
        }
    }
}
