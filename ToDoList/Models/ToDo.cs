using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("ToDo")]
    public class ToDo
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public DateTime PlannedDate { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
