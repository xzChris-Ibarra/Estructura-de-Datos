using System;
// Nodo de la lista enlazada que representa un término del polinomio
public class Termino
{
    public int Coeficiente { get; set; }
    public int Exponente { get; set; }

    //apuntador al siguiente nodo
    public Termino Siguiente { get; set; }

    //constructor para crear un nuevo termino
    public Termino(int coef, int exp)
    {
        Coeficiente = coef;
        Exponente = exp;
        Siguiente = null; //al crearse no apunta a nada
    }
}
