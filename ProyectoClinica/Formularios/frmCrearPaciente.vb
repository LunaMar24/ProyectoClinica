
Public Class frmCrearPaciente
  Implements IFormularios

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarUsuarios()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmMantPacientes.Show()
    frmMantPacientes.AjustarPantalla()
    Me.Close()
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

    Dim identificacion As String = txtIdentificacion.Text
    Dim nombre As String = txtNombre.Text
    Dim apellido As String = txtApellido.Text
    Dim telefono As String = txtTelefono.Text
    Dim correo As String = txtCorreo.Text
    Dim edad As String = txtEdad.Text
    Dim sexo As String = cmbSexo.Text
    Dim direccion As String = txtDireccion.Text
    Dim tipoSangre As String = cmbTipoSangre.Text
    Dim fechaNac As DateTime = dtpFechaNac.Value
    Dim usuario As Integer = cmbUsuario.SelectedValue
    Dim contactoEmergencia As String = txtContactoEmergencia.Text

    ValidateChildren() ' Valida los campos antes de continuar

    If String.IsNullOrWhiteSpace(nombre) OrElse
        String.IsNullOrWhiteSpace(correo) OrElse
        String.IsNullOrWhiteSpace(identificacion) OrElse
        String.IsNullOrWhiteSpace(apellido) OrElse
        String.IsNullOrWhiteSpace(telefono) OrElse
        String.IsNullOrWhiteSpace(edad) OrElse
        String.IsNullOrWhiteSpace(sexo) OrElse
        String.IsNullOrWhiteSpace(direccion) OrElse
        String.IsNullOrWhiteSpace(contactoEmergencia) OrElse
        String.IsNullOrWhiteSpace(tipoSangre) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If usuario = -1 OrElse
        usuario = -1 Then
      MessageBox.Show("El usuario se deben indicar. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      ' Insertar el usuario
      Dim dbPaciente As New PersonaDAO()
      Dim personaData As New Persona With {
        .Identificacion = identificacion,
        .NombreCompleto = nombre,
        .Apellido = apellido,
        .Direccion = direccion,
        .Telefono = telefono,
        .Correo = correo,
        .Edad = edad,
        .Sexo = sexo,
        .FechaNacimiento = fechaNac,
        .TipoSangre = tipoSangre,
        .ContactoEmergencia = contactoEmergencia,
        .UsuariosIdusuarios = usuario
      }

      Dim idInsertado As Integer = dbPaciente.Insert(personaData)
      dbPaciente.Dispose()

      If idInsertado > 0 Then

        MessageBox.Show("El Paciente '" & nombre & " " & apellido & "' registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Opcional: Limpiar los campos después de un registro exitoso
        txtIdentificacion.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtEdad.Clear()
        txtDireccion.Clear()
        cmbSexo.SelectedIndex = -1
        cmbTipoSangre.SelectedIndex = -1
        txtContactoEmergencia.Clear()
        dtpFechaNac.Value = DateTime.Now

        'Si tenemos usuarios de tipo personaData, seleccionamos el primero
        If cmbUsuario.Items.Count > 0 Then
          cmbUsuario.SelectedValue = -1
        End If
        txtIdentificacion.Focus() ' Poner el foco en el campo de usuario

        frmMantPacientes.Show()
        frmMantPacientes.AjustarPantalla()
        Me.Close()
      Else
        MessageBox.Show("No se pudo registrar el personaData. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar un personaData: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarUsuarios()
    Try
      Dim dbUsuarios As New VNuevosUsuariosPacientesDAO()
      Dim usuarios As List(Of VNuevosUsuariosPacientes) = dbUsuarios.GetByFilters()
      dbUsuarios.Dispose()

      cmbUsuario.DataSource = usuarios
      cmbUsuario.DisplayMember = "CodigoUsuario"
      cmbUsuario.ValueMember = "Id"
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar los usuarios.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacion.Validating, txtNombre.Validating, txtApellido.Validating, txtTelefono.Validating, txtCorreo.Validating, txtEdad.Validating, cmbSexo.Validating, txtDireccion.Validating, cmbUsuario.Validating, cmbTipoSangre.Validating, txtContactoEmergencia.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

  Private Sub dtpFechaNac_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaNac.ValueChanged
    txtEdad.Text = (DateTime.Now.Date.Year - dtpFechaNac.Value.Date.Year).ToString()
  End Sub
End Class