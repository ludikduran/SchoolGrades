<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddSubject.ascx.cs" Inherits="LD2.SchoolGrades.AddSubject" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>


<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    <div class="dnnFormItem">
        <dnn:Label ID="lblSubjectName" runat="server" />
        <asp:TextBox ID="txtSubjectName" runat="server" />
    </div>
</div>

<asp:LinkButton ID="btnSubmit" runat="server"
    OnClick="btnSubmit_Click" resourcekey="btnSubmit" CssClass="dnnPrimaryAction" />
<asp:LinkButton ID="btnCancel" runat="server"
    OnClick="btnCancel_Click" resourcekey="btnCancel" CssClass="dnnSecondaryAction" />