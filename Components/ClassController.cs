using System;
using System.Collections.Generic;
using DotNetNuke.Data;

namespace LD2.SchoolGrades.Components
{
    public class ClassController
    {

        // Create
        public void CreateClass(Classes s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                rep.Insert(s);
            }
        }

        // Delete
        public void DeleteClass(int classId)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                rep.Delete("WHERE ClassId = @0", classId);
            }
        }

        // Get All
        public IEnumerable<Classes> GetClasses()
        {
            IEnumerable<Classes> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                x = rep.Get();
            }
            return x;
        }

        // Get One
        public Classes GetClass(int classId)
        {
            Classes x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                x = rep.GetById(classId);
            }
            return x;
        }

        // Get All by studentId
        public IEnumerable<Classes> GetClasses(int studentId)
        {
            IEnumerable<Classes> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                x = rep.Find("WHERE StudentId = @0", studentId);
            }
            return x;
        }
        
        // Get All by subjectId
        public IEnumerable<Classes> GetClassesBySubId(int subjectId)
        {
            IEnumerable<Classes> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                x = rep.Find("WHERE SubjectId = @0", subjectId);
            }
            return x;
        }

        // Repeater Get Classes
        public IEnumerable<Classes> RptGetClasses()
        {
            IEnumerable<Classes> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                x = rep.Find("INNER JOIN LD2_SchoolGrades_Subjects ON LD2_SchoolGrades_Classes.SubjectId = LD2_SchoolGrades_Subjects.SubjectId");
                ctx.
            }
            return x;
        }

        // Update
        public void UpdateClass(Classes s)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Classes>();
                rep.Update(s);
            }
        }
    }
}