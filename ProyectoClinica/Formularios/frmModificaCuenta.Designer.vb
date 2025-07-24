<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmModificaCuenta
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
    btnRegresar = New Button()
    btnModificar = New Button()
    cboTipoUsuario = New ComboBox()
    Label3 = New Label()
    txtCorreo = New TextBox()
    Label1 = New Label()
    txtNombre = New TextBox()
    lblNombre = New Label()
    rrPError = New ErrorProvider(components)
    grbData.SuspendLayout()
    CType(rrPError, ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    ' 
    ' grbData
    ' 
    grbData.BackColor = Color.Transparent
    grbData.Controls.Add(btnRegresar)
    grbData.Controls.Add(btnModificar)
    grbData.Controls.Add(cboTipoUsuario)
    grbData.Controls.Add(Label3)
    grbData.Controls.Add(txtCorreo)
    grbData.Controls.Add(Label1)
    grbData.Controls.Add(txtNombre)
    grbData.Controls.Add(lblNombre)
    grbData.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    grbData.Location = New Point(27, 30)
    grbData.Name = "grbData"
    grbData.Size = New Size(631, 300)
    grbData.TabIndex = 0
    grbData.TabStop = False
    grbData.Text = "Datos"
    ' 
    ' btnRegresar
    ' 
    btnRegresar.BackColor = Color.IndianRed
    btnRegresar.FlatStyle = FlatStyle.Flat
    btnRegresar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnRegresar.ForeColor = Color.White
    btnRegresar.Location = New Point(143, 213)
    btnRegresar.Name = "btnRegresar"
    btnRegresar.Size = New Size(154, 58)
    btnRegresar.TabIndex = 9
    btnRegresar.Text = "Regresar"
    btnRegresar.UseVisualStyleBackColor = True
    ' 
    ' btnModificar
    ' 
    btnModificar.BackColor = Color.FromArgb(CByte(62), CByte(140), CByte(195))
    btnModificar.FlatAppearance.BorderColor = Color.FromArgb(CByte(165), CByte(200), CByte(226))
    btnModificar.FlatStyle = FlatStyle.Flat
    btnModificar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
    btnModificar.ForeColor = Color.White
    btnModificar.Location = New Point(334, 213)
    btnModificar.Name = "btnModificar"
    btnModificar.Size = New Size(154, 58)
    btnModificar.TabIndex = 8
    btnModificar.Text = "Modificar"
    btnModificar.UseVisualStyleBackColor = True
    ' 
    ' cboTipoUsuario
    ' 
    cboTipoUsuario.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    cboTipoUsuario.FormattingEnabled = True
    cboTipoUsuario.Items.AddRange(New Object() {"Administrador", "Paciente", "Doctor", "Secretaria"})
    cboTipoUsuario.Location = New Point(246, 140)
    cboTipoUsuario.Name = "cboTipoUsuario"
    cboTipoUsuario.Size = New Size(316, 33)
    cboTipoUsuario.TabIndex = 7
    ' 
    ' Label3
    ' 
    Label3.AutoSize = True
    Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    Label3.Location = New Point(96, 148)
    Label3.Name = "Label3"
    Label3.Size = New Size(131, 25)
    Label3.TabIndex = 6
    Label3.Text = "Tipo Usuario:"
    ' 
    ' txtCorreo
    ' 
    txtCorreo.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    txtCorreo.Location = New Point(246, 87)
    txtCorreo.Name = "txtCorreo"
    txtCorreo.Size = New Size(316, 33)
    txtCorreo.TabIndex = 3
    ' 
    ' Label1
    ' 
    Label1.AutoSize = True
    Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    Label1.Location = New Point(69, 95)
    Label1.Name = "Label1"
    Label1.Size = New Size(158, 25)
    Label1.TabIndex = 2
    Label1.Text = "Ingresar Correo:"
    ' 
    ' txtNombre
    ' 
    txtNombre.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    txtNombre.Location = New Point(246, 34)
    txtNombre.Name = "txtNombre"
    txtNombre.Size = New Size(316, 33)
    txtNombre.TabIndex = 1
    ' 
    ' lblNombre
    ' 
    lblNombre.AutoSize = True
    lblNombre.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold)
    lblNombre.Location = New Point(136, 42)
    lblNombre.Name = "lblNombre"
    lblNombre.Size = New Size(91, 25)
    lblNombre.TabIndex = 0
    lblNombre.Text = "Nombre:"
    ' 
    ' rrPError
    ' 
    rrPError.ContainerControl = Me
    ' 
    ' frmModificaCuenta
    ' 
    AutoScaleDimensions = New SizeF(7.0F, 15.0F)
    AutoScaleMode = AutoScaleMode.Font
    BackgroundImage = My.Resources.Resources.FondoApp
    ClientSize = New Size(689, 349)
    Controls.Add(grbData)
    Name = "frmModificaCuenta"
    StartPosition = FormStartPosition.CenterScreen
    Text = "Modificar Cuenta Usuario"
    grbData.ResumeLayout(False)
    grbData.PerformLayout()
    CType(rrPError, ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
  End Sub

  Friend WithEvents grbData As GroupBox
  Friend WithEvents Label3 As Label
  Friend WithEvents txtCorreo As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents txtNombre As TextBox
  Friend WithEvents lblNombre As Label
  Friend WithEvents btnRegresar As Button
  Friend WithEvents btnModificar As Button
  Friend WithEvents cboTipoUsuario As ComboBox
  Friend WithEvents rrPError As ErrorProvider
End Class
