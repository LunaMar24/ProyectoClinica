Imports MySql.Data.MySqlClient

Public MustInherit Class DAOBase
  Private conexionDB As Conexion = Nothing
  Private conn As MySqlConnection = Nothing

  ' Inicia una transacción y mantiene la conexión abierta
  Protected Sub BeginTransaction()
    conexionDB = New Conexion()
    conexionDB.AbrirTransaccion()
  End Sub

  ' Finaliza la transacción: Commit o Rollback, y cierra conexión
  Protected Sub EndTransaction(commit As Boolean)
    If conexionDB IsNot Nothing Then
      conexionDB.FinalizarTransaccion(commit)
    End If
  End Sub

  ' Ejecuta SELECT y devuelve DataTable
  Protected Function ExecuteQuery(query As String, parameters As List(Of MySqlParameter)) As DataTable
    Dim dt As New DataTable()

    If conexionDB IsNot Nothing AndAlso conn IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conn, conn.BeginTransaction())
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
        Dim connTemp As MySqlConnection = conexionTemp.Abrir()
        Using cmd As New MySqlCommand(query, connTemp)
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

    If conexionDB IsNot Nothing AndAlso conn IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conn, conn.BeginTransaction())
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        rowsAffected = cmd.ExecuteNonQuery()
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Dim connTemp As MySqlConnection = conexionTemp.Abrir()
        Using cmd As New MySqlCommand(query, connTemp)
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

    If conexionDB IsNot Nothing AndAlso conn IsNot Nothing Then
      ' En transacción
      Using cmd As New MySqlCommand(query, conn, conn.BeginTransaction())
        If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
          cmd.Parameters.AddRange(parameters.ToArray())
        End If
        result = cmd.ExecuteScalar()
      End Using
    Else
      ' Sin transacción
      Using conexionTemp As New Conexion()
        Dim connTemp As MySqlConnection = conexionTemp.Abrir()
        Using cmd As New MySqlCommand(query, connTemp)
          If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
            cmd.Parameters.AddRange(parameters.ToArray())
          End If
          result = cmd.ExecuteScalar()
        End Using
      End Using
    End If

    Return result
  End Function
End Class

