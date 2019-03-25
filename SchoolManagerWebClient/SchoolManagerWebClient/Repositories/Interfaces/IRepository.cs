using SchoolManagerWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerWebClient.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        HttpWebResponse Create(T entity);
        List<T> ReadAll();
        T ReadById(int id);
    }
}
