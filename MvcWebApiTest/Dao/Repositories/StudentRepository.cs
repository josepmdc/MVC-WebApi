using Dao.Logging.Adapters;
using Dao.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        ILogger Log;

        public StudentRepository()
        {
            Log = new SerilogAdapter();
        }

        public Student Create(Student entity)
        {
            Student addedStudent = null;
            using (var db = new SchoolEntities())
            {
                try
                {
                    addedStudent = db.Students.Add(entity);
                    db.SaveChanges();
                }
                #region Exceptions
                catch (DbUpdateConcurrencyException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                catch (DbUpdateException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                catch (DbEntityValidationException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                catch (NotSupportedException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                catch (ObjectDisposedException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                catch (InvalidOperationException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
                #endregion

            }
            return addedStudent;
        }

        public List<Student> ReadAll()
        {
            List<Student> students = null;
            using (var db = new SchoolEntities())
            {
                try
                {
                    students = db.Students.Include("Enrollments").ToList();
                }
                catch (ArgumentNullException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }
            return students;
        }

        public Student ReadById(int id)
        {
            Student student = null;
            using (var db = new SchoolEntities())
            {
                try
                {
                    student = db.Students.Include("Enrollments").FirstOrDefault(x => x.Id == id);
                }
                catch (ArgumentNullException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }
            return student;
        }
    }
}
