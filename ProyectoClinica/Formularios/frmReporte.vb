Imports OfficeOpenXml
Imports System.IO

Public Class frmReporte
  Implements IFormularios

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    btnEnviarExcel.Enabled = True

    Select Case TipoUsuario
      Case "Secretaria"
        CargarConsultas()
      Case Else
        MessageBox.Show("Tipo de usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btnEnviarExcel.Enabled = False
        PantallaManager.RegresarDesdeFormularioHijo()
    End Select
  End Sub

  Private Sub CargarConsultas()
    Try
      Dim dbvDoctorConsultas As New VDoctorConsultasDAO
      Dim listaConsultas As List(Of VDoctorConsultas) = dbvDoctorConsultas.GetByFilters().OrderByDescending(Of DateTime)(Function(c) c.FechaConsulta).ThenBy(Of Integer)(Function(c) c.NumPrioridad).ToList()
      dbvDoctorConsultas.Dispose()

      ConfigurarColumnasReporte()
      dgvConsultasPaciente.DataSource = listaConsultas

      dgvConsultasPaciente.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Error al cargar las consultas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub ConfigurarColumnasReporte()
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
  End Sub


  Private Sub btnEnviarExcel_Click(sender As Object, e As EventArgs) Handles btnEnviarExcel.Click
    Using sfd As New SaveFileDialog()
      sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx"
      sfd.FileName = $"CitasPaciente-{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx"

      If sfd.ShowDialog() = DialogResult.OK Then
        Try
          If dgvConsultasPaciente.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.", "Reporte Citas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
          End If
          ExportarConsultasAPacienteExcel(dgvConsultasPaciente, sfd.FileName)
          MessageBox.Show("Archivo exportado correctamente.", "Reporte Citas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
          MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Reporte Citas", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Return
        End Try
      End If
    End Using
  End Sub

  Public Sub ExportarConsultasAPacienteExcel(dgv As DataGridView, rutaArchivo As String)
    ' Habilita la licencia no comercial
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial

    Using package As New ExcelPackage()
      Dim worksheet = package.Workbook.Worksheets.Add("Citas")
      Dim colAsig = 1
      ' Encabezados
      For col = 0 To dgv.Columns.Count - 1
        If dgv.Columns(col).Visible Then
          worksheet.Cells(1, colAsig).Value = dgv.Columns(col).HeaderText
          worksheet.Cells(1, colAsig).Style.Font.Bold = True
          colAsig = colAsig + 1
        End If
      Next

      colAsig = 1
      ' Filas de datos
      For row = 0 To dgv.Rows.Count - 1
        colAsig = 1
        For col = 0 To dgv.Columns.Count - 1
          If dgv.Columns(col).Visible Then
            If dgv.Rows(row).Cells(col).Value IsNot Nothing Then
              If dgv.Columns(col).Name = "colConsultaFinalizada" Then
                worksheet.Cells(row + 2, colAsig).Value = If(dgv.Rows(row).Cells(col).Value = 1, "Sí", "No")
              ElseIf dgv.Columns(col).Name = "colFechaConsulta" Then
                worksheet.Cells(row + 2, colAsig).Value = CDate(dgv.Rows(row).Cells(col).Value).ToString("dd/MM/yyyy")
              Else
                worksheet.Cells(row + 2, colAsig).Value = dgv.Rows(row).Cells(col).Value.ToString()
              End If
            End If
            colAsig = colAsig + 1
          End If
        Next
      Next

      ' Autoajustar ancho de columnas
      worksheet.Cells.AutoFitColumns()

      ' Guardar archivo
      Dim fi As New FileInfo(rutaArchivo)
      package.SaveAs(fi)
    End Using
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

  Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
    CargarConsultas()
  End Sub
End Class