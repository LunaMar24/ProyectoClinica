Imports MySql.Data.MySqlClient

Public Class EspecialidadDAO
  Inherits DAOBase
  Implements IRepositorio(Of Especialidad)

  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of Especialidad) Implements IRepositorio(Of Especialidad).GetAll
    Dim lista As New List(Of Especialidad)()
    Dim query As String = "SELECT id, descripcion FROM especialidad"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    ' Construir WHERE dinámico
    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(Especialidad).GetProperties().
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
    End If

    If whereParts.Count > 0 Then
      query &= " WHERE " & String.Join(" AND ", whereParts)
    End If

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    For Each row As DataRow In dt.Rows
      Dim entity As New Especialidad()
      DataRowMapper.MapDataRowToEntity(row, entity)
      lista.Add(entity)
    Next

    Return lista
  End Function

  Public Function GetById(id As Integer) As Especialidad Implements IRepositorio(Of Especialidad).GetById
    Dim query As String = "SELECT id, descripcion FROM especialidad WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New Especialidad()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function Insert(entity As Especialidad) As Integer Implements IRepositorio(Of Especialidad).Insert
    Dim query As String = "INSERT INTO especialidad (descripcion) VALUES (@descripcion)"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@descripcion", entity.Descripcion)
    }

    Return ExecuteInsertReturnId(query, parameters)
  End Function

  Public Function Update(entity As Especialidad) As Integer Implements IRepositorio(Of Especialidad).Update
    Dim query As String = "UPDATE especialidad SET descripcion = @descripcion WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@descripcion", entity.Descripcion),
        New MySqlParameter("@id", entity.Id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Especialidad).Delete
    Dim query As String = "DELETE FROM especialidad WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function
End Class
