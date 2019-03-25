using Newtonsoft.Json;
using SchoolManagerWebClient.Models;
using SchoolManagerWebClient.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SchoolManagerWebClient.Repositories
{
    public class SubjectRepository : IRepository<SubjectViewModel>
    {
        public readonly string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public HttpWebResponse Create(SubjectViewModel entity)
        {
            throw new NotImplementedException();
        }

        public List<SubjectViewModel> ReadAll()
        {
            List<SubjectViewModel> subjects;
            using (var client = new WebClient())
            {
                var response = client.DownloadString(ConnectionString + "/subject/ReadAll");
                subjects = JsonConvert.DeserializeObject<List<SubjectViewModel>>(response);
            }
            return subjects;
        }

        public SubjectViewModel ReadById(int id)
        {
            throw new NotImplementedException();
        }
    }
}