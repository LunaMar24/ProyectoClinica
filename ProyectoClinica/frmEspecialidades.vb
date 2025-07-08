Imports System.Runtime.InteropServices.JavaScript.JSType
Imports MySql.Data.MySqlClient

Public Class frmEspecialidades

  Private conexion As Conexion

  Private Sub frmEspecialidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    conexion = New Conexion

    CargarEspecialidades()
  End Sub

  Private Sub CargarEspecialidades()
    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT id, descripcion FROM especialidad"
      Dim adaptador = New MySqlDataAdapter(selectQuery, conn)
      Dim dt = New DataTable

      'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
      adaptador.Fill(dt)

      'La vista se va a llenar con lo que tenga la tabla que se llenó el adaptador
      dgvEspecialidades.DataSource = dt
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    frmDashboard.Show()
    Me.Close()
  End Sub

  Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
    Dim especialidad As String = txtEspecialidad.Text.Trim()

    If String.IsNullOrWhiteSpace(especialidad) Then
      MessageBox.Show("La especialidad no puede estar vacía. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If ExisteEspecialidad(especialidad) Then
      MessageBox.Show("La especialidad '" & especialidad & "' ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      Dim conn = conexion.Abrir()
      Dim insertQuery = "INSERT INTO especialidad (descripcion) VALUES (@descripcion)"
      Using command As New MySqlCommand(insertQuery, conn)
        ' Añadir parámetros para evitar inyección SQL
        command.Parameters.AddWithValue("@descripcion", especialidad)

        Dim rowsAffected = command.ExecuteNonQuery

        If rowsAffected > 0 Then
          MessageBox.Show("La especialidad '" & especialidad & "' se registró exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)

          CargarEspecialidades()
          ' Opcional: Limpiar los campos después de un registro exitoso
          txtEspecialidad.Clear()
          txtEspecialidad.Focus() ' Poner el foco en el campo especialidad

        Else
          MessageBox.Show("No se pudo registrar la especialidad. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
      End Using

    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar la especialidad: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Function ExisteEspecialidad(especialidad As String) As Boolean
    Dim valorRetorno As Boolean = False

    Try
      Dim conn = conexion.Abrir()
      Dim selectQuery = "SELECT id, descripcion FROM especialidad WHERE descripcion = @descripcion"
      Dim dt = New DataTable()
      Using command As New MySqlCommand(selectQuery, conn)
        ' Añadir parámetros para evitar inyección SQL
        command.Parameters.AddWithValue("@descripcion", especialidad)

        Dim adaptador = New MySqlDataAdapter(command)
        'El adaptador va a cargar el datatable con lo que se leyó de la base de datos
        adaptador.Fill(dt)
      End Using

      valorRetorno = dt.Rows.Count > 0
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

    Return valorRetorno
  End Function

  Private Sub dgvEspecialidades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEspecialidades.CellClick
    If e.RowIndex >= 0 Then
      Dim row = dgvEspecialidades.Rows(e.RowIndex)
      lblIdSeleccionado.Text = row.Cells("clId").Value
      lblEspecialidadAnt.Text = row.Cells("clDescripcion").Value
      txtEspecialidad.Text = row.Cells("clDescripcion").Value
    End If
  End Sub

  Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    Try
      Dim idSeleccionado As Integer

      If Integer.TryParse(lblIdSeleccionado.Text, idSeleccionado) Then
        Dim conn = conexion.Abrir()
        Dim deleteQuery = "DELETE FROM especialidad WHERE id = @Id"
        Dim dt = New DataTable()
        Using command As New MySqlCommand(deleteQuery, conn)
          ' Añadir parámetros para evitar inyección SQL
          command.Parameters.AddWithValue("@Id", idSeleccionado)
          Dim rowAffected = command.ExecuteNonQuery()
          If rowAffected >= 0 Then
            MessageBox.Show("Especialidad " & lblEspecialidadAnt.Text & " eliminada exitosamente.", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblIdSeleccionado.Text = ""
            lblEspecialidadAnt.Text = ""
            txtEspecialidad.Clear()
            txtEspecialidad.Focus()
            CargarEspecialidades()
          Else
            MessageBox.Show("La Especialidad " & lblEspecialidadAnt.Text & " no se pudo eliminar. Inténtelo de nuevo", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End Using
      Else
        MessageBox.Show("Por favor seleccione una especialidad para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al eliminar la especialidad. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
    Try
      Dim idSeleccionado As Integer

      If Integer.TryParse(lblIdSeleccionado.Text, idSeleccionado) Then

        If ExisteEspecialidad(txtEspecialidad.Text) Then
          MessageBox.Show("La especialidad '" & txtEspecialidad.Text & "' ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Return
        End If

        Dim conn = conexion.Abrir()
        Dim updateQuery = "UPDATE especialidad SET descripcion = @descripcion WHERE id = @Id"
        Dim dt = New DataTable()
        Using command As New MySqlCommand(updateQuery, conn)
          ' Añadir parámetros para evitar inyección SQL
          command.Parameters.AddWithValue("@descripcion", txtEspecialidad.Text)
          command.Parameters.AddWithValue("@Id", idSeleccionado)
          Dim rowAffected = command.ExecuteNonQuery()
          If rowAffected >= 0 Then
            MessageBox.Show("La especialidad " & lblEspecialidadAnt.Text & " fue modificada " & txtEspecialidad.Text & " exitosamente.", "Modificar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblIdSeleccionado.Text = ""
            lblEspecialidadAnt.Text = ""
            txtEspecialidad.Clear()
            txtEspecialidad.Focus()
            CargarEspecialidades()
          Else
            MessageBox.Show("La Especialidad " & lblEspecialidadAnt.Text & " no se pudo modificar. Inténtelo de nuevo", "Modificar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End Using
      Else
        MessageBox.Show("Por favor seleccione una especialidad para modificar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al modificar la especialidad. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub
End Class