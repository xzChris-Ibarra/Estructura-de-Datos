

namespace Proyecto_ArbolDiccionario
{
    public class Arbol
    {
        public Nodo<string> Raiz {  get; set; }
        public Arbol(string valor) {
            Raiz = new Nodo<string>(valor);
        }
        public Nodo<string> AgregarHijo(Nodo<string> padre, string valor) {
            var newNodo = new Nodo<string>(valor);
            padre.AddHijo(newNodo);
            return newNodo;
        }
        public Nodo<string>? Find(string valor)
        {
            return FindRecursive(Raiz, valor);
        }
        private Nodo<string>? FindRecursive(Nodo<string> actual, string valor)
        {
            if (actual.Valor.Equals(valor, StringComparison.OrdinalIgnoreCase))
                return actual;

            foreach (var hijo in actual.Hijos)
            {
                var found = FindRecursive(hijo, valor);
                if (found != null)
                    return found;
            }

            return null;
        }
        public void MostrarArbol(Nodo<string> actual, string sangria = " ") {
            Console.WriteLine(sangria+"- "+ actual.Valor);
            foreach (var hijo in actual.Hijos)
                MostrarArbol(hijo, sangria+" ");
        }
        public void Navigate()
        {
            Nodo<string> actual = Raiz;

            while (true)
            {
                Console.WriteLine($"\n Estás en: {actual.Valor}");

                if (actual.EsHoja())
                {
                    Console.WriteLine("\nEste es un nodo final.\n");
                    actual.Info?.Print();
                    return;
                }

                Console.WriteLine("\nOpciones:");
                for (int i = 0; i < actual.Hijos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {actual.Hijos[i].Valor}");
                }
                Console.WriteLine("0. Salir");

                Console.Write("\nElige una opción: ");
                string input = Console.ReadLine();

                if (input == "0") return;

                if (int.TryParse(input, out int option) &&
                    option >= 1 &&
                    option <= actual.Hijos.Count)
                {
                    actual = actual.Hijos[option - 1];
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }
    }
}
