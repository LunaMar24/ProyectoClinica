Imports MySql.Data.MySqlClient

Public Class frmAsignarConsulta
  Implements IFormularios

  Private conexion As Conexion
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
    frmMantDoctores.Show()
    frmMantDoctores.AjustarPantalla()
    Me.Close()
  End Sub

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    lblInfoDoctor.Text = _nombreDoctor
    lblInfoEspecialidad.Text = _especialidad
  End Sub

  Private Sub frmAsignarConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
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
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT id, nombre_completo, apellido FROM persona WHERE identificacion = @cedula"
      Dim dt = New DataTable
      Using command As New MySqlCommand(selectQuery, conn)
        'Asignar los parametros
        If Not String.IsNullOrWhiteSpace(identificacion) Then
          command.Parameters.AddWithValue("@cedula", identificacion)
        End If

        Dim adaptador = New MySqlDataAdapter(command)

        'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
        adaptador.Fill(dt)
      End Using

      If dt.Rows.Count > 0 Then
        lblInfoPaciente.Text = dt.Rows(0)("nombre_completo").ToString() & " " & dt.Rows(0)("apellido").ToString()
        idPaciente = dt.Rows(0)("id").ToString()
      Else
        MessageBox.Show("Identificación no encontrada. Verifique el dato y vuelva a intentarlo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        txtIdentificacionPaciente.Focus()
      End If

    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
      conexion.Cerrar()
    End Try
  End Sub

  Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
    If ValidateChildren() Then
      'Crear la consulta con la información del paciente y el doctor
      Try
        Dim conn = conexion.Abrir()

        'Obtener el número de consulta y aucmentar su consecutivo
        Dim selectQuery = "SELECT IFNULL(MAX(numero),'') FROM db_clinica.consulta"
        Dim commandSelect As New MySqlCommand(selectQuery, conn)
        Dim numeroConsulta As String = commandSelect.ExecuteScalar().ToString()

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

        Dim insertQuery = "INSERT INTO consulta (numero, prioridad, fecha, persona_id, doctor_id) VALUES (@numero, @prioridad, @fecha, @persona_id, @doctor_id)"
        Dim dt = New DataTable
        Using command As New MySqlCommand(insertQuery, conn)
          'Asignar los parametros
          command.Parameters.AddWithValue("@numero", numeroConsulta)
          command.Parameters.AddWithValue("@fecha", DateTime.Now.Date)
          command.Parameters.AddWithValue("@prioridad", cmbPrioridad.Text)

          command.Parameters.AddWithValue("@doctor_id", _idDoctor)
          command.Parameters.AddWithValue("@persona_id", idPaciente)

          Dim rowsAffected = command.ExecuteNonQuery()

          If rowsAffected > 0 Then
            MessageBox.Show("Consulta asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMantDoctores.Show()
            frmMantDoctores.AjustarPantalla()
            Me.Close()
          Else
            MessageBox.Show("No se pudo asignar la consulta. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End If
        End Using
      Catch ex As Exception
        MessageBox.Show("Se presentó un error al crear la consulta. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
        conexion.Cerrar()
      End Try
    End If
  End Sub


End Class