using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Linked list
            var dll = new DoublyLinkedList<int>(7);

            dll.Print();
            
            //Push 1 at the beginning of the list
            dll.Push(1);

            //Push 2 at the beginning of the list
            dll.Push(2);
           
            //Push 4 after Head.Next
            var four = dll.InsertAfter(dll.Head.Next, 4);

            //Push 5 before 1
            dll.InsertBefore(dll.Head.Next, 5);

            //Append 9
            var nine = dll.Append(9);

            //Deletes 2 and makes 1 Head
            dll.Delete(dll.Head);

            //Delete 9
            dll.Delete(nine);

            //Delete 4
            dll.Delete(four);

            Console.ReadLine();

            dll.Print();
            //Finish program
            Console.ReadLine();
        }
    }

    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }


        /// <summary>
        /// Initializes doubly linked list with a new node as head.
        /// </summary>
        /// <param name="data">Node's data</param>
        public DoublyLinkedList(T data)
        {
            Head = GetNewNode(data);
        }

        /// <summary>
        /// Spawns a new node having the same type as linked list.
        /// </summary>
        /// <param name="data">Node's data.</param>
        /// <returns>Node<typeparamref name="T"/></returns>
        public Node<T> GetNewNode(T data)
        {
            return new Node<T>(data);
        }

        /// <summary>
        /// Traverse list and print the items.
        /// </summary>
        public void Print()
        {
            var pointer = Head;

            while(pointer != null)
            {
                Console.WriteLine("Value of this node is {0}.", pointer.Data);
                pointer = pointer.Next;
            }
        }

        /// <summary>
        /// Pushes a node at the start of the List.
        /// </summary>
        /// <param name="data">Node's data.</param>
        /// <returns>First node on the list.</returns>
        public Node<T> Push(T data)
        {
            var node = GetNewNode(data);
            node.Prev = null;
            node.Next = Head;
            Head.Prev = node;
            Head = node;

            Console.WriteLine("Pushing {0} at the start of the list.", node.Data);

            return Head;
        }

        /// <summary>
        /// Inserts after a given node.
        /// </summary>
        /// <param name="node">Previous node.</param>
        /// <param name="data">Node's data.</param>
        /// <returns>Inserted Node<typeparamref name="T"/></returns>
        public Node<T> InsertAfter(Node<T> node, T data)
        {
            var newNode = GetNewNode(data);

            newNode.Next = node.Next;
            node.Next = newNode;
            newNode.Prev = node;

            if(newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }

            Console.WriteLine("Inserting {0} after {1}.", data, node.Data);

            return newNode;
        }

        /// <summary>
        /// Appends a node to the end of the list.
        /// </summary>
        /// <param name="data">Node's data.</param>
        /// <returns>Node<typeparamref name="T"/></returns>
        public Node<T> Append(T data)
        {
            var node = GetNewNode(data);
            var last = Head;

            while(last.Next != null)
            {
                last = last.Next;
            }

            last.Next = node;
            node.Next = null;
            node.Prev = last;

            Console.WriteLine("Inserting {0} at the end of the list.", node.Data);

            return node;
        }

        /// <summary>
        /// Insert before a given node.
        /// </summary>
        /// <param name="node">Next node.</param>
        /// <param name="data">Node's data.</param>
        /// <returns>Node<typeparamref name="T"/></returns>
        public Node<T> InsertBefore(Node<T> node, T data)
        {
            var newNode = GetNewNode(data);

            newNode.Prev = node.Prev;
            node.Prev = newNode;
            newNode.Next = node;

            if(newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }

            Console.WriteLine("Inserting {0} before {1}.", data, node.Data);

            return newNode;
        }

        /// <summary>
        /// Deletes a given node
        /// </summary>
        /// <param name="node">Node to delete</param>
        public void Delete(Node<T> node)
        {
            Console.WriteLine("Deleting {0}", node.Data);

            if (node == Head)
            {
                Head = node.Next;
                Head.Prev = null;
                return;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
        }


    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes Node T
        /// </summary>
        /// <param name="data">Node's data.</param>
        public Node(T data)
        {
            Data = data;
        }

    }
}
