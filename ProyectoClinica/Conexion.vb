Imports MySql.Data.MySqlClient
Public Class Conexion
    Private conexion As MySqlConnection

    Public Sub New()
    Dim cadena As String = "server=localhost;user=root;password=1234;database=db_clinica;"
    conexion = New MySqlConnection(cadena)
    End Sub

  Public Function Abrir() As MySqlConnection
    If conexion.State = ConnectionState.Closed Then
      conexion.Open()
      'MessageBox.Show("Hola la conexion es exitosa")

    End If
    Return conexion
  End Function

  Public Sub Cerrar()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
            'MessageBox.Show("Hola la conexion se cerró correctamente")
        End If
    End Sub
End Class
