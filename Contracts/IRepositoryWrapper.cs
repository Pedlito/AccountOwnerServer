namespace AccountOwnerServer.Contracts;

public interface IRepositoryWrapper
{
    IOwnerRepository Owner { get; }
    IAccountRepository Account { get; }
    IUserRepository User { get; }

    Task SaveAsync();
}