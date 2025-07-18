<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspecialidades
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    components = New ComponentModel.Container()
    Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
    gpbEspeciadlidad = New GroupBox()
    lblEspecialidadAnt = New Label()
    lblIdSeleccionado = New Label()
    btnEliminar = New Button()
    btnModificar = New Button()
    btnInsertar = New Button()
    lblEspecialidad = New Label()
    txtEspecialidad = New TextBox()
    btnRegresar = New Button()
    dgvEspecialidades = New DataGridView()
    clId = New DataGridViewTextBoxColumn()
    clDescripcion = New DataGridViewTextBoxColumn()
    rrpError = New ErrorProvider(components)
    gpbEspeciadlidad.SuspendLayout()
    CType(dgvEspecialidades, ComponentModel.ISupportInitialize).BeginInit()
    CType(rrpError, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' gpbEspeciadlidad
    ' 
    gpbEspeciadlidad.Controls.Add(lblEspecialidadAnt)
    gpbEspeciadlidad.Controls.Add(lblIdSeleccionado)
    gpbEspeciadlidad.Controls.Add(btnEliminar)
    gpbEspeciadlidad.Controls.Add(btnModificar)
    gpbEspeciadlidad.Controls.Add(btnInsertar)
    gpbEspeciadlidad.Controls.Add(lblEspecialidad)
    gpbEspeciadlidad.Controls.Add(txtEspecialidad)
    gpbEspeciadlidad.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    gpbEspeciadlidad.Location = New Point(12, 12)
    gpbEspeciadlidad.Name = "gpbEspeciadlidad"
    gpbEspeciadlidad.Size = New Size(634, 192)
    gpbEspeciadlidad.TabIndex = 0
    gpbEspeciadlidad.TabStop = False
    gpbEspeciadlidad.Text = "Información"
    ' 
    ' lblEspecialidadAnt
    ' 
    lblEspecialidadAnt.AutoSize = True
    lblEspecialidadAnt.Location = New Point(579, 82)
    lblEspecialidadAnt.Name = "lblEspecialidadAnt"
    lblEspecialidadAnt.Size = New Size(42, 25)
    lblEspecialidadAnt.TabIndex = 6
    lblEspecialidadAnt.Text = "Esp"
    lblEspecialidadAnt.Visible = False
    ' 
    ' lblIdSeleccionado
    ' 
    lblIdSeleccionado.AutoSize = True
    lblIdSeleccionado.Location = New Point(579, 21)
    lblIdSeleccionado.Name = "lblIdSeleccionado"
    lblIdSeleccionado.Size = New Size(30, 25)
    lblIdSeleccionado.TabIndex = 5
    lblIdSeleccionado.Text = "Id"
    lblIdSeleccionado.Visible = False
    ' 
    ' btnEliminar
    ' 
    btnEliminar.Location = New Point(422, 112)
    btnEliminar.Name = "btnEliminar"
    btnEliminar.Size = New Size(151, 53)
    btnEliminar.TabIndex = 5
    btnEliminar.Text = "Eliminar"
    btnEliminar.UseVisualStyleBackColor = True
    ' 
    ' btnModificar
    ' 
    btnModificar.Location = New Point(219, 112)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(151, 53)
    btnModificar.TabIndex = 4
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = True
    ' 
    ' btnInsertar
    ' 
    btnInsertar.Location = New Point(30, 112)
    btnInsertar.Name = "btnInsertar"
    btnInsertar.Size = New Size(137, 53)
    btnInsertar.TabIndex = 3
    btnInsertar.Text = "Agregar"
    btnInsertar.UseVisualStyleBackColor = True
    ' 
    ' lblEspecialidad
    ' 
    lblEspecialidad.AutoSize = True
    lblEspecialidad.Location = New Point(30, 52)
    lblEspecialidad.Name = "lblEspecialidad"
    lblEspecialidad.Size = New Size(120, 25)
    lblEspecialidad.TabIndex = 2
    lblEspecialidad.Text = "Especialidad"
    ' 
    ' txtEspecialidad
    ' 
    txtEspecialidad.Location = New Point(156, 44)
    txtEspecialidad.Name = "txtEspecialidad"
    txtEspecialidad.Size = New Size(417, 33)
    txtEspecialidad.TabIndex = 1
    ' 
    ' btnRegresar
    ' 
    btnRegresar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnRegresar.Location = New Point(653, 25)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(124, 56)
    btnRegresar.TabIndex = 1
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = True
    ' 
    ' dgvEspecialidades
    ' 
    dgvEspecialidades.AllowUserToAddRows = False
    dgvEspecialidades.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = SystemColors.Control
    DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
    dgvEspecialidades.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvEspecialidades.Columns.AddRange(New DataGridViewColumn() {clId, clDescripcion})
    dgvEspecialidades.Location = New Point(12, 210)
    dgvEspecialidades.MultiSelect = False
    dgvEspecialidades.Name = "dgvEspecialidades"
    dgvEspecialidades.ReadOnly = True
    dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvEspecialidades.Size = New Size(634, 258)
    dgvEspecialidades.TabIndex = 4
    ' 
    ' clId
    ' 
    clId.DataPropertyName = "id"
    clId.HeaderText = "Identificador"
    clId.Name = "clId"
    clId.ReadOnly = True
    clId.Visible = False
    ' 
    ' clDescripcion
    ' 
    clDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clDescripcion.DataPropertyName = "descripcion"
    clDescripcion.HeaderText = "Especialidades"
    clDescripcion.Name = "clDescripcion"
    clDescripcion.ReadOnly = True
    ' 
    ' rrpError
    ' 
    rrpError.ContainerControl = Me
    ' 
    ' frmEspecialidades
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(789, 480)
    Controls.Add(dgvEspecialidades)
    Controls.Add(btnRegresar)
    Controls.Add(gpbEspeciadlidad)
    Name = "frmEspecialidades"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Mantenimiento de Especialidades"
    gpbEspeciadlidad.ResumeLayout(False)
    gpbEspeciadlidad.PerformLayout()
    CType(dgvEspecialidades, ComponentModel.ISupportInitialize).EndInit()
    CType(rrpError, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub
  Friend WithEvents gpbEspeciadlidad As GroupBox
  Friend WithEvents txtEspecialidad As TextBox
  Friend WithEvents lblEspecialidad As Label
  Friend WithEvents btnInsertar As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents dgvEspecialidades As DataGridView
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents lblIdSeleccionado As Label
  Friend WithEvents lblEspecialidadAnt As Label
  Friend WithEvents clId As DataGridViewTextBoxColumn
  Friend WithEvents clDescripcion As DataGridViewTextBoxColumn
  Friend WithEvents rrpError As ErrorProvider
End Class
