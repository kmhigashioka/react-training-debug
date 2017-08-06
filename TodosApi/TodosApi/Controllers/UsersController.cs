using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodosApi.Domain;

namespace TodosApi.Controllers
{
    public class UsersController : ApiController
    {
        public static List<User> Users = new List<User>{
            new User {
                Id = 1,
                Name = "Juan Dela Cruz",
                Description = "Tall, dark and handsome.",
                Todos = new List<Todo>{
                    new Todo {
                        Id = 1,
                        Task = "Eat some fries",
                        Date = DateTime.Now,
                        Done = false
                    },
                    new Todo {
                        Id = 2,
                        Task = "Write some code",
                        Date = DateTime.Now,
                        Done = true
                    }
                }
            },
            new User {
                Id = 2,
                Name = "April Santos",
                Description = "Strong and independent woman.",
                Todos = new List<Todo>()
            }
        };

        public IHttpActionResult Get()
        {
            return Ok(Users);
        }

        public IHttpActionResult Get(int userId)
        {
            return Ok(Users.First(t => t.Id == userId));
        }
    }
}
