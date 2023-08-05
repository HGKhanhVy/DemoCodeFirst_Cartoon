namespace Cartoon.Contract.Service.Base
{
    public interface IGetable<T, in TKey> where T : class, new()
    {
        ICollection<T> GetAllAsync();
        T GetByKeyIdAsync(TKey keyId);
    }
}
