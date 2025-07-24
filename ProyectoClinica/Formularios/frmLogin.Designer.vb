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
    pnlLogin = New Panel()
    txtPassword = New TextBox()
    txtCorreo = New TextBox()
    btnIngresar = New Button()
    btnSalir = New Button()
    lblPassword = New Label()
    lblCorreo = New Label()
    lblBienvenidos = New Label()
    pnlLogin.SuspendLayout()
    SuspendLayout()
    ' 
    ' pnlLogin
    ' 
    pnlLogin.BackColor = Color.FromArgb(CByte(187), CByte(212), CByte(235))
    pnlLogin.BorderStyle = BorderStyle.Fixed3D
    pnlLogin.Controls.Add(txtPassword)
    pnlLogin.Controls.Add(txtCorreo)
    pnlLogin.Controls.Add(btnIngresar)
    pnlLogin.Controls.Add(btnSalir)
    pnlLogin.Controls.Add(lblPassword)
    pnlLogin.Controls.Add(lblCorreo)
    pnlLogin.Location = New Point(46, 60)
    pnlLogin.Name = "pnlLogin"
    pnlLogin.Size = New Size(246, 231)
    pnlLogin.TabIndex = 0
    ' 
    ' txtPassword
    ' 
    txtPassword.Location = New Point(38, 118)
    txtPassword.Name = "txtPassword"
    txtPassword.PasswordChar = "*"c
    txtPassword.Size = New Size(165, 23)
    txtPassword.TabIndex = 3
    txtPassword.Text = "papucho"
    ' 
    ' txtCorreo
    ' 
    txtCorreo.Location = New Point(38, 52)
    txtCorreo.Name = "txtCorreo"
    txtCorreo.Size = New Size(165, 23)
    txtCorreo.TabIndex = 1
    txtCorreo.Text = "eladiovch@gmail.com"
    ' 
    ' btnIngresar
    ' 
    btnIngresar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnIngresar.FlatStyle = FlatStyle.Flat
    btnIngresar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnIngresar.ForeColor = Color.White
    btnIngresar.Location = New Point(130, 163)
    btnIngresar.Name = "btnIngresar"
    btnIngresar.Size = New Size(98, 43)
    btnIngresar.TabIndex = 5
    btnIngresar.Text = "Ingresar"
    btnIngresar.UseVisualStyleBackColor = True
    ' 
    ' btnSalir
    ' 
    btnSalir.BackColor = Color.IndianRed
    btnSalir.FlatStyle = FlatStyle.Flat
    btnSalir.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    btnSalir.ForeColor = Color.White
    btnSalir.Location = New Point(13, 163)
    btnSalir.Name = "btnSalir"
    btnSalir.Size = New Size(98, 43)
    btnSalir.TabIndex = 4
    btnSalir.Text = "Salir"
    btnSalir.UseVisualStyleBackColor = False
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
    lblBienvenidos.BackColor = Color.Transparent
    lblBienvenidos.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    lblBienvenidos.ForeColor = Color.FromArgb(CByte(43), CByte(98), CByte(138))
    lblBienvenidos.Location = New Point(3, 9)
    lblBienvenidos.Name = "lblBienvenidos"
    lblBienvenidos.Size = New Size(638, 32)
    lblBienvenidos.TabIndex = 1
    lblBienvenidos.Text = "Bienvenidos a Clinica Server...."
    lblBienvenidos.TextAlign = ContentAlignment.MiddleCenter
    ' 
    ' frmLogin
    ' 
    AutoScaleDimensions = New SizeF(7.0F, 15.0F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
    BackgroundImageLayout = ImageLayout.Stretch
    ClientSize = New Size(642, 371)
    Controls.Add(lblBienvenidos)
    Controls.Add(pnlLogin)
    DoubleBuffered = True
    FormBorderStyle = FormBorderStyle.FixedToolWindow
    MaximumSize = New Size(658, 410)
    MinimizeBox = False
    MinimumSize = New Size(658, 410)
    Name = "frmLogin"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Ingreso al Sistema"
    pnlLogin.ResumeLayout(False)
    pnlLogin.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents pnlLogin As Panel
  Friend WithEvents btnIngresar As Button
  Friend WithEvents btnSalir As Button
  Friend WithEvents lblPassword As Label
  Friend WithEvents lblCorreo As Label
  Friend WithEvents txtPassword As TextBox
  Friend WithEvents txtCorreo As TextBox
  Friend WithEvents lblBienvenidos As Label

End Class
