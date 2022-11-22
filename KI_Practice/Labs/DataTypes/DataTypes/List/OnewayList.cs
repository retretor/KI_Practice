namespace KI_Practice.Labs.DataTypes.DataTypes;

public class OnewayList<T> : IOnewayList<T>
{
    private ListNode<T> head = null;
    private ListNode<T> tail = null;
    
    public void Add(T Data)
    {
        ListNode<T> node = new ListNode<T>(Data);
        
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }
        Count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= Count)
        {
            Console.WriteLine("Index out of range");
            return default(T);
        }
        ListNode<T> node = head;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node.Data;
    }
    
    public void Remove(T data)
    {
        ListNode<T> current = head;
        ListNode<T> previous = null;
        while(current != null)
        {
            if(current.Data.Equals(data))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                    if(current.Next == null)
                        tail = previous;
                }
                else
                {
                    head = head.Next;
                    if(head == null)
                        tail = null;
                }
                Count--;
                break;
            }
            previous = current;
            current = current.Next;
        }
    }
 

    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    }
    public void Print()
    {
        ListNode<T> node = head;
        while (node != null)
        {
            Console.Write(node.Data + " ");
            node = node.Next;
        }
        Console.WriteLine();
    }

    public int Count { get; private set; }
}