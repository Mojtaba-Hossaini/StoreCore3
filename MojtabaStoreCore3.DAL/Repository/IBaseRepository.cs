using System;
using System.Collections.Generic;
using System.Text;

namespace MojtabaStoreCore3.DAL.Repository
{
    public interface IBaseRepository<TEntity>
    {
        void UpdateWithList(TEntity entity, List<string> properties);
        void DeleteAllDataFromTable(TEntity entity);
    }
}
