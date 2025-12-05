
namespace Proyecto_ArbolDiccionario
{
    public class Principal
    {
        static void Main(string[] args) {
            Arbol arbolVideojuegos = CrearArbol();
            int opc = 0;
            do {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       CLASIFICADOR DE VIDEOJUEGOS  ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Iniciar navegación por el árbol");
                Console.WriteLine("2. Mostrar estructura del árbol");
                Console.WriteLine("3. Mostrar información de un videojuego");
                Console.WriteLine("4. Salir");
                Console.WriteLine("====================================");
                Console.Write("Selecciona una opción: ");
                try {
                    opc = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opc) {
                        case 1:
                            Console.WriteLine("===== Navegación =====");
                            arbolVideojuegos.Navigate();
                            Console.WriteLine("\nPresiona enter para continuar...");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("===== Estructura del Árbol");
                            arbolVideojuegos.MostrarArbol(arbolVideojuegos.Raiz);
                            Console.Write("\nPresione enter para continuar...");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("=== CONSULTAR VIDEOJUEGO ===");
                            Console.Write("Ingresa el nombre del videojuego: ");
                            string nombre = Console.ReadLine();

                            var nodo = arbolVideojuegos.Find(nombre);

                            if (nodo != null && nodo.EsHoja())
                            {
                                nodo.Info.Print();
                            }
                            else
                            {
                                Console.WriteLine("El videojuego no existe o no es un nodo final.");
                            }

                            Console.WriteLine("\nPresiona enter para continuar...");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            break;
                    }
                } catch (Exception e) { Console.WriteLine(e.Message); }
            } while (opc != 4);
        }
        static Arbol CrearArbol()
        {
            var arbol = new Arbol("Videojuegos");

            // Géneros
            var accion = arbol.AgregarHijo(arbol.Raiz, "Acción");
            var rpg = arbol.AgregarHijo(arbol.Raiz, "RPG");

            // Subgéneros
            var shooter = arbol.AgregarHijo(accion, "Shooter");
            var plataformas = arbol.AgregarHijo(accion, "Plataformas");

            // Videojuego hoja con diccionario
            var doom = arbol.AgregarHijo(shooter, "DOOM Eternal");
            doom.Info = new Videojuego();
            doom.Info.Add("Año", "2020");
            doom.Info.Add("Plataforma", "PC, PS5, Xbox");
            doom.Info.Add("Desarrollador", "id Software");
            doom.Info.Add("Género", "Shooter");

            var hk = arbol.AgregarHijo(plataformas, "Hollow Knight");
            hk.Info = new Videojuego();
            hk.Info.Add("Año", "2017");
            hk.Info.Add("Plataforma", "PC, Switch, PS4, Xbox");
            hk.Info.Add("Desarrollador", "Team Cherry");
            hk.Info.Add("Género", "Metroidvania");

            var baldursGate = arbol.AgregarHijo(rpg, "Baldur's Gate III");
            baldursGate.Info = new Videojuego();
            baldursGate.Info.Add("Año", "2023");
            baldursGate.Info.Add("Plataforma", "PC, PS5, Xbox Series");
            baldursGate.Info.Add("Desarrollador", "Larian Studios");
            baldursGate.Info.Add("Género", "RPG");

            return arbol;
        }
    }
}
