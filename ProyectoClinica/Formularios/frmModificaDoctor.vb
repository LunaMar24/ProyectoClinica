
Public Class frmModificaDoctor
  Implements IFormularios

  Private _idDoctor As Integer
  Private _idUsuarioDoctor As Integer

  WriteOnly Property IdDoctor As Integer
    Set(value As Integer)
      _idDoctor = value
    End Set
  End Property

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarEspecialidades()
    CargarDoctor()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmMantDoctores.Show()
    frmMantDoctores.AjustarPantalla()
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
    Dim especialidad As Integer = cmbEspecialidad.SelectedValue

    ValidateChildren() ' Valida los campos antes de continuar

    If String.IsNullOrWhiteSpace(nombre) OrElse
        String.IsNullOrWhiteSpace(correo) OrElse
        String.IsNullOrWhiteSpace(identificacion) OrElse
        String.IsNullOrWhiteSpace(apellido) OrElse
        String.IsNullOrWhiteSpace(telefono) OrElse
        String.IsNullOrWhiteSpace(edad) OrElse
        String.IsNullOrWhiteSpace(sexo) OrElse
        String.IsNullOrWhiteSpace(direccion) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If especialidad = -1 Then
      MessageBox.Show("La especialidad se debe indicar. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      ' Modificar el usuario
      Dim dbDoctor As New DoctorDAO()
      Dim doctor As New Doctor With {
        .Id = _idDoctor,
        .Identificacion = identificacion,
        .NombreCompleto = nombre,
        .Apellido = apellido,
        .Direccion = direccion,
        .Telefono = telefono,
        .Correo = correo,
        .Edad = edad,
        .Sexo = sexo,
        .UsuariosIdusuarios = _idUsuarioDoctor
      }

      Dim rowsAffected As Integer = dbDoctor.Update(doctor)
      dbDoctor.Dispose()

      If rowsAffected > 0 Then
        Dim dbEspecialidad As New DoctorEspecialidadDAO()
        Dim doctorEspecialidad As DoctorEspecialidad = dbEspecialidad.GetByDoctorId(_idDoctor)
        dbEspecialidad.Dispose()

        doctorEspecialidad.EspecialidadId = especialidad

        rowsAffected = dbEspecialidad.Update(doctorEspecialidad)

        If rowsAffected > 0 Then
          MessageBox.Show("Doctor '" & nombre & " " & apellido & "' modificado exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

          txtIdentificacion.Focus() ' Poner el foco en el campo de usuario

          frmMantDoctores.Show()
          frmMantDoctores.AjustarPantalla()
          Me.Close()
        Else
          MessageBox.Show("No se pudo registrar la especialidad para el doctor registrado.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      Else
        MessageBox.Show("No se pudo registrar el doctor. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar un doctor: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarEspecialidades()
    Try
      Dim dbEspecialidad As New EspecialidadDAO()
      Dim especialidad As List(Of Especialidad) = dbEspecialidad.GetAll()
      dbEspecialidad.Dispose()

      cmbEspecialidad.DataSource = especialidad
      cmbEspecialidad.DisplayMember = "descripcion"
      cmbEspecialidad.ValueMember = "id"
      cmbEspecialidad.Update()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarDoctor()
    Try
      Dim dbDoctor As New DoctorDAO()
      Dim doctor As Doctor = dbDoctor.GetById(_idDoctor)
      dbDoctor.Dispose()

      If doctor IsNot Nothing Then
        txtIdentificacion.Text = doctor.Identificacion
        txtNombre.Text = doctor.NombreCompleto
        txtApellido.Text = doctor.Apellido
        txtTelefono.Text = doctor.Telefono
        txtCorreo.Text = doctor.Correo
        txtEdad.Text = doctor.Edad
        cmbSexo.Text = doctor.Sexo
        txtDireccion.Text = doctor.Direccion
        ' Cargar especialidad del doctor
        Dim dbEspecialidad As New DoctorEspecialidadDAO()
        Dim especialidadDoctor As DoctorEspecialidad = dbEspecialidad.GetByDoctorId(doctor.Id)
        dbEspecialidad.Dispose()

        If cmbEspecialidad.Items.Count > 0 Then
          cmbEspecialidad.SelectedValue = especialidadDoctor.EspecialidadId
        Else
          cmbEspecialidad.SelectedIndex = -1 ' No hay especialidades asignadas
        End If
        cmbEspecialidad.Update()
        _idUsuarioDoctor = doctor.UsuariosIdusuarios
      Else
        MessageBox.Show("No se encontró el doctor con ID: " & _idDoctor, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If


    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar los usuarios.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacion.Validating, txtNombre.Validating, txtApellido.Validating, txtTelefono.Validating, txtCorreo.Validating, txtEdad.Validating, cmbSexo.Validating, txtDireccion.Validating, cmbEspecialidad.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

End Class