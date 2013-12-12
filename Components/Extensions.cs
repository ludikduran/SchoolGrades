using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2.SchoolGrades.Components
{
    public static class Extensions
    {
        public static IEnumerable<Classes> OrderByStudentId(this IEnumerable<Classes> list, bool isAscending)
        {
            if (isAscending)
                return list.OrderBy(a => a.StudentId).ToList();
            else
                return list.OrderByDescending(a => a.StudentId).ToList();
        }

        public static IEnumerable<Classes> OrderBySubjectId(this IEnumerable<Classes> list, bool isAscending)
        {
            if (isAscending)
                return list.OrderBy(a => a.SubjectId).ToList();
            else
                return list.OrderByDescending(a => a.SubjectId).ToList();
        }

        public static IEnumerable<Classes> OrderByGrade(this IEnumerable<Classes> list, bool isAscending)
        {
            if (isAscending)
                return list.OrderBy(a => a.Grade).ToList();
            else
                return list.OrderByDescending(a => a.Grade).ToList();
        }

        public static IEnumerable<Classes> OrderByComment(this IEnumerable<Classes> list, bool isAscending)
        {
            if (isAscending)
                return list.OrderBy(a => a.Comment).ToList();
            else
                return list.OrderByDescending(a => a.Comment).ToList();
        }
    }
}