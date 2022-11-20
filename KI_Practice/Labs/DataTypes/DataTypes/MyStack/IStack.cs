namespace KI_Practice.Labs.DataTypes.DataTypes;

public interface IStack<T>
{
    void Push(T value);
    T Pop();
    bool CanPush();
    bool CanPop();
}