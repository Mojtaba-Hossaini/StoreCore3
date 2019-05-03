using Microsoft.EntityFrameworkCore;
using MojtabaStoreCore3.DAL;
using MojtabaStoreCore3.DAL.Repository;
using MojtabaStoreCore3.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MojtabaStoreCore3.EndPointConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MojtabaStoreCore3Db ctx = new MojtabaStoreCore3Db();

            StudentRepository repo = new StudentRepository(ctx);

            repo.DeleteAllDataFromTable(new Student());

            //Student student = new Student
            //{
            //    FirstName = "مجتبي",
            //    LastName = "حسینی"
            //};

            //var student = ctx.Students.FirstOrDefault();
            //student.FirstName = "هادي";

            //ctx.Add(student);
            //ctx.SaveChanges();
            Console.ReadLine();

        }

        public static void DeleteAllDataFromTable<TEntity>(TEntity entity)
        {
            MojtabaStoreCore3Db ctx = new MojtabaStoreCore3Db();

            /* 
             استاد میدونم باید یه شرط بذارم برا اینکه بعضی کلمات شاید آخرش صرفا با اضافه کردن حرف اس نشه درست بشه
             ولی خب شرط رو اگه بذارم درست میشه اما خب مفهوم رو تو تمرین رسوندم دیگه
             */
            var name = typeof(TEntity).Name + "s";
            var sql = @"delete from @name";
            ctx.Database.ExecuteSqlCommand(sql, new SqlParameter("@name", name));
        }

        public static void UpdateWithList<TEntity>(TEntity entity, List<string> properties)
        {
            MojtabaStoreCore3Db ctx = new MojtabaStoreCore3Db();
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
