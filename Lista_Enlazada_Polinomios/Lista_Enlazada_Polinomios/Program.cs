using System;

class Program
{
    static void Main(string[] args)
    {
        //instancia polinomio
        Polinomio miPolinomio = new Polinomio();
        //polinomio del ejemplo
        miPolinomio.Agregar(3, 4);
        miPolinomio.Agregar(-4, 2);
        miPolinomio.Agregar(11, 0);

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Lista Enlazada - Polinomios ---");
            Console.Write("Polinomio actual: ");
            miPolinomio.Mostrar();
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Agregar termino al final");
            Console.WriteLine("2. Evaluar polinomio con un valor de x");
            Console.WriteLine("3. Obtener la derivada"); 
            Console.WriteLine("4. Salir");
            Console.Write("Elija una opcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AgregarTermino(miPolinomio);
                    break;
                case "2":
                    EvaluarPolinomio(miPolinomio);
                    break;
                case "3":
                    CalcularDerivada(miPolinomio);
                    break;
                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void AgregarTermino(Polinomio p)
    {
        try
        {
            Console.Write("Introduce el Coeficiente: ");
            int coef = int.Parse(Console.ReadLine());

            Console.Write("Introduce el Exponente: ");
            int exp = int.Parse(Console.ReadLine());

            p.Agregar(coef, exp);
            Console.WriteLine("Término agregado.");
        }
        catch (Exception)
        {
            Console.WriteLine("Entrada no válida. Introduce solo números.");
        }
    }

    static void EvaluarPolinomio(Polinomio p)
    {
        try
        {
            Console.Write("Introduce el valor de x: ");
            int x = int.Parse(Console.ReadLine());

            double resultado = p.Evaluar(x);
            Console.WriteLine($"El resultado de P({x}) es: {resultado}");
        }
        catch (Exception)
        {
            Console.WriteLine("Entrada no válida. Introduce solo un número.");
        }
    }

    static void CalcularDerivada(Polinomio p)
    {
        //derivar devuelve un nuevo polinomio
        Polinomio derivada = p.Derivar();

        Console.WriteLine("La derivada es:");
        derivada.Mostrar();
    }
}