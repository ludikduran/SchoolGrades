using System;
using System.Web.UI.WebControls;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using LD2.SchoolGrades.Components;
using DotNetNuke.Common.Utilities;
using System.Collections;
using System.Collections.Generic;

namespace LD2.SchoolGrades
{
    public partial class View : SchoolGradesModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Build user dash
                lnkInputGrade.NavigateUrl = EditUrl();

                // Student DropDownList
                if (!IsPostBack)
                {
                    // Build ddlStudentName
                    var studentC = new StudentController();
                    ddlStudentName.DataSource = studentC.GetStudents();
                    ddlStudentName.DataTextField = "StudentName";
                    ddlStudentName.DataValueField = "StudentId";
                    ddlStudentName.DataBind();
                    ddlStudentName.Items.Insert(0, "--Select Student--");

                    // Build ddlSubjects
                    ddlSubjects_build();
                }

                // Repeater
                FillRepeater();
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void RepeaterBind()
        {
            var cC = new ClassController();
            rptSubjectList.DataSource = cC.RptGetClasses();
            rptSubjectList.DataBind();
        }

        protected void ddlSubjects_build()
        {
            var subjectC = new SubjectController();
            if (ddlStudentName.SelectedIndex == 0) // Show all
            {
                ddlSubjects.DataSource = subjectC.GetSubjects();
            }
            else // Show based on Student Name
            {
                ddlSubjects.DataSource = subjectC.GetSubjects(int.Parse(ddlStudentName.SelectedValue));
            }

            ddlSubjects.DataTextField = "subjectName";
            ddlSubjects.DataValueField = "subjectId";
            ddlSubjects.DataBind();
            ddlSubjects.Items.Insert(0, "--Select Subject--");
        }

        protected void ddlSubjects_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubjects.SelectedIndex == 0)
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
            
            // Else
            var tc = new ClassController();
            int x = int.Parse(ddlSubjects.SelectedValue);
            rptSubjectList.DataSource = tc.GetClassesBySubId(x); // Get subjects based on subjectId
            rptSubjectList.DataBind();
        }

        protected void ddlStudentNameOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStudentName.SelectedIndex == 0)  // Refresh page to view control
            {
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
            }

            // Else
            var tc = new ClassController();
            int x = int.Parse(ddlStudentName.SelectedValue);
            rptSubjectList.DataSource = tc.GetClasses(x);  // Get Classes based on studentId
            rptSubjectList.DataBind();

            ddlSubjects_build();  // Rebuild dllSubjects
        }

        protected void rptSubjectListOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;

                var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;

                var t = (Classes)e.Item.DataItem;   

                if (IsEditable && lnkDelete != null && lnkEdit != null && pnlAdminControls != null)
                {
                    pnlAdminControls.Visible = true;
                    lnkDelete.CommandArgument = t.ClassId.ToString();
                    lnkDelete.Enabled = lnkDelete.Visible = lnkEdit.Enabled = lnkEdit.Visible = true;

                    lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, "Edit", "classid=" + t.ClassId);

                    ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));
                }
                else
                {
                    pnlAdminControls.Visible = false;
                }
            }
        }

        public void rptSubjectListOnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["SortExpression"] = e.CommandName;
            FillRepeater();

            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "classid=" + e.CommandArgument));
            }

            if (e.CommandName == "Delete")
            {
                var tc = new ClassController();
                tc.DeleteClass(Convert.ToInt32(e.CommandArgument));
            }
            //Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            // Add Subject
                            GetNextActionID(), Localization.GetString("AddSubject", LocalResourceFile), "", "", "", EditUrl("AddSubject"), false, SecurityAccessLevel.Edit, true, false
                        },
                        {
                            // Add Student
                            GetNextActionID(), Localization.GetString("AddStudent", LocalResourceFile), "", "", "", EditUrl("AddStudent"), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;

            }
        }

        protected void lbtnPrev_Click(object sender, EventArgs e)
        {
            //Decrement page by one
            NowViewing--;
            //Fill repeater
            FillRepeater();
        }

        protected void lbtnNext_Click(object sender, EventArgs e)
        {
            //Increment page by one
            NowViewing++;
            //Fill repeater
            FillRepeater();
        }

        protected void FillRepeater()
        {
            //Create the object of PagedDataSource
            PagedDataSource objPds = new PagedDataSource();

            //Assign our data source to PagedDataSource object
            var cC = new ClassController();
            var list = cC.RptGetClasses();
            list = Sort(list);
            objPds.DataSource = list;

            //Set the allow paging to true
            objPds.AllowPaging = true;

            //Set the number of items you want to show
            objPds.PageSize = 7;

            //Disable Prev, Next buttons if necessary
            lbtnPrev.Enabled = !objPds.IsFirstPage;
            lbtnNext.Enabled = !objPds.IsLastPage;

            //Assign PagedDataSource to repeater
            rptSubjectList.DataSource = objPds;
            rptSubjectList.DataBind();
        }

        public int NowViewing
        {
            get
            {
                object obj = ViewState["_NowViewing"];
                if (obj == null)
                    return 0;
                else
                    return (int)obj;
            }
            set
            {
                this.ViewState["_NowViewing"] = value;
            }
        }

        protected IEnumerable<Classes> Sort(IEnumerable<Classes> list)
        {
            string sortExpression = (ViewState["SortExpression"] ?? "").ToString();
            bool isAscending = true;

            if (ViewState["SortDetails"] == null)
            {
                Hashtable hs = new Hashtable();
                hs.Add("StudentId", false);
                ViewState["SortDetails"] = hs;
            }

            Hashtable hsSortDetails = ViewState["SortDetails"] as Hashtable;

            if (sortExpression.Length > 0)
            {
                if (!hsSortDetails.Contains(sortExpression))
                    hsSortDetails.Add(sortExpression, true);
                isAscending = bool.Parse(hsSortDetails[sortExpression].ToString());
                hsSortDetails[sortExpression] = !isAscending;
            }

            switch (sortExpression)
            {
                case "StudentId":
                    return list.OrderByStudentId(isAscending);
                case "SubjectId":
                    return list.OrderBySubjectId(isAscending);
                case "Grade":
                    return list.OrderByGrade(isAscending);
                case "Comment":
                    return list.OrderByComment(isAscending);
                default:
                    return list.OrderByStudentId(isAscending);
            }
        }
    }
}