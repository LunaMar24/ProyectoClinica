Public Class frmMantPacientes
  Implements IFormularios

  Private idPaciente As Integer
  Private nombrePaciente As String

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    btnCrear.Enabled = True
    btnModificar.Enabled = True
    btnEliminar.Enabled = True
    btnVerConsultas.Enabled = True
    Select Case TipoUsuario
      Case "Doctor"
        CargarPacientes()
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
      Case "Secretaria"
        CargarPacientes()
        btnVerConsultas.Enabled = False
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnVerConsultas.Enabled = False
        PantallaManager.RegresarDesdeFormularioHijo()
    End Select
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub
  Private Sub CargarPacientes(Optional nombre As String = "", Optional apellido As String = "", Optional Cedula As String = "")
    Try
      If TipoUsuario = "Doctor" Then
        Dim dbPaciente As New VPacienteDAO
        Dim filtros As New Dictionary(Of String, Object) From {
            {"Nombre", nombre},
            {"Apellido", apellido},
            {"Cedula", Cedula}
        }
        Dim listaPacientes As List(Of VPaciente) = dbPaciente.GetByFilters(filtros)
        dbPaciente.Dispose()
        ConfigurarColumnasPaciente()
        dgvPacientes.DataSource = listaPacientes
      Else
        Dim dbPacienteSecre As New VPacienteSecretariaDAO
        Dim filtros As New Dictionary(Of String, Object) From {
            {"Nombre", nombre},
            {"Apellido", apellido},
            {"Cedula", Cedula}
        }
        Dim listaPacientes As List(Of VPacienteSecretaria) = dbPacienteSecre.GetByFilters(filtros)
        dbPacienteSecre.Dispose()
        ConfigurarColumnasPacienteSecretaria()
        idPaciente = -1
        dgvPacientes.DataSource = listaPacientes
      End If

      dgvPacientes.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información del paciente. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub
  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    CargarPacientes(txtFilNombre.Text, txtFilApellido.Text, txtFilCedula.Text)
  End Sub

  Private Sub ConfigurarColumnasPaciente()
    dgvPacientes.AutoGenerateColumns = False
    dgvPacientes.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Name = "colID"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "Apellido"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "Cedula"
    colIdentificacion.Name = "colIdentificacion"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "Telefono"
    colTelefono.Name = "colTelefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "Usuario"
    colUsuario.Name = "colUsuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)

    Dim colConsultasP As New DataGridViewTextBoxColumn()
    colConsultasP.HeaderText = "Consultas Pendientes"
    colConsultasP.DataPropertyName = "ConsultasPendientes"
    colConsultasP.Name = "colConsultasP"
    colConsultasP.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colConsultasP)

    Dim colConsultasF As New DataGridViewTextBoxColumn()
    colConsultasF.HeaderText = "Consultas Finalizadas"
    colConsultasF.DataPropertyName = "ConsultasFinalizadas"
    colConsultasF.Name = "colConsultasF"
    colConsultasF.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colConsultasF)
  End Sub

  Private Sub ConfigurarColumnasPacienteSecretaria()
    dgvPacientes.AutoGenerateColumns = False
    dgvPacientes.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Name = "colID"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "Apellido"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "Cedula"
    colIdentificacion.Name = "colIdentificacion"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "Telefono"
    colTelefono.Name = "colTelefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colCorreo As New DataGridViewTextBoxColumn()
    colCorreo.HeaderText = "Correo Electrónico"
    colCorreo.DataPropertyName = "CorreoElectronico"
    colCorreo.Name = "colCorreo"
    colCorreo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colCorreo)

    Dim colEdad As New DataGridViewTextBoxColumn()
    colEdad.HeaderText = "Edad"
    colEdad.DataPropertyName = "Edad"
    colEdad.Name = "colEdad"
    colEdad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colEdad)

    Dim colGenero As New DataGridViewTextBoxColumn()
    colGenero.HeaderText = "Género"
    colGenero.DataPropertyName = "Genero"
    colGenero.Name = "colGenero"
    colGenero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colGenero)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "Usuario"
    colUsuario.Name = "colUsuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    PantallaManager.LlamarPantallaHija(New frmCrearPaciente, Me)
  End Sub
  Private Sub dgvPacientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPacientes.CellClick
    If e.RowIndex >= 0 Then
      idPaciente = Integer.Parse(dgvPacientes.Rows(e.RowIndex).Cells("colId").Value)
      nombrePaciente = dgvPacientes.Rows(e.RowIndex).Cells("colNombre").Value
    End If
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
    If idPaciente > 0 Then
      Dim frmModificaPaciente As New frmModificaPaciente()
      frmModificaPaciente.idPaciente = idPaciente
      PantallaManager.LlamarPantallaHija(frmModificaPaciente, Me)
    Else
      MessageBox.Show("Debe seleccionar el paciente a modificar.", "Modificar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    If idPaciente > 0 Then
      Dim resultado As DialogResult = MessageBox.Show("Toda información relacionada a este paciente (" & nombrePaciente & ") será eliminada" & vbCrLf & vbCrLf & "¿Está seguro de que desea eliminar este paciente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If resultado = DialogResult.Yes Then
        Try
          Dim dbPaciente As New PersonaDAO()

          If dbPaciente.Delete(idPaciente) > 0 Then
            MessageBox.Show("Paciente eliminado correctamente.", "Eliminar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarPacientes()
          Else
            MessageBox.Show("Se presentó un error al eliminar el paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End If
        Catch ex As Exception
          MessageBox.Show("Se presentó un error al eliminar el paciente. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
      End If
    Else
      MessageBox.Show("Debe seleccionar el paciente a eliminar.", "Eliminar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub
End Class