using System.ComponentModel.DataAnnotations;

namespace RavirajSanjay_LB_M295_V1.Model
{
    public class ToDo
    {
        [Key]

        public int Id { get; set; }
        public string ToDoName { get; set; }

        public int GetNr()
        {
            return Id;
        }

        public string GetToDoName()
        {
            return ToDoName;
        }
    }
}