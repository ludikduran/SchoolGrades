using System;
using DotNetNuke.Services.Exceptions;
using LD2.SchoolGrades.Components;

namespace LD2.SchoolGrades
{
    public partial class Edit : SchoolGradesModuleBase 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // Subject Name DropdownList
                    ddlSubjectName.DataSource = new SubjectController().GetSubjects();
                    ddlSubjectName.DataTextField = "SubjectName";
                    ddlSubjectName.DataValueField = "SubjectId";
                    ddlSubjectName.DataBind();

                    // Student Name Dropdownlist
                    ddlStudentId.DataSource = new StudentController().GetStudents();
                    ddlStudentId.DataTextField = "StudentName";
                    ddlStudentId.DataValueField = "StudentId";
                    ddlStudentId.DataBind();

                    // Subject to edit
                    if (ClassId > 0)
                    {
                        var cC = new ClassController();
                        var c = cC.GetClass(ClassId);
                        if (c != null)
                        {
                            ddlSubjectName.Items.FindByValue(c.SubjectId.ToString()).Selected = true;
                            txtSubjectGrade.Text = c.Grade;
                            txtSubjectComment.Text = c.Comment;
                            ddlStudentId.Items.FindByValue(c.StudentId.ToString()).Selected = true;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var c = new Classes();
            var cC = new ClassController();

            // Edit subject values
            if (ClassId > 0)
            {
                c = cC.GetClass(ClassId);
                c.StudentId = Convert.ToInt32(ddlStudentId.SelectedValue);
                c.SubjectId = Convert.ToInt32(ddlSubjectName.SelectedValue);
                c.Grade = txtSubjectGrade.Text.Trim();
                c.Comment = txtSubjectComment.Text.Trim();
            }
            // Edit new subject values
            else
            {
                c = new Classes()
                {
                    StudentId = Convert.ToInt32(ddlStudentId.SelectedValue),
                    SubjectId = Convert.ToInt32(ddlSubjectName.SelectedValue),
                    Grade = txtSubjectGrade.Text.Trim(),
                    Comment = txtSubjectComment.Text.Trim()
                };
            }

            // Update Subject
            if (ClassId > 0)
            {
                cC.UpdateClass(c);
            }
            else // Create new Subject
            {
                cC.CreateClass(c);
            }

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}