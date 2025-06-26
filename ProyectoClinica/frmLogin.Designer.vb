<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
    Panel1 = New Panel()
    txtPassword = New TextBox()
    txtCorreo = New TextBox()
    btnIngresar = New Button()
    btnCrearCuenta = New Button()
    lblPassword = New Label()
    lblCorreo = New Label()
    lblBienvenidos = New Label()
    Panel1.SuspendLayout()
    SuspendLayout()
    ' 
    ' Panel1
    ' 
    Panel1.BackColor = Color.FromArgb(CByte(187), CByte(212), CByte(235))
    Panel1.BorderStyle = BorderStyle.Fixed3D
    Panel1.Controls.Add(txtPassword)
    Panel1.Controls.Add(txtCorreo)
    Panel1.Controls.Add(btnIngresar)
    Panel1.Controls.Add(btnCrearCuenta)
    Panel1.Controls.Add(lblPassword)
    Panel1.Controls.Add(lblCorreo)
    Panel1.Location = New Point(46, 60)
    Panel1.Name = "Panel1"
    Panel1.Size = New Size(246, 241)
    Panel1.TabIndex = 0
    ' 
    ' txtPassword
    ' 
    txtPassword.Location = New Point(38, 118)
    txtPassword.Name = "txtPassword"
    txtPassword.PasswordChar = "*"c
    txtPassword.Size = New Size(165, 23)
    txtPassword.TabIndex = 3
    ' 
    ' txtCorreo
    ' 
    txtCorreo.Location = New Point(38, 52)
    txtCorreo.Name = "txtCorreo"
    txtCorreo.Size = New Size(165, 23)
    txtCorreo.TabIndex = 1
    ' 
    ' btnIngresar
    ' 
    btnIngresar.Location = New Point(131, 169)
    btnIngresar.Name = "btnIngresar"
    btnIngresar.Size = New Size(98, 43)
    btnIngresar.TabIndex = 5
    btnIngresar.Text = "Ingresar"
    btnIngresar.UseVisualStyleBackColor = True
    ' 
    ' btnCrearCuenta
    ' 
    btnCrearCuenta.Location = New Point(14, 169)
    btnCrearCuenta.Name = "btnCrearCuenta"
    btnCrearCuenta.Size = New Size(98, 43)
    btnCrearCuenta.TabIndex = 4
    btnCrearCuenta.Text = "Crear Cuenta"
    btnCrearCuenta.UseVisualStyleBackColor = True
    ' 
    ' lblPassword
    ' 
    lblPassword.Location = New Point(38, 100)
    lblPassword.Name = "lblPassword"
    lblPassword.Size = New Size(165, 15)
    lblPassword.TabIndex = 2
    lblPassword.Text = "Contraseña "
    lblPassword.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblCorreo
    ' 
    lblCorreo.Location = New Point(38, 34)
    lblCorreo.Name = "lblCorreo"
    lblCorreo.Size = New Size(165, 15)
    lblCorreo.TabIndex = 0
    lblCorreo.Text = "Ingresar Correo "
    lblCorreo.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' lblBienvenidos
    ' 
    lblBienvenidos.AutoSize = True
    lblBienvenidos.BackColor = Color.FromArgb(CByte(208), CByte(226), CByte(243))
    lblBienvenidos.Location = New Point(41, 13)
    lblBienvenidos.Name = "lblBienvenidos"
    lblBienvenidos.Size = New Size(166, 15)
    lblBienvenidos.TabIndex = 1
    lblBienvenidos.Text = "Bienvenidos a Clinica Server...."
    ' 
    ' frmLogin
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
    BackgroundImageLayout = ImageLayout.Stretch
    ClientSize = New Size(642, 371)
    Controls.Add(lblBienvenidos)
    Controls.Add(Panel1)
    DoubleBuffered = True
    FormBorderStyle = FormBorderStyle.FixedToolWindow
    MaximumSize = New Size(658, 410)
    MinimizeBox = False
    MinimumSize = New Size(658, 410)
    Name = "frmLogin"
    Text = "Login"
    Panel1.ResumeLayout(False)
    Panel1.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Friend WithEvents Panel1 As Panel
  Friend WithEvents btnIngresar As Button
  Friend WithEvents btnCrearCuenta As Button
  Friend WithEvents lblPassword As Label
  Friend WithEvents lblCorreo As Label
  Friend WithEvents txtPassword As TextBox
  Friend WithEvents txtCorreo As TextBox
  Friend WithEvents lblBienvenidos As Label

End Class
