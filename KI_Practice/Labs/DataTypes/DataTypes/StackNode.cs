namespace KI_Practice.Labs.DataTypes.DataTypes;

public class StackNode<T>
{
    public T Data { get; private set; }
    public StackNode<T> Next { get; set; }
    
    public StackNode(T data)
    {
        Data = data;
    }
}