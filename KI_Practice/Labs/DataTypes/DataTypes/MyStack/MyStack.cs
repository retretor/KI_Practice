namespace KI_Practice.Labs.DataTypes.DataTypes;

public class MyStack<T> : IStack<T>
{
    private StackNode<T> _top;
    public long Count { get; private set; }

    public MyStack()
    {
        Count = 0;
        _top = null;
    }
    public void Push(T value)
    {
        if (_top == null)
            _top = new StackNode<T>(value);
        else
        {
            var newNode = new StackNode<T>(value);
            newNode.Next = _top;
            _top = newNode;
        }
        Count++;
    }

    public T Pop()
    {
        if (CanPop())
        {
            StackNode<T> node = _top;
            _top = _top.Next;
            Count--;
            return node.Data;
        }
        throw new InvalidOperationException("Stack is empty");
    }

    public bool CanPush() => true;

    public bool CanPop() => _top != null;
    
}
