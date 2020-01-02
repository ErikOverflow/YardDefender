using System.Collections.Generic;

public static class IEnumerableExt
{
    // usage: IEnumerableExt.FromSingleItem(someObject);
    public static IEnumerable<T> FromSingleItem<T>(T item)
    {
        yield return item;
    }
}