// IEntityRepository.cs
using System.Collections.Generic;
using YourProjectName.Models;

namespace YourProjectName.Repositories
{
    public interface IEntityRepository
    {
        IEnumerable<Entity> GetAllEntities();
        // Other methods for CRUD operations
    }
}
