
Public Class frmModificaPaciente
  Implements IFormularios

  Private _idPaciente As Integer
  Private _idUsuario As Integer

  WriteOnly Property idPaciente As Integer
    Set(value As Integer)
      _idPaciente = value
    End Set
  End Property

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarPaciente()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmMantPacientes.Show()
    frmMantPacientes.AjustarPantalla()
    Me.Close()
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

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

    Try
      ' Insertar el usuario
      Dim dbPaciente As New PersonaDAO()
      Dim personaData As New Persona With {
        .Id = _idPaciente,
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
        .UsuariosIdusuarios = _idUsuario
      }

      Dim rowsAffected As Integer = dbPaciente.Update(personaData)
      dbPaciente.Dispose()

      If rowsAffected > 0 Then

        MessageBox.Show("El Paciente '" & nombre & " " & apellido & "' modificado exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

        txtIdentificacion.Focus() ' Poner el foco en el campo de usuario

        frmMantPacientes.Show()
        frmMantPacientes.AjustarPantalla()
        Me.Close()
      Else
        MessageBox.Show("No se pudo modificar el paciente. Inténtelo de nuevo.", "Error de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al modificar el paciente: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarPaciente()
    Try
      Dim dbPersona As New PersonaDAO()
      Dim persona As Persona = dbPersona.GetById(_idPaciente)
      dbPersona.Dispose()

      If persona IsNot Nothing Then
        _idUsuario = persona.UsuariosIdusuarios
        txtIdentificacion.Text = persona.Identificacion
        txtNombre.Text = persona.NombreCompleto
        txtApellido.Text = persona.Apellido
        txtTelefono.Text = persona.Telefono
        txtCorreo.Text = persona.Correo
        txtEdad.Text = persona.Edad.ToString()
        cmbSexo.SelectedItem = persona.Sexo
        dtpFechaNac.Value = persona.FechaNacimiento
        cmbTipoSangre.SelectedItem = persona.TipoSangre
        txtContactoEmergencia.Text = persona.ContactoEmergencia
        txtDireccion.Text = persona.Direccion
        _idUsuario = persona.UsuariosIdusuarios
      Else
        MessageBox.Show("No se encontró el paciente con ID: " & _idPaciente, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar los pacientes. Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacion.Validating, txtNombre.Validating, txtApellido.Validating, txtTelefono.Validating, txtCorreo.Validating, txtEdad.Validating, cmbSexo.Validating, txtDireccion.Validating, cmbTipoSangre.Validating, txtContactoEmergencia.Validating
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