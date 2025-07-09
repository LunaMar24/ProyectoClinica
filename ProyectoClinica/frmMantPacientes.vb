Imports MySql.Data.MySqlClient

Public Class frmMantPacientes

  Private conexion As Conexion

  Private Sub frmMantPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Public Sub AjustarPantalla()
    btnCrear.Enabled = True
    btnModificar.Enabled = True
    btnEliminar.Enabled = True
    btnVerConsultas.Enabled = True
    Select Case TipoUsuario
      Case "Administrador"
        CargarPacientes()
        btnVerConsultas.Enabled = False
      Case "Secretaria"
        CargarPacientes()
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnVerConsultas.Enabled = False
        frmDashboard.Show()
        Me.Close()
    End Select
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub
End Class