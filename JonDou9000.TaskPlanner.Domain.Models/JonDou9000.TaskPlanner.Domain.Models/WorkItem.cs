using System;
using JonDou9000.TaskPlanner.Domain.Models.Enums;

namespace JonDou9000.TaskPlanner.Domain.Models
{
    public class WorkItem
    {
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Title} (пріоритет: {Priority}, дедлайн: {DueDate:dd.MM.yyyy})";
        }
    }
}
