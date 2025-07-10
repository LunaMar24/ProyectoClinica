Imports MySql.Data.MySqlClient

Public Class frmMantDoctores

  Private conexion As Conexion
  Private idDoctor As Integer
  Private nombreDoctor As String
  Private especialidad As String

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
      idDoctor = -1
      nombreDoctor = ""
      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvDoctores.DataSource = dt
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
    colID.DataPropertyName = "ID"
    colID.Name = "colID"
    colID.Visible = False
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "APELLIDOS"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colApellidos)

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Cédula"
    colIdentificacion.DataPropertyName = "IDENTIFICACION"
    colIdentificacion.Name = "colIdentificacion"
    colIdentificacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colIdentificacion)

    Dim colDireccion As New DataGridViewTextBoxColumn()
    colDireccion.HeaderText = "Dirección"
    colDireccion.DataPropertyName = "DIRECCION"
    colDireccion.Name = "colDireccion"
    colDireccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colDireccion)

    Dim colTelefono As New DataGridViewTextBoxColumn()
    colTelefono.HeaderText = "Teléfono"
    colTelefono.DataPropertyName = "TELEFONO"
    colTelefono.Name = "colTelefono"
    colTelefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colTelefono)

    Dim colCorreoPers As New DataGridViewTextBoxColumn()
    colCorreoPers.HeaderText = "Correo Personal"
    colCorreoPers.DataPropertyName = "CORREO_PERSONAL"
    colCorreoPers.Name = "colCorreoPers"
    colCorreoPers.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colCorreoPers)

    Dim colUsuario As New DataGridViewTextBoxColumn()
    colUsuario.HeaderText = "Usuario"
    colUsuario.DataPropertyName = "USUARIO"
    colUsuario.Name = "colUsuario"
    colUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colUsuario)

    Dim colEspec As New DataGridViewTextBoxColumn()
    colEspec.HeaderText = "Especialidad"
    colEspec.DataPropertyName = "ESPECIALIDAD"
    colEspec.Name = "colEspec"
    colEspec.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    dgvDoctores.Columns.Add(colEspec)
  End Sub


  Private Sub ConfigurarColumnasDoctorSecretaria()
    dgvDoctores.AutoGenerateColumns = False
    dgvDoctores.Columns.Clear()

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "ID"
    colID.Name = "colID"
    colID.Visible = False
    dgvDoctores.Columns.Add(colID)
    colID.Visible = False

    Dim colNombre As New DataGridViewTextBoxColumn()
    colNombre.HeaderText = "Nombre"
    colNombre.DataPropertyName = "NOMBRE"
    colNombre.Name = "colNombre"
    colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colNombre)

    Dim colApellidos As New DataGridViewTextBoxColumn()
    colApellidos.HeaderText = "Apellidos"
    colApellidos.DataPropertyName = "APELLIDOS"
    colApellidos.Name = "colApellidos"
    colApellidos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colApellidos)

    Dim colEspec As New DataGridViewTextBoxColumn()
    colEspec.HeaderText = "Especialidad"
    colEspec.DataPropertyName = "ESPECIALIDAD"
    colEspec.Name = "colEspec"
    colEspec.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    dgvDoctores.Columns.Add(colEspec)
  End Sub


  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    frmCrearDoctor.Show()
    Me.Hide()
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