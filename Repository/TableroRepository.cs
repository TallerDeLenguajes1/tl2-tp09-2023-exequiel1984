using System.Data.SQLite;

namespace Practico9
{
    public class TableroRepository : ITableroRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Tablero tablero)
        {
            var query = @"
            INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion)
            VALUES (@usuarioPropietario, @nombre , @descripcion);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@usuarioPropietario", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        
        public List<Tablero> GetAll()
        {
            string query = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();

                using (SQLiteDataReader Reader = command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Tablero tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(Reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(Reader["id_usuario_propietario"]);
                        tablero.Nombre = Reader["nombre"].ToString();
                        tablero.Descripcion = Reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }

                connection.Close();
            }
            return tableros;
        }
    }
}