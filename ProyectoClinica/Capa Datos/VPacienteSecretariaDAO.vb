Public Class VPacienteSecretariaDAO
  Inherits VistaBaseDAO(Of VPacienteSecretaria)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vpacientesecretaria"
    End Get
  End Property
End Class

