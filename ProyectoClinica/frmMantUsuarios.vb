Imports MySql.Data.MySqlClient

Public Class frmMantUsuarios

  Private conexion As Conexion

  Private Sub frmMantUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    frmCrearCuenta.Show()
    Me.Hide()
  End Sub
End Class