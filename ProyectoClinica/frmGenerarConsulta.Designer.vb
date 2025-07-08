<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarConsulta
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
    grbDoctor = New GroupBox()
    Label3 = New Label()
    Label4 = New Label()
    Label2 = New Label()
    Label1 = New Label()
    grbPaciente = New GroupBox()
    Label6 = New Label()
    Label5 = New Label()
    TextBox1 = New TextBox()
    Label7 = New Label()
    Label8 = New Label()
    ComboBox1 = New ComboBox()
    Button1 = New Button()
    Button2 = New Button()
    grbDoctor.SuspendLayout()
    grbPaciente.SuspendLayout()
    SuspendLayout()
    ' 
    ' grbDoctor
    ' 
    grbDoctor.Controls.Add(Label3)
    grbDoctor.Controls.Add(Label4)
    grbDoctor.Controls.Add(Label2)
    grbDoctor.Controls.Add(Label1)
    grbDoctor.Location = New Point(12, 12)
    grbDoctor.Name = "grbDoctor"
    grbDoctor.Size = New Size(320, 109)
    grbDoctor.TabIndex = 0
    grbDoctor.TabStop = False
    grbDoctor.Text = "Información Doctor"
    ' 
    ' Label3
    ' 
    Label3.Location = New Point(92, 66)
    Label3.Name = "Label3"
    Label3.Size = New Size(200, 25)
    Label3.TabIndex = 3
    Label3.Text = "Urologia"
    ' 
    ' Label4
    ' 
    Label4.AutoSize = True
    Label4.Location = New Point(14, 66)
    Label4.Name = "Label4"
    Label4.Size = New Size(75, 15)
    Label4.TabIndex = 2
    Label4.Text = "Especialidad:"
    ' 
    ' Label2
    ' 
    Label2.Location = New Point(92, 30)
    Label2.Name = "Label2"
    Label2.Size = New Size(200, 25)
    Label2.TabIndex = 1
    Label2.Text = "Eladio Valverde"
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Location = New Point(14, 30)
    Label1.Name = "Label1"
    Label1.Size = New Size(46, 15)
    Label1.TabIndex = 0
    Label1.Text = "Doctor:"
    ' 
    ' grbPaciente
    ' 
    grbPaciente.Controls.Add(ComboBox1)
    grbPaciente.Controls.Add(Label8)
    grbPaciente.Controls.Add(Label7)
    grbPaciente.Controls.Add(TextBox1)
    grbPaciente.Controls.Add(Label6)
    grbPaciente.Controls.Add(Label5)
    grbPaciente.Location = New Point(12, 139)
    grbPaciente.Name = "grbPaciente"
    grbPaciente.Size = New Size(320, 140)
    grbPaciente.TabIndex = 1
    grbPaciente.TabStop = False
    grbPaciente.Text = "Información Paciente"
    ' 
    ' Label6
    ' 
    Label6.AutoSize = True
    Label6.Location = New Point(23, 66)
    Label6.Name = "Label6"
    Label6.Size = New Size(54, 15)
    Label6.TabIndex = 2
    Label6.Text = "Nombre:"
    ' 
    ' Label5
    ' 
    Label5.AutoSize = True
    Label5.Location = New Point(23, 32)
    Label5.Name = "Label5"
    Label5.Size = New Size(55, 15)
    Label5.TabIndex = 1
    Label5.Text = "Paciente:"
    ' 
    ' TextBox1
    ' 
    TextBox1.Location = New Point(84, 29)
    TextBox1.Name = "TextBox1"
    TextBox1.Size = New Size(134, 23)
    TextBox1.TabIndex = 3
    ' 
    ' Label7
    ' 
    Label7.Location = New Point(84, 63)
    Label7.Name = "Label7"
    Label7.Size = New Size(208, 25)
    Label7.TabIndex = 4
    Label7.Text = "Eladio Valverde"
    ' 
    ' Label8
    ' 
    Label8.AutoSize = True
    Label8.Location = New Point(23, 99)
    Label8.Name = "Label8"
    Label8.Size = New Size(58, 15)
    Label8.TabIndex = 5
    Label8.Text = "Prioridad:"
    ' 
    ' ComboBox1
    ' 
    ComboBox1.FormattingEnabled = True
    ComboBox1.Items.AddRange(New Object() {"Alta", "Media", "Baja"})
    ComboBox1.Location = New Point(84, 91)
    ComboBox1.Name = "ComboBox1"
    ComboBox1.Size = New Size(134, 23)
    ComboBox1.TabIndex = 6
    ' 
    ' Button1
    ' 
    Button1.Location = New Point(180, 297)
    Button1.Name = "Button1"
    Button1.Size = New Size(77, 33)
    Button1.TabIndex = 2
    Button1.Text = "Aceptar"
    Button1.UseVisualStyleBackColor = True
    ' 
    ' Button2
    ' 
    Button2.Location = New Point(77, 297)
    Button2.Name = "Button2"
    Button2.Size = New Size(77, 33)
    Button2.TabIndex = 3
    Button2.Text = "Cancelar"
    Button2.UseVisualStyleBackColor = True
    ' 
    ' frmGenerarConsulta
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(349, 340)
    Controls.Add(Button2)
    Controls.Add(Button1)
    Controls.Add(grbPaciente)
    Controls.Add(grbDoctor)
    Name = "frmGenerarConsulta"
    Text = "Asignar Consulta"
    grbDoctor.ResumeLayout(False)
    grbDoctor.PerformLayout()
    grbPaciente.ResumeLayout(False)
    grbPaciente.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbDoctor As GroupBox
  Friend WithEvents grbPaciente As GroupBox
  Friend WithEvents Label3 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents ComboBox1 As ComboBox
  Friend WithEvents Label8 As Label
  Friend WithEvents Label7 As Label
  Friend WithEvents TextBox1 As TextBox
  Friend WithEvents Button1 As Button
  Friend WithEvents Button2 As Button
End Class
