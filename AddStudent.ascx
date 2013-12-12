<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.ascx.cs" Inherits="LD2.SchoolGrades.AddStudent" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>


<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormItem">
        <dnn:Label ID="lblStudentFName" runat="server" />
        <asp:TextBox ID="txtStudentFName" runat="server" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label ID="lblStudentLName" runat="server" />
        <asp:TextBox ID="txtStudentLName" runat="server" />
    </div>
</div>

<asp:LinkButton ID="btnSubmit" runat="server"
    OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server"
    OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />