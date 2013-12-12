using System;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Content;
using System.Web.Caching;

namespace LD2.SchoolGrades.Components
{
    [TableName("LD2_SchoolGrades_Subjects")]
    [PrimaryKey("SubjectId", AutoIncrement = true)]
    [Cacheable("LD2_SchoolGrades_Subjects", CacheItemPriority.Default, 20)]
    [Scope("SubjectId")]
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }
    }
}