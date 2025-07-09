Imports MySql.Data.MySqlClient

Public Class frmMantUsuarios

  Private conexion As Conexion

  Private Sub frmMantUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
    CargarUsuarios()
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
    frmCrearCuenta.Show()
    Me.Hide()
  End Sub

  Private Sub CargarUsuarios(Optional nombre As String = "", Optional codigo As String = "", Optional tipoUsuario As String = "")
    Try
      Dim conn = conexion.Abrir()
      Dim dt = New DataTable
      Dim selectQuery = "SELECT * FROM vUsuarios"
      Dim parteWhere = ""
      Dim comandoFiltro = ""

      If Not (String.IsNullOrWhiteSpace(nombre) AndAlso String.IsNullOrWhiteSpace(codigo) AndAlso String.IsNullOrWhiteSpace(tipoUsuario)) Then
        parteWhere = " Where "
        If Not String.IsNullOrWhiteSpace(nombre) Then
          comandoFiltro = comandoFiltro & "nombre_usuario like @Nombre"
        End If

        If Not String.IsNullOrWhiteSpace(codigo) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "codigo_usuario like @Codigo"
        End If

        If Not String.IsNullOrWhiteSpace(tipoUsuario) Then
          If Not String.IsNullOrWhiteSpace(comandoFiltro) Then
            comandoFiltro = comandoFiltro & " AND "
          End If
          comandoFiltro = comandoFiltro & "tipo_usuario like @TipoUsuario"
        End If
      End If
      selectQuery = selectQuery & parteWhere & comandoFiltro

      Using command As New MySqlCommand(selectQuery, conn)

        'Asignar los parametros
        If Not String.IsNullOrWhiteSpace(nombre) Then
          command.Parameters.AddWithValue("@Nombre", "%" & nombre & "%")
        End If
        If Not String.IsNullOrWhiteSpace(codigo) Then
          command.Parameters.AddWithValue("@Codigo", "%" & codigo & "%")
        End If
        If Not String.IsNullOrWhiteSpace(tipoUsuario) Then
          command.Parameters.AddWithValue("@TipoUsuario", "%" & tipoUsuario & "%")
        End If

        Dim adaptador = New MySqlDataAdapter(command)
        'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
        adaptador.Fill(dt)
      End Using

      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvUsuarios.DataSource = dt
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información de los doctores. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    CargarUsuarios(txtFilNombre.Text, txtFilCodigo.Text, cmbFilTipoUsuario.Text)
  End Sub
End Class