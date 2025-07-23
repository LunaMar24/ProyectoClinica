Public Class VDoctorConsultasDAO
  Inherits VistaBaseDAO(Of VDoctorConsultas)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vdoctorconsultas"
    End Get
  End Property
End Class
