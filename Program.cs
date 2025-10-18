using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda_final.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un programa real
    // la aplicamos para poder crear nuestra base de datos desde cero


    // Insertar datos
    string insertQuery = "INSERT INTO Productos (Descripcion, Precio) VALUES ('Funda Notebook', 25000)";
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'Productos'.");
    }

    // Leer datos
    string selectQuery = "SELECT * FROM Productos";
    using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
    using (SqliteDataReader reader = selectCmd.ExecuteReader())
    {
        Console.WriteLine("Datos en la tabla 'productos':");
        while (reader.Read())
        {
            Console.WriteLine($"Id Producto: {reader["idProducto"]}, Descripcion: {reader["Descripcion"]}, Precio: {reader["Precio"]}");
        }
    }

    connection.Close();
}