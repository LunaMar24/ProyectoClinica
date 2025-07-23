Imports MySql.Data.MySqlClient

Public Class TratamientoDAO
  Inherits DAOBase
  Implements IRepositorio(Of Tratamiento)

  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of Tratamiento) Implements IRepositorio(Of Tratamiento).GetAll
    Dim tratamientos As New List(Of Tratamiento)()
    Dim query As String = "SELECT id, descripcion, consulta_id FROM tratamiento"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(Tratamiento).GetProperties().FirstOrDefault(Function(p) p.Name.ToUpper() = filtro.Key.ToUpper())
        If prop IsNot Nothing Then
          Dim attr = prop.GetCustomAttributes(GetType(ColumnNameAttribute), False).FirstOrDefault()
          Dim columnName = If(attr IsNot Nothing, DirectCast(attr, ColumnNameAttribute).Name, prop.Name)

          If filtro.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(filtro.Value.ToString()) Then
            whereParts.Add($"{columnName} LIKE @{filtro.Key}")
            parameters.Add(New MySqlParameter($"@{filtro.Key}", $"%{filtro.Value}%"))
          End If
        End If
      Next
    End If

    If whereParts.Count > 0 Then
      query &= " WHERE " & String.Join(" AND ", whereParts)
    End If

    Dim dt As DataTable = ExecuteQuery(query, parameters)
    For Each row As DataRow In dt.Rows
      Dim entity As New Tratamiento()
      DataRowMapper.MapDataRowToEntity(row, entity)
      tratamientos.Add(entity)
    Next

    Return tratamientos
  End Function

  Public Function GetById(id As Integer) As Tratamiento Implements IRepositorio(Of Tratamiento).GetById
    Dim query As String = "SELECT id, descripcion, consulta_id FROM tratamiento WHERE id = @id"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parametros)
    If dt.Rows.Count = 0 Then Return Nothing

    Dim entity As New Tratamiento()
    DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
    Return entity
  End Function

  Public Function Insert(entity As Tratamiento) As Integer Implements IRepositorio(Of Tratamiento).Insert
    Dim query As String = "INSERT INTO tratamiento (descripcion, consulta_id) VALUES (@descripcion, @consulta_id)"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@descripcion", entity.Descripcion),
        New MySqlParameter("@consulta_id", entity.ConsultaId)
    }

    Return ExecuteInsertReturnId(query, parametros)
  End Function

  Public Function Update(entity As Tratamiento) As Integer Implements IRepositorio(Of Tratamiento).Update
    Dim query As String = "UPDATE tratamiento SET descripcion = @descripcion, consulta_id = @consulta_id WHERE id = @id"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@descripcion", entity.Descripcion),
        New MySqlParameter("@consulta_id", entity.ConsultaId),
        New MySqlParameter("@id", entity.Id)
    }

    Return ExecuteNonQuery(query, parametros)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Tratamiento).Delete
    Dim query As String = "DELETE FROM tratamiento WHERE id = @id"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Return ExecuteNonQuery(query, parametros)
  End Function

End Class
