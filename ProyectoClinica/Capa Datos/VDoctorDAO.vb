Public Class VDoctorDAO
  Inherits VistaBaseDAO(Of VDoctor)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vdoctor"
    End Get
  End Property
End Class

