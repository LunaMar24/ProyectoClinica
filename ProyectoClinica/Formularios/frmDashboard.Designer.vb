<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
  Inherits Form

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
    grbOpciones = New GroupBox()
    btnUsuarios = New Button()
    btnConsultas = New Button()
    btnEspecialidades = New Button()
    btnDoctores = New Button()
    btnPersonas = New Button()
    btnSalir = New Button()
    btnReporte = New Button()
    grbOpciones.SuspendLayout()
    SuspendLayout()
    ' 
    ' grbOpciones
    ' 
    grbOpciones.Controls.Add(btnReporte)
    grbOpciones.Controls.Add(btnUsuarios)
    grbOpciones.Controls.Add(btnConsultas)
    grbOpciones.Controls.Add(btnEspecialidades)
    grbOpciones.Controls.Add(btnDoctores)
    grbOpciones.Controls.Add(btnPersonas)
    grbOpciones.Location = New Point(30, 25)
    grbOpciones.Name = "grbOpciones"
    grbOpciones.Size = New Size(554, 213)
    grbOpciones.TabIndex = 0
    grbOpciones.TabStop = False
    grbOpciones.Text = "Seleccione una opción"
    ' 
    ' btnUsuarios
    ' 
    btnUsuarios.Location = New Point(26, 33)
    btnUsuarios.Name = "btnUsuarios"
    btnUsuarios.Size = New Size(134, 57)
    btnUsuarios.TabIndex = 4
    btnUsuarios.Text = "Usuarios"
    btnUsuarios.UseVisualStyleBackColor = True
    ' 
    ' btnConsultas
    ' 
    btnConsultas.Location = New Point(26, 119)
    btnConsultas.Name = "btnConsultas"
    btnConsultas.Size = New Size(134, 57)
    btnConsultas.TabIndex = 3
    btnConsultas.Text = "Consultas"
    btnConsultas.UseVisualStyleBackColor = True
    ' 
    ' btnEspecialidades
    ' 
    btnEspecialidades.Location = New Point(394, 33)
    btnEspecialidades.Name = "btnEspecialidades"
    btnEspecialidades.Size = New Size(134, 57)
    btnEspecialidades.TabIndex = 2
    btnEspecialidades.Text = "Especialidades"
    btnEspecialidades.UseVisualStyleBackColor = True
    ' 
    ' btnDoctores
    ' 
    btnDoctores.Location = New Point(210, 33)
    btnDoctores.Name = "btnDoctores"
    btnDoctores.Size = New Size(134, 57)
    btnDoctores.TabIndex = 1
    btnDoctores.Text = "Doctores"
    btnDoctores.UseVisualStyleBackColor = True
    ' 
    ' btnPersonas
    ' 
    btnPersonas.Location = New Point(210, 119)
    btnPersonas.Name = "btnPersonas"
    btnPersonas.Size = New Size(134, 57)
    btnPersonas.TabIndex = 0
    btnPersonas.Text = "Pacientes"
    btnPersonas.UseVisualStyleBackColor = True
    ' 
    ' btnSalir
    ' 
    btnSalir.BackColor = Color.IndianRed
    btnSalir.ForeColor = Color.White
    btnSalir.Location = New Point(450, 257)
    btnSalir.Name = "btnSalir"
    btnSalir.Size = New Size(134, 57)
    btnSalir.TabIndex = 3
    btnSalir.Text = "Salir"
    btnSalir.UseVisualStyleBackColor = False
    ' 
    ' btnReporte
    ' 
    btnReporte.Location = New Point(394, 119)
    btnReporte.Name = "btnReporte"
    btnReporte.Size = New Size(134, 57)
    btnReporte.TabIndex = 5
    btnReporte.Text = "Reporte"
    btnReporte.UseVisualStyleBackColor = True
    ' 
    ' frmDashboard
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(602, 338)
    Controls.Add(btnSalir)
    Controls.Add(grbOpciones)
    Name = "frmDashboard"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Menú Principal"
    grbOpciones.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbOpciones As GroupBox
  Friend WithEvents btnUsuarios As Button
  Friend WithEvents btnConsultas As Button
  Friend WithEvents btnEspecialidades As Button
  Friend WithEvents btnDoctores As Button
  Friend WithEvents btnPersonas As Button
  Friend WithEvents btnSalir As Button
  Friend WithEvents btnReporte As Button
End Class
