using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext context;

        public TodoRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Todo todo)
        {
            this.context.Add(todo);
            this.context.SaveChanges();
        }
        public void Update(Todo todo)
        {
            this.context.Update(todo);
            this.context.SaveChanges();
        }
        public void UpdateById(int id, Todo todo)
        {
            Todo updateTodo = context.Todos.Find(id);
            if (todo.Id.Equals(null))
                updateTodo.Id = todo.Id;
            if (todo.Description != null)
                updateTodo.Description = todo.Description;
            if (todo.Created != null)
                updateTodo.Created = todo.Created;
            if (todo.IsDone.Equals(null))
                updateTodo.IsDone = todo.IsDone;
            this.context.SaveChanges();
        }

        public IEnumerable<Todo> GetAll()
        {
            return this.context.Todos.ToList();
        }

        public Todo GetById(int id)
        {
            return this.context.Todos.Find(id);
        }
        public void Remove(Todo todo)
        {
            this.context.Remove(todo);
            this.context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            Todo toDelete = this.context.Todos.Find(id);
            this.context.Remove(toDelete);
            this.context.SaveChanges();
        }

        public IEnumerable<Todo> GetTodoDone()
        {
            //List<Todo> list = this.context.Todos.ToList();
            //List<Todo> newList = list.FindAll(x => x.IsDone == true);
            return this.context.Todos.Where(todo => todo.IsDone == true);
        }

        public IEnumerable<Todo> GetTodoActive()
        {
            //List<Todo> list = this.context.Todos.ToList();
            //List<Todo> newList = list.FindAll(x => x.IsDone == false);
            return this.context.Todos.Where(todo => todo.IsDone == false);
        }
    }
}