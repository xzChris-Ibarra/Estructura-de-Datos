
namespace Proyecto_ArbolDiccionario
{
    public class Nodo<T>
    {
        public T Valor { get; set; }
        public List<Nodo<T>> Hijos { get; set; }
        public Videojuego? Info { get; set; }
        public Nodo(T valor) { 
            Valor = valor;
            Hijos = new List<Nodo<T>>();
            Info = null;
        }
        public void AddHijo(Nodo<T> hijo) {
            Hijos.Add(hijo);
        }
        public bool EsHoja() {
            return Hijos.Count == 0;
        }
    }
}
