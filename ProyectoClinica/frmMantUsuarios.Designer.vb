<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMantUsuarios
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
    Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
    dgvUsuarios = New DataGridView()
    clID = New DataGridViewTextBoxColumn()
    clNombre = New DataGridViewTextBoxColumn()
    clCodigoUsuario = New DataGridViewTextBoxColumn()
    clTipoUsuario = New DataGridViewTextBoxColumn()
    btnCrear = New Button()
    btnModificar = New Button()
    btnEliminar = New Button()
    btnRegresar = New Button()
    grpFiltros = New GroupBox()
    cmbFilTipoUsuario = New ComboBox()
    btnFiltrar = New Button()
    txtFilCodigo = New TextBox()
    lblCodigoUsuario = New Label()
    lblTipoUsuario = New Label()
    lblNombre = New Label()
    txtFilNombre = New TextBox()
    CType(dgvUsuarios, ComponentModel.ISupportInitialize).BeginInit()
    grpFiltros.SuspendLayout()
    SuspendLayout()
    ' 
    ' dgvUsuarios
    ' 
    dgvUsuarios.AllowUserToAddRows = False
    dgvUsuarios.AllowUserToDeleteRows = False
    dgvUsuarios.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = SystemColors.Control
    DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
    dgvUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
    dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvUsuarios.Columns.AddRange(New DataGridViewColumn() {clID, clNombre, clCodigoUsuario, clTipoUsuario})
    dgvUsuarios.Location = New Point(12, 153)
    dgvUsuarios.MultiSelect = False
    dgvUsuarios.Name = "dgvUsuarios"
    dgvUsuarios.ReadOnly = True
    dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvUsuarios.Size = New Size(738, 271)
    dgvUsuarios.TabIndex = 0
    ' 
    ' clID
    ' 
    clID.DataPropertyName = "ID"
    clID.HeaderText = "ID"
    clID.Name = "clID"
    clID.ReadOnly = True
    clID.Visible = False
    ' 
    ' clNombre
    ' 
    clNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clNombre.DataPropertyName = "NOMBRE_USUARIO"
    clNombre.HeaderText = "Nombre Usuario"
    clNombre.Name = "clNombre"
    clNombre.ReadOnly = True
    ' 
    ' clCodigoUsuario
    ' 
    clCodigoUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clCodigoUsuario.DataPropertyName = "CODIGO_USUARIO"
    clCodigoUsuario.HeaderText = "Código Usuario"
    clCodigoUsuario.Name = "clCodigoUsuario"
    clCodigoUsuario.ReadOnly = True
    ' 
    ' clTipoUsuario
    ' 
    clTipoUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clTipoUsuario.DataPropertyName = "TIPO_USUARIO"
    clTipoUsuario.HeaderText = "Tipo Usuario"
    clTipoUsuario.Name = "clTipoUsuario"
    clTipoUsuario.ReadOnly = True
    ' 
    ' btnCrear
    ' 
    btnCrear.Location = New Point(11, 101)
    btnCrear.Name = "btnCrear"
    btnCrear.Size = New Size(72, 46)
    btnCrear.TabIndex = 1
    btnCrear.Text = "Crear"
    btnCrear.UseVisualStyleBackColor = True
    ' 
    ' btnModificar
    ' 
    btnModificar.Location = New Point(89, 101)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(72, 46)
    btnModificar.TabIndex = 2
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = True
    ' 
    ' btnEliminar
    ' 
    btnEliminar.Location = New Point(167, 101)
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
    ' grpFiltros
    ' 
    grpFiltros.Controls.Add(cmbFilTipoUsuario)
    grpFiltros.Controls.Add(btnFiltrar)
    grpFiltros.Controls.Add(txtFilCodigo)
    grpFiltros.Controls.Add(lblCodigoUsuario)
    grpFiltros.Controls.Add(lblTipoUsuario)
    grpFiltros.Controls.Add(lblNombre)
    grpFiltros.Controls.Add(txtFilNombre)
    grpFiltros.Location = New Point(11, 8)
    grpFiltros.Name = "grpFiltros"
    grpFiltros.Size = New Size(620, 88)
    grpFiltros.TabIndex = 7
    grpFiltros.TabStop = False
    grpFiltros.Text = "Filtros"
    ' 
    ' cmbFilTipoUsuario
    ' 
    cmbFilTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList
    cmbFilTipoUsuario.Font = New Font("Segoe UI", 9F)
    cmbFilTipoUsuario.FormattingEnabled = True
    cmbFilTipoUsuario.Items.AddRange(New Object() {"Administrador", "Paciente", "Doctor", "Secretaria"})
    cmbFilTipoUsuario.Location = New Point(88, 51)
    cmbFilTipoUsuario.Name = "cmbFilTipoUsuario"
    cmbFilTipoUsuario.Size = New Size(213, 23)
    cmbFilTipoUsuario.TabIndex = 8
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
    ' txtFilCodigo
    ' 
    txtFilCodigo.Location = New Point(369, 16)
    txtFilCodigo.Name = "txtFilCodigo"
    txtFilCodigo.Size = New Size(239, 23)
    txtFilCodigo.TabIndex = 5
    ' 
    ' lblCodigoUsuario
    ' 
    lblCodigoUsuario.AutoSize = True
    lblCodigoUsuario.Location = New Point(314, 24)
    lblCodigoUsuario.Name = "lblCodigoUsuario"
    lblCodigoUsuario.Size = New Size(49, 15)
    lblCodigoUsuario.TabIndex = 2
    lblCodigoUsuario.Text = "Código:"
    ' 
    ' lblTipoUsuario
    ' 
    lblTipoUsuario.AutoSize = True
    lblTipoUsuario.Location = New Point(6, 59)
    lblTipoUsuario.Name = "lblTipoUsuario"
    lblTipoUsuario.Size = New Size(76, 15)
    lblTipoUsuario.TabIndex = 1
    lblTipoUsuario.Text = "Tipo Usuario:"
    ' 
    ' lblNombre
    ' 
    lblNombre.AutoSize = True
    lblNombre.Location = New Point(28, 24)
    lblNombre.Name = "lblNombre"
    lblNombre.Size = New Size(54, 15)
    lblNombre.TabIndex = 0
    lblNombre.Text = "Nombre:"
    ' 
    ' txtFilNombre
    ' 
    txtFilNombre.Location = New Point(88, 16)
    txtFilNombre.Name = "txtFilNombre"
    txtFilNombre.Size = New Size(213, 23)
    txtFilNombre.TabIndex = 3
    ' 
    ' frmMantUsuarios
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(762, 436)
    Controls.Add(grpFiltros)
    Controls.Add(btnRegresar)
    Controls.Add(btnEliminar)
    Controls.Add(btnModificar)
    Controls.Add(btnCrear)
    Controls.Add(dgvUsuarios)
    MinimumSize = New Size(778, 475)
    Name = "frmMantUsuarios"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Mantenimiento de Usuarios"
    CType(dgvUsuarios, ComponentModel.ISupportInitialize).EndInit()
    grpFiltros.ResumeLayout(False)
    grpFiltros.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents dgvUsuarios As DataGridView
  Friend WithEvents btnCrear As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents btnEliminar As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents grpFiltros As GroupBox
  Friend WithEvents btnFiltrar As Button
  Friend WithEvents txtFilCodigo As TextBox
  Friend WithEvents txtFilNombre As TextBox
  Friend WithEvents lblCodigoUsuario As Label
  Friend WithEvents lblTipoUsuario As Label
  Friend WithEvents lblNombre As Label
  Friend WithEvents cmbFilTipoUsuario As ComboBox
  Friend WithEvents clID As DataGridViewTextBoxColumn
  Friend WithEvents clNombre As DataGridViewTextBoxColumn
  Friend WithEvents clCodigoUsuario As DataGridViewTextBoxColumn
  Friend WithEvents clTipoUsuario As DataGridViewTextBoxColumn
End Class
