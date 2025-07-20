Public Class Persona
  <ColumnName("id")>
  Public Property Id As Integer

  <ColumnName("identificacion")>
  Public Property Identificacion As String

  <ColumnName("nombre_completo")>
  Public Property NombreCompleto As String

  <ColumnName("apellido")>
  Public Property Apellido As String

  <ColumnName("direccion")>
  Public Property Direccion As String

  <ColumnName("telefono")>
  Public Property Telefono As String

  <ColumnName("correo")>
  Public Property Correo As String

  <ColumnName("edad")>
  Public Property Edad As String

  <ColumnName("sexo")>
  Public Property Sexo As String

  <ColumnName("fecha_nacimiento")>
  Public Property FechaNacimiento As Date

  <ColumnName("tipo_sangre")>
  Public Property TipoSangre As String

  <ColumnName("contacto_emergencia")>
  Public Property ContactoEmergencia As String

  <ColumnName("usuarios_idusuarios")>
  Public Property UsuariosIdusuarios As Integer
End Class
