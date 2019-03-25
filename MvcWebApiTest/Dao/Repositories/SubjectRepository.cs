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
    public class SubjectRepository : IRepository<Subject>
    {
        readonly ILogger Log;

        public SubjectRepository()
        {
            Log = new SerilogAdapter();
        }

        public Subject Create(Subject entity)
        {
            Subject addedSubject = null;
            using (var db = new SchoolEntities())
            {
                try
                {
                    addedSubject = db.Subjects.Add(entity);
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
            return addedSubject;
        }

        public List<Subject> ReadAll()
        {
            List<Subject> subjects = null;
            using (var db = new SchoolEntities())
            {
                try
                {
                    subjects = db.Subjects.ToList();
                }
                catch (ArgumentNullException e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }
            return subjects;
        }

        public Subject ReadById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
