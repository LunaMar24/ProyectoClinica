Imports MySql.Data.MySqlClient

Public MustInherit Class DAOBase
  Implements IDisposable
  Private conexionInterna As Conexion = Nothing

  ' Inicia una transacción y mantiene la conexión abierta
  Protected Sub BeginTransaction()
    conexionInterna = New Conexion()
    conexionInterna.AbrirTransaccion()
  End Sub

  ' Finaliza la transacción: Commit o Rollback, y cierra conexión
  Protected Sub EndTransaction(commit As Boolean)
    If conexionInterna IsNot Nothing Then
      conexionInterna.FinalizarTransaccion(commit)
    End If
  End Sub

  Protected Sub CerrarConexion()
    If conexionInterna IsNot Nothing Then
      conexionInterna.Cerrar()
      conexionInterna.Dispose()
      conexionInterna = Nothing
    End If
  End Sub

  ' Ejecuta SELECT y devuelve DataTable
  Protected Function ExecuteQuery(query As String, parameters As List(Of MySqlParameter)) As DataTable
    Dim dt As New DataTable()

    If conexionInterna IsNot Nothing AndAlso conexionInterna.Transaccion IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conexionInterna.BDConnexion, conexionInterna.Transaccion)
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        Using adapter As New MySqlDataAdapter(cmd)
          adapter.Fill(dt)
        End Using
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Using cmd As New MySqlCommand(query, conexionTemp.Abrir())
          If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
            cmd.Parameters.AddRange(parameters.ToArray())
          End If
          Using adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dt)
          End Using
        End Using
      End Using
    End If

    Return dt
  End Function

  ' Ejecuta INSERT/UPDATE/DELETE y devuelve filas afectadas
  Protected Function ExecuteNonQuery(query As String, parameters As List(Of MySqlParameter)) As Integer
    Dim rowsAffected As Integer = 0

    If conexionInterna IsNot Nothing AndAlso conexionInterna.Transaccion IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conexionInterna.BDConnexion, conexionInterna.Transaccion)
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        rowsAffected = cmd.ExecuteNonQuery()
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Using cmd As New MySqlCommand(query, conexionTemp.Abrir())
          If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
            cmd.Parameters.AddRange(parameters.ToArray())
          End If
          rowsAffected = cmd.ExecuteNonQuery()
        End Using
      End Using
    End If

    Return rowsAffected
  End Function

  ' Ejecuta ESCALAR (COUNT, MAX, etc.) y devuelve resultado
  Protected Function ExecuteScalar(query As String, parameters As List(Of MySqlParameter)) As Object
    Dim result As Object = Nothing

    If conexionInterna IsNot Nothing AndAlso conexionInterna.Transaccion IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conexionInterna.BDConnexion, conexionInterna.Transaccion)
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        result = cmd.ExecuteScalar()
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Using cmd As New MySqlCommand(query, conexionTemp.Abrir())
          If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
            cmd.Parameters.AddRange(parameters.ToArray())
          End If
          result = cmd.ExecuteScalar()
        End Using
      End Using
    End If

    Return result
  End Function

  ''' <summary>
  ''' Ejecuta una instrucción INSERT en la base de datos y devuelve el ID autonumérico generado.
  ''' Este método es compatible con transacciones activas (si existen) o inserciones independientes.
  ''' 
  ''' Requiere que la tabla tenga un campo autonumérico tipo INTEGER (ej. AUTO_INCREMENT en MySQL).
  ''' </summary>
  ''' <param name="query">La sentencia SQL INSERT a ejecutar (sin punto y coma final).</param>
  ''' <param name="parameters">Lista de parámetros MySqlParameter para la consulta. Puede ser Nothing.</param>
  ''' <returns>El ID (Integer) del registro insertado.</returns>
  ''' <remarks>
  ''' Ejemplo de uso:
  ''' Dim id As Integer = ExecuteInsertReturnId("INSERT INTO usuarios (nombre) VALUES (@nombre)", params)
  ''' </remarks>
  Protected Function ExecuteInsertReturnId(query As String, parameters As List(Of MySqlParameter)) As Integer
    Dim insertedId As Integer = 0

    If conexionInterna IsNot Nothing AndAlso conexionInterna.Transaccion IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query & "; SELECT LAST_INSERT_ID();", conexionInterna.BDConnexion, conexionInterna.Transaccion)
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        insertedId = Convert.ToInt32(cmd.ExecuteScalar())
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Using cmd As New MySqlCommand(query & "; SELECT LAST_INSERT_ID();", conexionTemp.Abrir())
          If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
            cmd.Parameters.AddRange(parameters.ToArray())
          End If
          insertedId = Convert.ToInt32(cmd.ExecuteScalar())
        End Using
      End Using
    End If

    Return insertedId
  End Function

  Public Sub Dispose() Implements IDisposable.Dispose
    CerrarConexion()
  End Sub

End Class

