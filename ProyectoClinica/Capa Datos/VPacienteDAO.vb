Public Class VPacienteDAO
  Inherits VistaBaseDAO(Of VPaciente)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vpaciente"
    End Get
  End Property
End Class

