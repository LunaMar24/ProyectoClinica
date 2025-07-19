<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaCitasDoctor
  Inherits System.Windows.Forms.Form

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    DataGridView1 = New DataGridView()
    btnCrear = New Button()
    btnModificar = New Button()
    btnEliminar = New Button()
    btnRegresar = New Button()
    CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' DataGridView1
    ' 
    DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridView1.Location = New Point(12, 64)
    DataGridView1.Name = "DataGridView1"
    DataGridView1.Size = New Size(776, 362)
    DataGridView1.TabIndex = 0
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
    ' frmDoctores
    ' 
    AutoScaleDimensions = New SizeF(7.0F, 15.0F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(800, 450)
    Controls.Add(btnRegresar)
    Controls.Add(btnEliminar)
    Controls.Add(btnModificar)
    Controls.Add(btnCrear)
    Controls.Add(DataGridView1)
    Name = "frmDoctores"
    Text = "Mantenimiento de Doctores"
    CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents DataGridView1 As DataGridView
  Friend WithEvents btnCrear As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnRegresar As Button
End Class
