using OnlineShop.Models;

namespace OnlineShop.Repositories;

public class UserRepository : IRepositoryUser
{
    private readonly Guid _userId;
    public Guid GetUserId()
    {
        return _userId;
    }
}