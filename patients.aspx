<%@ Page Language="C#" AutoEventWireup="true" CodeFile="patients.aspx.cs" Inherits="patients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patients</title>
</head>
<body>
    <form id="form1" runat="server">
    <div title="Patients by Floor">
    
        <h1>Current Patients -<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="margin-bottom: 1px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="AdmissionDate" HeaderText="AdmissionDate" SortExpression="AdmissionDate" />
                <asp:BoundField DataField="PrimaryDiagnosis" HeaderText="PrimaryDiagnosis" SortExpression="PrimaryDiagnosis" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="Bed" HeaderText="Bed" SortExpression="Bed" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CHDBConnectionString %>" SelectCommand="SELECT P.PatientID, P.FirstName, P.LastName, A.AdmissionDate, A.PrimaryDiagnosis, A.Room, A.Bed FROM Patients AS P INNER JOIN Admissions AS A ON P.PatientID = A.PatientID WHERE (A.NursingUnitID = @NursingUnitID) AND (A.DischargeDate IS NULL)">
            <SelectParameters>
                <asp:QueryStringParameter Name="NursingUnitID" QueryStringField="category" />
            </SelectParameters>
        </asp:SqlDataSource>
    <br/>
    <a href = "default.aspx">Home</a>
    </div>
    </form>
</body>
</html>
