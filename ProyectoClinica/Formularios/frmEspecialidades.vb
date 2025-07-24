Public Class frmEspecialidades
  Implements IFormularios

  Public Sub AjustarPantalla() Implements IFormularios.AjustarPantalla
    CargarEspecialidades()
  End Sub

  Private Sub CargarEspecialidades()
    Try
      Dim dbEspecialidad As New EspecialidadDAO()
      Dim listaEspecialidades As List(Of Especialidad) = dbEspecialidad.GetAll()
      dbEspecialidad.Dispose()
      dgvEspecialidades.DataSource = listaEspecialidades
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al cargar las especialidades. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub

  Private Sub data_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEspecialidad.Validating
    Dim campo = CType(sender, Control)

    If campo.Text.Length = 0 Then
      rrpError.SetError(campo, "Este dato es obligatorio. Por favor ingrese un valor.")
    Else
      rrpError.SetError(campo, "")
    End If
  End Sub

  Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
    PantallaManager.RegresarDesdeFormularioHijo()
  End Sub

  Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
    Dim especialidad As String = txtEspecialidad.Text.Trim()

    If Not ValidateChildren() Then
      Return
    End If

    If String.IsNullOrWhiteSpace(especialidad) Then
      MessageBox.Show("La especialidad no puede estar vacía. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    If ExisteEspecialidad(especialidad) Then
      MessageBox.Show("La especialidad '" & especialidad & "' ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    Try
      Dim dbEspecialidad As New EspecialidadDAO()
      Dim especialidadData As New Especialidad With {
        .Descripcion = especialidad
      }

      Dim rowsAffected = dbEspecialidad.Insert(especialidadData)
      dbEspecialidad.Dispose()

      If rowsAffected > 0 Then
        MessageBox.Show("La especialidad '" & especialidad & "' se registró exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CargarEspecialidades()
        ' Opcional: Limpiar los campos después de un registro exitoso
        txtEspecialidad.Clear()
        txtEspecialidad.Focus() ' Poner el foco en el campo especialidad
      Else
        MessageBox.Show("No se pudo registrar la especialidad. Inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
    Catch ex As Exception
      MessageBox.Show("Error de base de datos al registrar la especialidad: " & ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Function ExisteEspecialidad(especialidad As String) As Boolean
    Dim valorRetorno As Boolean = False

    Try
      Dim dboEspecialidad As New EspecialidadDAO()
      Dim filtros As New Dictionary(Of String, Object) From {
            {"Descripcion", especialidad}
        }
      Dim especialidades As List(Of Especialidad) = dboEspecialidad.GetAll(filtros)
      dboEspecialidad.Dispose()

      valorRetorno = especialidades.Count > 0
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
        If MessageBox.Show("¿Está seguro de que desea eliminar la especialidad '" & lblEspecialidadAnt.Text & "'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
          Return
        End If

        Dim dboEspecialidad As New EspecialidadDAO()
        Dim rowAffected = dboEspecialidad.Delete(idSeleccionado)
        dboEspecialidad.Dispose()

        If rowAffected > 0 Then
          MessageBox.Show("Especialidad '" & lblEspecialidadAnt.Text & "' eliminada exitosamente.", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
          lblIdSeleccionado.Text = ""
          lblEspecialidadAnt.Text = ""
          txtEspecialidad.Clear()
          txtEspecialidad.Focus()
          CargarEspecialidades()
        Else
          MessageBox.Show("La Especialidad " & lblEspecialidadAnt.Text & " no se pudo eliminar. Inténtelo de nuevo", "Eliminar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
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
        If String.IsNullOrWhiteSpace(txtEspecialidad.Text) Then
          MessageBox.Show("La especialidad no puede estar vacía. Por favor verifique y vuelva a intentarlo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Return
        End If

        If ExisteEspecialidad(txtEspecialidad.Text) Then
          MessageBox.Show("La especialidad '" & txtEspecialidad.Text & "' ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Return
        End If

        Dim dboEspecialidad As New EspecialidadDAO()
        Dim especialidadData As New Especialidad With {
          .Id = idSeleccionado,
          .Descripcion = txtEspecialidad.Text.Trim()
        }
        Dim rowAffected = dboEspecialidad.Update(especialidadData)
        dboEspecialidad.Dispose()

        If rowAffected > 0 Then
          MessageBox.Show("La especialidad '" & lblEspecialidadAnt.Text & "' fue modificada a '" & txtEspecialidad.Text & "' exitosamente.", "Modificar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
          lblIdSeleccionado.Text = ""
          lblEspecialidadAnt.Text = ""
          txtEspecialidad.Clear()
          txtEspecialidad.Focus()
          CargarEspecialidades()
        Else
          MessageBox.Show("La Especialidad " & lblEspecialidadAnt.Text & " no se pudo modificar. Inténtelo de nuevo", "Modificar Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
      Else
        MessageBox.Show("Por favor seleccione una especialidad para modificar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
    Catch ex As Exception
      MessageBox.Show("Se presentó un error al modificar la especialidad. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
  End Sub


End Class