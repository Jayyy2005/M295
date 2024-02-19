namespace RavirajSanjay_LB_M295_V1.Model
{
    public class Auflösungstabelle
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public List<int> ToDoNr { get; set; }

        public string GetTitelNr()
        {
            return Titel;
        }

        public List<int> GetToDoNr()
        {
            return ToDoNr;
        }
    }
}