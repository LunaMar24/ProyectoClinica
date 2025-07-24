
Public Class frmCompletarConsulta
  Implements IFormularios

  Dim _idConsulta As Integer = -1
  Dim _Doctor As String = ""
  Dim _Paciente As String = ""
  Dim _especialidad As String = ""
  Dim _ModificarConsulta As Boolean = False
  Dim _datoConsultaAct As Consulta
  Dim _datoTratamientoAct As Tratamiento

  WriteOnly Property IdConsulta As Integer
    Set(value As Integer)
      _idConsulta = value
    End Set
  End Property

  WriteOnly Property NombreDoctor As String
    Set(value As String)
      _Doctor = value
    End Set
  End Property

  WriteOnly Property NombrePaciente As String
    Set(value As String)
      _Paciente = value
    End Set
  End Property
  WriteOnly Property Especialidad As String
    Set(value As String)
      _especialidad = value
    End Set
  End Property

  WriteOnly Property ModificarConsulta As Boolean
    Set(value As Boolean)
      _ModificarConsulta = value
    End Set
  End Property

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarConsulta()
    CargarTratamiento()
    tltToolTip.AutoPopDelay = 7000
    tltToolTip.InitialDelay = 3000
    btnCerrarConsulta.Visible = True
    txtTemperatura.ReadOnly = False
    txtPeso.ReadOnly = False
    txtEstatura.ReadOnly = False
    txtPresion.ReadOnly = False
    txtSintomas.ReadOnly = False
    txtAlergias.ReadOnly = False
    txtPadecimientos.ReadOnly = False
    txtTratamiento.ReadOnly = False

    If TipoUsuario = "Paciente" Then
      'eliminar los mouse hover de los controles ya que los pacientes no van a ingresar datos
      RemoveHandler txtPeso.MouseHover, AddressOf txtPeso_MouseHover
      RemoveHandler txtTemperatura.MouseHover, AddressOf txtTemperatura_MouseHover
      RemoveHandler txtEstatura.MouseHover, AddressOf txtEstatura_MouseHover
      RemoveHandler txtAlergias.MouseHover, AddressOf actualizaDatos_MouseHover
      RemoveHandler txtSintomas.MouseHover, AddressOf actualizaDatos_MouseHover
      RemoveHandler txtPadecimientos.MouseHover, AddressOf actualizaDatos_MouseHover
      RemoveHandler txtPresion.MouseHover, AddressOf txtPresion_MouseHover

      'deshabilitar los controles para que no puedan ser editados
      txtTemperatura.ReadOnly = True
      txtPeso.ReadOnly = True
      txtPresion.ReadOnly = True
      txtEstatura.ReadOnly = True
      txtSintomas.ReadOnly = True
      txtAlergias.ReadOnly = True
      txtPadecimientos.ReadOnly = True
      txtTratamiento.ReadOnly = True
      btnCerrarConsulta.Visible = False
    End If
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub btnCerrarConsulta_Click(sender As Object, e As EventArgs) Handles btnCerrarConsulta.Click

    Dim temperatura As String = txtTemperatura.Text.Trim()
    Dim peso As String = txtPeso.Text.Trim()
    Dim estatura As String = txtEstatura.Text.Trim()
    Dim sintomas As String = txtSintomas.Text.Trim()
    Dim alergias As String = txtAlergias.Text.Trim()
    Dim padecimientos As String = txtPadecimientos.Text.Trim()
    Dim tratamiento As String = txtTratamiento.Text.Trim()
    Dim presion As String = txtPresion.Text.Trim()

    ValidateChildren() ' Valida los campos antes de continuar

    If String.IsNullOrWhiteSpace(temperatura) OrElse
        String.IsNullOrWhiteSpace(peso) OrElse
        String.IsNullOrWhiteSpace(estatura) OrElse
        String.IsNullOrWhiteSpace(presion) OrElse
        String.IsNullOrWhiteSpace(sintomas) OrElse
        String.IsNullOrWhiteSpace(alergias) OrElse
        String.IsNullOrWhiteSpace(padecimientos) OrElse
        String.IsNullOrWhiteSpace(tratamiento) Then
      MessageBox.Show("Alguno de los campos está vacío. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If MessageBox.Show("¿Está seguro de que desea cerrar la consulta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
      Return
    End If

    Try
      Dim dbConsulta As New ConsultaDAO()
      _datoConsultaAct.Temperatura = temperatura
      _datoConsultaAct.Peso = peso
      _datoConsultaAct.Estatura = estatura
      _datoConsultaAct.Presion = presion
      _datoConsultaAct.Sintomas = sintomas
      _datoConsultaAct.Alergias = alergias
      _datoConsultaAct.Padecimientos = padecimientos

      Dim rowsAffected As Integer = dbConsulta.Update(_datoConsultaAct)
      dbConsulta.Dispose()

      If rowsAffected > 0 Then
        rowsAffected = 0
        Dim dbTratamiento As New TratamientoDAO()
        Dim tratamientoNuevo As New Tratamiento With {
          .ConsultaId = _datoConsultaAct.Id,
          .Descripcion = tratamiento
        }

        If _ModificarConsulta Then
          tratamientoNuevo.Id = _datoTratamientoAct.Id
          rowsAffected = dbTratamiento.Update(tratamientoNuevo)
        Else
          rowsAffected = dbTratamiento.Insert(tratamientoNuevo)
        End If
        dbTratamiento.Dispose()

        If rowsAffected > 0 Then
          MessageBox.Show("Consulta actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
          frmConsultaCitas.Show()
          frmConsultaCitas.AjustarPantalla()
          Me.Close()
        Else
          MessageBox.Show("No se pudo registrar el tratamiento. Por favor intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      Else
        MessageBox.Show("No se pudo actualizar la consulta. Por favor intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar un doctor: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Sub CargarConsulta()
    Try
      Dim dbConsulta As New ConsultaDAO()
      _datoConsultaAct = dbConsulta.GetById(_idConsulta)

      'Asignar los valores a los campos del formulario
      txtCodigoConsulta.Text = _datoConsultaAct.Numero
      txtDoctor.Text = _Doctor
      txtPaciente.Text = _Paciente
      txtEspecialidad.Text = _especialidad
      txtTemperatura.Text = _datoConsultaAct.Temperatura
      txtPeso.Text = _datoConsultaAct.Peso
      txtEstatura.Text = _datoConsultaAct.Estatura
      txtPresion.Text = _datoConsultaAct.Presion
      txtAlergias.Text = _datoConsultaAct.Alergias
      txtSintomas.Text = _datoConsultaAct.Sintomas
      txtPadecimientos.Text = _datoConsultaAct.Padecimientos
      txtPrioridad.Text = _datoConsultaAct.Prioridad
      txtFecha.Text = _datoConsultaAct.Fecha.ToString("dd/MM/yyyy")
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la consulta. Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub CargarTratamiento()
    Try
      Dim dbTratamiento As New TratamientoDAO()
      Dim filtros As New Dictionary(Of String, Object) From {
        {"ConsultaId", _idConsulta}
      }
      _datoTratamientoAct = dbTratamiento.GetAll(filtros).FirstOrDefault()
      dbTratamiento.Dispose()

      If _datoTratamientoAct IsNot Nothing Then
        txtTratamiento.Text = _datoTratamientoAct.Descripcion
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar el tratamiento. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTemperatura.Validating, txtPeso.Validating, txtTratamiento.Validating, txtAlergias.Validating, txtSintomas.Validating, txtPadecimientos.Validating, txtTemperatura.Validating, txtEstatura.Validating, txtPresion.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

  Private Sub txtTemperatura_MouseHover(sender As Object, e As EventArgs) Handles txtTemperatura.MouseHover
    tltToolTip.ToolTipIcon = ToolTipIcon.Info
    tltToolTip.ToolTipTitle = "Información"
    tltToolTip.SetToolTip(sender, "Información en grados centígrados...")
  End Sub

  Private Sub txtPeso_MouseHover(sender As Object, e As EventArgs) Handles txtPeso.MouseHover
    tltToolTip.ToolTipIcon = ToolTipIcon.Info
    tltToolTip.ToolTipTitle = "Información"
    tltToolTip.SetToolTip(sender, "Información en kilogramos...")
  End Sub

  Private Sub txtEstatura_MouseHover(sender As Object, e As EventArgs) Handles txtEstatura.MouseHover
    tltToolTip.ToolTipIcon = ToolTipIcon.Info
    tltToolTip.ToolTipTitle = "Información"
    tltToolTip.SetToolTip(sender, "Información en metros...")
  End Sub

  Private Sub actualizaDatos_MouseHover(sender As Object, e As EventArgs) Handles txtAlergias.MouseHover, txtSintomas.MouseHover, txtPadecimientos.MouseHover
    tltToolTip.ToolTipIcon = ToolTipIcon.Info
    tltToolTip.ToolTipTitle = "Información"
    tltToolTip.SetToolTip(sender, "Solicite información actualizada al paciente...")
  End Sub

  Private Sub txtPresion_MouseHover(sender As Object, e As EventArgs) Handles txtPresion.MouseHover
    tltToolTip.ToolTipIcon = ToolTipIcon.Info
    tltToolTip.ToolTipTitle = "Información"
    tltToolTip.SetToolTip(sender, "Información a registrar Sistólica/Diastólica...")
  End Sub
End Class