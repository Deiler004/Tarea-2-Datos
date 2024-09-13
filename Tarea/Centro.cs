using System;

public class ListNode
{
    public int Value { get; set; }
    public ListNode NextNode { get; set; }

    public ListNode(int value)
    {
        Value = value;
        NextNode = null;
    }
}

public class OrderedLinkedList
{
    public ListNode HeadNode { get; set; }
    private ListNode middleNode; // Nodo que mantiene el elemento central
    private int nodeCount; // Número de nodos en la lista

    public OrderedLinkedList()
    {
        HeadNode = null;
        middleNode = null;
        nodeCount = 0;
    }

    // Método para insertar múltiples elementos en orden
    public void InsertInOrder(params int[] values)
    {
        foreach (var value in values)
        {
            ListNode newNode = new ListNode(value);

            if (HeadNode == null)
            {
                HeadNode = newNode;
                middleNode = newNode;
            }
            else
            {
                // Insertar al final de la lista en el orden recibido
                ListNode currentNode = HeadNode;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }
                currentNode.NextNode = newNode;
            }

            nodeCount++;
            UpdateMiddle();
        }
    }


    // Método para actualizar el nodo central
    private void UpdateMiddle()
    {
        if (nodeCount % 2 == 0)
        {
            // Si hay un número par de nodos, tomamos el nodo (nodeCount / 2 - 1)
            middleNode = GetNodeAt(nodeCount / 2 );
        }
        else
        {
            // Si hay un número impar de nodos, tomamos el nodo en (nodeCount / 2)
            middleNode = GetNodeAt(nodeCount / 2);
        }
    }

    // Método para obtener el nodo en la posición dada (cuenta desde 0)
    private ListNode GetNodeAt(int index)
    {
        ListNode currentNode = HeadNode;
        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.NextNode;
        }
        return currentNode;
    }

    // Método para obtener el elemento central
    public int GetMiddle()
    {
        if (middleNode == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }
        return middleNode.Value;
    }
}



