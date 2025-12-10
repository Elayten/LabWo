    using JonDou9000.TaskPlanner.DataAccess.Abstractions;
    using JonDou9000.TaskPlanner.Domain.Models;

    namespace JonDou9000.TaskPlanner.Domain.Logic
    {
        public class SimpleTaskPlanner
        {
            private readonly IWorkItemsRepository _repository;

            public SimpleTaskPlanner(IWorkItemsRepository repository)
            {
                _repository = repository;
            }

            public Guid AddTask(WorkItem item)
            {
                return _repository.Add(item);
            }

            public WorkItem[] GetAllTasks()
            {
                return _repository.GetAll();
            }

            public WorkItem? GetTask(Guid id)
            {
                return _repository.Get(id);
            }

            public bool UpdateTask(WorkItem item)
            {
                return _repository.Update(item);
            }

            public bool RemoveTask(Guid id)
            {
                return _repository.Remove(id);
            }

            public void Save()
            {
                _repository.SaveChanges();
            }

            // 🔥 Ось метод, якого тобі бракувало
            public WorkItem[] CreatePlan()
            {
                return _repository
                    .GetAll()
                    .OrderByDescending(x => x.Priority)     // спочатку високий пріоритет
                    .ThenBy(x => x.DueDate)                 // потім найближчий дедлайн
                    .ToArray();
            }
        }
    }
