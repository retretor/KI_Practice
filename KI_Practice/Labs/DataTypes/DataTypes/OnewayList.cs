namespace KI_Practice.Labs.DataTypes.DataTypes;

/*public class OnewayList<T> : IOnewayList<T>
{
    /*private ListNode<T> head = null;
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


    public void Remove(int value)
    {
        throw new NotImplementedException();
    }

    public int Get(int index)
    {
        throw new NotImplementedException();
    }
    public void Delete(T data)
        {
            var current = head;

            Item<T> previous = null;
            
            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        // Устанавливаем у предыдущего элемента указатель на следующий элемент от текущего.
                        previous.Next = current.Next;
                        if(current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Устанавливаем головной элемент следующим.
                        _head = _head.Next;
 
                        // Если список оказался пустым,
                        // то обнуляем и крайний элемент.
                        if(_head == null)
                        {
                            _tail = null;
                        }
                    }
 
                    // Элемент был удален.
                    // Уменьшаем количество элементов и выходим из цикла.
                    // Для того, чтобы удалить все вхождения данных из списка
                    // необходимо не выходить из цикла, а продолжать до его завершения.
                    _count--;
                    break;
                }
 
                // Переходим к следующему элементу списка.
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

    public int Count { get; private set; }
}*/