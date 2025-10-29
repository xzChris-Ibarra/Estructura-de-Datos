using System;

class Program
{
    static void Main(string[] args)
    {
        //matricula 240247
        int capacidad = 8; //C = 5 + (19 % 4) = 5 + 3 = 8
        string[] nombres = {
            "Elena", "Jorge", "Karla", "Ana", "Luis",
            "María", "Pedro", "Sofía", "Juan", "Pablo"
        };

        int nombreIndex = 0;
        //inicio de cola con politica por defecto
        PoliticaSaturacion politicaActual = PoliticaSaturacion.REJECT_NEW;
        ColaCircular<string> cola = new ColaCircular<string>(capacidad, politicaActual);

        Console.WriteLine("Simulación de Ventanilla con Cola Circular");
        Console.WriteLine($"Matrícula asumida: 12345 -> Capacidad (C) = {capacidad}");
        Console.WriteLine("Estado inicial de la cola:");
        cola.Visualizar();

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ DE OPERACIONES ---");
            Console.WriteLine("1. Encolar Cliente (E)");
            Console.WriteLine("2. Desencolar Cliente (D)");
            Console.WriteLine($"3. Cambiar Política (Actual: {politicaActual})");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                case "e":
                case "E":
                    string cliente = nombres[nombreIndex % nombres.Length];
                    nombreIndex++;
                    Console.WriteLine($"\n==> Operación: Encolar a {cliente}");
                    cola.Encolar(cliente);
                    cola.Visualizar();
                    break;
                case "2":
                case "d":
                case "D":
                    Console.WriteLine("\n==> Operación: Desencolar");
                    cola.Desencolar();
                    cola.Visualizar();
                    break;
                case "3":
                    if (politicaActual == PoliticaSaturacion.REJECT_NEW)
                    {
                        politicaActual = PoliticaSaturacion.DROP_OLDEST;
                    }
                    else
                    {
                        politicaActual = PoliticaSaturacion.REJECT_NEW;
                    }
                    cola.politica = politicaActual; //actualizar politica en cola
                    Console.WriteLine($"\n==> Política actualizada a: {politicaActual}");
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Fin de la simulación.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}