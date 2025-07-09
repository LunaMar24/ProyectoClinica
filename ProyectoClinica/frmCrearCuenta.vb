Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmCrearCuenta

  Private conexion As Conexion

  Private Sub frmCrearCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmMantUsuarios.Show()
    Me.Close()
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    Dim nombre As String = txtNombre.Text
    Dim correo As String = txtCorreo.Text
    Dim contrasena As String = txtContrasena.Text
    Dim tipoUsuario As String = cboTipoUsuario.Text


    If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(correo) OrElse String.IsNullOrWhiteSpace(contrasena) OrElse String.IsNullOrWhiteSpace(tipoUsuario) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      Dim conn = conexion.Abrir()
      Dim insertQuery = "INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES (@nombre, @password, @correo, @tipoUsuario)"
      Using command As New MySqlCommand(insertQuery, conn)
        ' Añadir parámetros para evitar inyección SQL
        command.Parameters.AddWithValue("@nombre", nombre)
        command.Parameters.AddWithValue("@password", HashSHA256(contrasena)) ' ¡Recordatorio: en una app real, hashea las contraseñas!
        command.Parameters.AddWithValue("@correo", correo)
        command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario)

        Dim rowsAffected = command.ExecuteNonQuery

        If rowsAffected > 0 Then
          MessageBox.Show("Usuario '" & nombre & "' registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
          ' Opcional: Limpiar los campos después de un registro exitoso
          txtNombre.Clear()
          txtContrasena.Clear()
          txtCorreo.Clear()
          cboTipoUsuario.Text = ""
          txtNombre.Focus() ' Poner el foco en el campo de usuario

        Else
          MessageBox.Show("No se pudo registrar el usuario. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End Using

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

End Class