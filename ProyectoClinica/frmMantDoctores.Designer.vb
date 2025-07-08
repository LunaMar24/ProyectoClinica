<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantDoctores
  Inherits System.Windows.Forms.Form

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Requerido por el Diseñador de Windows Forms
  Private components As System.ComponentModel.IContainer

  'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
  'Se puede modificar usando el Diseñador de Windows Forms.  
  'No lo modifique con el editor de código.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    dgvDoctores = New DataGridView()
    btnCrear = New Button()
    btnModificar = New Button()
    btnEliminar = New Button()
    btnRegresar = New Button()
    btnAsignarConsulta = New Button()
    CType(dgvDoctores, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' dgvDoctores
    ' 
    dgvDoctores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvDoctores.Location = New Point(12, 64)
    dgvDoctores.Name = "dgvDoctores"
    dgvDoctores.Size = New Size(776, 362)
    dgvDoctores.TabIndex = 0
    ' 
    ' btnCrear
    ' 
    btnCrear.Location = New Point(12, 12)
    btnCrear.Name = "btnCrear"
    btnCrear.Size = New Size(72, 46)
    btnCrear.TabIndex = 1
    btnCrear.Text = "Crear"
    btnCrear.UseVisualStyleBackColor = True
    ' 
    ' btnModificar
    ' 
    btnModificar.Location = New Point(90, 12)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(72, 46)
    btnModificar.TabIndex = 2
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = True
    ' 
    ' btnEliminar
    ' 
    btnEliminar.Location = New Point(168, 12)
    btnEliminar.Name = "btnEliminar"
    btnEliminar.Size = New Size(72, 46)
    btnEliminar.TabIndex = 3
    btnEliminar.Text = "Eliminar"
    btnEliminar.UseVisualStyleBackColor = True
    ' 
    ' btnRegresar
    ' 
    btnRegresar.BackColor = Color.IndianRed
    btnRegresar.ForeColor = Color.White
    btnRegresar.Location = New Point(688, 12)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(100, 46)
    btnRegresar.TabIndex = 4
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = False
    ' 
    ' btnAsignarConsulta
    ' 
    btnAsignarConsulta.Location = New Point(246, 12)
    btnAsignarConsulta.Name = "btnAsignarConsulta"
    btnAsignarConsulta.Size = New Size(113, 46)
    btnAsignarConsulta.TabIndex = 5
    btnAsignarConsulta.Text = "Asignar Consulta"
    btnAsignarConsulta.UseVisualStyleBackColor = True
    ' 
    ' frmMantDoctores
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(800, 450)
    Controls.Add(btnAsignarConsulta)
    Controls.Add(btnRegresar)
    Controls.Add(btnEliminar)
    Controls.Add(btnModificar)
    Controls.Add(btnCrear)
    Controls.Add(dgvDoctores)
    Name = "frmMantDoctores"
    Text = "Mantenimiento de Doctores"
    CType(dgvDoctores, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents dgvDoctores As DataGridView
  Friend WithEvents btnCrear As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnAsignarConsulta As Button
End Class
