
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub CalculationBTN_Click(sender As Object, e As EventArgs) Handles CalculationBTN.Click
        Dim loanAmount As Double
        Dim annualRate As Double
        Dim interestRate As Double
        Dim term As Integer
        Dim loanTerm As Integer
        Dim monthlyPayment As Double

        Dim interestPaid As Double
        Dim nBalance As Double
        Dim principal As Double
        Dim paymentdate As Date

        Dim table As DataTable = New DataTable("ParentTable")
        Dim loanAmortTbl As DataTable = New DataTable("AmortizationTable")
        Dim tRow As DataRow

        interestPaid = 0.0

        loanAmount = CDbl(LoanAmttxt.Text)
        annualRate = CDbl(Anninttxt.Text)
        term = CDbl(Loantermtxt.Text)

        LoanAmttxt.Text = FormatCurrency(loanAmount)

        interestRate = annualRate / (100 * 12)

        loanTerm = term * 12

        monthlyPayment = loanAmount * interestRate / (1 - Math.Pow((1 + interestRate), (-loanTerm)))


        lblmonthlypmt.Text = FormatCurrency(monthlyPayment)

        loanAmortTbl.Columns.Add("Payment Number", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Payment Date", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Principal Paid", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Interest Paid", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("New Balance", System.Type.GetType("System.String"))


        Dim counterStart As Integer

        For counterStart = 1 To loanTerm

            interestPaid = loanAmount * interestRate
            principal = monthlyPayment - interestPaid
            nBalance = loanAmount - principal
            loanAmount = nBalance
            paymentdate = DateTime.Now.AddMonths(counterStart).ToShortDateString

            tRow = loanAmortTbl.NewRow()
            tRow("Payment Number") = String.Format(counterStart)
            tRow("payment date") = String.Format(paymentdate)
            tRow("Principal Paid") = String.Format("{0:C}", principal)
            tRow("Interest Paid") = String.Format("{0:C}", interestPaid)
            tRow("New Balance") = String.Format("{0:C}", nBalance)
            loanAmortTbl.Rows.Add(tRow)

        Next counterStart

        LoanGridView.DataSource = loanAmortTbl
        LoanGridView.DataBind()


    End Sub

    Protected Sub ClearBtn_Click(sender As Object, e As EventArgs) Handles ClearBtn.Click
        LoanAmttxt.Text = String.Empty
        Anninttxt.Text = String.Empty
        Loantermtxt.Text = String.Empty
        lblmonthlypmt.Text = String.Empty
        LoanGridView.DataSource = Nothing
        LoanGridView.DataBind()
    End Sub


End Class
