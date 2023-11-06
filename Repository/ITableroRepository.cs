namespace Practico9
{
    public interface ITableroRepository
    {
        public Tablero Create(Tablero tablero);
        public void UpDate(int id, Tablero tablero);
        public Tablero GetById(int id);
        public List<Tablero> GetAll();
        public List<Tablero> GetAllByIdUsuario(int idUsuario);
        public void Remove(int id);
    }
}