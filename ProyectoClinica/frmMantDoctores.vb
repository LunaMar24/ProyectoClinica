Imports MySql.Data.MySqlClient

Public Class frmMantDoctores

  Private conexion As Conexion

  Private Sub frmMantDoctores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion

    CargarDoctores()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub CargarDoctores()
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT * FROM vDoctor"
      Dim adaptador = New MySqlDataAdapter(selectQuery, conn)
      Dim dt = New DataTable

      'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
      adaptador.Fill(dt)

      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvDoctores.DataSource = dt
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información de los doctores. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub
End Class