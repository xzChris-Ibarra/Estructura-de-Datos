
namespace Proyecto_ArbolDiccionario
{
    public class Videojuego
    {
        public Dictionary<string, string> Atributos { get; private set; }
        public Videojuego() { 
            Atributos = new Dictionary<string, string>();
        }
        public void Add(string key, string value) {
            Atributos[key] = value;
        }
        public void Print() {
            Console.WriteLine("===== Información del Videojuego");
            foreach (var kvp in Atributos)
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            Console.WriteLine("================================");
        }
    }
}
