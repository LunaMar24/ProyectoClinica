Imports System.Data
Imports System.Data.Common
Imports MySql.Data.MySqlClient

Public Class ConsultaDAO
  Inherits DAOBase
  Implements IRepositorio(Of Consulta)

  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of Consulta) Implements IRepositorio(Of Consulta).GetAll
    Dim consultas As New List(Of Consulta)()
    Dim query As String = "SELECT id, numero, prioridad, fecha, sintomas, padecimientos, alergias, presion, temperatura, peso, estatura, persona_id, doctor_id FROM consulta"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(Consulta).GetProperties().FirstOrDefault(Function(p) p.Name.ToUpper() = filtro.Key.ToUpper())
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
      Dim consulta As New Consulta()
      DataRowMapper.MapDataRowToEntity(row, consulta)
      consultas.Add(consulta)
    Next

    Return consultas
  End Function

  Public Function GetById(id As Integer) As Consulta Implements IRepositorio(Of Consulta).GetById
    Dim query As String = "SELECT id, numero, prioridad, fecha, sintomas, padecimientos, alergias, presion, temperatura, peso, estatura, persona_id, doctor_id FROM consulta WHERE id = @id"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parametros)
    If dt.Rows.Count = 0 Then Return Nothing

    Dim consulta As New Consulta()
    DataRowMapper.MapDataRowToEntity(dt.Rows(0), consulta)
    Return consulta
  End Function

  Public Function UltimaConsulta() As String
    Dim query As String = "SELECT IFNULL(MAX(numero), '') FROM consulta"

    Return ExecuteScalar(query, New List(Of MySqlParameter)())
  End Function

  Public Function Insert(entity As Consulta) As Integer Implements IRepositorio(Of Consulta).Insert
    Dim query As String = "INSERT INTO consulta (numero, prioridad, fecha, sintomas, padecimientos, alergias, presion, temperatura, peso, estatura, persona_id, doctor_id) 
                               VALUES (@numero, @prioridad, @fecha, @sintomas, @padecimientos, @alergias, @presion, @temperatura, @peso, @estatura, @persona_id, @doctor_id)"

    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@numero", entity.Numero),
        New MySqlParameter("@prioridad", entity.Prioridad),
        New MySqlParameter("@fecha", entity.Fecha),
        New MySqlParameter("@sintomas", entity.Sintomas),
        New MySqlParameter("@padecimientos", entity.Padecimientos),
        New MySqlParameter("@alergias", entity.Alergias),
        New MySqlParameter("@presion", entity.Presion),
        New MySqlParameter("@temperatura", entity.Temperatura),
        New MySqlParameter("@peso", entity.Peso),
        New MySqlParameter("@estatura", entity.Estatura),
        New MySqlParameter("@persona_id", entity.PersonaId),
        New MySqlParameter("@doctor_id", entity.DoctorId)
    }

    Return ExecuteInsertReturnId(query, parametros)
  End Function

  Public Function Update(entity As Consulta) As Integer Implements IRepositorio(Of Consulta).Update
    Dim query As String = "UPDATE consulta SET numero = @numero, prioridad = @prioridad, fecha = @fecha, sintomas = @sintomas, padecimientos = @padecimientos,
                            alergias = @alergias, presion = @presion, temperatura = @temperatura, peso = @peso, estatura = @estatura,
                            persona_id = @persona_id, doctor_id = @doctor_id WHERE id = @id"

    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@numero", entity.Numero),
        New MySqlParameter("@prioridad", entity.Prioridad),
        New MySqlParameter("@fecha", entity.Fecha),
        New MySqlParameter("@sintomas", entity.Sintomas),
        New MySqlParameter("@padecimientos", entity.Padecimientos),
        New MySqlParameter("@alergias", entity.Alergias),
        New MySqlParameter("@presion", entity.Presion),
        New MySqlParameter("@temperatura", entity.Temperatura),
        New MySqlParameter("@peso", entity.Peso),
        New MySqlParameter("@estatura", entity.Estatura),
        New MySqlParameter("@persona_id", entity.PersonaId),
        New MySqlParameter("@doctor_id", entity.DoctorId),
        New MySqlParameter("@id", entity.Id)
    }

    Return ExecuteNonQuery(query, parametros)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Consulta).Delete
    Dim query As String = "DELETE FROM consulta WHERE id = @id"
    Dim parametros As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }
    Return ExecuteNonQuery(query, parametros)
  End Function

End Class
