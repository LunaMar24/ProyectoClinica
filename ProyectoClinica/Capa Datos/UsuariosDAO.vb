Imports MySql.Data.MySqlClient

Public Class UsuariosDAO
  Inherits DAOBase
  Implements IRepositorio(Of Usuario)

  ' Obtener todos los usuarios
  Public Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of Usuario) Implements IRepositorio(Of Usuario).GetAll
    Dim usuarios As New List(Of Usuario)()
    Dim query As String = "SELECT idusuarios, nombre, password, correo, tipo_usuario FROM usuarios"
    Dim whereParts As New List(Of String)()
    Dim parameters As New List(Of MySqlParameter)()

    ' Construir WHERE dinámico
    If filtros IsNot Nothing Then
      For Each filtro In filtros
        Dim prop = GetType(Usuario).GetProperties().
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
      Dim entity As New Usuario()
      DataRowMapper.MapDataRowToEntity(row, entity)
      usuarios.Add(entity)
    Next

    Return usuarios
  End Function

  ' Obtener un usuario por ID
  Public Function GetById(id As Integer) As Usuario Implements IRepositorio(Of Usuario).GetById
    Dim query As String = "SELECT idusuarios, nombre, password, correo, tipo_usuario FROM usuarios WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@id", id)
        }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New Usuario()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function IsValidLogin(Correo As String, Clave As String) As Usuario
    Dim query As String = "SELECT * FROM usuarios WHERE correo = @correo AND password = @password"
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@correo", Correo),
            New MySqlParameter("@password", Clave)
        }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim entity As New Usuario()
      DataRowMapper.MapDataRowToEntity(dt.Rows(0), entity)
      Return entity
    Else
      Return Nothing
    End If
  End Function

  Public Function CambiarClave(entity As Usuario) As Integer
    Dim query As String = "UPDATE usuarios SET password = @password WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@password", entity.Password),
            New MySqlParameter("@id", entity.IdUsuarios)
        }

    Return ExecuteNonQuery(query, parameters)
  End Function

  ' Insertar un nuevo usuario
  Public Function Insert(entity As Usuario) As Integer Implements IRepositorio(Of Usuario).Insert
    Dim query As String = "INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES (@nombre, @password, @correo, @tipo_usuario)"
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@nombre", entity.Nombre),
            New MySqlParameter("@password", entity.Password),
            New MySqlParameter("@correo", entity.Correo),
            New MySqlParameter("@tipo_usuario", entity.TipoUsuario)
        }

    Return ExecuteInsertReturnId(query, parameters)
  End Function

  ' Actualizar un usuario existente
  Public Function Update(entity As Usuario) As Integer Implements IRepositorio(Of Usuario).Update
    Dim query As String = "UPDATE usuarios SET nombre = @nombre, correo = @correo, tipo_usuario = @tipo_usuario WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@nombre", entity.Nombre),
            New MySqlParameter("@correo", entity.Correo),
            New MySqlParameter("@tipo_usuario", entity.TipoUsuario),
            New MySqlParameter("@id", entity.IdUsuarios)
        }

    Return ExecuteNonQuery(query, parameters)
  End Function

  ' Eliminar un usuario por ID
  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Usuario).Delete
    Dim query As String = ""
    Dim parameters As New List(Of MySqlParameter) From {
            New MySqlParameter("@idUsuario", id)
        }
    Dim rowsAffected As Integer = 0

    Try
      BeginTransaction()

#Region "Eliminar Información Usuario Doctor"
      'Se requiere eliminar información adicional para doctores
      '1) Elimina Especialidades si el usuario es doctor
      query = "DELETE FROM doctor_especialidad WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario)"
      ExecuteNonQuery(query, parameters)

      '2) Elimina tratamientos asociados a las consultas del doctor
      query = "DELETE FROM tratamiento WHERE consulta_id in (SELECT id FROM consulta WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario))"

      ExecuteNonQuery(query, parameters)

      '3) Elimina consultas si el usuario es doctor
      query = "DELETE FROM consulta WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario)"

      ExecuteNonQuery(query, parameters)

      '4) Elimina información del doctor
      query = "DELETE FROM doctor WHERE usuarios_idusuarios = @idUsuario"

      ExecuteNonQuery(query, parameters)
#End Region

#Region "Eliminar Información Usuario Paciente"
      '1) Elimina tratamientos asociados a las consultas del paciente
      query = "DELETE FROM tratamiento WHERE consulta_id in (SELECT id FROM consulta WHERE persona_id = (SELECT id FROM persona WHERE usuarios_idusuarios = @idUsuario))"

      ExecuteNonQuery(query, parameters)

      '2) Elimina consultas si el usuario es paciente
      query = "DELETE FROM consulta WHERE persona_id = (SELECT id FROM persona WHERE usuarios_idusuarios = @idUsuario)"

      ExecuteNonQuery(query, parameters)

      '3) Elimina información del doctor
      query = "DELETE FROM persona WHERE usuarios_idusuarios = @idUsuario"

      ExecuteNonQuery(query, parameters)
#End Region


      query = "DELETE FROM usuarios WHERE idusuarios = @idUsuario"

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

