Public Class frmMantPacientes
  Public Sub AjustarPantalla()
    btnCrear.Enabled = True
    btnModificar.Enabled = True
    btnEliminar.Enabled = True
    btnVerConsultas.Enabled = True
    Select Case TipoUsuario
      Case "Doctor"
        CargarPaciente()
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
      Case "Secretaria"
        CargarPaciente()
        btnVerConsultas.Enabled = False
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnCrear.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnVerConsultas.Enabled = False
        frmDashboard.Show()
        Me.Close()
    End Select
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub CargarPaciente(Optional nombre As String = "", Optional apellido As String = "", Optional Cedula As String = "")
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
        dgvPacientes.DataSource = listaPacientes
      End If

      dgvPacientes.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información del paciente. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    CargarPaciente(txtFilNombre.Text, txtFilApellido.Text, txtFilCedula.Text)
  End Sub

  Private Sub ConfigurarColumnasPaciente()
    dgvPacientes.AutoGenerateColumns = False
    dgvPacientes.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "Apellido"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "Cedula"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "Telefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "Usuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)

    Dim colConsultasP As New DataGridViewTextBoxColumn()
    colConsultasP.HeaderText = "Consultas Pendientes"
    colConsultasP.DataPropertyName = "ConsultasPendientes"
    colConsultasP.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colConsultasP)

    Dim colConsultasF As New DataGridViewTextBoxColumn()
    colConsultasF.HeaderText = "Consultas Finalizadas"
    colConsultasF.DataPropertyName = "ConsultasFinalizadas"
    colConsultasF.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colConsultasF)
  End Sub


  Private Sub ConfigurarColumnasPacienteSecretaria()
    dgvPacientes.AutoGenerateColumns = False
    dgvPacientes.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "Nombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "Apellido"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "Cedula"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "Telefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colCorreo As New DataGridViewTextBoxColumn()
    colCorreo.HeaderText = "Correo Electrónico"
    colCorreo.DataPropertyName = "CorreoElectronico"
    colCorreo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colCorreo)

    Dim colEdad As New DataGridViewTextBoxColumn()
    colEdad.HeaderText = "Edad"
    colEdad.DataPropertyName = "Edad"
    colEdad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colEdad)

    Dim colGenero As New DataGridViewTextBoxColumn()
    colGenero.HeaderText = "Género"
    colGenero.DataPropertyName = "Genero"
    colGenero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colGenero)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "Usuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)
  End Sub

End Class