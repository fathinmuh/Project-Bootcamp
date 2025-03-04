using System;
using System.Collections.Generic;

public class CustomCollection<T> : ICollection<T>
{
    private List<T> _items = new List<T>();

    public int Count => _items.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Clear()
    {
        _items.Clear();
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _items.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}

class Program{
    static void Main(){
        
    }
}