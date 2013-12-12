using System;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Content;
using System.Web.Caching;

namespace LD2.SchoolGrades.Components
{
    [TableName("LD2_SchoolGrades_Classes")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    [Cacheable("LD2_SchoolGrades_Classes", CacheItemPriority.Default, 20)]
    [Scope("ClassId")]
    public class Classes
    {
        public int ClassId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public string Grade { get; set; }

        public string Comment { get; set; }
    }
}