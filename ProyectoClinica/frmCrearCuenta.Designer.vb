<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCrearCuenta
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
    grbData = New GroupBox()
    btnRegresar = New Button()
    btnCrear = New Button()
    cboTipoUsuario = New ComboBox()
    Label3 = New Label()
    txtContrasena = New TextBox()
    Label2 = New Label()
    txtCorreo = New TextBox()
    Label1 = New Label()
    txtNombre = New TextBox()
    lblNombre = New Label()
    grbData.SuspendLayout()
    SuspendLayout()
    ' 
    ' grbData
    ' 
    grbData.Controls.Add(btnRegresar)
    grbData.Controls.Add(btnCrear)
    grbData.Controls.Add(cboTipoUsuario)
    grbData.Controls.Add(Label3)
    grbData.Controls.Add(txtContrasena)
    grbData.Controls.Add(Label2)
    grbData.Controls.Add(txtCorreo)
    grbData.Controls.Add(Label1)
    grbData.Controls.Add(txtNombre)
    grbData.Controls.Add(lblNombre)
    grbData.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    grbData.Location = New Point(27, 30)
    grbData.Name = "grbData"
    grbData.Size = New Size(631, 391)
    grbData.TabIndex = 0
    grbData.TabStop = False
    grbData.Text = "Crear Cuenta"
    ' 
    ' btnRegresar
    ' 
    btnRegresar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnRegresar.Location = New Point(360, 317)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(154, 58)
    btnRegresar.TabIndex = 9
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = True
    ' 
    ' btnCrear
    ' 
    btnCrear.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnCrear.Location = New Point(153, 317)
    btnCrear.Name = "btnCrear"
    btnCrear.Size = New Size(154, 58)
    btnCrear.TabIndex = 8
    btnCrear.Text = "Crear"
    btnCrear.UseVisualStyleBackColor = True
    ' 
    ' cboTipoUsuario
    ' 
    cboTipoUsuario.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    cboTipoUsuario.FormattingEnabled = True
    cboTipoUsuario.Items.AddRange(New Object() {"Administrador", "Paciente", "Doctor", "Secretaria"})
    cboTipoUsuario.Location = New Point(285, 237)
    cboTipoUsuario.Name = "cboTipoUsuario"
    cboTipoUsuario.Size = New Size(316, 38)
    cboTipoUsuario.TabIndex = 7
    ' 
    ' Label3
    ' 
    Label3.AutoSize = True
    Label3.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Label3.Location = New Point(135, 245)
    Label3.Name = "Label3"
    Label3.Size = New Size(144, 30)
    Label3.TabIndex = 6
    Label3.Text = "Tipo Usuario:"
    ' 
    ' txtContrasena
    ' 
    txtContrasena.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    txtContrasena.Location = New Point(285, 183)
    txtContrasena.Name = "txtContrasena"
    txtContrasena.PasswordChar = "*"c
    txtContrasena.Size = New Size(316, 35)
    txtContrasena.TabIndex = 5
    ' 
    ' Label2
    ' 
    Label2.AutoSize = True
    Label2.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Label2.Location = New Point(64, 183)
    Label2.Name = "Label2"
    Label2.Size = New Size(215, 30)
    Label2.TabIndex = 4
    Label2.Text = "Ingresar Contraseña:"
    ' 
    ' txtCorreo
    ' 
    txtCorreo.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    txtCorreo.Location = New Point(285, 119)
    txtCorreo.Name = "txtCorreo"
    txtCorreo.Size = New Size(316, 35)
    txtCorreo.TabIndex = 3
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Label1.Location = New Point(108, 124)
    Label1.Name = "Label1"
    Label1.Size = New Size(171, 30)
    Label1.TabIndex = 2
    Label1.Text = "Ingresar Correo:"
    ' 
    ' txtNombre
    ' 
    txtNombre.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    txtNombre.Location = New Point(285, 61)
    txtNombre.Name = "txtNombre"
    txtNombre.Size = New Size(316, 35)
    txtNombre.TabIndex = 1
    ' 
    ' lblNombre
    ' 
    lblNombre.AutoSize = True
    lblNombre.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    lblNombre.Location = New Point(179, 66)
    lblNombre.Name = "lblNombre"
    lblNombre.Size = New Size(100, 30)
    lblNombre.TabIndex = 0
    lblNombre.Text = "Nombre:"
    ' 
    ' frmCrearCuenta
    ' 
    AutoScaleDimensions = New SizeF(7F, 15F)
    AutoScaleMode = AutoScaleMode.Font
    ClientSize = New Size(689, 450)
    Controls.Add(grbData)
    Name = "frmCrearCuenta"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Crear Cuenta Usuario"
    grbData.ResumeLayout(False)
    grbData.PerformLayout()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbData As GroupBox
  Friend WithEvents Label3 As Label
  Friend WithEvents txtContrasena As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents txtCorreo As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents txtNombre As TextBox
  Friend WithEvents lblNombre As Label
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnCrear As Button
  Friend WithEvents cboTipoUsuario As ComboBox
End Class
