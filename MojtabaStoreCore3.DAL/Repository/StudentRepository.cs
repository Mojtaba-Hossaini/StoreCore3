using System;
using System.Collections.Generic;
using System.Text;
using MojtabaStoreCore3.Domain;

namespace MojtabaStoreCore3.DAL.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(MojtabaStoreCore3Db ctx) : base(ctx)
        {
        }
    }
}
