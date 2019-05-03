using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MojtabaStoreCore3.DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly MojtabaStoreCore3Db ctx;

        public BaseRepository(MojtabaStoreCore3Db ctx)
        {
            this.ctx = ctx;
        }

        //MojtabaStoreCore3Db ctx = new MojtabaStoreCore3Db();

        public void DeleteAllDataFromTable(TEntity entity)
        {
            /* 
             استاد میدونم باید یه شرط بذارم برا اینکه بعضی کلمات شاید آخرش صرفا با اضافه کردن حرف اس نشه درست بشه
             ولی خب شرط رو اگه بذارم درست میشه اما خب مفهوم رو تو تمرین رسوندم دیگه
             */
            var name = typeof(TEntity).Name + "s";

            var sql = @"delete from @name";
            ctx.Database.ExecuteSqlCommand(sql, new SqlParameter("@name", name));
        }

        public void UpdateWithList(TEntity entity, List<string> properties)
        {
            
            List<string> discoveredProperties = new List<string>();
            foreach (var item in typeof(TEntity).GetProperties())
            {
                discoveredProperties.Add(item.Name);
            }

            foreach (var property in properties)
            {
                if (properties.Contains(property))
                {
                    ctx.Entry(entity).Property(property).IsModified = true;
                    ctx.SaveChanges();
                }
            }

        }
    }
}
