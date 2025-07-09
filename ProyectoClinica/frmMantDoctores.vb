Imports MySql.Data.MySqlClient

Public Class frmMantDoctores

  Private conexion As Conexion

  Private Sub frmMantDoctores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

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
        frmDashboard.Show()
        Me.Close()
    End Select
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub CargarDoctores(Optional nombre As String = "", Optional apellido As String = "", Optional especialidad As String = "")
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT * FROM "
      Dim dt = New DataTable
      Dim parteWhere = ""
      Dim comandoFiltro = ""

      If TipoUsuario = "Administrador" Then
        selectQuery = selectQuery & "vDoctor"
      Else
        selectQuery = selectQuery & "vDoctorSecretaria"
      End If

      If Not (String.IsNullOrWhiteSpace(nombre) AndAlso String.IsNullOrWhiteSpace(apellido) AndAlso String.IsNullOrWhiteSpace(especialidad)) Then
        parteWhere = " Where "
        If Not String.IsNullOrWhiteSpace(nombre) Then
          comandoFiltro = comandoFiltro & "nombre like @Nombre"
        End If

        If Not String.IsNullOrWhiteSpace(apellido) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "apellidos like @apellido"
        End If

        If Not String.IsNullOrWhiteSpace(especialidad) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "especialidad like @especialidad"
        End If
      End If
      selectQuery = selectQuery & parteWhere & comandoFiltro

      Using command As New MySqlCommand(selectQuery, conn)

        'Asignar los parametros
        If Not String.IsNullOrWhiteSpace(nombre) Then
          command.Parameters.AddWithValue("@Nombre", "%" & nombre & "%")
        End If
        If Not String.IsNullOrWhiteSpace(apellido) Then
          command.Parameters.AddWithValue("@apellido", "%" & apellido & "%")
        End If
        If Not String.IsNullOrWhiteSpace(especialidad) Then
          command.Parameters.AddWithValue("@especialidad", "%" & especialidad & "%")
        End If

        Dim adaptador = New MySqlDataAdapter(command)
        'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
        adaptador.Fill(dt)
      End Using

      If TipoUsuario = "Administrador" Then
        ConfigurarColumnasDoctor()
      Else
        ConfigurarColumnasDoctorSecretaria()
      End If

      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvDoctores.DataSource = dt
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
    colID.DataPropertyName = "ID"
    colID.Visible = False
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "APELLIDOS"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cédula"
    colIdentificacion.DataPropertyName = "IDENTIFICACION"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colIdentificacion)

    Dim colDireccion As New DataGridViewTextBoxColumn()
    colDireccion.HeaderText = "Dirección"
    colDireccion.DataPropertyName = "DIRECCION"
    colDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colDireccion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "TELEFONO"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colTelefono)

    Dim colCorreoPers As New DataGridViewTextBoxColumn()
    colCorreoPers.HeaderText = "Correo Personal"
    colCorreoPers.DataPropertyName = "CORREO_PERSONAL"
    colCorreoPers.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colCorreoPers)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Usuario"
    colUsuario.DataPropertyName = "USUARIO"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colUsuario)

    Dim colEspec As New DataGridViewTextBoxColumn()
    colEspec.HeaderText = "Especialidad"
    colEspec.DataPropertyName = "ESPECIALIDAD"
    colEspec.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colEspec)
  End Sub

  Private Sub ConfigurarColumnasDoctorSecretaria()
    dgvDoctores.AutoGenerateColumns = False
    dgvDoctores.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "ID"
    colID.Visible = False
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "APELLIDOS"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colApellidos)

    Dim colEspec As New DataGridViewTextBoxColumn()
    colEspec.HeaderText = "Especialidad"
    colEspec.DataPropertyName = "ESPECIALIDAD"
    colEspec.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colEspec)
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    frmCrearDoctor.Show()
    Me.Hide()
  End Sub
End Class