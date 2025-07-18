Public Class VPaciente
  <ColumnName("ID")>
  Public Property Id As Integer

  <ColumnName("NOMBRE")>
  Public Property Nombre As String

  <ColumnName("APELLIDO")>
  Public Property Apellido As String

  <ColumnName("CEDULA")>
  Public Property Cedula As String

  <ColumnName("TELEFONO")>
  Public Property Telefono As String

  <ColumnName("USUARIO")>
  Public Property Usuario As String

  <ColumnName("CONSULTAS_PENDIENTES")>
  Public Property ConsultasPendientes As Long

  <ColumnName("CONSULTAS_FINALIZADAS")>
  Public Property ConsultasFinalizadas As Long
End Class
