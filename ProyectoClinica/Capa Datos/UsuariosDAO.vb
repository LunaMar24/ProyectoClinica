Imports MySql.Data.MySqlClient

Public Class UsuariosDAO
  Inherits DAOBase
  Implements IRepositorio(Of Usuario)

  Public Function GetAll() As List(Of Usuario) Implements IRepositorio(Of Usuario).GetAll
    Dim usuarios As New List(Of Usuario)()
    Dim query As String = "SELECT idusuarios, nombre, password, correo, tipo_usuario FROM usuarios"

    Dim dt As DataTable = ExecuteQuery(query, Nothing)

    For Each row As DataRow In dt.Rows
      usuarios.Add(New Usuario With {
          .IdUsuarios = Convert.ToInt32(row("idusuarios")),
          .Nombre = row("nombre").ToString(),
          .Password = row("password").ToString(),
          .Correo = row("correo").ToString(),
          .TipoUsuario = row("tipo_usuario").ToString()
      })
    Next

    Return usuarios
  End Function

  Public Function GetById(id As Integer) As Usuario Implements IRepositorio(Of Usuario).GetById
    Dim query As String = "SELECT idusuarios, nombre, password, correo, tipo_usuario FROM usuarios WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Dim dt As DataTable = ExecuteQuery(query, parameters)

    If dt.Rows.Count > 0 Then
      Dim row = dt.Rows(0)
      Return New Usuario With {
          .IdUsuarios = Convert.ToInt32(row("idusuarios")),
          .Nombre = row("nombre").ToString(),
          .Password = row("password").ToString(),
          .Correo = row("correo").ToString(),
          .TipoUsuario = row("tipo_usuario").ToString()
      }
    Else
      Return Nothing
    End If
  End Function

  Public Function Insert(entity As Usuario) As Integer Implements IRepositorio(Of Usuario).Insert
    Dim query As String = "INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES (@nombre, @password, @correo, @tipo_usuario)"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@nombre", entity.Nombre),
        New MySqlParameter("@password", entity.Password),
        New MySqlParameter("@correo", entity.Correo),
        New MySqlParameter("@tipo_usuario", entity.TipoUsuario)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function

  Public Function Update(entity As Usuario) As Integer Implements IRepositorio(Of Usuario).Update
    Dim query As String = "UPDATE usuarios SET nombre = @nombre, password = @password, correo = @correo, tipo_usuario = @tipo_usuario WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@nombre", entity.Nombre),
        New MySqlParameter("@password", entity.Password),
        New MySqlParameter("@correo", entity.Correo),
        New MySqlParameter("@tipo_usuario", entity.TipoUsuario),
        New MySqlParameter("@id", entity.IdUsuarios)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function

  Public Function Delete(id As Integer) As Integer Implements IRepositorio(Of Usuario).Delete
    Dim query As String = "DELETE FROM usuarios WHERE idusuarios = @id"
    Dim parameters As New List(Of MySqlParameter) From {
        New MySqlParameter("@id", id)
    }

    Return ExecuteNonQuery(query, parameters)
  End Function
End Class
