Imports MySql.Data.MySqlClient

Public Class frmMantUsuarios
  Implements IFormularios

  Private conexion As Conexion
  Private idUsuario As Integer
  Private tipoUsuario As String

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarUsuarios()
  End Sub

  Private Sub frmMantUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion
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
      idUsuario = -1
      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvUsuarios.DataSource = dt
      dgvUsuarios.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información de los doctores. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    CargarUsuarios(txtFilNombre.Text, txtFilCodigo.Text, cmbFilTipoUsuario.Text)
  End Sub

  Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
    If e.RowIndex >= 0 Then
      idUsuario = Integer.Parse(dgvUsuarios.Rows(e.RowIndex).Cells("clID").Value)
      tipoUsuario = dgvUsuarios.Rows(e.RowIndex).Cells("clTipoUsuario").Value.ToString()
    End If
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
    If idUsuario >= 0 Then
      frmModificaCuenta.Show()
      frmModificaCuenta.UsuarioID = idUsuario
      frmModificaCuenta.AjustarPantalla()
      Me.Hide()
    Else
      MessageBox.Show("Debe seleccionar el usuario a modificar.", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    If idUsuario >= 0 Then
      Dim resultado As DialogResult = MessageBox.Show("Toda información relacionada a este usuario (" & tipoUsuario & ") será eliminada" & vbCrLf & vbCrLf & "¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If resultado = DialogResult.Yes Then
        Dim conn = conexion.Abrir()
        Dim trans As MySqlTransaction = Nothing
        Try
          Dim comando As New MySqlCommand()
          trans = conn.BeginTransaction()

#Region "Eliminar Información Usuario Doctor"
          'Se requiere eliminar información adicional para doctores
          '1) Elimina Especialidades si el usuario es doctor
          comando = New MySqlCommand("DELETE FROM doctor_especialidad WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario)", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()

          '2) Elimina tratamientos asociados a las consultas del doctor
          comando = New MySqlCommand("DELETE FROM tratamiento WHERE consulta_id in (SELECT id FROM consulta WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario))", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()

          '3) Elimina consultas si el usuario es doctor
          comando = New MySqlCommand("DELETE FROM consulta WHERE doctor_id = (SELECT id FROM doctor WHERE usuarios_idusuarios = @idUsuario)", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()

          '4) Elimina información del doctor
          comando = New MySqlCommand("DELETE FROM doctor WHERE usuarios_idusuarios = @idUsuario", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()
#End Region

#Region "Eliminar Información Usuario Paciente"
          '1) Elimina tratamientos asociados a las consultas del paciente
          comando = New MySqlCommand("DELETE FROM tratamiento WHERE consulta_id in (SELECT id FROM consulta WHERE persona_id = (SELECT id FROM persona WHERE usuarios_idusuarios = @idUsuario))", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()

          '2) Elimina consultas si el usuario es paciente
          comando = New MySqlCommand("DELETE FROM consulta WHERE persona_id = (SELECT id FROM persona WHERE usuarios_idusuarios = @idUsuario)", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()

          '3) Elimina información del doctor
          comando = New MySqlCommand("DELETE FROM persona WHERE usuarios_idusuarios = @idUsuario", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()
#End Region

#Region "Eliminar Usuario"

          comando = New MySqlCommand("DELETE FROM usuarios WHERE idusuarios = @idUsuario", conn)
          comando.Parameters.AddWithValue("@idUsuario", idUsuario)
          comando.ExecuteNonQuery()
#End Region

          trans.Commit()

          MessageBox.Show("Usuario eliminado correctamente.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

          If CodigoUsuario = idUsuario Then
            ' Si el usuario eliminado es el mismo que está logueado, se cierra la sesión
            frmLogin.Show()
            frmLogin.AjustarPantalla()
            Me.Close()
          End If
          CargarUsuarios()
        Catch ex As Exception
          If conn IsNot Nothing AndAlso trans IsNot Nothing Then
            trans.Rollback()
          End If
          MessageBox.Show("Se presentó un error al eliminar el usuario. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
          conexion.Cerrar()
        End Try
      End If

    Else
      MessageBox.Show("Debe seleccionar el usuario a eliminar.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub
End Class