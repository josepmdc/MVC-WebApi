using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Mapping
{
    public class Mapper
    {
        public Student StudentDtoToDao(StudentDto studentDto)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            if (studentDto.Subjects != null)
            {
                foreach (var subject in studentDto.Subjects)
                {
                    Enrollment enrollment = new Enrollment {
                        StudentId = studentDto.Id,
                        SubjectId = subject.Id
                    };
                    enrollments.Add(enrollment);
                }
            }

            Student student = new Student {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Enrollments = enrollments
            };

            return student;
        }
    }
}