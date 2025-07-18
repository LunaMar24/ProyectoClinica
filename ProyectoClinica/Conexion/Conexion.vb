Imports MySql.Data.MySqlClient
Public Class Conexion
  Implements IDisposable
  Private conexion As MySqlConnection
  Private trans As MySqlTransaction = Nothing
  Private disposedValue As Boolean = False

  Public ReadOnly Property Transaccion As MySqlTransaction
    Get
      Return trans
    End Get
  End Property

  Public ReadOnly Property BDConnexion As MySqlConnection
    Get
      Return conexion
    End Get
  End Property

  Public Sub New()
    Dim cadena As String = "server=localhost;user=root;password=1234;database=db_clinica;"
    conexion = New MySqlConnection(cadena)
  End Sub

  Public Function Abrir() As MySqlConnection
    If conexion.State = ConnectionState.Closed Then
      Try
        conexion.Open()
      Catch ex As Exception
        MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
        conexion = Nothing
      End Try

    End If
    Return conexion
  End Function

  Public Sub Cerrar()
    If conexion.State = ConnectionState.Open Then
      conexion.Close()
    End If
  End Sub

  Public Sub AbrirTransaccion()
    If Abrir() IsNot Nothing Then
      trans = conexion.BeginTransaction()
    End If
  End Sub

  Public Sub FinalizarTransaccion(Commit As Boolean)
    If conexion IsNot Nothing AndAlso trans IsNot Nothing Then
      If Commit Then
        trans.Commit()
      Else
        trans.Rollback()
      End If
    End If
  End Sub

  ' Implementación de IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' Libera recursos administrados
        Cerrar()
        If conexion IsNot Nothing Then
          conexion.Dispose()
          conexion = Nothing
        End If
      End If
      ' Si tuvieras recursos no administrados, los liberarías aquí.
      disposedValue = True
    End If
  End Sub

  Public Sub Dispose() Implements IDisposable.Dispose
    Dispose(disposing:=True)
    GC.SuppressFinalize(Me)
  End Sub

End Class
