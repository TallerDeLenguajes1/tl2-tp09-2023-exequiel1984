using System.Data.SQLite;

namespace Practico9
{
    public class TareaRepository : ITareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public Tarea Create(Tarea tarea)
        {
            var query = @"
            INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado)
            VALUES (@idTablero, @nombre , @estado, @descripcion, @color, @idUsuarioAsignado);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
                command.ExecuteNonQuery();
                connection.Close();
            }
            return tarea;
        }

        public void UpDateNombre(int id, string Nombre){
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tarea SET nombre = @nombre
                WHERE id = @id;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                //command.Parameters.Add(new SQLiteParameter("@idTablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", Nombre));
                /* command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado)); */
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpDateEstado(int id, EstadoTarea Estado){
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var queryString = @"
                UPDATE Tarea SET estado = @estado
                WHERE id = @id;";
                connection.Open();
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estado", Estado));
                command.Parameters.Add(new SQLiteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Tarea GetById(int id)
        {
            Tarea tarea = new Tarea();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                string queryString = @"SELECT * FROM Tarea WHERE id = @idTarea;";
                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", id));
                connection.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    }
                }
                connection.Close();
            }
            return tarea;
        }
    }
}