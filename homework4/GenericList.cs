using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = null;
            tail = null;

        }

        public Node<T> Head
        {
            get => head;
        }
        public Node<T> Tail
        {
            get => tail;
        }


        public void addNode(T data) {
            Node<T> node = new Node<T>(data);
            if (head == null) { head = tail = node; }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }


        public void Foreach(Action<T>action){
            Node<T> temp = head;
            while (temp != null)
            {
                action(temp.Data);
                temp = temp.Next;
            }
        }
        
    }
}
