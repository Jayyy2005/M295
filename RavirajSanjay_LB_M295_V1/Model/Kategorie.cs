namespace RavirajSanjay_LB_M295_V1.Model
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Titel { get; set; }

        public List<ToDo> ToDos { get; set; }

        public int GetNr()
        {
            return Id;
        }

        public string GetKategorie()
        {
            return Titel;
        }

        public List<ToDo> GetToDos()
        {
            return ToDos;
        }
    }
}
