Public Class frmAsignarConsulta
  Implements IFormularios

  Private idPaciente As Integer

  Private _idDoctor As Integer
  Public WriteOnly Property Doctor() As Integer
    Set(ByVal value As Integer)
      _idDoctor = value
    End Set
  End Property

  Private _nombreDoctor As String
  Public WriteOnly Property NombreDoctor() As String
    Set(ByVal value As String)
      _nombreDoctor = value
    End Set
  End Property

  Private _especialidad As String
  Public WriteOnly Property Especialidad() As String
    Set(ByVal value As String)
      _especialidad = value
    End Set
  End Property

  Private Const NUMERO_CONSULTA_INICIAL As String = "CLICONS-00001"


  Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    lblInfoDoctor.Text = _nombreDoctor
    lblInfoEspecialidad.Text = _especialidad
  End Sub

  Private Sub txtIdentificacionPaciente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacionPaciente.Validating
    If txtIdentificacionPaciente.TextLength = 0 Then
      errProv.SetError(txtIdentificacionPaciente, "Debe indicar la identificación del paciente")
    Else
      errProv.SetError(txtIdentificacionPaciente, "")
      CargarDatosPaciente(txtIdentificacionPaciente.Text)
    End If
  End Sub

  Private Sub txtIdentificacionPaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdentificacionPaciente.KeyDown
    If e.KeyCode = Keys.Enter Then
      e.SuppressKeyPress = True
      CargarDatosPaciente(txtIdentificacionPaciente.Text)
    End If
  End Sub
  Private Sub txtIdentificacionPaciente_TextChanged(sender As Object, e As EventArgs) Handles txtIdentificacionPaciente.TextChanged
    If txtIdentificacionPaciente.TextLength = 0 Then
      errProv.SetError(txtIdentificacionPaciente, "Debe indicar la identificación del paciente")
    Else
      errProv.SetError(txtIdentificacionPaciente, "")
    End If
    lblInfoPaciente.Text = ""
    idPaciente = -1
  End Sub

  Private Sub txtIdentificacionPaciente_MouseHover(sender As Object, e As EventArgs) Handles txtIdentificacionPaciente.MouseHover
    tlpToolTip.ToolTipIcon = ToolTipIcon.Info
    tlpToolTip.ToolTipTitle = "Información"
    tlpToolTip.AutoPopDelay = 7000
    tlpToolTip.InitialDelay = 3000
    tlpToolTip.SetToolTip(txtIdentificacionPaciente, "Carga información de paciente. Presione ENTER para continuar....")
  End Sub

  Private Sub cmbPrioridad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbPrioridad.Validating
    If cmbPrioridad.Text.Length = 0 Then
      errProv.SetError(cmbPrioridad, "Debe indicar la prioridad de la consulta")
    Else
      errProv.SetError(cmbPrioridad, "")
    End If
  End Sub

  Private Sub CargarDatosPaciente(identificacion As String)
    Try
      Dim dbPaciente As New PersonaDAO
      Dim filtros As New Dictionary(Of String, Object) From {
        {"identificacion", identificacion}
      }
      Dim paciente As Persona = dbPaciente.GetAll(filtros).FirstOrDefault()
      dbPaciente.Dispose()

      If paciente IsNot Nothing Then
        lblInfoPaciente.Text = $"{paciente.NombreCompleto} {paciente.Apellido}"
        idPaciente = paciente.Id
      Else
        MessageBox.Show("Identificación no encontrada. Verifique el dato y vuelva a intentarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        txtIdentificacionPaciente.Focus()
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
    ValidateChildren()

    If txtIdentificacionPaciente.TextLength = 0 Then
      MessageBox.Show("Debe indicar la identificación del paciente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      txtIdentificacionPaciente.Focus()
      Return
    End If

    If cmbPrioridad.Text.Length = 0 Then
      MessageBox.Show("Debe indicar la prioridad de la consulta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      cmbPrioridad.Focus()
      Return
    End If

    'Crear la consulta con la información del paciente y el doctor
    Try
      Dim dbconsultaDAO = New ConsultaDAO
      Dim numeroConsulta As String = dbconsultaDAO.UltimaConsulta()

      'Incrementar el número de consulta
      Dim partes() As String = numeroConsulta.Split("-"c)
      If partes.Length = 2 Then
        Dim prefix As String = partes(0)
        Dim numeroStr As String = partes(1)
        Dim numeroInt As Integer = Integer.Parse(numeroStr)
        numeroInt += 1
        Dim nuevoNumeroStr As String = numeroInt.ToString(New String("0"c, numeroStr.Length))
        numeroConsulta = prefix & "-" & nuevoNumeroStr
      ElseIf numeroConsulta.Length = 0 Then
        numeroConsulta = NUMERO_CONSULTA_INICIAL
      Else
        MessageBox.Show("Formato de número de consulta no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return
      End If

      Dim consulta As New Consulta With {
        .Numero = numeroConsulta,
        .Prioridad = cmbPrioridad.Text,
        .Fecha = DateTime.Now.Date,
        .PersonaId = idPaciente,
        .DoctorId = _idDoctor
      }

      Dim rowsAffected = dbconsultaDAO.Insert(consulta)
      dbconsultaDAO.Dispose()

      If rowsAffected > 0 Then
        MessageBox.Show("Consulta asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frmMantDoctores.Show()
        frmMantDoctores.AjustarPantalla()
        Me.Close()
      Else
        MessageBox.Show("No se pudo asignar la consulta. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al crear la consulta. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub


End Class