Imports System.Runtime.InteropServices.JavaScript.JSType
Imports MySql.Data.MySqlClient

Public Class frmAsignarConsulta
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


  Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    frmMantDoctores.Show()
    frmMantDoctores.AjustarPantalla()
    Me.Close()
  End Sub

  Public Sub AjustarPantalla()
    lblInfoDoctor.Text = _nombreDoctor
    lblInfoEspecialidad.Text = _especialidad
  End Sub

  Private Sub frmAsignarConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Private Sub txtIdentificacionPaciente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIdentificacionPaciente.Validating
    If txtIdentificacionPaciente.TextLength = 0 Then
      errProv.SetError(txtIdentificacionPaciente, "Debe indicar la identificación del paciente")
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

  Private Sub CargarDatosPaciente(identificacion As String)
    Try
      Dim conn = Conexion.Abrir()
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


End Class