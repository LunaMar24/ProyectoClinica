Imports System.Runtime.InteropServices.JavaScript.JSType

Public Module mdlInfoLogin

  Private _tipoUsuario As String
  Public Property TipoUsuario() As String
    Get
      Return _tipoUsuario
    End Get
    Set(ByVal value As String)
      _tipoUsuario = value
    End Set
  End Property

  Private _codigoUsuario As Int32
  Public Property CodigoUsuario() As Int32
    Get
      Return _codigoUsuario
    End Get
    Set(ByVal value As Int32)
      _codigoUsuario = value
    End Set
  End Property

End Module
