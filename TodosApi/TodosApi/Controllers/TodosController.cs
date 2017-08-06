using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodosApi.Domain;

namespace TodosApi.Controllers
{
    public class TodosController : ApiController
    {
        public IHttpActionResult Get(int userId)
        {
            return Ok(
                UsersController
                    .Users
                    .First(t => t.Id == userId)
                    .Todos
            );
        }

        public IHttpActionResult Post(int userId, [FromBody] Todo todo)
        {
            todo.Id = new Random().Next();
            UsersController.Users.First(t => t.Id == userId).Todos.Add(todo);
            return Created("", todo);
        }

        public IHttpActionResult Put(int userId, [FromBody] Todo todo)
        {
            var storedTodo = UsersController
                .Users
                .First(t => t.Id == userId)
                .Todos
                .First(t => t.Id == todo.Id);

            storedTodo.Task = todo.Task;
            storedTodo.Done = todo.Done;
            storedTodo.Date = todo.Date;

            return Ok(storedTodo);
        }

        public IHttpActionResult Delete(int userId, int todoId)
        {
            var todo = UsersController
                .Users
                .First(t => t.Id == userId)
                .Todos
                .First(t => t.Id == todoId);

            UsersController
                .Users
                .First(t => t.Id == userId)
                .Todos
                .Remove(todo);

            return Ok(true);
        }
    }
}
