Public Class frmLogin
  Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblUsuario.Click

  End Sub

  Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblPassword.Click

  End Sub

  Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
    Me.Close()

  End Sub

  Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
    'Validar el nombre del usuario y la contraseña,que los espacios no esten vacios

    If String.IsNullOrWhiteSpace(txtUsuario.Text) Or String.IsNullOrWhiteSpace(txtPassword.Text) Then
      MessageBox.Show("El campo no puede estar en blanco.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Return

    End If


  End Sub
End Class
