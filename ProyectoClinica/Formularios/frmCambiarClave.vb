Imports System.Security.Cryptography
Imports System.Text

Public Class frmCambiarClave
  Implements IFormularios
  Private _UsuarioId As Integer

  Public WriteOnly Property UsuarioID As Integer
    Set(value As Integer)
      _UsuarioId = value
    End Set
  End Property


  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla

  End Sub

  Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    frmMantUsuarios.Show()
    frmMantUsuarios.AjustarPantalla()
    Me.Close()
  End Sub

  Private Sub datos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtClaveAnt.Validating, txtNuevaClave.Validating, txtConfirmaClave.Validating
    Dim campo As Control = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

  Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
    ValidateChildren()

    Dim claveActual As String = txtClaveAnt.Text.Trim()
    Dim nuevaClave As String = txtNuevaClave.Text.Trim()
    Dim confirmaClave As String = txtConfirmaClave.Text.Trim()

    'validar que la clave actual no este vacía
    If String.IsNullOrWhiteSpace(claveActual) Then
      MessageBox.Show("La clave actual no puede estar vacía. Por favor, ingrese su clave actual.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    ' Validar que la clave actual coincide con la almacenada
    If Not ValidarClaveUsuario(claveActual) Then
      MessageBox.Show("La clave actual es incorrecta. Por favor, inténtelo de nuevo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    'Validar que la clave actual no sea igual a la nueva clave
    If claveActual = nuevaClave Then
      MessageBox.Show("La nueva clave no puede ser igual a la clave actual. Por favor, elija una clave diferente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    If String.IsNullOrWhiteSpace(nuevaClave) Then
      MessageBox.Show("La nueva clave no puede estar vacía.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    If String.IsNullOrWhiteSpace(confirmaClave) Then
      MessageBox.Show("La confirmación de la clave no puede estar vacía.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    If nuevaClave <> confirmaClave Then
      MessageBox.Show("La nueva clave y la confirmación no coinciden. Por favor, inténtelo de nuevo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    'cambiar la clave del usuario
    Dim dbusuario As New UsuariosDAO()
    Dim usuario As Usuario = dbusuario.GetById(_UsuarioId)

    If usuario IsNot Nothing Then
      usuario.Password = HashSHA256(nuevaClave)
      If dbusuario.CambiarClave(usuario) > 0 Then
        MessageBox.Show("Clave cambiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frmMantUsuarios.Show()
        frmMantUsuarios.AjustarPantalla()
        Me.Close()
      Else
        MessageBox.Show("Error al cambiar la clave. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Else
      MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If

  End Sub

  Private Function ValidarClaveUsuario(claveActual As String) As Boolean
    Dim claveActualHash As String = ""
    Dim dbusuario As New UsuariosDAO()
    Dim usuario As Usuario = dbusuario.GetById(_UsuarioId)
    dbusuario.Dispose()

    If String.IsNullOrWhiteSpace(claveActual) Then
      Return False
    End If

    If usuario IsNot Nothing Then
      ' Compara la clave actual con la almacenada en la base de datos
      claveActualHash = HashSHA256(claveActual)
    End If

    Return usuario.Password = claveActualHash
  End Function


  Private Function HashSHA256(texto As String) As String
    Using sha256 As SHA256 = SHA256.Create()
      Dim bytes As Byte() = Encoding.UTF8.GetBytes(texto)
      Dim hash As Byte() = sha256.ComputeHash(bytes)
      Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Using
  End Function
End Class