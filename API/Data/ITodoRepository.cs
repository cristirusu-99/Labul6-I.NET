using API.Entities;
using System.Collections.Generic;
namespace API.Data
{
    public interface ITodoRepository
    {
        void Create(Todo todo);
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        IEnumerable<Todo> GetTodoActive();
        IEnumerable<Todo> GetTodoDone();
        void Remove(Todo product);
        void RemoveById(int id);
        void Update(Todo todo);
        void UpdateById(int id, Todo todo);
    }
}