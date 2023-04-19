using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace LinkedList
{   
    // 1. LinkedList 구현해보기
    // AddFirst, AddLast,
    // AddBefore, AddAfter,
    // Remove(T value), Remove(node), Find
    // + 주석 추가
    // -------------------------------
    // 2. LinkedList 기술면접 준비
    // -------------------------------
    // 0. msdn C# LinkedList 참고해서
    // Contains, FindLast, RemoveFirst, RemoveLast

    public class LinkedListNode<T>
    {
        public LinkedList<T> list;
        public LinkedListNode<T> prev;
        public LinkedListNode<T> next;
        public T item;

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
        public T Item { get { return item; } set { item = value; } }
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

        // AddBefore
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            InsertNodeBefore(node, newNode);
            if (node == head)
                head = newNode;
            return newNode;
        }

        // AddAfter
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            InsertNodeAfter(node, newNode);
            if (node == tail)
                tail = newNode;
            return newNode;
        }

        // AddFirst
        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (head != null)
            {
                InsertNodeBefore(head, newNode);
                head = newNode;
            }
            else
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        // AddLast
        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (tail != null)
            {
                InsertNodeAfter(tail, newNode);
                tail = newNode;
            }
            else
            {
                InsertNodeToEmptyList(newNode);
            }
            return newNode;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        // Find
        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T>? node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (value != null)
            {
                while (node != null)
                {
                    if (c.Equals(node.Item, value))
                        return node;
                    else
                        node = node.next;
                }
            }
            else
            {
                while (node != null)
                {
                    if (node.Item == null)
                        return node;
                    else
                        node = node.next;
                }
            }
            return null;
        }

        // Remove(T value)
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

        // Remove(node)
        public void Remove(LinkedListNode<T> node)
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

        public void RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException();

            LinkedListNode<T> headNode = head;
            Remove(headNode);
        }

        public void RemoveLast()
        {
            if (tail == null)
                throw new InvalidOperationException();

            LinkedListNode<T> tailNode = tail;
            Remove(tailNode);
        }

        private void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.list != this)
                throw new InvalidOperationException();
        }

        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            if (newNode.prev != null)
                newNode.prev.next = newNode;

            node.prev = newNode;

            count++;
        }

        private void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.prev = node;
            newNode.next = node.next;
            if (newNode.next != null)
                newNode.next.prev = newNode;

            node.next = newNode;

            count++;
        }

        private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            if (count != 0)
                throw new InvalidOperationException();

            head = newNode;
            tail = newNode;
            count++;
        }

        private void RemoveNode(LinkedListNode<T> node)
        {
            if (node.list != this)
                throw new InvalidOperationException();

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;
        }
    }
}
