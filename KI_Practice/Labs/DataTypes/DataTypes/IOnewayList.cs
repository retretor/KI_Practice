namespace KI_Practice.Labs.DataTypes.DataTypes;

public interface IOnewayList<T>
{
    void Add(T data);
    void Remove(T value);
    void Clear();
    int Count { get; }
}