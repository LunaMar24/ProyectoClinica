<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReporte
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
    btnEnviarExcel = New Button()
    btnRegresar = New Button()
    btnRefrescar = New Button()
    CType(dgvConsultasPaciente, ComponentModel.ISupportInitialize).BeginInit()
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
    dgvConsultasPaciente.Location = New Point(12, 70)
    dgvConsultasPaciente.MultiSelect = False
    dgvConsultasPaciente.Name = "dgvConsultasPaciente"
    dgvConsultasPaciente.ReadOnly = True
    dgvConsultasPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    dgvConsultasPaciente.Size = New Size(728, 382)
    dgvConsultasPaciente.TabIndex = 0
    ' 
    ' btnEnviarExcel
    ' 
    btnEnviarExcel.Location = New Point(12, 18)
    btnEnviarExcel.Name = "btnEnviarExcel"
    btnEnviarExcel.Size = New Size(117, 46)
    btnEnviarExcel.TabIndex = 1
    btnEnviarExcel.Text = "Enviar A Excel"
    btnEnviarExcel.UseVisualStyleBackColor = True
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
    ' btnRefrescar
    ' 
    btnRefrescar.Location = New Point(135, 18)
    btnRefrescar.Name = "btnRefrescar"
    btnRefrescar.Size = New Size(117, 46)
    btnRefrescar.TabIndex = 5
    btnRefrescar.Text = "Refrescar"
    btnRefrescar.UseVisualStyleBackColor = True
    ' 
    ' frmReporte
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(752, 464)
    Controls.Add(btnRefrescar)
    Controls.Add(btnRegresar)
    Controls.Add(btnEnviarExcel)
    Controls.Add(dgvConsultasPaciente)
    MinimumSize = New Size(768, 503)
    Name = "frmReporte"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Reporte de Citas"
    CType(dgvConsultasPaciente, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents dgvConsultasPaciente As DataGridView
  Friend WithEvents btnEnviarExcel As Button
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnRefrescar As Button
End Class
