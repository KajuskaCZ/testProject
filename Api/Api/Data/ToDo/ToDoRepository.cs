using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.ToDo
{
    public class ToDoRepository
    {
        public ToDoRepository() {
            defaultData();
        }

        public void defaultData() {
            toDoList.Add(new ToDoModel() { Id = 1, Name = "D", Check = false });
            toDoList.Add(new ToDoModel() { Id = 2, Name = "C", Check = false });
            toDoList.Add(new ToDoModel() { Id = 3, Name = "A", Check = true });
            toDoList.Add(new ToDoModel() { Id = 4, Name = "B", Check = false });
            toDoList.Add(new ToDoModel() { Id = 5, Name = "F", Check = false });
            toDoList.Add(new ToDoModel() { Id = 6, Name = "E", Check = true });
            toDoList.Add(new ToDoModel() { Id = 7, Name = "H", Check = true });
            toDoList.Add(new ToDoModel() { Id = 8, Name = "G", Check = false });
        }

        public List<ToDoModel> toDoList = new List<ToDoModel>();

        public List<ToDoModel> Get() {
            return toDoList;
        }

        public bool Put(Decimal id, string value)
        {
            if(toDoList.Exists(x => x.Id == id))
                return true;
            return false;
        }
    }
}
