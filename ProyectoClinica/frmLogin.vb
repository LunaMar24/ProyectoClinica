Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class frmLogin
  Implements IFormularios
  Private conexion As Conexion

  Private Const CUENTA_ADMIN As String = "admin@"
  Private Const CLAVE_ADMIN As String = "admin@1234"

  Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
    'Validar el nombre del usuario y la contraseña,que los espacios no esten vacios
    Dim correo As String = txtCorreo.Text.Trim()
    Dim contrasena As String = txtPassword.Text.Trim()

    If String.IsNullOrWhiteSpace(txtCorreo.Text) Or String.IsNullOrWhiteSpace(txtPassword.Text) Then
      MessageBox.Show("El correo y la contraseña no pueden estar en blanco.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If correo = CUENTA_ADMIN Then
      If contrasena = CLAVE_ADMIN Then
        frmDashboard.Show()
        TipoUsuario = "Administrador"
        frmDashboard.AjustarPantalla()
        Me.Hide()
      End If
    Else
      Try
        contrasena = HashSHA256(txtPassword.Text.Trim())

        Dim dbuser As New UsuariosDAO()
        Dim usuario As Usuario = dbuser.IsValidLogin(correo, contrasena)
        dbuser.Dispose()

        If usuario IsNot Nothing Then
          CodigoUsuario = usuario.IdUsuarios
          TipoUsuario = usuario.TipoUsuario
          frmDashboard.AjustarPantalla()
          MessageBox.Show("Inicio de sesión exitoso para el correo '" & correo & "'.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information)
          ' Aquí podrías abrir otra ventana o hacer lo que necesites
          frmDashboard.Show()
          Me.Hide()
        Else
          MessageBox.Show("Correo o contraseña incorrectos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
      Catch ex As Exception
        MessageBox.Show("Error de base de datos al consultar usuario: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
        conexion.Cerrar()
      End Try
    End If
  End Sub

  Private Sub btnCrearCuenta_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
    Me.Close()
  End Sub

  Private Function HashSHA256(texto As String) As String
    Using sha256 As SHA256 = SHA256.Create()
      Dim bytes As Byte() = Encoding.UTF8.GetBytes(texto)
      Dim hash As Byte() = sha256.ComputeHash(bytes)
      Return BitConverter.ToString(hash).Replace("-", "").ToLower()
    End Using
  End Function

  Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
  End Sub

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    txtCorreo.Clear()
    txtPassword.Clear()
  End Sub
End Class
