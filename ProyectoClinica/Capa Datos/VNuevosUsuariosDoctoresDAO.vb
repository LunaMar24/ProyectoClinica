Public Class VNuevosUsuariosDoctoresDAO
  Inherits VistaBaseDAO(Of VNuevosUsuariosDoctores)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vnuevosusuariosdoctores"
    End Get
  End Property
End Class
