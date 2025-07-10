<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarConsulta
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
    components = New ComponentModel.Container()
    grbDoctor = New GroupBox()
    lblInfoEspecialidad = New Label()
    lblEspecialidad = New Label()
    lblInfoDoctor = New Label()
    lblDoctor = New Label()
    grbPaciente = New GroupBox()
    cmbPrioridad = New ComboBox()
    lblPrioridad = New Label()
    lblInfoPaciente = New Label()
    txtIdentificacionPaciente = New TextBox()
    lblNombrePaciente = New Label()
    lblPaciente = New Label()
    btnAsignar = New Button()
    btnCancelar = New Button()
    errProv = New ErrorProvider(components)
    tlpToolTip = New ToolTip(components)
    grbDoctor.SuspendLayout()
    grbPaciente.SuspendLayout()
    CType(errProv, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' grbDoctor
    ' 
    grbDoctor.Controls.Add(lblInfoEspecialidad)
    grbDoctor.Controls.Add(lblEspecialidad)
    grbDoctor.Controls.Add(lblInfoDoctor)
    grbDoctor.Controls.Add(lblDoctor)
    grbDoctor.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    grbDoctor.Location = New Point(12, 12)
    grbDoctor.Name = "grbDoctor"
    grbDoctor.Size = New Size(433, 113)
    grbDoctor.TabIndex = 0
    grbDoctor.TabStop = False
    grbDoctor.Text = "Información Doctor"
    ' 
    ' lblInfoEspecialidad
    ' 
    lblInfoEspecialidad.Font = New Font("Segoe UI", 14.25F)
    lblInfoEspecialidad.Location = New Point(145, 66)
    lblInfoEspecialidad.Name = "lblInfoEspecialidad"
    lblInfoEspecialidad.Size = New Size(254, 25)
    lblInfoEspecialidad.TabIndex = 3
    lblInfoEspecialidad.Text = "Urologia"
    ' 
    ' lblEspecialidad
    ' 
    lblEspecialidad.AutoSize = True
    lblEspecialidad.Location = New Point(14, 66)
    lblEspecialidad.Name = "lblEspecialidad"
    lblEspecialidad.Size = New Size(125, 25)
    lblEspecialidad.TabIndex = 2
    lblEspecialidad.Text = "Especialidad:"
    ' 
    ' lblInfoDoctor
    ' 
    lblInfoDoctor.Font = New Font("Segoe UI", 14.25F)
    lblInfoDoctor.Location = New Point(145, 30)
    lblInfoDoctor.Name = "lblInfoDoctor"
    lblInfoDoctor.Size = New Size(254, 25)
    lblInfoDoctor.TabIndex = 1
    lblInfoDoctor.Text = "Eladio Valverde"
    ' 
    ' lblDoctor
    ' 
    lblDoctor.AutoSize = True
    lblDoctor.Location = New Point(59, 30)
    lblDoctor.Name = "lblDoctor"
    lblDoctor.Size = New Size(80, 25)
    lblDoctor.TabIndex = 0
    lblDoctor.Text = "Doctor:"
    ' 
    ' grbPaciente
    ' 
    grbPaciente.Controls.Add(cmbPrioridad)
    grbPaciente.Controls.Add(lblPrioridad)
    grbPaciente.Controls.Add(lblInfoPaciente)
    grbPaciente.Controls.Add(txtIdentificacionPaciente)
    grbPaciente.Controls.Add(lblNombrePaciente)
    grbPaciente.Controls.Add(lblPaciente)
    grbPaciente.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    grbPaciente.Location = New Point(12, 131)
    grbPaciente.Name = "grbPaciente"
    grbPaciente.Size = New Size(433, 155)
    grbPaciente.TabIndex = 1
    grbPaciente.TabStop = False
    grbPaciente.Text = "Información Paciente"
    ' 
    ' cmbPrioridad
    ' 
    cmbPrioridad.Font = New Font("Segoe UI", 14.25F)
    cmbPrioridad.FormattingEnabled = True
    cmbPrioridad.Items.AddRange(New Object() {"Alta", "Media", "Baja"})
    cmbPrioridad.Location = New Point(145, 110)
    cmbPrioridad.Name = "cmbPrioridad"
    cmbPrioridad.Size = New Size(178, 33)
    cmbPrioridad.TabIndex = 6
    ' 
    ' lblPrioridad
    ' 
    lblPrioridad.AutoSize = True
    lblPrioridad.Location = New Point(38, 118)
    lblPrioridad.Name = "lblPrioridad"
    lblPrioridad.Size = New Size(101, 25)
    lblPrioridad.TabIndex = 5
    lblPrioridad.Text = "Prioridad:"
    ' 
    ' lblInfoPaciente
    ' 
    lblInfoPaciente.Font = New Font("Segoe UI", 14.25F)
    lblInfoPaciente.Location = New Point(145, 76)
    lblInfoPaciente.Name = "lblInfoPaciente"
    lblInfoPaciente.Size = New Size(254, 25)
    lblInfoPaciente.TabIndex = 4
    ' 
    ' txtIdentificacionPaciente
    ' 
    txtIdentificacionPaciente.Font = New Font("Segoe UI", 14.25F)
    txtIdentificacionPaciente.Location = New Point(145, 32)
    txtIdentificacionPaciente.Name = "txtIdentificacionPaciente"
    txtIdentificacionPaciente.Size = New Size(254, 33)
    txtIdentificacionPaciente.TabIndex = 3
    ' 
    ' lblNombrePaciente
    ' 
    lblNombrePaciente.AutoSize = True
    lblNombrePaciente.Location = New Point(48, 76)
    lblNombrePaciente.Name = "lblNombrePaciente"
    lblNombrePaciente.Size = New Size(91, 25)
    lblNombrePaciente.TabIndex = 2
    lblNombrePaciente.Text = "Nombre:"
    ' 
    ' lblPaciente
    ' 
    lblPaciente.AutoSize = True
    lblPaciente.Location = New Point(47, 32)
    lblPaciente.Name = "lblPaciente"
    lblPaciente.Size = New Size(92, 25)
    lblPaciente.TabIndex = 1
    lblPaciente.Text = "Paciente:"
    ' 
    ' btnAsignar
    ' 
    btnAsignar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnAsignar.Location = New Point(228, 292)
    btnAsignar.Name = "btnAsignar"
    btnAsignar.Size = New Size(107, 47)
    btnAsignar.TabIndex = 2
    btnAsignar.Text = "Asignar"
    btnAsignar.UseVisualStyleBackColor = True
    ' 
    ' btnCancelar
    ' 
    btnCancelar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnCancelar.Location = New Point(89, 292)
    btnCancelar.Name = "btnCancelar"
    btnCancelar.Size = New Size(107, 47)
    btnCancelar.TabIndex = 3
    btnCancelar.Text = "Cancelar"
    btnCancelar.UseVisualStyleBackColor = True
    ' 
    ' errProv
    ' 
    errProv.ContainerControl = Me
    ' 
    ' frmAsignarConsulta
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(457, 351)
    Controls.Add(btnCancelar)
    Controls.Add(btnAsignar)
    Controls.Add(grbPaciente)
    Controls.Add(grbDoctor)
    Name = "frmAsignarConsulta"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Asignar Consulta"
    grbDoctor.ResumeLayout(False)
    grbDoctor.PerformLayout()
    grbPaciente.ResumeLayout(False)
    grbPaciente.PerformLayout()
    CType(errProv, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbDoctor As GroupBox
  Friend WithEvents grbPaciente As GroupBox
  Friend WithEvents lblInfoEspecialidad As Label
  Friend WithEvents lblEspecialidad As Label
  Friend WithEvents lblInfoDoctor As Label
  Friend WithEvents lblDoctor As Label
  Friend WithEvents lblNombrePaciente As Label
  Friend WithEvents lblPaciente As Label
  Friend WithEvents cmbPrioridad As ComboBox
  Friend WithEvents lblPrioridad As Label
  Friend WithEvents lblInfoPaciente As Label
  Friend WithEvents txtIdentificacionPaciente As TextBox
  Friend WithEvents btnAsignar As Button
  Friend WithEvents btnCancelar As Button
  Friend WithEvents errProv As ErrorProvider
  Friend WithEvents tlpToolTip As ToolTip
End Class
