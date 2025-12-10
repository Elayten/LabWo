using System;
using JonDou9000.TaskPlanner.Domain.Models.Enums;

namespace JonDou9000.TaskPlanner.Domain.Models
{
    public class WorkItem
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Нове поле — те, якого не вистачало
        public WorkStatus Status { get; set; } = WorkStatus.New;

        public WorkItem Clone()
        {
            return new WorkItem
            {
                Id = this.Id,
                CreationDate = this.CreationDate,
                DueDate = this.DueDate,
                Priority = this.Priority,
                Complexity = this.Complexity,
                Title = this.Title,
                Description = this.Description,
                Status = this.Status
            };
        }

        public override string ToString()
        {
            return $"{Title}: due {DueDate:dd.MM.yyyy}, {Priority.ToString().ToLower()} priority, status: {Status}";
        }
    }
}
