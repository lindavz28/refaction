using System;
using System.Collections.Generic;

namespace Data
{
    interface IRepository<IEntity>
    {
        bool Save(IEntity entity);
        bool Update(IEntity entity);
        bool Delete(Guid id);
        IEntity GetItem(Guid id);
        List<IEntity> GetAllItems();
        List<IEntity> GetItemsByName(string name);
    }
}
