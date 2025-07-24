Public Class frmMantDoctores

  Private idDoctor As Integer
  Private nombreDoctor As String
  Private especialidad As String

  Public Sub AjustarPantalla()
    btnCrear.Enabled = True
    btnModificar.Enabled = True
    btnEliminar.Enabled = True
    btnAsignarConsulta.Enabled = True
    Select Case TipoUsuario
      Case "Administrador"
        CargarDoctores()
        btnAsignarConsulta.Enabled = False
      Case "Secretaria"
        CargarDoctores()
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnAsignarConsulta.Enabled = False
        PantallaManager.RegresarDesdeFormularioHijo()
    End Select
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub CargarDoctores(Optional nombre As String = "", Optional apellido As String = "", Optional especialidad As String = "")
    Try
      If TipoUsuario = "Administrador" Then
        Dim dbvDoctor As New VDoctorDAO
        Dim filtros As New Dictionary(Of String, Object) From {
              {"Nombre", nombre},
              {"Apellidos", apellido},
              {"Especialidad", especialidad}
        }

        Dim listaDoctores As List(Of VDoctor) = dbvDoctor.GetByFilters(filtros)
        dbvDoctor.Dispose()

        ConfigurarColumnasDoctor()
        dgvDoctores.DataSource = listaDoctores

      Else
        Dim dbvDoctorSecre As New VDoctorSecretariaDAO
        Dim filtros As New Dictionary(Of String, Object) From {
              {"Nombre", nombre},
              {"Apellidos", apellido},
              {"Especialidad", especialidad}
        }

        Dim listaDoctores As List(Of VDoctorSecretaria) = dbvDoctorSecre.GetByFilters(filtros)
        dbvDoctorSecre.Dispose()

        ConfigurarColumnasDoctorSecretaria()
        dgvDoctores.DataSource = listaDoctores
      End If

      idDoctor = -1
      nombreDoctor = ""

      dgvDoctores.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información de los doctores. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    CargarDoctores(txtFilNombre.Text, txtFilApellido.Text, txtFilEspecialidad.Text)
  End Sub


  Private Sub ConfigurarColumnasDoctor()
    dgvDoctores.AutoGenerateColumns = False
    dgvDoctores.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Visible = False
    colID.Name = "colID"
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "Apellidos"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Identificación"
    colIdentificacion.DataPropertyName = "Identificacion"
    colIdentificacion.Name = "colIdentificacion"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colIdentificacion)

    Dim colDireccion As New DataGridViewTextBoxColumn()
    colDireccion.HeaderText = "Dirección"
    colDireccion.DataPropertyName = "Direccion"
    colDireccion.Name = "colDireccion"
    colDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colDireccion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "Telefono"
    colTelefono.Name = "colTelefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colTelefono)

    Dim colCorreo As New DataGridViewTextBoxColumn()
    colCorreo.HeaderText = "Correo Personal"
    colCorreo.DataPropertyName = "CorreoPersonal"
    colCorreo.Name = "colCorreo"
    colCorreo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colCorreo)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Usuario"
    colUsuario.DataPropertyName = "Usuario"
    colUsuario.Name = "colUsuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colUsuario)

    Dim colEspecialidad As New DataGridViewTextBoxColumn()
    colEspecialidad.HeaderText = "Especialidad"
    colEspecialidad.DataPropertyName = "Especialidad"
    colEspecialidad.Name = "colEspec"
    colEspecialidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colEspecialidad)
  End Sub

  Private Sub ConfigurarColumnasDoctorSecretaria()
    dgvDoctores.AutoGenerateColumns = False
    dgvDoctores.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Name = "colID"
    colID.Visible = False
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "Apellidos"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colApellidos)

    Dim colEspec As New DataGridViewTextBoxColumn()
    colEspec.HeaderText = "Especialidad"
    colEspec.DataPropertyName = "Especialidad"
    colEspec.Name = "colEspec"
    colEspec.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colEspec)
  End Sub



  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    frmCrearDoctor.Show()
    frmCrearDoctor.AjustarPantalla()
    Me.Hide()
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
    If idDoctor >= 0 Then
      frmModificaDoctor.IdDoctor = idDoctor
      frmModificaDoctor.Show()
      frmModificaDoctor.AjustarPantalla()
      Me.Hide()
    Else
      MessageBox.Show("Debe seleccionar el doctor a modificar.", "Modificar Doctor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    If idDoctor >= 0 Then
      Dim resultado As DialogResult = MessageBox.Show("Toda información relacionada a este doctor (" & nombreDoctor & ") será eliminada" & vbCrLf & vbCrLf & "¿Está seguro de que desea eliminar este doctor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If resultado = DialogResult.Yes Then
        Try
          Dim dbDoctor As New DoctorDAO()

          If dbDoctor.Delete(idDoctor) > 0 Then
            MessageBox.Show("Doctor eliminado correctamente.", "Eliminar Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarDoctores()
          Else
            MessageBox.Show("Se presentó un error al eliminar el doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End If
        Catch ex As Exception
          MessageBox.Show("Se presentó un error al eliminar el doctor. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
      End If
    Else
      MessageBox.Show("Debe seleccionar el doctor a eliminar.", "Eliminar Doctor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub
  Private Sub btnAsignarConsulta_Click(sender As Object, e As EventArgs) Handles btnAsignarConsulta.Click

    If idDoctor >= 0 Then
      frmAsignarConsulta.Show()
      frmAsignarConsulta.Doctor = idDoctor
      frmAsignarConsulta.NombreDoctor = nombreDoctor
      frmAsignarConsulta.Especialidad = especialidad
      frmAsignarConsulta.AjustarPantalla()
      Me.Hide()
    Else
      MessageBox.Show("Debe seleccionar un doctor para asignarle un paciente.", "Asignar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub dgvDoctores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctores.CellClick
    If e.RowIndex >= 0 Then
      idDoctor = Integer.Parse(dgvDoctores.Rows(e.RowIndex).Cells("colId").Value)
      nombreDoctor = dgvDoctores.Rows(e.RowIndex).Cells("colNombre").Value & " " & dgvDoctores.Rows(e.RowIndex).Cells("colApellidos").Value
      especialidad = dgvDoctores.Rows(e.RowIndex).Cells("colEspec").Value
    End If
  End Sub


End Class