public abstract class BaseLogic<T> where T : IModel
{

    public static List<T> _items;

    public abstract void UpdateList(T acc);

    public T GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }
}

