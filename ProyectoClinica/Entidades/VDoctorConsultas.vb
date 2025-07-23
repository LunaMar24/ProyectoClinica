Public Class VDoctorConsultas
  <ColumnName("ID")>
  Public Property Id As Integer

  <ColumnName("CONSECUTIVO")>
  Public Property Consecutivo As String

  <ColumnName("FECHA_CONSULTA")>
  Public Property FechaConsulta As DateTime

  <ColumnName("PRIORIDAD")>
  Public Property Prioridad As String

  <ColumnName("NUM_PRIORIDAD")>
  Public Property NumPrioridad As Integer

  <ColumnName("CODIGO_DOCTOR")>
  Public Property CodigoDoctor As Integer

  <ColumnName("CODIGO_PACIENTE")>
  Public Property CodigoPaciente As Integer

  <ColumnName("IDENTIFICACION")>
  Public Property Identificacion As String

  <ColumnName("PACIENTE")>
  Public Property Paciente As String

  <ColumnName("DOCTOR")>
  Public Property Doctor As String

  <ColumnName("ESPECIALIDAD")>
  Public Property Especialidad As String

  <ColumnName("EDAD_PACIENTE")>
  Public Property EdadPaciente As String

  <ColumnName("SEXO_PACIENTE")>
  Public Property SexoPaciente As String

  <ColumnName("CONSULTA_FINALIZADA")>
  Public Property ConsultaFinalizada As Long
End Class
