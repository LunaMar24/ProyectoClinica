﻿Public Class frmDashboard

  Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
    frmLogin.Show()
    Me.Close()
  End Sub

  Private Sub btnDoctores_Click(sender As Object, e As EventArgs) Handles btnDoctores.Click
    frmMantDoctores.Show()
    frmMantDoctores.AjustarPantalla()
    Me.Hide()
  End Sub

  Public Sub AjustarPantalla()
    btnConsultas.Enabled = True
    btnPersonas.Enabled = True
    btnDoctores.Enabled = True
    btnEspecialidades.Enabled = True
    btnUsuarios.Enabled = True


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
    frmMantUsuarios.Show()
    Me.Hide()
  End Sub

  Private Sub btnEspecialidades_Click(sender As Object, e As EventArgs) Handles btnEspecialidades.Click
    frmEspecialidades.Show()
    Me.Hide()
  End Sub

  Private Sub btnPersonas_Click(sender As Object, e As EventArgs) Handles btnPersonas.Click
    frmMantPacientes.Show()
    frmMantPacientes.AjustarPantalla()
    Me.Hide()

  End Sub
End Class