Imports MySql.Data.MySqlClient

Public Class DoctorEspecialidadDAO
  Inherits DAOBase
  Implements IRepositorio(Of DoctorEspecialidad)

  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of DoctorEspecialidad) Implements IRepositorio(Of DoctorEspecialidad).GetAll
    Dim lista As New List(Of DoctorEspecialidad)()
    Dim query As String = "SELECT id, doctor_id, especialidad_id FROM doctor_especialidad"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(DoctorEspecialidad).GetProperties().
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
      Dim entity As New DoctorEspecialidad()
      DataRowMapper.MapDataRowToEntity(row, entity)
      lista.Add(entity)
    Next

    Return lista
  End Function

  Public Function GetById(id As Integer) As DoctorEspecialidad Implements IRepositorio(Of DoctorEspecialidad).GetById
    Dim query As String = "SELECT id, doctor_id, especialidad_id FROM doctor_especialidad WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New DoctorEspecialidad()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function GetByDoctorId(id As Integer) As DoctorEspecialidad
    Dim query As String = "SELECT id, doctor_id, especialidad_id FROM doctor_especialidad WHERE doctor_id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New DoctorEspecialidad()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function Insert(entity As DoctorEspecialidad) As Integer Implements IRepositorio(Of DoctorEspecialidad).Insert
    Dim query As String = "INSERT INTO doctor_especialidad (doctor_id, especialidad_id) VALUES (@doctor_id, @especialidad_id)"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@doctor_id", entity.DoctorId),
        New MySqlParameter("@especialidad_id", entity.EspecialidadId)
    }

    Return ExecuteInsertReturnId(query, parameters)
  End Function

  Public Function Update(entity As DoctorEspecialidad) As Integer Implements IRepositorio(Of DoctorEspecialidad).Update
    Dim query As String = "UPDATE doctor_especialidad SET doctor_id = @doctor_id, especialidad_id = @especialidad_id WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@doctor_id", entity.DoctorId),
        New MySqlParameter("@especialidad_id", entity.EspecialidadId),
        New MySqlParameter("@id", entity.Id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of DoctorEspecialidad).Delete
    Dim query As String = "DELETE FROM doctor_especialidad WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function
End Class
