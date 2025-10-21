using System;
using System.Linq;
using JonDou9000.TaskPlanner.Domain.Models;

namespace JonDou9000.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            return items
                .OrderByDescending(x => x.Priority)  // Спочатку — за пріоритетом
                .ThenBy(x => x.DueDate)              // Потім — за дедлайном
                .ThenBy(x => x.Title)                // Потім — за назвою
                .ToArray();
        }
    }
}
