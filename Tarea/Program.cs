using System;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomLinkedList
{
    public Node Head { get; set; }

    public CustomLinkedList()
    {
        Head = null;
    }

    // Método para añadir múltiples nodos al final de la lista
    public void Add(params int[] data)
    {
        foreach (var item in data)
        {
            Node newNode = new Node(item);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
    }

    // Método para invertir la lista
    public void Reverse()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        Node prev = null;
        Node current = Head;
        Node next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        Head = prev;
    }

    // Método para obtener los elementos de la lista como una cadena
    public override string ToString()
    {
        if (Head == null)
        {
            return "vacia";
        }

        Node current = Head;
        System.Collections.Generic.List<int> elements = new System.Collections.Generic.List<int>();

        while (current != null)
        {
            elements.Add(current.Data);
            current = current.Next;
        }

        return string.Join(",", elements);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Programa de prueba ejecutado.");

        // Crear una instancia de CustomLinkedList y agregar elementos
        var lista = new CustomLinkedList();
        lista.Add(2, 1, 5, 4, 6, 78, 4);

        // Imprimir la lista original
        Console.WriteLine("Lista original: " + lista.ToString());

        // Invertir la lista
        lista.Reverse();

        // Imprimir la lista invertida
        Console.WriteLine("Lista invertida: " + lista.ToString());
    }
}




