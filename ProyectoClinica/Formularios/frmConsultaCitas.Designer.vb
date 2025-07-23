<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaCitas
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
    dgvConsultasPaciente = New DataGridView()
    btnCompletar = New Button()
    btnVerConsulta = New Button()
    btnRegresar = New Button()
    GroupBox1 = New GroupBox()
    cmbFiltPrioridad = New ComboBox()
    lblPrioridad = New Label()
    btnFiltrar = New Button()
    txtFilIdentificacion = New TextBox()
    txtFilApellido = New TextBox()
    txtFilNombre = New TextBox()
    lblIdentificacion = New Label()
    lblApellidoDoctor = New Label()
    lblNombreDoctor = New Label()
    chbVerCerradas = New CheckBox()
    CType(dgvConsultasPaciente, ComponentModel.ISupportInitialize).BeginInit()
    GroupBox1.SuspendLayout()
    SuspendLayout()
    ' 
    ' dgvConsultasPaciente
    ' 
    dgvConsultasPaciente.AllowUserToAddRows = False
    dgvConsultasPaciente.AllowUserToDeleteRows = False
    dgvConsultasPaciente.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = SystemColors.Control
    DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
    DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
    dgvConsultasPaciente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    dgvConsultasPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dgvConsultasPaciente.Location = New Point(12, 156)
    dgvConsultasPaciente.MultiSelect = False
    dgvConsultasPaciente.Name = "dgvConsultasPaciente"
    dgvConsultasPaciente.ReadOnly = True
    dgvConsultasPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvConsultasPaciente.Size = New Size(728, 296)
    dgvConsultasPaciente.TabIndex = 0
    ' 
    ' btnCompletar
    ' 
    btnCompletar.Location = New Point(10, 104)
    btnCompletar.Name = "btnCompletar"
    btnCompletar.Size = New Size(117, 46)
    btnCompletar.TabIndex = 1
    btnCompletar.Text = "Completar"
    btnCompletar.UseVisualStyleBackColor = True
    ' 
    ' btnVerConsulta
    ' 
    btnVerConsulta.Location = New Point(145, 104)
    btnVerConsulta.Name = "btnVerConsulta"
    btnVerConsulta.Size = New Size(118, 46)
    btnVerConsulta.TabIndex = 2
    btnVerConsulta.Text = "Ver Consulta"
    btnVerConsulta.UseVisualStyleBackColor = True
    ' 
    ' btnRegresar
    ' 
    btnRegresar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    btnRegresar.BackColor = Color.IndianRed
    btnRegresar.ForeColor = Color.White
    btnRegresar.Location = New Point(636, 18)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(100, 46)
    btnRegresar.TabIndex = 4
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = False
    ' 
    ' GroupBox1
    ' 
    GroupBox1.Controls.Add(cmbFiltPrioridad)
    GroupBox1.Controls.Add(lblPrioridad)
    GroupBox1.Controls.Add(btnFiltrar)
    GroupBox1.Controls.Add(txtFilIdentificacion)
    GroupBox1.Controls.Add(txtFilApellido)
    GroupBox1.Controls.Add(txtFilNombre)
    GroupBox1.Controls.Add(lblIdentificacion)
    GroupBox1.Controls.Add(lblApellidoDoctor)
    GroupBox1.Controls.Add(lblNombreDoctor)
    GroupBox1.Location = New Point(11, 12)
    GroupBox1.Name = "GroupBox1"
    GroupBox1.Size = New Size(620, 90)
    GroupBox1.TabIndex = 7
    GroupBox1.TabStop = False
    GroupBox1.Text = "Filtros"
    ' 
    ' cmbFiltPrioridad
    ' 
    cmbFiltPrioridad.FormattingEnabled = True
    cmbFiltPrioridad.Items.AddRange(New Object() {"Alta", "Media", "Baja"})
    cmbFiltPrioridad.Location = New Point(402, 51)
    cmbFiltPrioridad.Name = "cmbFiltPrioridad"
    cmbFiltPrioridad.Size = New Size(110, 23)
    cmbFiltPrioridad.TabIndex = 9
    ' 
    ' lblPrioridad
    ' 
    lblPrioridad.AutoSize = True
    lblPrioridad.Location = New Point(338, 59)
    lblPrioridad.Name = "lblPrioridad"
    lblPrioridad.Size = New Size(58, 15)
    lblPrioridad.TabIndex = 8
    lblPrioridad.Text = "Prioridad:"
    ' 
    ' btnFiltrar
    ' 
    btnFiltrar.Location = New Point(518, 48)
    btnFiltrar.Name = "btnFiltrar"
    btnFiltrar.Size = New Size(90, 30)
    btnFiltrar.TabIndex = 7
    btnFiltrar.Text = "Filtrar"
    btnFiltrar.UseVisualStyleBackColor = True
    ' 
    ' txtFilIdentificacion
    ' 
    txtFilIdentificacion.Location = New Point(402, 16)
    txtFilIdentificacion.Name = "txtFilIdentificacion"
    txtFilIdentificacion.Size = New Size(206, 23)
    txtFilIdentificacion.TabIndex = 5
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
    ' lblIdentificacion
    ' 
    lblIdentificacion.AutoSize = True
    lblIdentificacion.Location = New Point(314, 24)
    lblIdentificacion.Name = "lblIdentificacion"
    lblIdentificacion.Size = New Size(82, 15)
    lblIdentificacion.TabIndex = 2
    lblIdentificacion.Text = "Identificación:"
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
    ' chbVerCerradas
    ' 
    chbVerCerradas.AutoSize = True
    chbVerCerradas.Location = New Point(485, 119)
    chbVerCerradas.Name = "chbVerCerradas"
    chbVerCerradas.Size = New Size(146, 19)
    chbVerCerradas.TabIndex = 8
    chbVerCerradas.Text = "Ver Consultas Cerradas"
    chbVerCerradas.UseVisualStyleBackColor = True
    ' 
    ' frmConsultaCitas
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(752, 464)
    Controls.Add(chbVerCerradas)
    Controls.Add(GroupBox1)
    Controls.Add(btnRegresar)
    Controls.Add(btnVerConsulta)
    Controls.Add(btnCompletar)
    Controls.Add(dgvConsultasPaciente)
    MinimumSize = New Size(768, 503)
    Name = "frmConsultaCitas"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Control Citas"
    CType(dgvConsultasPaciente, ComponentModel.ISupportInitialize).EndInit()
    GroupBox1.ResumeLayout(False)
    GroupBox1.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents dgvConsultasPaciente As DataGridView
  Friend WithEvents btnCompletar As Button
  Friend WithEvents btnVerConsulta As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents lblPrioridad As Label
  Friend WithEvents btnFiltrar As Button
  Friend WithEvents txtFilIdentificacion As TextBox
  Friend WithEvents txtFilApellido As TextBox
  Friend WithEvents txtFilNombre As TextBox
  Friend WithEvents lblIdentificacion As Label
  Friend WithEvents lblApellidoDoctor As Label
  Friend WithEvents lblNombreDoctor As Label
  Friend WithEvents cmbFiltPrioridad As ComboBox
  Friend WithEvents chbVerCerradas As CheckBox
End Class
