Imports System.Security.Cryptography
Imports System.Text

Public Class frmCrearCuenta
  Implements IFormularios

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    'No se requiere para esta pantalla
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    Dim nombre As String = txtNombre.Text
    Dim correo As String = txtCorreo.Text
    Dim contrasena As String = txtContrasena.Text
    Dim tipoUsuario As String = cboTipoUsuario.Text

    If Not ValidateChildren() Then
      Return
    End If

    If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(correo) OrElse String.IsNullOrWhiteSpace(contrasena) OrElse String.IsNullOrWhiteSpace(tipoUsuario) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      Dim usuario As New Usuario With {
        .Nombre = nombre,
        .Correo = correo,
        .Password = HashSHA256(contrasena), ' ¡Recordatorio: en una app real, hashea las contraseñas!
        .TipoUsuario = tipoUsuario
      }

      Dim BDUsuario As New UsuariosDAO()

      Dim idUsuario As Integer = BDUsuario.Insert(usuario)

      BDUsuario.Dispose() 'Asegurarse de liberar recursos
      BDUsuario = Nothing

      If idUsuario > 0 Then
        MessageBox.Show("Usuario '" & nombre & "' registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Opcional: Limpiar los campos después de un registro exitoso
        txtNombre.Clear()
        txtContrasena.Clear()
        txtCorreo.Clear()
        cboTipoUsuario.Text = ""
        txtNombre.Focus() ' Poner el foco en el campo de usuario
        btnRegresar.PerformClick()
      Else
        MessageBox.Show("No se pudo registrar el usuario. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar usuario: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Function HashSHA256(texto As String) As String
    Using sha256 As SHA256 = SHA256.Create()
      Dim bytes As Byte() = Encoding.UTF8.GetBytes(texto)
      Dim hash As Byte() = sha256.ComputeHash(bytes)
      Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Using
  End Function

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating, txtCorreo.Validating, txtContrasena.Validating, cboTipoUsuario.Validating
    Dim campo As Control = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrPError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrPError.SetError(campo, "")
    End If
  End Sub


End Class