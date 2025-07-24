﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
    Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
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
    btnCambiarClave = New Button()
    CType(dgvUsuarios, ComponentModel.ISupportInitialize).BeginInit()
    grpFiltros.SuspendLayout()
    SuspendLayout()
    ' 
    ' dgvUsuarios
    ' 
    dgvUsuarios.AllowUserToAddRows = False
    dgvUsuarios.AllowUserToDeleteRows = False
    dgvUsuarios.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = SystemColors.Control
    DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
    dgvUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
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
    clID.DataPropertyName = "Id"
    clID.HeaderText = "ID"
    clID.Name = "clID"
    clID.ReadOnly = True
    clID.Visible = False
    ' 
    ' clNombre
    ' 
    clNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clNombre.DataPropertyName = "NombreUsuario"
    clNombre.HeaderText = "Nombre Usuario"
    clNombre.Name = "clNombre"
    clNombre.ReadOnly = True
    ' 
    ' clCodigoUsuario
    ' 
    clCodigoUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clCodigoUsuario.DataPropertyName = "CodigoUsuario"
    clCodigoUsuario.HeaderText = "Código Usuario"
    clCodigoUsuario.Name = "clCodigoUsuario"
    clCodigoUsuario.ReadOnly = True
    ' 
    ' clTipoUsuario
    ' 
    clTipoUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    clTipoUsuario.DataPropertyName = "TipoUsuario"
    clTipoUsuario.HeaderText = "Tipo Usuario"
    clTipoUsuario.Name = "clTipoUsuario"
    clTipoUsuario.ReadOnly = True
    ' 
    ' btnCrear
    ' 
    btnCrear.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnCrear.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnCrear.FlatStyle = FlatStyle.Flat
    btnCrear.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnCrear.ForeColor = Color.White
    btnCrear.Location = New Point(11, 101)
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
    btnModificar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnModificar.ForeColor = Color.White
    btnModificar.Location = New Point(89, 101)
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
    btnEliminar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnEliminar.ForeColor = Color.White
    btnEliminar.Location = New Point(167, 101)
    btnEliminar.Name = "btnEliminar"
    btnEliminar.Size = New Size(72, 46)
    btnEliminar.TabIndex = 3
    btnEliminar.Text = "Eliminar"
    btnEliminar.UseVisualStyleBackColor = False
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
    grpFiltros.BackColor = Color.Transparent
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
    cmbFilTipoUsuario.Font = New Font("Segoe UI", 9.0F)
    cmbFilTipoUsuario.FormattingEnabled = True
    cmbFilTipoUsuario.Items.AddRange(New Object() {"Administrador", "Paciente", "Doctor", "Secretaria"})
    cmbFilTipoUsuario.Location = New Point(88, 51)
    cmbFilTipoUsuario.Name = "cmbFilTipoUsuario"
    cmbFilTipoUsuario.Size = New Size(213, 23)
    cmbFilTipoUsuario.TabIndex = 8
    ' 
    ' btnFiltrar
    ' 
    btnFiltrar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnFiltrar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnFiltrar.FlatStyle = FlatStyle.Flat
    btnFiltrar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnFiltrar.ForeColor = Color.White
    btnFiltrar.Location = New Point(518, 51)
    btnFiltrar.Name = "btnFiltrar"
    btnFiltrar.Size = New Size(90, 30)
    btnFiltrar.TabIndex = 7
    btnFiltrar.Text = "Filtrar"
    btnFiltrar.UseVisualStyleBackColor = False
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
    lblTipoUsuario.Size = New Size(77, 15)
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
    ' btnCambiarClave
    ' 
    btnCambiarClave.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnCambiarClave.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnCambiarClave.FlatStyle = FlatStyle.Flat
    btnCambiarClave.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnCambiarClave.ForeColor = Color.White
    btnCambiarClave.Location = New Point(245, 102)
    btnCambiarClave.Name = "btnCambiarClave"
    btnCambiarClave.Size = New Size(72, 46)
    btnCambiarClave.TabIndex = 8
    btnCambiarClave.Text = "Cambiar Clave"
    btnCambiarClave.UseVisualStyleBackColor = False
    ' 
    ' frmMantUsuarios
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(762, 436)
    Controls.Add(btnCambiarClave)
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
  Friend WithEvents btnCambiarClave As Button
  Friend WithEvents clID As DataGridViewTextBoxColumn
  Friend WithEvents clNombre As DataGridViewTextBoxColumn
  Friend WithEvents clCodigoUsuario As DataGridViewTextBoxColumn
  Friend WithEvents clTipoUsuario As DataGridViewTextBoxColumn
End Class
