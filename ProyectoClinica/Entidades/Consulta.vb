Public Class Consulta
  <ColumnName("id")>
  Public Property Id As Integer

  <ColumnName("numero")>
  Public Property Numero As String

  <ColumnName("prioridad")>
  Public Property Prioridad As String

  <ColumnName("fecha")>
  Public Property Fecha As DateTime

  <ColumnName("sintomas")>
  Public Property Sintomas As String

  <ColumnName("padecimientos")>
  Public Property Padecimientos As String

  <ColumnName("alergias")>
  Public Property Alergias As String

  <ColumnName("presion")>
  Public Property Presion As String

  <ColumnName("temperatura")>
  Public Property Temperatura As String

  <ColumnName("peso")>
  Public Property Peso As String

  <ColumnName("estatura")>
  Public Property Estatura As String

  <ColumnName("persona_id")>
  Public Property PersonaId As Integer

  <ColumnName("doctor_id")>
  Public Property DoctorId As Integer
End Class
