<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarClave
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    components = New ComponentModel.Container()
    grbClaves = New GroupBox()
    txtConfirmaClave = New TextBox()
    Label2 = New Label()
    txtNuevaClave = New TextBox()
    lblClaveNueva = New Label()
    txtClaveAnt = New TextBox()
    lblClaveAnt = New Label()
    btnCancelar = New Button()
    btnAceptar = New Button()
    rrpError = New ErrorProvider(components)
    grbClaves.SuspendLayout()
    CType(rrpError, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' grbClaves
    ' 
    grbClaves.BackColor = Color.Transparent
    grbClaves.Controls.Add(txtConfirmaClave)
    grbClaves.Controls.Add(Label2)
    grbClaves.Controls.Add(txtNuevaClave)
    grbClaves.Controls.Add(lblClaveNueva)
    grbClaves.Controls.Add(txtClaveAnt)
    grbClaves.Controls.Add(lblClaveAnt)
    grbClaves.Location = New Point(12, 12)
    grbClaves.Name = "grbClaves"
    grbClaves.Size = New Size(329, 181)
    grbClaves.TabIndex = 0
    grbClaves.TabStop = False
    ' 
    ' txtConfirmaClave
    ' 
    txtConfirmaClave.Location = New Point(126, 127)
    txtConfirmaClave.Name = "txtConfirmaClave"
    txtConfirmaClave.PasswordChar = "*"c
    txtConfirmaClave.Size = New Size(182, 23)
    txtConfirmaClave.TabIndex = 5
    ' 
    ' Label2
    ' 
    Label2.AutoSize = True
    Label2.Location = New Point(24, 135)
    Label2.Name = "Label2"
    Label2.Size = New Size(96, 15)
    Label2.TabIndex = 4
    Label2.Text = "Confirmar Clave:"
    ' 
    ' txtNuevaClave
    ' 
    txtNuevaClave.Location = New Point(126, 89)
    txtNuevaClave.Name = "txtNuevaClave"
    txtNuevaClave.PasswordChar = "*"c
    txtNuevaClave.Size = New Size(182, 23)
    txtNuevaClave.TabIndex = 3
    ' 
    ' lblClaveNueva
    ' 
    lblClaveNueva.AutoSize = True
    lblClaveNueva.Location = New Point(44, 97)
    lblClaveNueva.Name = "lblClaveNueva"
    lblClaveNueva.Size = New Size(76, 15)
    lblClaveNueva.TabIndex = 2
    lblClaveNueva.Text = "Nueva Clave:"
    ' 
    ' txtClaveAnt
    ' 
    txtClaveAnt.Location = New Point(126, 26)
    txtClaveAnt.Name = "txtClaveAnt"
    txtClaveAnt.PasswordChar = "*"c
    txtClaveAnt.Size = New Size(182, 23)
    txtClaveAnt.TabIndex = 1
    ' 
    ' lblClaveAnt
    ' 
    lblClaveAnt.AutoSize = True
    lblClaveAnt.Location = New Point(35, 34)
    lblClaveAnt.Name = "lblClaveAnt"
    lblClaveAnt.Size = New Size(85, 15)
    lblClaveAnt.TabIndex = 0
    lblClaveAnt.Text = "Clave Anterior:"
    ' 
    ' btnCancelar
    ' 
    btnCancelar.BackColor = Color.IndianRed
    btnCancelar.FlatStyle = FlatStyle.Flat
    btnCancelar.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
    btnCancelar.ForeColor = Color.White
    btnCancelar.Location = New Point(53, 199)
    btnCancelar.Name = "btnCancelar"
    btnCancelar.Size = New Size(107, 47)
    btnCancelar.TabIndex = 5
    btnCancelar.Text = "Cancelar"
    btnCancelar.UseVisualStyleBackColor = True
    ' 
    ' btnAceptar
    ' 
    btnAceptar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnAceptar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnAceptar.FlatStyle = FlatStyle.Flat
    btnAceptar.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
    btnAceptar.ForeColor = Color.White
    btnAceptar.Location = New Point(192, 199)
    btnAceptar.Name = "btnAceptar"
    btnAceptar.Size = New Size(107, 47)
    btnAceptar.TabIndex = 4
    btnAceptar.Text = "Aceptar"
    btnAceptar.UseVisualStyleBackColor = True
    ' 
    ' rrpError
    ' 
    rrpError.ContainerControl = Me
    ' 
    ' frmCambiarClave
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(352, 256)
    Controls.Add(btnCancelar)
    Controls.Add(btnAceptar)
    Controls.Add(grbClaves)
    Name = "frmCambiarClave"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Cambiar Clave"
    grbClaves.ResumeLayout(False)
    grbClaves.PerformLayout()
    CType(rrpError, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbClaves As GroupBox
  Friend WithEvents txtConfirmaClave As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents txtNuevaClave As TextBox
  Friend WithEvents lblClaveNueva As Label
  Friend WithEvents txtClaveAnt As TextBox
  Friend WithEvents lblClaveAnt As Label
  Friend WithEvents btnCancelar As Button
  Friend WithEvents btnAceptar As Button
  Friend WithEvents rrpError As ErrorProvider
End Class
