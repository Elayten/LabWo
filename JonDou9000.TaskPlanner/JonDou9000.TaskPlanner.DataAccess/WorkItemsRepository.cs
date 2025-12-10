using JonDou9000.TaskPlanner.DataAccess.Abstractions;
using JonDou9000.TaskPlanner.Domain.Models;

namespace JonDou9000.TaskPlanner.DataAccess
{
    public class WorkItemsRepository : IWorkItemsRepository
    {
        private readonly List<WorkItem> _items = new();

        public Guid Add(WorkItem workItem)
        {
            workItem.Id = Guid.NewGuid();
            _items.Add(workItem);
            return workItem.Id;
        }

        public WorkItem? Get(Guid id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public WorkItem[] GetAll()
        {
            return _items.ToArray();
        }

        public bool Update(WorkItem workItem)
        {
            var existing = Get(workItem.Id);
            if (existing == null) return false;

            existing.Title = workItem.Title;
            existing.Description = workItem.Description;
            existing.Status = workItem.Status;
            return true;
        }

        public bool Remove(Guid id)
        {
            var item = Get(id);
            if (item == null) return false;

            return _items.Remove(item);
        }

        public void SaveChanges()
        {
            // Для майбутнього якщо буде файлова БД
        }
    }
}
