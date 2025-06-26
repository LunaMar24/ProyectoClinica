Public Class frmDashboard
  Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
    frmLogin.Show()
    Me.Close()
  End Sub
End Class