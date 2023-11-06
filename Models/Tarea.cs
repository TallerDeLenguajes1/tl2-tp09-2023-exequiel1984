namespace Practico9
{
    public enum EstadoTarea
    {
        Ideas,
        ToDo,
        Doing,
        Review,
        Done    
    }

    public class Tarea
    {
        private int id;
        private int idTablero;
        private string nombre;
        private EstadoTarea estado;
        private string descripcion;
        private string color;
        private int idUsuarioAsignado;
    }
}