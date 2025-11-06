namespace Practica_Listas_Playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Playlist miPlaylist = new Playlist();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\nMenu de la Playlist:");
                Console.WriteLine("1. Agregar cancion");
                Console.WriteLine("2. Insertar cancion en posicion");
                Console.WriteLine("3. Eliminar cancion");
                Console.WriteLine("4. Mostrar canciones");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion (1-5): ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        miPlaylist.AgregarCancion("");
                        break;
                    case "2":
                        miPlaylist.InsertarCancion("", 0);
                        break;
                    case "3":
                        miPlaylist.EliminarCancion("");
                        break;
                    case "4":
                        miPlaylist.MostrarCanciones();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }
    }
}