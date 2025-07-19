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
    Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
    dgvDoctores = New DataGridView()
    btnCrear = New Button()
    btnModificar = New Button()
    btnEliminar = New Button()
    btnRegresar = New Button()
    btnAsignarConsulta = New Button()
    GroupBox1 = New GroupBox()
    btnFiltrar = New Button()
    txtFilEspecialidad = New TextBox()
    txtFilApellido = New TextBox()
    txtFilNombre = New TextBox()
    Label1 = New Label()
    lblApellidoDoctor = New Label()
    lblNombreDoctor = New Label()
    CType(dgvDoctores, ComponentModel.ISupportInitialize).BeginInit()
    GroupBox1.SuspendLayout()
    SuspendLayout()
    ' 
    ' dgvDoctores
    ' 
    dgvDoctores.AllowUserToAddRows = False
    dgvDoctores.AllowUserToDeleteRows = False
    dgvDoctores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = SystemColors.Control
    DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
    dgvDoctores.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    dgvDoctores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvDoctores.Location = New Point(12, 155)
    dgvDoctores.MultiSelect = False
    dgvDoctores.Name = "dgvDoctores"
    dgvDoctores.ReadOnly = True
    dgvDoctores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvDoctores.Size = New Size(738, 269)
    dgvDoctores.TabIndex = 0
    ' 
    ' btnCrear
    ' 
    btnCrear.Location = New Point(11, 103)
    btnCrear.Name = "btnCrear"
    btnCrear.Size = New Size(72, 46)
    btnCrear.TabIndex = 1
    btnCrear.Text = "Crear"
    btnCrear.UseVisualStyleBackColor = True
    ' 
    ' btnModificar
    ' 
    btnModificar.Location = New Point(89, 103)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(72, 46)
    btnModificar.TabIndex = 2
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = True
    ' 
    ' btnEliminar
    ' 
    btnEliminar.Location = New Point(167, 103)
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
    btnRegresar.Location = New Point(638, 17)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(100, 46)
    btnRegresar.TabIndex = 4
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = False
    ' 
    ' btnAsignarConsulta
    ' 
    btnAsignarConsulta.Location = New Point(245, 103)
    btnAsignarConsulta.Name = "btnAsignarConsulta"
    btnAsignarConsulta.Size = New Size(113, 46)
    btnAsignarConsulta.TabIndex = 5
    btnAsignarConsulta.Text = "Asignar Consulta"
    btnAsignarConsulta.UseVisualStyleBackColor = True
    ' 
    ' GroupBox1
    ' 
    GroupBox1.Controls.Add(btnFiltrar)
    GroupBox1.Controls.Add(txtFilEspecialidad)
    GroupBox1.Controls.Add(txtFilApellido)
    GroupBox1.Controls.Add(txtFilNombre)
    GroupBox1.Controls.Add(Label1)
    GroupBox1.Controls.Add(lblApellidoDoctor)
    GroupBox1.Controls.Add(lblNombreDoctor)
    GroupBox1.Location = New Point(12, 9)
    GroupBox1.Name = "GroupBox1"
    GroupBox1.Size = New Size(620, 88)
    GroupBox1.TabIndex = 6
    GroupBox1.TabStop = False
    GroupBox1.Text = "Filtros"
    ' 
    ' btnFiltrar
    ' 
    btnFiltrar.Location = New Point(518, 51)
    btnFiltrar.Name = "btnFiltrar"
    btnFiltrar.Size = New Size(90, 30)
    btnFiltrar.TabIndex = 7
    btnFiltrar.Text = "Filtrar"
    btnFiltrar.UseVisualStyleBackColor = True
    ' 
    ' txtFilEspecialidad
    ' 
    txtFilEspecialidad.Location = New Point(395, 16)
    txtFilEspecialidad.Name = "txtFilEspecialidad"
    txtFilEspecialidad.Size = New Size(213, 23)
    txtFilEspecialidad.TabIndex = 5
    ' 
    ' txtFilApellido
    ' 
    txtFilApellido.Location = New Point(81, 51)
    txtFilApellido.Name = "txtFilApellido"
    txtFilApellido.Size = New Size(213, 23)
    txtFilApellido.TabIndex = 4
    ' 
    ' txtFilNombre
    ' 
    txtFilNombre.Location = New Point(81, 16)
    txtFilNombre.Name = "txtFilNombre"
    txtFilNombre.Size = New Size(213, 23)
    txtFilNombre.TabIndex = 3
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Location = New Point(314, 24)
    Label1.Name = "Label1"
    Label1.Size = New Size(75, 15)
    Label1.TabIndex = 2
    Label1.Text = "Especialidad:"
    ' 
    ' lblApellidoDoctor
    ' 
    lblApellidoDoctor.AutoSize = True
    lblApellidoDoctor.Location = New Point(21, 59)
    lblApellidoDoctor.Name = "lblApellidoDoctor"
    lblApellidoDoctor.Size = New Size(54, 15)
    lblApellidoDoctor.TabIndex = 1
    lblApellidoDoctor.Text = "Apellido:"
    ' 
    ' lblNombreDoctor
    ' 
    lblNombreDoctor.AutoSize = True
    lblNombreDoctor.Location = New Point(21, 24)
    lblNombreDoctor.Name = "lblNombreDoctor"
    lblNombreDoctor.Size = New Size(54, 15)
    lblNombreDoctor.TabIndex = 0
    lblNombreDoctor.Text = "Nombre:"
    ' 
    ' frmMantDoctores
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(762, 436)
    Controls.Add(GroupBox1)
    Controls.Add(btnAsignarConsulta)
    Controls.Add(btnRegresar)
    Controls.Add(btnEliminar)
    Controls.Add(btnModificar)
    Controls.Add(btnCrear)
    Controls.Add(dgvDoctores)
    MinimumSize = New Size(778, 475)
    Name = "frmMantDoctores"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Mantenimiento de Doctores"
    CType(dgvDoctores, ComponentModel.ISupportInitialize).EndInit()
    GroupBox1.ResumeLayout(False)
    GroupBox1.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents dgvDoctores As DataGridView
  Friend WithEvents btnCrear As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnAsignarConsulta As Button
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents btnFiltrar As Button
  Friend WithEvents txtFilEspecialidad As TextBox
  Friend WithEvents txtFilApellido As TextBox
  Friend WithEvents txtFilNombre As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents lblApellidoDoctor As Label
  Friend WithEvents lblNombreDoctor As Label
End Class
