using System;
using System.Collections.Generic;
using DotNetNuke.Data;

namespace LD2.SchoolGrades.Components
{
    public class StudentController
    {
        // Create
        public void CreateStudent(Student s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Student>();
                rep.Insert(s);
            }
        }

        // Delete

        // Get
        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Student>();
                x = rep.Get();
            }
            return x;
        }

        // Get
        public Student GetStudent(int studentId)
        {
            Student x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Student>();
                x = rep.GetById(studentId);
            }
            return x;
        }

        //Update
        public void UpdateStudent(Student s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Student>();
                rep.Update(s);
            }
        }
    }
}