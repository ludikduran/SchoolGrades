<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="LD2.SchoolGrades.Edit" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormItem">
        <dnn:label id="lblSubjectName" runat="server" />
        <asp:DropDownList ID="ddlSubjectName" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:label id="lblSubjectGrade" runat="server" />
        <asp:Textbox ID="txtSubjectGrade" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:label id="lblSubjectComment" runat="server" />
        <asp:Textbox ID="txtSubjectComment" runat="server" TextMode="MultiLine" Rows="5" Columns="20" />
    </div>

    <div class="dnnFormItem">
        <dnn:label id="lblStudentId" runat="server" />
        <asp:DropDownList ID="ddlStudentId" runat="server" />
    </div>
</div>
<asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />