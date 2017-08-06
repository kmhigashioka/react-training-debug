using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodosApi.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
    }
}
