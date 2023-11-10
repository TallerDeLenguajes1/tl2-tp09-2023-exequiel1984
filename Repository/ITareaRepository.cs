namespace Practico9
{
    public interface ITareaRepository
    {
        public Tarea Create(Tarea tarea);
        public void UpDateNombre(int id, string nombre);
        public void UpDateEstado(int id, EstadoTarea Estado);
        public Tarea GetById(int id);
        public List<Tarea> GetAllByIdUsuario(int idUsuario);
    }
}