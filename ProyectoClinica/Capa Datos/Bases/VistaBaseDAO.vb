Imports MySql.Data.MySqlClient

Public MustInherit Class VistaBaseDAO(Of T)
  Inherits DAOBase

  Protected MustOverride ReadOnly Property NombreVista As String

  Public Function GetByFilters(filtros As Dictionary(Of String, Object)) As List(Of T)
    Dim lista As New List(Of T)()
    Dim query As String = $"SELECT * FROM {NombreVista}"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    ' Construir WHERE dinámico
    For Each filtro In filtros
      Dim prop = GetType(T).GetProperties().
        FirstOrDefault(Function(p) p.Name.ToUpper() = filtro.Key.ToUpper())
      If prop IsNot Nothing Then
        Dim attr = prop.GetCustomAttributes(GetType(ColumnNameAttribute), False).FirstOrDefault()
        Dim columnName = If(attr IsNot Nothing, DirectCast(attr, ColumnNameAttribute).Name, prop.Name)

        If filtro.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(filtro.Value.ToString()) Then
          whereParts.Add($"{columnName} LIKE @{filtro.Key}")
          parameters.Add(New MySqlParameter($"@{filtro.Key}", $"%{filtro.Value}%"))
        End If
      End If
    Next

    If whereParts.Count > 0 Then
      query &= " WHERE " & String.Join(" AND ", whereParts)
    End If

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    ' Mapear filas usando helper
    For Each row As DataRow In dt.Rows
      Dim entidad As T = Activator.CreateInstance(Of T)()
      DataRowMapper.MapDataRowToEntity(row, entidad)
      lista.Add(entidad)
    Next

    Return lista
  End Function
End Class
