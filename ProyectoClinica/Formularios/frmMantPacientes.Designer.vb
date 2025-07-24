<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMantPacientes
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
    Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
    dgvPacientes = New DataGridView()
    btnCrear = New Button()
    btnModificar = New Button()
    btnEliminar = New Button()
    btnRegresar = New Button()
    grbFiltros = New GroupBox()
    btnFiltrar = New Button()
    txtFilCedula = New TextBox()
    txtFilApellido = New TextBox()
    txtFilNombre = New TextBox()
    lblFilCedula = New Label()
    lblApellidoDoctor = New Label()
    lblNombreDoctor = New Label()
    btnVerConsultas = New Button()
    CType(dgvPacientes, ComponentModel.ISupportInitialize).BeginInit()
    grbFiltros.SuspendLayout()
    SuspendLayout()
    ' 
    ' dgvPacientes
    ' 
    dgvPacientes.AllowUserToAddRows = False
    dgvPacientes.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = SystemColors.Control
    DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
    dgvPacientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvPacientes.Location = New Point(0, 155)
    dgvPacientes.MultiSelect = False
    dgvPacientes.Name = "dgvPacientes"
    dgvPacientes.ReadOnly = True
    dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvPacientes.Size = New Size(762, 281)
    dgvPacientes.TabIndex = 0
    ' 
    ' btnCrear
    ' 
    btnCrear.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnCrear.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnCrear.FlatStyle = FlatStyle.Flat
    btnCrear.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnCrear.ForeColor = Color.White
    btnCrear.Location = New Point(12, 103)
    btnCrear.Name = "btnCrear"
    btnCrear.Size = New Size(72, 46)
    btnCrear.TabIndex = 1
    btnCrear.Text = "Crear"
    btnCrear.UseVisualStyleBackColor = False
    ' 
    ' btnModificar
    ' 
    btnModificar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnModificar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnModificar.FlatStyle = FlatStyle.Flat
    btnModificar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnModificar.ForeColor = Color.White
    btnModificar.Location = New Point(90, 103)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(72, 46)
    btnModificar.TabIndex = 2
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = False
    ' 
    ' btnEliminar
    ' 
    btnEliminar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnEliminar.FlatStyle = FlatStyle.Flat
    btnEliminar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnEliminar.ForeColor = Color.White
    btnEliminar.Location = New Point(168, 103)
    btnEliminar.Name = "btnEliminar"
    btnEliminar.Size = New Size(72, 46)
    btnEliminar.TabIndex = 3
    btnEliminar.Text = "Eliminar"
    btnEliminar.UseVisualStyleBackColor = False
    ' 
    ' btnRegresar
    ' 
    btnRegresar.BackColor = Color.IndianRed
    btnRegresar.FlatStyle = FlatStyle.Flat
    btnRegresar.ForeColor = Color.White
    btnRegresar.Location = New Point(638, 17)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(100, 46)
    btnRegresar.TabIndex = 4
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = False
    ' 
    ' grbFiltros
    ' 
    grbFiltros.BackColor = Color.Transparent
    grbFiltros.Controls.Add(btnFiltrar)
    grbFiltros.Controls.Add(txtFilCedula)
    grbFiltros.Controls.Add(txtFilApellido)
    grbFiltros.Controls.Add(txtFilNombre)
    grbFiltros.Controls.Add(lblFilCedula)
    grbFiltros.Controls.Add(lblApellidoDoctor)
    grbFiltros.Controls.Add(lblNombreDoctor)
    grbFiltros.Location = New Point(12, 9)
    grbFiltros.Name = "grbFiltros"
    grbFiltros.Size = New Size(620, 88)
    grbFiltros.TabIndex = 7
    grbFiltros.TabStop = False
    grbFiltros.Text = "Filtros"
    ' 
    ' btnFiltrar
    ' 
    btnFiltrar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnFiltrar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnFiltrar.FlatStyle = FlatStyle.Flat
    btnFiltrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnFiltrar.ForeColor = Color.White
    btnFiltrar.Location = New Point(518, 51)
    btnFiltrar.Name = "btnFiltrar"
    btnFiltrar.Size = New Size(90, 30)
    btnFiltrar.TabIndex = 7
    btnFiltrar.Text = "Filtrar"
    btnFiltrar.UseVisualStyleBackColor = False
    ' 
    ' txtFilCedula
    ' 
    txtFilCedula.Location = New Point(395, 16)
    txtFilCedula.Name = "txtFilCedula"
    txtFilCedula.Size = New Size(213, 23)
    txtFilCedula.TabIndex = 5
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
    ' lblFilCedula
    ' 
    lblFilCedula.AutoSize = True
    lblFilCedula.Location = New Point(342, 24)
    lblFilCedula.Name = "lblFilCedula"
    lblFilCedula.Size = New Size(47, 15)
    lblFilCedula.TabIndex = 2
    lblFilCedula.Text = "Cédula:"
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
    ' btnVerConsultas
    ' 
    btnVerConsultas.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnVerConsultas.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnVerConsultas.FlatStyle = FlatStyle.Flat
    btnVerConsultas.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnVerConsultas.ForeColor = Color.White
    btnVerConsultas.Location = New Point(260, 103)
    btnVerConsultas.Name = "btnVerConsultas"
    btnVerConsultas.Size = New Size(99, 46)
    btnVerConsultas.TabIndex = 8
    btnVerConsultas.Text = "Ver Consultas"
    btnVerConsultas.UseVisualStyleBackColor = False
    ' 
    ' frmMantPacientes
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(762, 436)
    Controls.Add(btnVerConsultas)
    Controls.Add(grbFiltros)
    Controls.Add(btnRegresar)
    Controls.Add(btnEliminar)
    Controls.Add(btnModificar)
    Controls.Add(btnCrear)
    Controls.Add(dgvPacientes)
    MinimumSize = New Size(778, 475)
    Name = "frmMantPacientes"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Mantenimiento de Pacientes"
    CType(dgvPacientes, ComponentModel.ISupportInitialize).EndInit()
    grbFiltros.ResumeLayout(False)
    grbFiltros.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents dgvPacientes As DataGridView
  Friend WithEvents btnCrear As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents grbFiltros As GroupBox
  Friend WithEvents btnFiltrar As Button
  Friend WithEvents txtFilCedula As TextBox
  Friend WithEvents txtFilApellido As TextBox
  Friend WithEvents txtFilNombre As TextBox
  Friend WithEvents lblFilCedula As Label
  Friend WithEvents lblApellidoDoctor As Label
  Friend WithEvents lblNombreDoctor As Label
  Friend WithEvents btnVerConsultas As Button
End Class
