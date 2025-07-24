
Public Class frmCrearDoctor
  Implements IFormularios

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarEspecialidades()
    CargarUsuarios()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
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
    Dim especialidad As Integer = cmbEspecialidad.SelectedValue
    Dim usuario As Integer = cmbUsuario.SelectedValue

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

    If especialidad = -1 OrElse
        usuario = -1 Then
      MessageBox.Show("La especialidad y el usuario se deben indicar. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      ' Insertar el usuario
      Dim dbDoctor As New DoctorDAO()
      Dim doctor As New Doctor With {
        .Identificacion = identificacion,
        .NombreCompleto = nombre,
        .Apellido = apellido,
        .Direccion = direccion,
        .Telefono = telefono,
        .Correo = correo,
        .Edad = edad,
        .Sexo = sexo,
        .UsuariosIdusuarios = usuario
      }

      Dim idInsertado As Integer = dbDoctor.Insert(doctor)
      dbDoctor.Dispose()

      If idInsertado > 0 Then
        Dim dbEspecialidad As New DoctorEspecialidadDAO()
        Dim doctorEspecialidad As New DoctorEspecialidad With {
          .DoctorId = idInsertado,
          .EspecialidadId = especialidad
        }
        dbEspecialidad.Dispose()
        Dim rowsAffected As Integer = dbEspecialidad.Insert(doctorEspecialidad)

        If rowsAffected > 0 Then
          MessageBox.Show("Doctor '" & nombre & " " & apellido & "' registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
          ' Opcional: Limpiar los campos después de un registro exitoso
          txtIdentificacion.Clear()
          txtNombre.Clear()
          txtApellido.Clear()
          txtTelefono.Clear()
          txtCorreo.Clear()
          txtEdad.Clear()
          txtDireccion.Clear()
          cmbSexo.SelectedIndex = -1 ' Limpia la selección del ComboBox
          cmbSexo.Text = ""
          'Si tenemos especialidades seleccionamos la primera
          If cmbEspecialidad.Items.Count > 0 Then
            cmbEspecialidad.SelectedValue = 0
          End If
          'Si tenemos usuarios de tipo doctor, seleccionamos el primero
          If cmbUsuario.Items.Count > 0 Then
            cmbUsuario.SelectedValue = 0
          End If
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

  Sub CargarUsuarios()
    Try
      Dim dbUsuarios As New VNuevosUsuariosDoctoresDAO()
      Dim usuarios As List(Of VNuevosUsuariosDoctores) = dbUsuarios.GetByFilters()
      dbUsuarios.Dispose()

      cmbUsuario.DataSource = usuarios
      cmbUsuario.DisplayMember = "CodigoUsuario"
      cmbUsuario.ValueMember = "Id"
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar los usuarios.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacion.Validating, txtNombre.Validating, txtApellido.Validating, txtTelefono.Validating, txtCorreo.Validating, txtEdad.Validating, cmbSexo.Validating, txtDireccion.Validating, cmbEspecialidad.Validating, cmbUsuario.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

End Class