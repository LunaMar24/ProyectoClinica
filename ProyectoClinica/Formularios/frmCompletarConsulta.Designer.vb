<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCompletarConsulta
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
    components = New ComponentModel.Container()
    grbData = New GroupBox()
    txtPresion = New TextBox()
    lblPresion = New Label()
    txtEspecialidad = New TextBox()
    lblEspecialidad = New Label()
    txtDoctor = New TextBox()
    lblDoctor = New Label()
    txtPaciente = New TextBox()
    lblPaciente = New Label()
    txtEstatura = New TextBox()
    lblEstatura = New Label()
    txtTemperatura = New TextBox()
    lblTemperatura = New Label()
    txtFecha = New TextBox()
    lblFecha = New Label()
    txtPrioridad = New TextBox()
    lblPrioridad = New Label()
    txtPeso = New TextBox()
    lblPeso = New Label()
    txtCodigoConsulta = New TextBox()
    lblCodConsulta = New Label()
    txtTratamiento = New TextBox()
    btnRegresar = New Button()
    btnCerrarConsulta = New Button()
    grbSintomas = New GroupBox()
    txtSintomas = New TextBox()
    grbAlergias = New GroupBox()
    txtAlergias = New TextBox()
    rrpError = New ErrorProvider(components)
    grbPadecimientos = New GroupBox()
    txtPadecimientos = New TextBox()
    tltToolTip = New ToolTip(components)
    grbTratamiento = New GroupBox()
    grbData.SuspendLayout()
    grbSintomas.SuspendLayout()
    grbAlergias.SuspendLayout()
    CType(rrpError, ComponentModel.ISupportInitialize).BeginInit()
    grbPadecimientos.SuspendLayout()
    grbTratamiento.SuspendLayout()
    SuspendLayout()
    ' 
    ' grbData
    ' 
    grbData.BackColor = Color.Transparent
    grbData.Controls.Add(txtPresion)
    grbData.Controls.Add(lblPresion)
    grbData.Controls.Add(txtEspecialidad)
    grbData.Controls.Add(lblEspecialidad)
    grbData.Controls.Add(txtDoctor)
    grbData.Controls.Add(lblDoctor)
    grbData.Controls.Add(txtPaciente)
    grbData.Controls.Add(lblPaciente)
    grbData.Controls.Add(txtEstatura)
    grbData.Controls.Add(lblEstatura)
    grbData.Controls.Add(txtTemperatura)
    grbData.Controls.Add(lblTemperatura)
    grbData.Controls.Add(txtFecha)
    grbData.Controls.Add(lblFecha)
    grbData.Controls.Add(txtPrioridad)
    grbData.Controls.Add(lblPrioridad)
    grbData.Controls.Add(txtPeso)
    grbData.Controls.Add(lblPeso)
    grbData.Controls.Add(txtCodigoConsulta)
    grbData.Controls.Add(lblCodConsulta)
    grbData.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    grbData.Location = New Point(27, 30)
    grbData.Name = "grbData"
    grbData.Size = New Size(541, 368)
    grbData.TabIndex = 0
    grbData.TabStop = False
    grbData.Text = "Datos"
    ' 
    ' txtPresion
    ' 
    txtPresion.Font = New Font("Segoe UI", 14.25F)
    txtPresion.Location = New Point(324, 320)
    txtPresion.Name = "txtPresion"
    txtPresion.Size = New Size(192, 33)
    txtPresion.TabIndex = 19
    ' 
    ' lblPresion
    ' 
    lblPresion.AutoSize = True
    lblPresion.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblPresion.Location = New Point(324, 292)
    lblPresion.Name = "lblPresion"
    lblPresion.Size = New Size(181, 25)
    lblPresion.TabIndex = 18
    lblPresion.Text = "Presión (Sist/Diast)"
    ' 
    ' txtEspecialidad
    ' 
    txtEspecialidad.Enabled = False
    txtEspecialidad.Font = New Font("Segoe UI", 14.25F)
    txtEspecialidad.Location = New Point(14, 189)
    txtEspecialidad.Name = "txtEspecialidad"
    txtEspecialidad.Size = New Size(293, 33)
    txtEspecialidad.TabIndex = 9
    ' 
    ' lblEspecialidad
    ' 
    lblEspecialidad.AutoSize = True
    lblEspecialidad.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblEspecialidad.Location = New Point(14, 160)
    lblEspecialidad.Name = "lblEspecialidad"
    lblEspecialidad.Size = New Size(120, 25)
    lblEspecialidad.TabIndex = 8
    lblEspecialidad.Text = "Especialidad"
    ' 
    ' txtDoctor
    ' 
    txtDoctor.Enabled = False
    txtDoctor.Font = New Font("Segoe UI", 14.25F)
    txtDoctor.Location = New Point(14, 123)
    txtDoctor.Name = "txtDoctor"
    txtDoctor.Size = New Size(293, 33)
    txtDoctor.TabIndex = 5
    ' 
    ' lblDoctor
    ' 
    lblDoctor.AutoSize = True
    lblDoctor.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblDoctor.Location = New Point(14, 94)
    lblDoctor.Name = "lblDoctor"
    lblDoctor.Size = New Size(74, 25)
    lblDoctor.TabIndex = 4
    lblDoctor.Text = "Doctor"
    ' 
    ' txtPaciente
    ' 
    txtPaciente.Enabled = False
    txtPaciente.Font = New Font("Segoe UI", 14.25F)
    txtPaciente.Location = New Point(14, 254)
    txtPaciente.Name = "txtPaciente"
    txtPaciente.Size = New Size(293, 33)
    txtPaciente.TabIndex = 13
    ' 
    ' lblPaciente
    ' 
    lblPaciente.AutoSize = True
    lblPaciente.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblPaciente.Location = New Point(14, 228)
    lblPaciente.Name = "lblPaciente"
    lblPaciente.Size = New Size(87, 25)
    lblPaciente.TabIndex = 12
    lblPaciente.Text = "Paciente"
    ' 
    ' txtEstatura
    ' 
    txtEstatura.Font = New Font("Segoe UI", 14.25F)
    txtEstatura.Location = New Point(19, 320)
    txtEstatura.Name = "txtEstatura"
    txtEstatura.Size = New Size(288, 33)
    txtEstatura.TabIndex = 17
    ' 
    ' lblEstatura
    ' 
    lblEstatura.AutoSize = True
    lblEstatura.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblEstatura.Location = New Point(13, 292)
    lblEstatura.Name = "lblEstatura"
    lblEstatura.Size = New Size(120, 25)
    lblEstatura.TabIndex = 16
    lblEstatura.Text = "Estatura (m)"
    ' 
    ' txtTemperatura
    ' 
    txtTemperatura.Font = New Font("Segoe UI", 14.25F)
    txtTemperatura.Location = New Point(324, 188)
    txtTemperatura.Name = "txtTemperatura"
    txtTemperatura.Size = New Size(192, 33)
    txtTemperatura.TabIndex = 11
    ' 
    ' lblTemperatura
    ' 
    lblTemperatura.AutoSize = True
    lblTemperatura.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblTemperatura.Location = New Point(324, 160)
    lblTemperatura.Name = "lblTemperatura"
    lblTemperatura.Size = New Size(206, 25)
    lblTemperatura.TabIndex = 10
    lblTemperatura.Text = "Temperatura (grados)"
    ' 
    ' txtFecha
    ' 
    txtFecha.Enabled = False
    txtFecha.Font = New Font("Segoe UI", 14.25F)
    txtFecha.Location = New Point(324, 56)
    txtFecha.Name = "txtFecha"
    txtFecha.Size = New Size(192, 33)
    txtFecha.TabIndex = 3
    ' 
    ' lblFecha
    ' 
    lblFecha.AutoSize = True
    lblFecha.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblFecha.Location = New Point(324, 28)
    lblFecha.Name = "lblFecha"
    lblFecha.Size = New Size(62, 25)
    lblFecha.TabIndex = 2
    lblFecha.Text = "Fecha"
    ' 
    ' txtPrioridad
    ' 
    txtPrioridad.Enabled = False
    txtPrioridad.Font = New Font("Segoe UI", 14.25F)
    txtPrioridad.Location = New Point(324, 123)
    txtPrioridad.Name = "txtPrioridad"
    txtPrioridad.Size = New Size(192, 33)
    txtPrioridad.TabIndex = 7
    ' 
    ' lblPrioridad
    ' 
    lblPrioridad.AutoSize = True
    lblPrioridad.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblPrioridad.Location = New Point(324, 94)
    lblPrioridad.Name = "lblPrioridad"
    lblPrioridad.Size = New Size(96, 25)
    lblPrioridad.TabIndex = 6
    lblPrioridad.Text = "Prioridad"
    ' 
    ' txtPeso
    ' 
    txtPeso.Font = New Font("Segoe UI", 14.25F)
    txtPeso.Location = New Point(324, 254)
    txtPeso.Name = "txtPeso"
    txtPeso.Size = New Size(192, 33)
    txtPeso.TabIndex = 15
    ' 
    ' lblPeso
    ' 
    lblPeso.AutoSize = True
    lblPeso.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblPeso.Location = New Point(321, 226)
    lblPeso.Name = "lblPeso"
    lblPeso.Size = New Size(96, 25)
    lblPeso.TabIndex = 14
    lblPeso.Text = "Peso (Kg)"
    ' 
    ' txtCodigoConsulta
    ' 
    txtCodigoConsulta.Enabled = False
    txtCodigoConsulta.Font = New Font("Segoe UI", 14.25F)
    txtCodigoConsulta.Location = New Point(14, 57)
    txtCodigoConsulta.Name = "txtCodigoConsulta"
    txtCodigoConsulta.Size = New Size(293, 33)
    txtCodigoConsulta.TabIndex = 1
    ' 
    ' lblCodConsulta
    ' 
    lblCodConsulta.AutoSize = True
    lblCodConsulta.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblCodConsulta.Location = New Point(14, 28)
    lblCodConsulta.Name = "lblCodConsulta"
    lblCodConsulta.Size = New Size(90, 25)
    lblCodConsulta.TabIndex = 0
    lblCodConsulta.Text = "Consulta"
    ' 
    ' txtTratamiento
    ' 
    txtTratamiento.Font = New Font("Segoe UI", 14.25F)
    txtTratamiento.Location = New Point(6, 34)
    txtTratamiento.Multiline = True
    txtTratamiento.Name = "txtTratamiento"
    txtTratamiento.Size = New Size(510, 112)
    txtTratamiento.TabIndex = 0
    ' 
    ' btnRegresar
    ' 
    btnRegresar.BackColor = Color.IndianRed
    btnRegresar.FlatStyle = FlatStyle.Flat
    btnRegresar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnRegresar.ForeColor = Color.White
    btnRegresar.Location = New Point(574, 471)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(154, 83)
    btnRegresar.TabIndex = 5
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = False
    ' 
    ' btnCerrarConsulta
    ' 
    btnCerrarConsulta.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnCerrarConsulta.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnCerrarConsulta.FlatStyle = FlatStyle.Flat
    btnCerrarConsulta.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnCerrarConsulta.ForeColor = Color.White
    btnCerrarConsulta.Location = New Point(746, 471)
    btnCerrarConsulta.Name = "btnCerrarConsulta"
    btnCerrarConsulta.Size = New Size(154, 83)
    btnCerrarConsulta.TabIndex = 6
    btnCerrarConsulta.Text = "Cerrar Consulta"
    btnCerrarConsulta.UseVisualStyleBackColor = True
    ' 
    ' grbSintomas
    ' 
    grbSintomas.BackColor = Color.Transparent
    grbSintomas.Controls.Add(txtSintomas)
    grbSintomas.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    grbSintomas.Location = New Point(574, 30)
    grbSintomas.Name = "grbSintomas"
    grbSintomas.Size = New Size(326, 119)
    grbSintomas.TabIndex = 1
    grbSintomas.TabStop = False
    grbSintomas.Text = "Síntomas"
    ' 
    ' txtSintomas
    ' 
    txtSintomas.Font = New Font("Segoe UI", 14.25F)
    txtSintomas.Location = New Point(6, 31)
    txtSintomas.Multiline = True
    txtSintomas.Name = "txtSintomas"
    txtSintomas.Size = New Size(300, 82)
    txtSintomas.TabIndex = 0
    ' 
    ' grbAlergias
    ' 
    grbAlergias.BackColor = Color.Transparent
    grbAlergias.Controls.Add(txtAlergias)
    grbAlergias.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    grbAlergias.Location = New Point(574, 173)
    grbAlergias.Name = "grbAlergias"
    grbAlergias.Size = New Size(326, 119)
    grbAlergias.TabIndex = 2
    grbAlergias.TabStop = False
    grbAlergias.Text = "Alergias"
    ' 
    ' txtAlergias
    ' 
    txtAlergias.Font = New Font("Segoe UI", 14.25F)
    txtAlergias.Location = New Point(6, 31)
    txtAlergias.Multiline = True
    txtAlergias.Name = "txtAlergias"
    txtAlergias.Size = New Size(300, 82)
    txtAlergias.TabIndex = 0
    ' 
    ' rrpError
    ' 
    rrpError.ContainerControl = Me
    ' 
    ' grbPadecimientos
    ' 
    grbPadecimientos.BackColor = Color.Transparent
    grbPadecimientos.Controls.Add(txtPadecimientos)
    grbPadecimientos.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    grbPadecimientos.Location = New Point(574, 308)
    grbPadecimientos.Name = "grbPadecimientos"
    grbPadecimientos.Size = New Size(326, 119)
    grbPadecimientos.TabIndex = 3
    grbPadecimientos.TabStop = False
    grbPadecimientos.Text = "Padecimientos"
    ' 
    ' txtPadecimientos
    ' 
    txtPadecimientos.Font = New Font("Segoe UI", 14.25F)
    txtPadecimientos.Location = New Point(6, 31)
    txtPadecimientos.Multiline = True
    txtPadecimientos.Name = "txtPadecimientos"
    txtPadecimientos.Size = New Size(300, 82)
    txtPadecimientos.TabIndex = 0
    ' 
    ' grbTratamiento
    ' 
    grbTratamiento.BackColor = Color.Transparent
    grbTratamiento.Controls.Add(txtTratamiento)
    grbTratamiento.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    grbTratamiento.Location = New Point(27, 404)
    grbTratamiento.Name = "grbTratamiento"
    grbTratamiento.Size = New Size(541, 150)
    grbTratamiento.TabIndex = 4
    grbTratamiento.TabStop = False
    grbTratamiento.Text = "Tratamiento"
    ' 
    ' frmCompletarConsulta
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(913, 560)
    Controls.Add(grbTratamiento)
    Controls.Add(grbPadecimientos)
    Controls.Add(grbAlergias)
    Controls.Add(grbSintomas)
    Controls.Add(grbData)
    Controls.Add(btnRegresar)
    Controls.Add(btnCerrarConsulta)
    Name = "frmCompletarConsulta"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Consulta"
    grbData.ResumeLayout(False)
    grbData.PerformLayout()
    grbSintomas.ResumeLayout(False)
    grbSintomas.PerformLayout()
    grbAlergias.ResumeLayout(False)
    grbAlergias.PerformLayout()
    CType(rrpError, ComponentModel.ISupportInitialize).EndInit()
    grbPadecimientos.ResumeLayout(False)
    grbPadecimientos.PerformLayout()
    grbTratamiento.ResumeLayout(False)
    grbTratamiento.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbData As GroupBox
  Friend WithEvents lblEspecialidad As Label
  Friend WithEvents txtPeso As TextBox
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnCerrarConsulta As Button
  Friend WithEvents txtTemperatura As TextBox
  Friend WithEvents txtTratamiento As TextBox
  Friend WithEvents rrpError As ErrorProvider
  Friend WithEvents txtEstatura As TextBox
  Friend WithEvents lblEstatura As Label
  Friend WithEvents lblTemperatura As Label
  Friend WithEvents txtFecha As TextBox
  Friend WithEvents lblFecha As Label
  Friend WithEvents txtPrioridad As TextBox
  Friend WithEvents lblPrioridad As Label
  Friend WithEvents lblPeso As Label
  Friend WithEvents txtCodigoConsulta As TextBox
  Friend WithEvents lblCodConsulta As Label
  Friend WithEvents txtPaciente As TextBox
  Friend WithEvents lblPaciente As Label
  Friend WithEvents txtEspecialidad As TextBox
  Friend WithEvents txtDoctor As TextBox
  Friend WithEvents lblDoctor As Label
  Friend WithEvents grbSintomas As GroupBox
  Friend WithEvents txtSintomas As TextBox
  Friend WithEvents grbAlergias As GroupBox
  Friend WithEvents txtAlergias As TextBox
  Friend WithEvents grbPadecimientos As GroupBox
  Friend WithEvents txtPadecimientos As TextBox
  Friend WithEvents tltToolTip As ToolTip
  Friend WithEvents grbTratamiento As GroupBox
  Friend WithEvents txtPresion As TextBox
  Friend WithEvents lblPresion As Label
End Class
