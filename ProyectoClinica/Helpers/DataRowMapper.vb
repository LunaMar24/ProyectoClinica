Imports System.Reflection

Public Module DataRowMapper
  Public Sub MapDataRowToEntity(Of T)(row As DataRow, entity As T)
    Dim props = GetType(T).GetProperties(BindingFlags.Public Or BindingFlags.Instance)

    For Each prop As PropertyInfo In props
      Dim columnName As String = prop.Name

      ' Buscar atributo [ColumnName]
      Dim attr = prop.GetCustomAttributes(GetType(ColumnNameAttribute), False).FirstOrDefault()
      If attr IsNot Nothing Then
        columnName = DirectCast(attr, ColumnNameAttribute).Name
      End If

      ' Validar si existe la columna en el DataTable
      If row.Table.Columns.Contains(columnName) AndAlso Not IsDBNull(row(columnName)) Then
        prop.SetValue(entity, Convert.ChangeType(row(columnName), prop.PropertyType))
      End If
    Next
  End Sub
End Module
