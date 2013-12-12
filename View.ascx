<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="LD2.SchoolGrades.View" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>

<asp:DropDownList runat="server" ID="ddlStudentName" OnSelectedIndexChanged="ddlStudentNameOnSelectedIndexChanged" AutoPostBack="true" />
&nbsp;
<asp:DropDownList runat="server" ID="ddlSubjects" OnSelectedIndexChanged="ddlSubjects_OnSelectedIndexChanged" AutoPostBack="true" />
&nbsp; &nbsp;
    <asp:LinkButton ID="lbtnPrev" runat="server" resourceKey="lbtnPrev.Text" OnClick="lbtnPrev_Click" />
    &nbsp; &nbsp;
    <asp:LinkButton ID="lbtnNext" runat="server" resourceKey="lbtnNext.Text" OnClick="lbtnNext_Click" />

<asp:Repeater ID="rptSubjectList" runat="server" OnItemDataBound="rptSubjectListOnItemDataBound" OnItemCommand="rptSubjectListOnItemCommand">
    <HeaderTemplate>
        <table width="100%">
            <thead>
              <tr>
                <th width="25%">
                    <asp:linkbutton ID="lblStudent" runat="server" resourceKey="lblStudent.Text" CommandName="StudentId"/>
                </th>
                <th width="25%">
                    <asp:linkbutton ID="lblSubject" runat="server" resourceKey="lblSubject.Text" CommandName="SubjectId"/>
                </th>
                <th width="25%">
                    <asp:linkbutton ID="lblGrade" runat="server" resourceKey="lblGrade.Text" CommandName="Grade"/>
                </th>
                <th width="25%">
                    <asp:linkbutton ID="lblComment" runat="server" resourceKey="lblComment.Text" CommandName="Comment"/>
                </th>

                <td align="right">
                    
                </td>
              </tr>
            </thead>
    </HeaderTemplate>

    <ItemTemplate>
        <tr>
            <td align="center">
                <asp:Label ID="lblStudentId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentId").ToString() %>' />
            </td>
            <td align="center">
                <asp:Label ID="lblSubjectName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectId").ToString() %>' />
            </td>
            <td align="center">
                <asp:Label ID="lblSubjectGrade" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Grade").ToString() %>' />
            </td>
            <td align="center">
                <asp:Label ID="lblSubjectComment" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Comment").ToString() %>' />
            </td>
            <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
                <td>
                    <asp:HyperLink ID="lnkEdit" runat="server" visible="false" enabled="false" resourcekey="EditItem.Text"/>
                    <asp:LinkButton ID="lnkDelete" runat="server" Visible="false" enabled="false" CommandName="Delete" resourcekey="DeleteItem.Text"/>
                </td>
            </asp:Panel>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<br />
<asp:HyperLink ID="lnkInputGrade" runat="server" resourceKey="btnInputGrade" CssClass="dnnTertiaryAction" />