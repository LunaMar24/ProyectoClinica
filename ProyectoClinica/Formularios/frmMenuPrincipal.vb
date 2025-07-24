Public Class frmMenuPrincipal
  Implements IFormularios

  Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
    If MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
      PantallaManager.Finalizar()

      frmLogin.Show()
      Me.Close()
    End If
  End Sub

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    PantallaManager.Inicializar(Me.pnlPantallas)

    btnConsultas.Enabled = True
    btnPersonas.Enabled = True
    btnDoctores.Enabled = True
    btnEspecialidades.Enabled = True
    btnUsuarios.Enabled = True
    btnReporte.Enabled = False


    Select Case TipoUsuario
      Case "Administrador"
        btnConsultas.Enabled = False
        btnPersonas.Enabled = False
      Case "Doctor"
        btnDoctores.Enabled = False
        btnEspecialidades.Enabled = False
        btnUsuarios.Enabled = False
      Case "Paciente"
        btnPersonas.Enabled = False
        btnDoctores.Enabled = False
        btnEspecialidades.Enabled = False
        btnUsuarios.Enabled = False
      Case "Secretaria"
        btnConsultas.Enabled = False
        btnEspecialidades.Enabled = False
        btnUsuarios.Enabled = False
        btnReporte.Enabled = True
      Case Else
        MessageBox.Show("Tipo de usuario no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnConsultas.Enabled = False
        btnPersonas.Enabled = False
        btnDoctores.Enabled = False
        btnEspecialidades.Enabled = False
        btnUsuarios.Enabled = False
    End Select
  End Sub

  Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
    PantallaManager.LlamarPantallaHija(New frmMantUsuarios(), Me)
  End Sub

  Private Sub btnEspecialidades_Click(sender As Object, e As EventArgs) Handles btnEspecialidades.Click
    PantallaManager.LlamarPantallaHija(New frmEspecialidades(), Me)
  End Sub

  Private Sub btnDoctores_Click(sender As Object, e As EventArgs) Handles btnDoctores.Click
    PantallaManager.LlamarPantallaHija(New frmMantDoctores(), Me)
  End Sub

  Private Sub btnPersonas_Click(sender As Object, e As EventArgs) Handles btnPersonas.Click
    PantallaManager.LlamarPantallaHija(New frmMantPacientes(), Me)
  End Sub

  Private Sub btnConsultas_Click(sender As Object, e As EventArgs) Handles btnConsultas.Click
    PantallaManager.LlamarPantallaHija(New frmConsultaCitas(), Me)
  End Sub

  Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
    PantallaManager.LlamarPantallaHija(New frmReporte(), Me)
  End Sub

End Class