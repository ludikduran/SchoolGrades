using System;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace LD2.SchoolGrades.Components
{
    [TableName("LD2_SchoolGrades_Students")]
    [PrimaryKey("StudentId", AutoIncrement = true)]
    [Cacheable("LD2_SchoolGrades_Students", CacheItemPriority.Default, 20)]
    [Scope("StudentId")]
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
    }
}