<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="formatting.css"/>
    <title>Loan Calculation</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
   <h1> Mortgage Calculator</h1>

        <br /><br />
        Loan Amount
        <asp:TextBox ID="LoanAmttxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter the Loan Amount" Display="Dynamic" Font-Overline="False" ControlToValidate="LoanAmttxt"></asp:RequiredFieldValidator>
        <br />
        <br />
        Annual Interest %
        <asp:TextBox ID="Anninttxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter the Annual Interest Rate" Display="Dynamic" ControlToValidate="Anninttxt"></asp:RequiredFieldValidator>
        <br />
        <br />
        Loan Term (Yrs)
        <asp:TextBox ID="Loantermtxt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter the Loan Term" Display="Dynamic" ControlToValidate="Loantermtxt"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="CalculationBTN" runat="server" Text="Calculate" />
        <asp:Button ID="ClearBtn" runat="server" Text="Clear" />
        <br />
        <br />
        Monthly Payment &nbsp <asp:Label ID="lblmonthlypmt" runat="server"></asp:Label>
        <br />
        <br />
        <div> 
        <asp:GridView ID="LoanGridView" runat="server" CssClass="cssgridview">
            <AlternatingRowStyle CssClass="alt" />
        </asp:GridView>
            </div>
        <br />

    </div>
    </form>
</body>
</html>
