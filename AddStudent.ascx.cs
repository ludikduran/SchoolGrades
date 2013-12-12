using DotNetNuke.Services.Exceptions;
using LD2.SchoolGrades.Components;
using System;
using System.Collections.Generic;


namespace LD2.SchoolGrades
{
    public partial class AddStudent : SchoolGradesModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (StudentId > 0)
                    {
                        var student = new StudentController().GetStudent(StudentId);
                        if (student != null)
                        {
                            string[] studentName = student.StudentName.Split(' ');
                            txtStudentFName.Text = studentName[0];
                            txtStudentLName.Text = studentName[1];
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
            var student = new Student();
            var studentC = new StudentController();

            if (StudentId > 0)
            {
                student = studentC.GetStudent(StudentId);
                student.StudentName = txtStudentFName.Text + " " + txtStudentLName.Text;
            }
            else
            {
                student = new Student()
                {
                    StudentName = txtStudentFName.Text + " " + txtStudentLName.Text
                };
            }

            if (StudentId > 0)
            {
                studentC.UpdateStudent(student);
            }
            else
            {
                studentC.CreateStudent(student);
            }

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}