﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
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
    btnReporte = New Button()
    btnSalir = New Button()
    btnUsuarios = New Button()
    btnConsultas = New Button()
    btnEspecialidades = New Button()
    btnDoctores = New Button()
    btnPersonas = New Button()
    grbPantallas = New GroupBox()
    pnlPantallas = New Panel()
    grbOpciones.SuspendLayout()
    grbPantallas.SuspendLayout()
    SuspendLayout()
    ' 
    ' grbOpciones
    ' 
    grbOpciones.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    grbOpciones.BackColor = Color.Transparent
    grbOpciones.Controls.Add(btnReporte)
    grbOpciones.Controls.Add(btnSalir)
    grbOpciones.Controls.Add(btnUsuarios)
    grbOpciones.Controls.Add(btnConsultas)
    grbOpciones.Controls.Add(btnEspecialidades)
    grbOpciones.Controls.Add(btnDoctores)
    grbOpciones.Controls.Add(btnPersonas)
    grbOpciones.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    grbOpciones.Location = New Point(10, 12)
    grbOpciones.Name = "grbOpciones"
    grbOpciones.Size = New Size(260, 585)
    grbOpciones.TabIndex = 0
    grbOpciones.TabStop = False
    grbOpciones.Text = "Seleccione una opción"
    ' 
    ' btnReporte
    ' 
    btnReporte.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnReporte.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnReporte.FlatStyle = FlatStyle.Flat
    btnReporte.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnReporte.ForeColor = Color.White
    btnReporte.Location = New Point(26, 348)
    btnReporte.Name = "btnReporte"
    btnReporte.Size = New Size(134, 57)
    btnReporte.TabIndex = 5
    btnReporte.Text = "Reporte"
    btnReporte.UseVisualStyleBackColor = True
    ' 
    ' btnSalir
    ' 
    btnSalir.BackColor = Color.IndianRed
    btnSalir.FlatStyle = FlatStyle.Flat
    btnSalir.ForeColor = Color.White
    btnSalir.Location = New Point(26, 411)
    btnSalir.Name = "btnSalir"
    btnSalir.Size = New Size(134, 57)
    btnSalir.TabIndex = 3
    btnSalir.Text = "Salir"
    btnSalir.UseVisualStyleBackColor = False
    ' 
    ' btnUsuarios
    ' 
    btnUsuarios.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnUsuarios.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnUsuarios.FlatStyle = FlatStyle.Flat
    btnUsuarios.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnUsuarios.ForeColor = Color.White
    btnUsuarios.Location = New Point(26, 33)
    btnUsuarios.Name = "btnUsuarios"
    btnUsuarios.Size = New Size(134, 57)
    btnUsuarios.TabIndex = 4
    btnUsuarios.Text = "Usuarios"
    btnUsuarios.UseVisualStyleBackColor = True
    ' 
    ' btnConsultas
    ' 
    btnConsultas.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnConsultas.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnConsultas.FlatStyle = FlatStyle.Flat
    btnConsultas.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnConsultas.ForeColor = Color.White
    btnConsultas.Location = New Point(26, 285)
    btnConsultas.Name = "btnConsultas"
    btnConsultas.Size = New Size(134, 57)
    btnConsultas.TabIndex = 3
    btnConsultas.Text = "Consultas"
    btnConsultas.UseVisualStyleBackColor = True
    ' 
    ' btnEspecialidades
    ' 
    btnEspecialidades.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnEspecialidades.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnEspecialidades.FlatStyle = FlatStyle.Flat
    btnEspecialidades.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnEspecialidades.ForeColor = Color.White
    btnEspecialidades.Location = New Point(26, 96)
    btnEspecialidades.Name = "btnEspecialidades"
    btnEspecialidades.Size = New Size(134, 57)
    btnEspecialidades.TabIndex = 2
    btnEspecialidades.Text = "Especialidades"
    btnEspecialidades.UseVisualStyleBackColor = True
    ' 
    ' btnDoctores
    ' 
    btnDoctores.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnDoctores.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnDoctores.FlatStyle = FlatStyle.Flat
    btnDoctores.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnDoctores.ForeColor = Color.White
    btnDoctores.Location = New Point(26, 159)
    btnDoctores.Name = "btnDoctores"
    btnDoctores.Size = New Size(134, 57)
    btnDoctores.TabIndex = 1
    btnDoctores.Text = "Doctores"
    btnDoctores.UseVisualStyleBackColor = True
    ' 
    ' btnPersonas
    ' 
    btnPersonas.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnPersonas.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnPersonas.FlatStyle = FlatStyle.Flat
    btnPersonas.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnPersonas.ForeColor = Color.White
    btnPersonas.Location = New Point(26, 222)
    btnPersonas.Name = "btnPersonas"
    btnPersonas.Size = New Size(134, 57)
    btnPersonas.TabIndex = 0
    btnPersonas.Text = "Pacientes"
    btnPersonas.UseVisualStyleBackColor = True
    ' 
    ' grbPantallas
    ' 
    grbPantallas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    grbPantallas.BackColor = Color.Transparent
    grbPantallas.Controls.Add(pnlPantallas)
    grbPantallas.Location = New Point(187, 12)
    grbPantallas.Name = "grbPantallas"
    grbPantallas.Size = New Size(864, 585)
    grbPantallas.TabIndex = 4
    grbPantallas.TabStop = False
    ' 
    ' pnlPantallas
    ' 
    pnlPantallas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    pnlPantallas.AutoScroll = True
    pnlPantallas.AutoSize = True
    pnlPantallas.BackColor = Color.Transparent
    pnlPantallas.BackgroundImageLayout = ImageLayout.Stretch
    pnlPantallas.Location = New Point(6, 14)
    pnlPantallas.Name = "pnlPantallas"
    pnlPantallas.Size = New Size(852, 565)
    pnlPantallas.TabIndex = 0
    ' 
    ' frmMenuPrincipal
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(1066, 610)
    Controls.Add(grbPantallas)
    Controls.Add(grbOpciones)
    MinimumSize = New Size(1082, 649)
    Name = "frmMenuPrincipal"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Menú Principal"
    grbOpciones.ResumeLayout(False)
    grbPantallas.ResumeLayout(False)
    grbPantallas.PerformLayout()
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
  Friend WithEvents grbPantallas As GroupBox
  Friend WithEvents pnlPantallas As Panel
End Class
