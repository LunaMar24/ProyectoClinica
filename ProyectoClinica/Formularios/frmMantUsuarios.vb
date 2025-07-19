Public Class frmMantUsuarios
  Implements IFormularios

  Private idUsuario As Integer
  Private tipoUsuario As String

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    cmbFilTipoUsuario.ContextMenuStrip = New ContextMenuStrip() ' Elimina el menú contextual (click derecho)
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
      Dim dao As New VUsuariosDAO()
      Dim filtros As New Dictionary(Of String, Object) From {
                {"NombreUsuario", txtFilNombre.Text},
                {"_UsuarioId", txtFilCodigo.Text},
                {"TipoUsuario", cmbFilTipoUsuario.Text}
            }

      Dim lista As List(Of VUsuario) = dao.GetByFilters(filtros)
      dgvUsuarios.DataSource = lista
      idUsuario = -1
      dgvUsuarios.ClearSelection()
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar la información de los usuarios. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Try
          Dim dbUsuarios As New UsuariosDAO()

          If dbUsuarios.Delete(idUsuario) > 0 Then
            MessageBox.Show("Usuario eliminado correctamente.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If CodigoUsuario = idUsuario Then
              ' Si el usuario eliminado es el mismo que está logueado, se cierra la sesión
              frmLogin.Show()
              frmLogin.AjustarPantalla()
              Me.Close()
            End If
          Else
            MessageBox.Show("Se presentó un error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End If

          CargarUsuarios()
        Catch ex As Exception
          MessageBox.Show("Se presentó un error al eliminar el usuario. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
      End If

    Else
      MessageBox.Show("Debe seleccionar el usuario a eliminar.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub

  Private Sub cmbFilTipoUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFilTipoUsuario.KeyPress
    e.Handled = True ' Evita que se pueda escribir en el ComboBox
  End Sub

  Private Sub cmbFilTipoUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbFilTipoUsuario.KeyDown
    If e.Control AndAlso e.KeyCode = Keys.V Then ' Evita que se pueda pegar algo al ComboBox
      e.SuppressKeyPress = True
    End If
  End Sub

  Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click
    If idUsuario >= 0 Then
      frmCambiarClave.Show()
      frmCambiarClave.UsuarioID = idUsuario
      frmCambiarClave.AjustarPantalla()
      Me.Hide()
    Else
      MessageBox.Show("Debe seleccionar el usuario a cambiar la clave.", "Cambio Clave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If
  End Sub
End Class