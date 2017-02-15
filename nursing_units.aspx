<%@ Page Language="C#" AutoEventWireup="true" CodeFile="nursing_units.aspx.cs" Inherits="nursing_units" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nursing Units</title>
</head>
<body>
    <form id="form1" runat="server">
    <div title="Nursing Units" aria-sort="descending">
    
        <asp:Chart ID="Chart1" runat="server" Height="600px" OnLoad="Chart1_Load1" Width="600px">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="AliceBlue" Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Docking="Bottom" Font="Microsoft Sans Serif, 12pt" Name="Nursing Unit" Text="Nursing Unit">
                </asp:Title>
            </Titles>
            <BorderSkin BackColor="AliceBlue" SkinStyle="Emboss" />
        </asp:Chart>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br/>
    <a href = "default.aspx">Back</a>
    </div>
    </form>
</body>
</html>
