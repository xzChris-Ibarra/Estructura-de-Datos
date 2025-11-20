using System;

//clase principal que gestiona la cadena de nodos Termino
public class Polinomio
{
    public Termino head;
    public Polinomio()
    {
        head = null; //lista empieza vacia
    }

    public void Agregar(int coef, int exp)
    {
        Termino nuevoTermino = new Termino(coef, exp);
        if (head == null) 
        {
            head = nuevoTermino; //si la lista esta vacia, el nuevo termino es la cabeza
        }
        else
        {
            //sino, se viaja hasta el final de la lista
            Termino actual = head;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoTermino; //se enlaza el ultimo termino con el nuevo
        }
    }

    public void Mostrar()
    {
        if (head == null)
        {
            Console.WriteLine("El polinomio está vacío.");
            return;
        }
        Termino actual = head;
        string resultado = "";

        while (actual != null)
        {
            //formatear cada termino
            if (actual.Coeficiente != 0)
            {
                if (resultado.Length > 0 && actual.Coeficiente > 0)
                {
                    resultado += " + ";
                }
                else if (actual.Coeficiente < 0)
                {
                    resultado += " - ";
                }

                int coefAbs = Math.Abs(actual.Coeficiente);
                if (coefAbs != 1 || actual.Exponente == 0)
                {
                    resultado += coefAbs;
                }
                if (actual.Exponente > 0)
                {
                    resultado += "x";
                    if (actual.Exponente > 1)
                    {
                        resultado += $"^{actual.Exponente}";
                    }
                }
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine(resultado);
    }
    //evaluar el polinomio con un valor x
    public double Evaluar(int x)
    {
        double resultado = 0;
        Termino actual = head;
        //recorrer la lista
        while (actual != null)
        {
            //sumar el (coeficiente * (x^exponente))
            resultado += actual.Coeficiente * Math.Pow(x, actual.Exponente);
            actual = actual.Siguiente;
        }
        return resultado;
    }

    public Polinomio Derivar()
    {
        //la derivada sera un nuevo polinomio
        Polinomio derivada = new Polinomio();
        Termino actual = head;
        //recorrer el polinomio original
        while (actual != null)
        {
            //derivacion (c*e) * x^(e-1)
            int nuevoCoef = actual.Coeficiente * actual.Exponente;
            int nuevoExp = actual.Exponente - 1;
            //si el nuevo coeficiente es 0 no se agrega
            if (nuevoCoef != 0)
            {
                derivada.Agregar(nuevoCoef, nuevoExp);
            }
            actual = actual.Siguiente;
        }
        return derivada;
    }
}
