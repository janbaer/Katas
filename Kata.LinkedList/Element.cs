namespace Kata.LinkedList
{
    public class Element<T>
    {
        public Element(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }
        public Element<T> Next { get; set; }
    }
}