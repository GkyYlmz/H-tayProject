namespace Hitay.UI.Helper.Order
{
    public interface IProvider<T>
    {
        void Execute(T model);
    }
}
