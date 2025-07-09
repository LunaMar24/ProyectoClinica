Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmCrearDoctor

  Private conexion As Conexion

  Private Sub frmCrearDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
    CargarEspecialidades()
    CargarUsuarios()
  End Sub


  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
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
    Dim especialidad As Integer = cmbEspecialidad.SelectedValue
    Dim usuario As Integer = cmbUsuario.SelectedValue

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
      Dim conn = conexion.Abrir()
      Dim insertQuery As String = "INSERT INTO doctor (identificacion, nombre_completo, apellido, direccion, telefono, correo, edad, sexo, usuarios_idusuarios) " &
                                  "VALUES (@identificacion, @nombre_completo, @apellido, @direccion, @telefono, @correo, @edad, @sexo, @usuarios_idusuarios)"

      Using command As New MySqlCommand(insertQuery, conn)
        ' Añadir parámetros para evitar inyección SQL
        command.Parameters.AddWithValue("@identificacion", identificacion)
        command.Parameters.AddWithValue("@nombre_completo", nombre)
        command.Parameters.AddWithValue("@apellido", apellido)
        command.Parameters.AddWithValue("@direccion", direccion)
        command.Parameters.AddWithValue("@telefono", telefono)
        command.Parameters.AddWithValue("@correo", correo)
        command.Parameters.AddWithValue("@edad", edad)
        command.Parameters.AddWithValue("@sexo", sexo)
        command.Parameters.AddWithValue("@usuarios_idusuarios", usuario)

        Dim rowsAffected = command.ExecuteNonQuery

        If rowsAffected > 0 Then
          ' Obtener el ID generado
          Dim idInsertado As Long = command.LastInsertedId
          Dim insertEspQuery As String = "INSERT INTO doctor_especialidad (doctor_id, especialidad_id) VALUES (@doctor, @especialidad)"
          Using especialidaDoctor As New MySqlCommand(insertEspQuery, conn)
            especialidaDoctor.Parameters.AddWithValue("@doctor", idInsertado)
            especialidaDoctor.Parameters.AddWithValue("@especialidad", especialidad)

            rowsAffected = especialidaDoctor.ExecuteNonQuery

            If rowsAffected = 0 Then
              MessageBox.Show("No se pudo registrar la especialidad para el doctor registrado.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
          End Using

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
          MessageBox.Show("No se pudo registrar el doctor. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End Using

    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar un doctor: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub


  Sub CargarEspecialidades()
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT id, descripcion FROM especialidad"
      Dim adaptador = New MySqlDataAdapter(selectQuery, conn)
      Dim dt As New DataTable()

      'El adaptador va a cargar el datatable con lo que se leyo de la base de datos
      adaptador.Fill(dt)
      'La vista se va a llenar con lo que tenga la table que se llenoel adaptador
      cmbEspecialidad.DataSource = dt
      cmbEspecialidad.DisplayMember = "descripcion"
      cmbEspecialidad.ValueMember = "id"
      cmbEspecialidad.Update()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarUsuarios()
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT idusuarios, correo FROM usuarios where tipo_usuario = 'Doctor' and idusuarios not in (select usuarios_idusuarios from doctor)"
      Dim adaptador = New MySqlDataAdapter(selectQuery, conn)
      Dim dt As New DataTable()

      'El adaptador va a cargar el datatable con lo que se leyo de la base de datos
      adaptador.Fill(dt)
      'La vista se va a llenar con lo que tenga la table que se llenoel adaptador
      cmbUsuario.DataSource = dt
      cmbUsuario.DisplayMember = "correo"
      cmbUsuario.ValueMember = "idusuarios"

    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar los usuarios.error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

End Class