using Newtonsoft.Json;
using SchoolManagerWebClient.Models;
using SchoolManagerWebClient.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SchoolManagerWebClient.Repositories
{
    public class StudentRepository : IRepository<StudentViewModel>
    {
        public readonly string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public HttpWebResponse Create(StudentViewModel entity)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConnectionString + "/student/Create");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(entity);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return httpResponse;
        }

        public List<StudentViewModel> ReadAll()
        {
            List<StudentViewModel> students;

            using (var client = new WebClient())
            {
                var response = client.DownloadString(ConnectionString + "/student/ReadAll");
                students = JsonConvert.DeserializeObject<List<StudentViewModel>>(response);
            }

            return students;
        }

        public StudentViewModel ReadById(int id)
        {
            StudentViewModel student;

            using (var client = new WebClient())
            {
                var response = client.DownloadString(ConnectionString + "/student/ReadById/" + id);
                student = JsonConvert.DeserializeObject<StudentViewModel>(response);
            }

            return student;
        }
    }
}