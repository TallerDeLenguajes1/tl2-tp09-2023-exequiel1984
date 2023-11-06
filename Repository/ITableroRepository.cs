namespace Practico9
{
    public interface ITableroRepository
    {
        public void Create(Tablero tablero);
        public List<Tablero> GetAll();
    }
}