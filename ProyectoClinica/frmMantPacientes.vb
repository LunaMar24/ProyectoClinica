Imports MySql.Data.MySqlClient

Public Class frmMantPacientes

  Private conexion As Conexion

  Private Sub frmMantPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

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
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT * FROM "
      Dim dt = New DataTable
      Dim parteWhere = ""
      Dim comandoFiltro = ""

      If TipoUsuario = "Doctor" Then
        selectQuery = selectQuery & "vPaciente"
      Else
        selectQuery = selectQuery & "vPacienteSecretaria"
      End If

      If Not (String.IsNullOrWhiteSpace(nombre) AndAlso String.IsNullOrWhiteSpace(apellido) AndAlso String.IsNullOrWhiteSpace(Cedula)) Then
        parteWhere = " Where "
        If Not String.IsNullOrWhiteSpace(nombre) Then
          comandoFiltro = comandoFiltro & "nombre like @Nombre"
        End If

        If Not String.IsNullOrWhiteSpace(apellido) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "apellido like @Apellido"
        End If

        If Not String.IsNullOrWhiteSpace(Cedula) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "cedula like @Cedula"
        End If
      End If
      selectQuery = selectQuery & parteWhere & comandoFiltro

      Using command As New MySqlCommand(selectQuery, conn)

        'Asignar los parametros
        If Not String.IsNullOrWhiteSpace(nombre) Then
          command.Parameters.AddWithValue("@Nombre", "%" & nombre & "%")
        End If
        If Not String.IsNullOrWhiteSpace(apellido) Then
          command.Parameters.AddWithValue("@Apellido", "%" & apellido & "%")
        End If
        If Not String.IsNullOrWhiteSpace(Cedula) Then
          command.Parameters.AddWithValue("@Cedula", "%" & Cedula & "%")
        End If

        Dim adaptador = New MySqlDataAdapter(command)
        'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
        adaptador.Fill(dt)
      End Using

      If TipoUsuario = "Doctor" Then
        ConfigurarColumnasPaciente()
      Else
        ConfigurarColumnasPacienteSecretaria()
      End If

      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvPacientes.DataSource = dt
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
    colID.DataPropertyName = "ID"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "APELLIDO"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "CEDULA"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "TELEFONO"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "USUARIO"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)

    Dim colConsultas As New DataGridViewTextBoxColumn()
    colConsultas.HeaderText = "Consultas"
    colConsultas.DataPropertyName = "CANT_CONSULTAS"
    colConsultas.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colConsultas)



  End Sub

  Private Sub ConfigurarColumnasPacienteSecretaria()
    dgvPacientes.AutoGenerateColumns = False
    dgvPacientes.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "ID"
    colID.Visible = False
    dgvPacientes.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellido"
    colApellidos.DataPropertyName = "APELLIDO"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cedula"
    colIdentificacion.DataPropertyName = "CEDULA"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colIdentificacion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "TELEFONO"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colTelefono)

    Dim colCorreo As New DataGridViewTextBoxColumn()
    colCorreo.HeaderText = "Correo Electrónico"
    colCorreo.DataPropertyName = "CORREO_ELECTRONICO"
    colCorreo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colCorreo)


    Dim colEdad As New DataGridViewTextBoxColumn()
    colEdad.HeaderText = "Edad"
    colEdad.DataPropertyName = "EDAD"
    colEdad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colEdad)

    ' Género
    Dim colGenero As New DataGridViewTextBoxColumn()
    colGenero.HeaderText = "Género"
    colGenero.DataPropertyName = "GENERO"
    colGenero.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colGenero)

    ' Usuario
    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Codigo Usuario"
    colUsuario.DataPropertyName = "USUARIO"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvPacientes.Columns.Add(colUsuario)
  End Sub


End Class