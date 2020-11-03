using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using API.Entities;
namespace API.Data
{
    public class TodoDbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Todos.Any())
            {
                return;  
            }
            var todos = new Todo[]
            {new Todo {Id = 1, Description = "description1", Created =  new DateTime(2000, 01, 10),IsDone = true},
            new Todo { Id = 2, Description = "description2", Created = new DateTime(2001, 01, 10), IsDone = true },
            new Todo { Id = 3, Description = "description3", Created = new DateTime(2002, 01, 10), IsDone = false },
            new Todo { Id = 4, Description = "description4", Created = new DateTime(2003, 01, 10), IsDone = true },
            new Todo { Id = 5, Description = "description5", Created = new DateTime(2004, 01, 10), IsDone = false },};
            foreach (Todo s in todos)
            {
                context.Todos.Add(s);
            }
            context.SaveChanges();

        }
    }
}