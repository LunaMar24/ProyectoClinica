Public Class frmConsultaCitas
  Implements IFormularios

  Dim _idConsulta As Integer
  Dim _nombreDoctor As String
  Dim _nombrePaciente As String
  Dim _especialidadDoctor As String
  Dim _ConsulaFinalizada As Integer

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    btnVerConsulta.Enabled = True
    btnCompletar.Enabled = True
    _idConsulta = -1 ' Reiniciar ID de consulta al ajustar pantall
    _nombreDoctor = ""
    _nombrePaciente = ""
    _especialidadDoctor = ""
    chbVerCerradas.Checked = False
    chbVerCerradas.Visible = True

    Select Case TipoUsuario
      Case "Doctor"
        CargarConsultas()
        btnVerConsulta.Enabled = False
        Me.Text = "Control de Citas - Doctor"
      Case "Paciente"
        chbVerCerradas.Visible = False
        CargarConsultas()
        btnCompletar.Enabled = False
        Me.Text = "Control de Citas - Paciente"
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnCompletar.Enabled = False
        btnVerConsulta.Enabled = False
        PantallaManager.RegresarDesdeFormularioHijo()
    End Select
  End Sub

  Private Sub CargarConsultas(Optional nombre As String = "", Optional apellido As String = "", Optional identificacion As String = "", Optional prioridad As String = "")
    Try
      Dim dbvDoctorConsultas As New VDoctorConsultasDAO
      Dim filtros As New Dictionary(Of String, Object) From {
        {"Nombre", nombre},
        {"Apellidos", apellido},
        {"Identificacion", identificacion},
        {"Prioridad", prioridad}
      }

      If TipoUsuario = "Doctor" Then
        filtros.Add("CodigoDoctor", CodigoUsuario)
        If Not chbVerCerradas.Checked Then
          filtros.Add("ConsultaFinalizada", 0) ' Solo consultas no finalizadas
        End If
      Else
        filtros.Add("CodigoPaciente", CodigoUsuario)
      End If

      Dim listaConsultas As List(Of VDoctorConsultas) = dbvDoctorConsultas.GetByFilters(filtros).OrderBy(Of Integer)(Function(c) c.NumPrioridad).ToList()
      dbvDoctorConsultas.Dispose()

      ConfigurarColumnasDoctorConsultas()
      dgvConsultasPaciente.DataSource = listaConsultas

      _idConsulta = -1 ' Reiniciar ID de consulta al cargar
      dgvConsultasPaciente.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Error al cargar las consultas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub ConfigurarColumnasDoctorConsultas()
    dgvConsultasPaciente.Columns.Clear()
    dgvConsultasPaciente.AutoGenerateColumns = False

    Dim colID As New DataGridViewTextBoxColumn()
    colID.HeaderText = "ID"
    colID.DataPropertyName = "Id"
    colID.Name = "colID"
    dgvConsultasPaciente.Columns.Add(colID)
    colID.Visible = False

    Dim colConsecutivo As New DataGridViewTextBoxColumn()
    colConsecutivo.HeaderText = "Consecutivo"
    colConsecutivo.DataPropertyName = "Consecutivo"
    colConsecutivo.Name = "colConsecutivo"
    dgvConsultasPaciente.Columns.Add(colConsecutivo)

    Dim colFechaConsulta As New DataGridViewTextBoxColumn()
    colFechaConsulta.HeaderText = "Fecha"
    colFechaConsulta.DataPropertyName = "FechaConsulta"
    colFechaConsulta.Name = "colFechaConsulta"
    colFechaConsulta.DefaultCellStyle.Format = "dd/MM/yyyy"
    dgvConsultasPaciente.Columns.Add(colFechaConsulta)

    Dim colPrioridad As New DataGridViewTextBoxColumn()
    colPrioridad.HeaderText = "Prioridad"
    colPrioridad.DataPropertyName = "Prioridad"
    colPrioridad.Name = "colPrioridad"
    dgvConsultasPaciente.Columns.Add(colPrioridad)

    Dim colNumPrioridad As New DataGridViewTextBoxColumn()
    colNumPrioridad.HeaderText = "Num Prioridad"
    colNumPrioridad.DataPropertyName = "NumPrioridad"
    colNumPrioridad.Name = "colNumPrioridad"
    colNumPrioridad.Visible = False
    dgvConsultasPaciente.Columns.Add(colNumPrioridad)
    colNumPrioridad.Visible = False

    Dim colCodigoDoctor As New DataGridViewTextBoxColumn()
    colCodigoDoctor.HeaderText = "Cod Doctor"
    colCodigoDoctor.DataPropertyName = "CodigoDoctor"
    colCodigoDoctor.Name = "colCodigoDoctor"
    dgvConsultasPaciente.Columns.Add(colCodigoDoctor)
    colCodigoDoctor.Visible = False

    Dim colCodigoPaciente As New DataGridViewTextBoxColumn()
    colCodigoPaciente.HeaderText = "Cod Paciente"
    colCodigoPaciente.DataPropertyName = "CodigoPaciente"
    colCodigoPaciente.Name = "colCodigoPaciente"
    dgvConsultasPaciente.Columns.Add(colCodigoPaciente)
    colCodigoPaciente.Visible = False

    Dim colIdentificacion As New DataGridViewTextBoxColumn()
    colIdentificacion.HeaderText = "Identificación"
    colIdentificacion.DataPropertyName = "Identificacion"
    colIdentificacion.Name = "colIdentificacion"
    dgvConsultasPaciente.Columns.Add(colIdentificacion)

    Dim colPaciente As New DataGridViewTextBoxColumn()
    colPaciente.HeaderText = "Paciente"
    colPaciente.DataPropertyName = "Paciente"
    colPaciente.Name = "colPaciente"
    dgvConsultasPaciente.Columns.Add(colPaciente)

    Dim colDoctor As New DataGridViewTextBoxColumn()
    colDoctor.HeaderText = "Doctor"
    colDoctor.DataPropertyName = "Doctor"
    colDoctor.Name = "colDoctor"
    dgvConsultasPaciente.Columns.Add(colDoctor)

    Dim colEspecialidad As New DataGridViewTextBoxColumn()
    colEspecialidad.HeaderText = "Especialidad"
    colEspecialidad.DataPropertyName = "Especialidad"
    colEspecialidad.Name = "colEspecialidad"
    dgvConsultasPaciente.Columns.Add(colEspecialidad)

    Dim colEdadPaciente As New DataGridViewTextBoxColumn()
    colEdadPaciente.HeaderText = "Edad"
    colEdadPaciente.DataPropertyName = "EdadPaciente"
    colEdadPaciente.Name = "colEdadPaciente"
    dgvConsultasPaciente.Columns.Add(colEdadPaciente)

    Dim colSexoPaciente As New DataGridViewTextBoxColumn()
    colSexoPaciente.HeaderText = "Sexo"
    colSexoPaciente.DataPropertyName = "SexoPaciente"
    colSexoPaciente.Name = "colSexoPaciente"
    dgvConsultasPaciente.Columns.Add(colSexoPaciente)

    Dim colConsultaFinalizada As New DataGridViewCheckBoxColumn()
    colConsultaFinalizada.HeaderText = "Finalizada"
    colConsultaFinalizada.DataPropertyName = "ConsultaFinalizada"
    colConsultaFinalizada.Name = "colConsultaFinalizada"
    dgvConsultasPaciente.Columns.Add(colConsultaFinalizada)
    colConsultaFinalizada.Visible = False

    If TipoUsuario = "Doctor" Then
      colIdentificacion.Visible = True
      colPaciente.Visible = True
      colDoctor.Visible = False
      colEspecialidad.Visible = False
      If chbVerCerradas.Checked Then
        colConsultaFinalizada.Visible = True
      Else
        colConsultaFinalizada.Visible = False
      End If
    Else
      colIdentificacion.Visible = False
      colPaciente.Visible = False
      colDoctor.Visible = True
      colEspecialidad.Visible = True
      colConsultaFinalizada.Visible = True
    End If
  End Sub


  Private Sub btnCompletar_Click(sender As Object, e As EventArgs) Handles btnCompletar.Click
    If _idConsulta >= 0 Then
      If _ConsulaFinalizada = 1 Then
        If MessageBox.Show("La consulta ya ha sido completada. ¿Desea editar esta consulta?", "Consulta Completada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
          Return
        End If
      End If

      ' Mostrar el formulario de completar consulta
      frmCompletarConsulta.Show()
      frmCompletarConsulta.IdConsulta = _idConsulta
      frmCompletarConsulta.NombreDoctor = _nombreDoctor
      frmCompletarConsulta.NombrePaciente = _nombrePaciente
      frmCompletarConsulta.Especialidad = _especialidadDoctor
      frmCompletarConsulta.ModificarConsulta = (_ConsulaFinalizada = 1)
      frmCompletarConsulta.AjustarPantalla()
      Hide()
    Else
      MessageBox.Show("Debe seleccionar una consulta para ser completada.", "Asignar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub btnVerConsulta_Click(sender As Object, e As EventArgs) Handles btnVerConsulta.Click
    If _idConsulta >= 0 Then
      If _ConsulaFinalizada = 0 Then
        MessageBox.Show("La consulta no ha sido completada. No se puede ver el detalle de la cita", "Consulta No Completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return
      End If
      frmCompletarConsulta.Show()
      frmCompletarConsulta.IdConsulta = _idConsulta
      frmCompletarConsulta.NombreDoctor = _nombreDoctor
      frmCompletarConsulta.NombrePaciente = _nombrePaciente
      frmCompletarConsulta.Especialidad = _especialidadDoctor
      frmCompletarConsulta.AjustarPantalla()
      Me.Hide()
    Else
      MessageBox.Show("Debe seleccionar una consulta para poder verla.", "Asignar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub dgvConsultasPaciente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultasPaciente.CellClick
    If e.RowIndex >= 0 Then
      _idConsulta = Integer.Parse(dgvConsultasPaciente.Rows(e.RowIndex).Cells("colId").Value)
      _nombreDoctor = dgvConsultasPaciente.Rows(e.RowIndex).Cells("colDoctor").Value.ToString()
      _nombrePaciente = dgvConsultasPaciente.Rows(e.RowIndex).Cells("colPaciente").Value.ToString()
      _especialidadDoctor = dgvConsultasPaciente.Rows(e.RowIndex).Cells("colEspecialidad").Value.ToString()
      _ConsulaFinalizada = If(dgvConsultasPaciente.Rows(e.RowIndex).Cells("colConsultaFinalizada").Value > 0, 1, 0)
    End If
  End Sub

  Private Sub dgvConsultasPaciente_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvConsultasPaciente.CellFormatting
    ' Verificá que la columna sea la de FechaConsulta
    If dgvConsultasPaciente.Columns(e.ColumnIndex).Name = "colFechaConsulta" Then
      If e.Value IsNot Nothing AndAlso Date.TryParse(e.Value.ToString(), Nothing) Then
        e.Value = CDate(e.Value).ToString("dd/MM/yyyy")
        e.FormattingApplied = True
      End If
    End If

    If dgvConsultasPaciente.Columns(e.ColumnIndex).Name = "colPrioridad" Then
      If e.Value IsNot Nothing Then
        Select Case e.Value.ToString()
          Case "Alta"
            e.CellStyle.BackColor = Color.Red
            e.CellStyle.ForeColor = Color.White
          Case "Media"
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.ForeColor = Color.Black
          Case "Baja"
            e.CellStyle.BackColor = Color.Green
            e.CellStyle.ForeColor = Color.White
        End Select
      End If
    End If

    If dgvConsultasPaciente.Columns(e.ColumnIndex).Name = "colConsultaFinalizada" Then
      If e.Value IsNot Nothing Then
        If e.Value > 0 Then
          e.CellStyle.BackColor = Color.LightGray
          e.CellStyle.ForeColor = Color.Black
          e.Value = True
        Else
          e.CellStyle.BackColor = Color.White
          e.CellStyle.ForeColor = Color.Black
          e.Value = False
        End If
        e.FormattingApplied = True
      End If
    End If
  End Sub

  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click, chbVerCerradas.CheckedChanged
    CargarConsultas(txtFilNombre.Text.Trim, txtFilApellido.Text.Trim, txtFilIdentificacion.Text.Trim, cmbFiltPrioridad.SelectedItem?.ToString)
  End Sub

End Class