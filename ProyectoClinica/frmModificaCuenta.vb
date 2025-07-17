Imports MySql.Data.MySqlClient

Public Class frmModificaCuenta
  Implements IFormularios

  Private _idUsuario As Integer
  Public WriteOnly Property UsuarioID() As Integer
    Set(ByVal value As Integer)
      _idUsuario = value
    End Set
  End Property

  Private conexion As Conexion

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarDatosUsuario()
  End Sub

  Private Sub CargarDatosUsuario()
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT nombre, correo, password, tipo_usuario FROM usuarios WHERE idusuarios = @idUsuario"
      Dim dt = New DataTable
      Using command As New MySqlCommand(selectQuery, conn)
        command.Parameters.AddWithValue("@idUsuario", _idUsuario)

        Dim adaptador = New MySqlDataAdapter(command)

        adaptador.Fill(dt)
      End Using

      If dt.Rows.Count > 0 Then
        txtNombre.Text = dt.Rows(0)("nombre").ToString()
        txtCorreo.Text = dt.Rows(0)("correo").ToString()
        cboTipoUsuario.Text = dt.Rows(0)("tipo_usuario").ToString()
      Else
        MessageBox.Show("No se encontraron datos para el usuario seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información del usuario. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub frmModificaCuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmMantUsuarios.Show()
    frmMantUsuarios.AjustarPantalla()
    Me.Close()
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
      Dim conn = conexion.Abrir()
      Dim updateQuery = "UPDATE usuarios SET nombre = @nombre, correo = @correo, tipo_usuario = @tipoUsuario WHERE idusuarios = @idUsuario"
      Using command As New MySqlCommand(updateQuery, conn)
        ' Añadir parámetros para evitar inyección SQL
        command.Parameters.AddWithValue("@nombre", nombre)
        command.Parameters.AddWithValue("@correo", correo)
        command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario)

        command.Parameters.AddWithValue("@idUsuario", _idUsuario)

        Dim rowsAffected = command.ExecuteNonQuery

        If rowsAffected > 0 Then
          MessageBox.Show("Usuario '" & nombre & "' actualizado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

          btnRegresar.PerformClick() ' Regresar a la pantalla de mantenimiento de usuarios
        Else
          MessageBox.Show("No se pudo registrar el usuario. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End Using

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