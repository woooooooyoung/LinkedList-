using System.Security.Cryptography.X509Certificates;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedList<T> list;
        public LinkedListNode<T> prev;
        public LinkedListNode<T> next;
        public T item;
        public int mp;

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
            
        }
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedListNode<T> Next { get { return next; } }
        public T Value { get { return item; } set { item = value; } }
    }

    public class LinkedList<T>
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        private LinkedListNode<T> First { get { return head; } }
        private LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (head != null)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
            count++;
            return newNode;
        }
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (node == head)
                head = newNode;
            return newNode;
        }

        public LinkedListNode<T> AddLast(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            return newNode;
        }
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            return newNode;
        }
        public bool Remove(T value)
        {
            LinkedListNode<T>? node = Find(value);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveNode(LinkedListNode<T> node)
        {
            ValidateNode(node);
            if (head == node)
                head = node.next;
            // head와 node가 같을 때 head의 자리에 다음의 노드를 넣어준다.
            if (tail == node)
                tail = node.prev;
            // tail과 node가 같을 때 head의 자리에 이전의 노드를 넣어준다.
            RemoveNode(node);
        }
        public LinkedListNode<T> Find(T value)
        {

        }
        public void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();
        }
    


    }
}

