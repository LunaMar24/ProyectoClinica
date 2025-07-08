Imports MySql.Data.MySqlClient

Public Class frmMantPacientes

  Private conexion As Conexion

  Private Sub frmMantPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub
End Class