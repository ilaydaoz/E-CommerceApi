using E_CommerceApi.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_CommerceApi.Application.Repositories
{
    // solide repository pattern uygun değil çünkü command ve query tanımlanıyo
    // bu yüzden IWriteRepository veIReadRepository diye ayırdık
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
