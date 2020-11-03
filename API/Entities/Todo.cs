using System;

namespace API.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool IsDone { get; set; }
        public Todo()
        {
            IsDone=false;
        }
    }
}