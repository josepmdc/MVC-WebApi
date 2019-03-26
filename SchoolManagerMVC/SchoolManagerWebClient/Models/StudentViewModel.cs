using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagerWebClient.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
    }
}