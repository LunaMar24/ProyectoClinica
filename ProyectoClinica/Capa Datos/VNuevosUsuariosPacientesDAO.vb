Public Class VNuevosUsuariosPacientesDAO
  Inherits VistaBaseDAO(Of VNuevosUsuariosPacientes)

  Protected Overrides ReadOnly Property NombreVista As String
    Get
      Return "vnuevosusuariospacientes"
    End Get
  End Property
End Class
