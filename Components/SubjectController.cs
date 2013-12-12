using System;
using System.Collections.Generic;
using DotNetNuke.Data;

namespace LD2.SchoolGrades.Components
{
    public class SubjectController
    {
        public void CreateSubject(Subject x)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                rep.Insert(x);
            }
        }

        public void DeleteSubject(int subjectId)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                rep.Delete("WHERE subjectId = @0", subjectId);
            }
        }

        public void UpdateSubject(Subject x)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                rep.Update(x);
            }
        }

        public IEnumerable<Subject> GetSubjects()
        {
            IEnumerable<Subject> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                x = rep.Get();
            }
            return x;
        }

        // GetSubjects(studentId)
        public IEnumerable<Subject> GetSubjects(int studentId)
        {
            IEnumerable<Subject> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                x = rep.Find("INNER JOIN LD2_SchoolGrades_Classes ON LD2_SchoolGrades_Classes.SubjectId = LD2_SchoolGrades_Subjects.SubjectId WHERE studentId = @0", studentId);
            }
            return x;
        }

        public IEnumerable<Subject> GetSubjectsBySubName(string subjectName)
        {
            IEnumerable<Subject> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                x = rep.Find("WHERE subjectName = @0", subjectName);
            }
            return x;
        }

        public Subject GetSubject(int subjectId)
        {
            Subject x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Subject>();
                x = rep.GetById(subjectId);
            }
            return x;
        }
    }
}