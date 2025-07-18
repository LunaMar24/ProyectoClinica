Public Class VUsuariosDAO
  Inherits VistaBaseDAO(Of VUsuario)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vusuarios"
    End Get
  End Property
End Class
