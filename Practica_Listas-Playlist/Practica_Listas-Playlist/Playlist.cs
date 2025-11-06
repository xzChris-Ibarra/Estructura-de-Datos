using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Listas_Playlist
{
    public class  Playlist
    {
        public List<string> canciones = new List<string>();
        public void AgregarCancion(string cancion)
        {
            Console.Write("Escriba el nombre de la cancion a agregar: ");
            string nuevaCancion = Console.ReadLine();
            canciones.Add(nuevaCancion);
            Console.WriteLine($"Cancion '{nuevaCancion}' agregada a la playlist.");
        }
        public void InsertarCancion(string cancion, int posicion)
        {
            Console.Write("Escriba el nombre de la cancion a insertar: ");
            string cancionInsertar = Console.ReadLine();
            Console.Write("Escriba la posicion donde desea insertar la cancion: ");
            int posicionInsertar = int.Parse(Console.ReadLine());
            canciones.Insert(posicionInsertar, cancionInsertar);
            Console.WriteLine($"Cancion '{cancionInsertar}' insertada en la posicion {posicionInsertar}.");
        }
        public void EliminarCancion(string cancion)
        {
            Console.Write("Escriba el nombre de la cancion a eliminar: ");
            string cancionEliminar = Console.ReadLine();
            if (canciones.Remove(cancionEliminar))
            {
                Console.WriteLine($"Cancion '{cancionEliminar}' eliminada de la playlist.");
            }
            else
            {
                Console.WriteLine($"La cancion '{cancionEliminar}' no se encontro en la playlist.");
            }
        }
        public void MostrarCanciones()
        {
            Console.WriteLine("Canciones en la playlist:");
            foreach (var cancion in canciones)
            {
                Console.WriteLine("- " + cancion);
            }
        }

    }
}
