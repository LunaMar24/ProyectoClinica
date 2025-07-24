Public Class frmModificaCuenta
  Implements IFormularios

  Private _idUsuario As Integer
  Public WriteOnly Property UsuarioID() As Integer
    Set(ByVal value As Integer)
      _idUsuario = value
    End Set
  End Property

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarDatosUsuario()
  End Sub

  Private Sub CargarDatosUsuario()
    Try
      Dim dbUsuario As New UsuariosDAO()
      Dim usuario As Usuario = dbUsuario.GetById(_idUsuario)
      dbUsuario.Dispose() ' Asegurarse de liberar recursos

      If usuario IsNot Nothing Then
        txtNombre.Text = usuario.Nombre
        txtCorreo.Text = usuario.Correo
        cboTipoUsuario.Text = usuario.TipoUsuario
      Else
        MessageBox.Show("No se encontraron datos para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información del usuario. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
    Dim nombre As String = txtNombre.Text
    Dim correo As String = txtCorreo.Text
    Dim tipoUsuario As String = cboTipoUsuario.Text

    If Not ValidateChildren() Then
      Return
    End If

    If String.IsNullOrWhiteSpace(nombre) OrElse String.IsNullOrWhiteSpace(correo) OrElse String.IsNullOrWhiteSpace(tipoUsuario) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      Dim dbUsuario As New UsuariosDAO()
      Dim usuario As New Usuario With {
        .IdUsuarios = _idUsuario,
        .Nombre = nombre,
        .Correo = correo,
        .TipoUsuario = tipoUsuario
      }

      ' Actualizar el usuario en la base de datos
      Dim rowsAffected = dbUsuario.Update(usuario)

      If rowsAffected > 0 Then
        MessageBox.Show("Usuario '" & nombre & "' actualizado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        btnRegresar.PerformClick() ' Regresar a la pantalla de mantenimiento de usuarios
      Else
        MessageBox.Show("No se pudo registrar el usuario. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar usuario: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating, txtCorreo.Validating, cboTipoUsuario.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrPError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrPError.SetError(campo, "")
    End If
  End Sub


End Class