Imports MySql.Data.MySqlClient

Public Class DoctorDAO
  Inherits DAOBase
  Implements IRepositorio(Of Doctor)

  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of Doctor) Implements IRepositorio(Of Doctor).GetAll
    Dim lista As New List(Of Doctor)()
    Dim query As String = "SELECT id, identificacion, nombre_completo, apellido, direccion, telefono, correo, edad, sexo, usuarios_idusuarios FROM doctor"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(Doctor).GetProperties().
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
      Dim entity As New Doctor()
      DataRowMapper.MapDataRowToEntity(row, entity)
      lista.Add(entity)
    Next

    Return lista
  End Function

  Public Function GetById(id As Integer) As Doctor Implements IRepositorio(Of Doctor).GetById
    Dim query As String = "SELECT id, identificacion, nombre_completo, apellido, direccion, telefono, correo, edad, sexo, usuarios_idusuarios FROM doctor WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New Doctor()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function Insert(entity As Doctor) As Integer Implements IRepositorio(Of Doctor).Insert
    Dim query As String = "INSERT INTO doctor (identificacion, nombre_completo, apellido, direccion, telefono, correo, edad, sexo, usuarios_idusuarios) VALUES (@identificacion, @nombre_completo, @apellido, @direccion, @telefono, @correo, @edad, @sexo, @usuarios_idusuarios)"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@identificacion", entity.Identificacion),
        New MySqlParameter("@nombre_completo", entity.NombreCompleto),
        New MySqlParameter("@apellido", entity.Apellido),
        New MySqlParameter("@direccion", entity.Direccion),
        New MySqlParameter("@telefono", entity.Telefono),
        New MySqlParameter("@correo", entity.Correo),
        New MySqlParameter("@edad", entity.Edad),
        New MySqlParameter("@sexo", entity.Sexo),
        New MySqlParameter("@usuarios_idusuarios", entity.UsuariosIdusuarios)
    }

    Return ExecuteInsertReturnId(query, parameters)
  End Function

  Public Function Update(entity As Doctor) As Integer Implements IRepositorio(Of Doctor).Update
    Dim query As String = "UPDATE doctor SET identificacion = @identificacion, nombre_completo = @nombre_completo, apellido = @apellido, direccion = @direccion, telefono = @telefono, correo = @correo, edad = @edad, sexo = @sexo, usuarios_idusuarios = @usuarios_idusuarios WHERE id = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@identificacion", entity.Identificacion),
        New MySqlParameter("@nombre_completo", entity.NombreCompleto),
        New MySqlParameter("@apellido", entity.Apellido),
        New MySqlParameter("@direccion", entity.Direccion),
        New MySqlParameter("@telefono", entity.Telefono),
        New MySqlParameter("@correo", entity.Correo),
        New MySqlParameter("@edad", entity.Edad),
        New MySqlParameter("@sexo", entity.Sexo),
        New MySqlParameter("@usuarios_idusuarios", entity.UsuariosIdusuarios),
        New MySqlParameter("@id", entity.Id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Doctor).Delete
    Dim query As String = ""
    Dim rowsAffected As Integer = 0
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Try
      BeginTransaction()

#Region "Eliminar Información Asociada al Doctor"

      '1) Elimina Especialidades si el usuario es doctor
      query = "DELETE FROM doctor_especialidad WHERE doctor_id = @id"
      ExecuteNonQuery(query, parameters)

      '2) Elimina tratamientos asociados a las consultas del doctor
      query = "DELETE FROM tratamiento WHERE consulta_id in (SELECT id FROM consulta WHERE doctor_id = @id)"

      ExecuteNonQuery(query, parameters)

      '3) Elimina consultas si el usuario es doctor
      query = "DELETE FROM consulta WHERE doctor_id = @id"

      ExecuteNonQuery(query, parameters)

#End Region

      ' Elimina información del doctor
      query = "DELETE FROM doctor WHERE id = @id"

      rowsAffected = ExecuteNonQuery(query, parameters)

      EndTransaction(True)
    Catch ex As Exception
      EndTransaction(False)
      Throw New Exception("Error al eliminar el usuario: " & ex.Message)
    Finally
      CerrarConexion()
    End Try


    Return rowsAffected
  End Function
End Class

