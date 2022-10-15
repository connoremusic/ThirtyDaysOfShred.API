namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        IMessageRespository MessageRespository { get; }
        IGuitarTabRepository GuitarTabRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
