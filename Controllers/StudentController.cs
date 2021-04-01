using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDay1.Models;

namespace WebApiDay1.Controllers
{
    public class StudentController : ApiController
    {
        static List<Student> _studentList = null;
        // GET: api/Student
        void Initialize()
        {
            _studentList = new List<Student>()
            {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},

               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},
            };
        }
        public StudentController()
        {
            if(_studentList==null)
            {
                Initialize();
            }
        }
        public List<Student> Get()
        {
            return _studentList;
        }

        // GET: api/Student/5
        public Student Get(int? id)
        {
            Student student = null;
            if(id!=null)
            {
                student =_studentList.FirstOrDefault(m => m.StudentId == id);
            }
            return student;
        }

        // POST: api/Student
        public void Post(Student student)
        {
            if (student != null)
            {
                _studentList.Add(student);
            }
        }

        // PUT: api/Student/5
        public void Put(int id, Student objStudent)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();
            if(student!=null)
            {
                foreach(Student temp in _studentList)
                {
                    if (temp.StudentId==id)
                    {
                        temp.Name = objStudent.Name;
                        temp.Marks = objStudent.Marks;
                        temp.DateOfBirth = objStudent.DateOfBirth;
                        temp.Batch = objStudent.Batch;

                    }
                }

            }
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();

            if (student != null)
            {
                _studentList.Remove(student);
            }

        }
    }
}
