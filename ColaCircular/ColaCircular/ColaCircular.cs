using System;
using System.Collections.Generic;
public enum PoliticaSaturacion
{
    REJECT_NEW,
    DROP_OLDEST
}

public class ColaCircular<T>
{
    public T[] buffer;
    public int head;   //primer elemento
    public int tail;   //proxima celda libre
    public int count; 
    public int capacidad; //variable de la clase

    //politica a elegir en ejecucion
    public PoliticaSaturacion politica;
                          
    public ColaCircular(int capacidad, PoliticaSaturacion politicaInicial)
    {                   //variable del parametro
        this.capacidad = capacidad;
        this.buffer = new T[this.capacidad];
        this.head = 0;
        this.tail = 0;
        this.count = 0;
        this.politica = politicaInicial;
    }
    //metodos de estado
    public int ObtenerCount() => count;
    public bool IsEmpty() => count == 0;
    public bool IsFull() => count == capacidad;
    //metodos de operacionb
    public T VerFrente()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: La cola está vacía.");
            return default(T);
        }
        return buffer[head];
    }
    public void Encolar(T cliente)
    {
        if (IsFull())
        {
            //si esta lleno, se aplica politica
            if (politica == PoliticaSaturacion.REJECT_NEW)
            {
                Console.WriteLine($"Rechazado: {cliente} (capacidad llena)");
                return; //no se encola
            }
            else if (politica == PoliticaSaturacion.DROP_OLDEST)
            {
                //descartar el mas antiguo y encolar el nuevo
                T antiguo = buffer[head];
                head = (head + 1) % capacidad;
                count--; //reduccion temporal del count para hacer espacio
                Console.WriteLine($"Se descartó al más antiguo: {antiguo}; Entró: {cliente}");
            }
        }
        //si hay espacio, se encola normal
        buffer[tail] = cliente;
        tail = (tail + 1) % capacidad; //avanza tail con modulo
        count++;
    }
    public T Desencolar()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: La cola está vacía.");
            return default(T);
        }
        //obtener el cliente en el frente y avanzar head
        T clienteAtendido = buffer[head];
        buffer[head] = default(T); //limpiar la celda
        head = (head + 1) % capacidad; //avanza head con modulo
        count--;
        Console.WriteLine($"{clienteAtendido} ha sido desencolado.");
        return clienteAtendido;
    }
    public void Visualizar()
    {
        Console.WriteLine($"Capacidad = {capacidad} | COUNT={count} | HEAD={head} | TAIL={tail}");
        // --- 1. Visualización del Buffer ---
        Console.Write("Buffer idx: ");
        for (int i = 0; i < capacidad; i++) Console.Write($"[{i}]");
        Console.WriteLine();

        Console.Write("Contenido:  ");

        // Para mostrar [---] en celdas vacías, necesitamos saber cuáles están ocupadas
        // Creamos un array temporal para marcar las celdas ocupadas
        bool[] estaOcupado = new bool[capacidad];
        int indiceActualFIFO = head;
        for (int i = 0; i < count; i++)
        {
            estaOcupado[indiceActualFIFO] = true;
            indiceActualFIFO = (indiceActualFIFO + 1) % capacidad;
        }

        // Ahora recorremos el buffer y pintamos según esté ocupado o no
        for (int i = 0; i < capacidad; i++)
        {
            if (estaOcupado[i])
            {
                Console.Write($"[{buffer[i]}]");
            }
            else
            {
                Console.Write("[---]");
            }
        }
        Console.WriteLine();

        //visualizar fifo
        Console.Write("FIFO actual: ");
        if (IsEmpty())
        {
            Console.WriteLine("[Vacía]");
        }
        else
        {
            indiceActualFIFO = head; //reiniciar indice al head
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[indiceActualFIFO]);
                if (i < count - 1) Console.Write(" -> ");

                indiceActualFIFO = (indiceActualFIFO + 1) % capacidad; //avanzar con modulo
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('=', 50)); // Separador
    }
}