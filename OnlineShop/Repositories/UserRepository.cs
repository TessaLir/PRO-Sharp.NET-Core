using OnlineShop.Models;
using OnlineShop.Models.Interfaces;

namespace OnlineShop.Repositories;

public class UserRepository : IRepositoryUser
{
    private readonly Guid _userId = new Guid("3abbd50d-6634-44da-bffa-9cc072657214");
    public Guid GetUserId()
    {
        return _userId;
    }
}