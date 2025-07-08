<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCrearDoctor
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
        txtDireccion = New TextBox()
        lblDireccion = New Label()
        cmbSexo = New ComboBox()
        txtEdad = New TextBox()
        lblEdad = New Label()
        txtTelefono = New TextBox()
        lblTelefono = New Label()
        txtApellido = New TextBox()
        lblApellido = New Label()
        txtNombre = New TextBox()
        lblNombre = New Label()
        lblSexo = New Label()
        txtCorreo = New TextBox()
        lblCorreo = New Label()
        txtIdentificacion = New TextBox()
        lblIdentificacion = New Label()
        btnRegresar = New Button()
        btnCrear = New Button()
        cmbEspecialidad = New ComboBox()
        grbEspecialidad = New GroupBox()
        grbUsuario = New GroupBox()
        cmbUsuario = New ComboBox()
        grbData.SuspendLayout()
        grbEspecialidad.SuspendLayout()
        grbUsuario.SuspendLayout()
        SuspendLayout()
        ' 
        ' grbData
        ' 
        grbData.Controls.Add(txtDireccion)
        grbData.Controls.Add(lblDireccion)
        grbData.Controls.Add(cmbSexo)
        grbData.Controls.Add(txtEdad)
        grbData.Controls.Add(lblEdad)
        grbData.Controls.Add(txtTelefono)
        grbData.Controls.Add(lblTelefono)
        grbData.Controls.Add(txtApellido)
        grbData.Controls.Add(lblApellido)
        grbData.Controls.Add(txtNombre)
        grbData.Controls.Add(lblNombre)
        grbData.Controls.Add(lblSexo)
        grbData.Controls.Add(txtCorreo)
        grbData.Controls.Add(lblCorreo)
        grbData.Controls.Add(txtIdentificacion)
        grbData.Controls.Add(lblIdentificacion)
        grbData.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grbData.Location = New Point(27, 30)
        grbData.Name = "grbData"
        grbData.Size = New Size(541, 524)
        grbData.TabIndex = 0
        grbData.TabStop = False
        grbData.Text = "Datos  Doctor"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtDireccion.Location = New Point(198, 401)
        txtDireccion.Multiline = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(316, 112)
        txtDireccion.TabIndex = 15
        ' 
        ' lblDireccion
        ' 
        lblDireccion.AutoSize = True
        lblDireccion.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDireccion.Location = New Point(81, 402)
        lblDireccion.Name = "lblDireccion"
        lblDireccion.Size = New Size(111, 30)
        lblDireccion.TabIndex = 14
        lblDireccion.Text = "Dirección:"
        ' 
        ' cmbSexo
        ' 
        cmbSexo.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbSexo.FormattingEnabled = True
        cmbSexo.Items.AddRange(New Object() {"Mujer", "Hombre", "Otro"})
        cmbSexo.Location = New Point(198, 357)
        cmbSexo.Name = "cmbSexo"
        cmbSexo.Size = New Size(316, 38)
        cmbSexo.TabIndex = 13
        ' 
        ' txtEdad
        ' 
        txtEdad.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtEdad.Location = New Point(198, 307)
        txtEdad.Name = "txtEdad"
        txtEdad.Size = New Size(316, 35)
        txtEdad.TabIndex = 11
        ' 
        ' lblEdad
        ' 
        lblEdad.AutoSize = True
        lblEdad.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEdad.Location = New Point(125, 312)
        lblEdad.Name = "lblEdad"
        lblEdad.Size = New Size(67, 30)
        lblEdad.TabIndex = 10
        lblEdad.Text = "Edad:"
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtTelefono.Location = New Point(198, 201)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(316, 35)
        txtTelefono.TabIndex = 7
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTelefono.Location = New Point(88, 206)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(104, 30)
        lblTelefono.TabIndex = 6
        lblTelefono.Text = "Teléfono:"
        ' 
        ' txtApellido
        ' 
        txtApellido.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtApellido.Location = New Point(198, 148)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(316, 35)
        txtApellido.TabIndex = 5
        ' 
        ' lblApellido
        ' 
        lblApellido.AutoSize = True
        lblApellido.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblApellido.Location = New Point(90, 153)
        lblApellido.Name = "lblApellido"
        lblApellido.Size = New Size(102, 30)
        lblApellido.TabIndex = 4
        lblApellido.Text = "Apellido:"
        ' 
        ' txtNombre
        ' 
        txtNombre.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtNombre.Location = New Point(198, 95)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(316, 35)
        txtNombre.TabIndex = 3
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNombre.Location = New Point(92, 100)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(100, 30)
        lblNombre.TabIndex = 2
        lblNombre.Text = "Nombre:"
        ' 
        ' lblSexo
        ' 
        lblSexo.AutoSize = True
        lblSexo.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSexo.Location = New Point(125, 365)
        lblSexo.Name = "lblSexo"
        lblSexo.Size = New Size(67, 30)
        lblSexo.TabIndex = 12
        lblSexo.Text = "Sexo:"
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtCorreo.Location = New Point(198, 254)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(316, 35)
        txtCorreo.TabIndex = 9
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCorreo.Location = New Point(21, 259)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(171, 30)
        lblCorreo.TabIndex = 8
        lblCorreo.Text = "Ingresar Correo:"
        ' 
        ' txtIdentificacion
        ' 
        txtIdentificacion.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtIdentificacion.Location = New Point(198, 42)
        txtIdentificacion.Name = "txtIdentificacion"
        txtIdentificacion.Size = New Size(316, 35)
        txtIdentificacion.TabIndex = 1
        ' 
        ' lblIdentificacion
        ' 
        lblIdentificacion.AutoSize = True
        lblIdentificacion.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblIdentificacion.Location = New Point(38, 47)
        lblIdentificacion.Name = "lblIdentificacion"
        lblIdentificacion.Size = New Size(154, 30)
        lblIdentificacion.TabIndex = 0
        lblIdentificacion.Text = "Identificación:"
        ' 
        ' btnRegresar
        ' 
        btnRegresar.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
        btnRegresar.Location = New Point(591, 496)
        btnRegresar.Name = "btnRegresar"
        btnRegresar.Size = New Size(154, 58)
        btnRegresar.TabIndex = 4
        btnRegresar.Text = "Regresar"
        btnRegresar.UseVisualStyleBackColor = True
        ' 
        ' btnCrear
        ' 
        btnCrear.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold)
        btnCrear.Location = New Point(591, 404)
        btnCrear.Name = "btnCrear"
        btnCrear.Size = New Size(154, 58)
        btnCrear.TabIndex = 3
        btnCrear.Text = "Crear"
        btnCrear.UseVisualStyleBackColor = True
        ' 
        ' cmbEspecialidad
        ' 
        cmbEspecialidad.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbEspecialidad.FormattingEnabled = True
        cmbEspecialidad.Location = New Point(6, 58)
        cmbEspecialidad.Name = "cmbEspecialidad"
        cmbEspecialidad.Size = New Size(238, 38)
        cmbEspecialidad.TabIndex = 0
        ' 
        ' grbEspecialidad
        ' 
        grbEspecialidad.Controls.Add(cmbEspecialidad)
        grbEspecialidad.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold)
        grbEspecialidad.Location = New Point(574, 30)
        grbEspecialidad.Name = "grbEspecialidad"
        grbEspecialidad.Size = New Size(260, 119)
        grbEspecialidad.TabIndex = 1
        grbEspecialidad.TabStop = False
        grbEspecialidad.Text = "Especialidad"
        ' 
        ' grbUsuario
        ' 
        grbUsuario.Controls.Add(cmbUsuario)
        grbUsuario.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold)
        grbUsuario.Location = New Point(574, 173)
        grbUsuario.Name = "grbUsuario"
        grbUsuario.Size = New Size(260, 119)
        grbUsuario.TabIndex = 2
        grbUsuario.TabStop = False
        grbUsuario.Text = "Usuario"
        ' 
        ' cmbUsuario
        ' 
        cmbUsuario.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbUsuario.FormattingEnabled = True
        cmbUsuario.Location = New Point(6, 42)
        cmbUsuario.Name = "cmbUsuario"
        cmbUsuario.Size = New Size(238, 38)
        cmbUsuario.TabIndex = 0
        ' 
        ' frmCrearDoctor
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(858, 561)
        Controls.Add(grbUsuario)
        Controls.Add(grbEspecialidad)
        Controls.Add(grbData)
        Controls.Add(btnRegresar)
        Controls.Add(btnCrear)
        Name = "frmCrearDoctor"
        Text = "Crear Doctor"
        grbData.ResumeLayout(False)
        grbData.PerformLayout()
        grbEspecialidad.ResumeLayout(False)
        grbUsuario.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents grbData As GroupBox
    Friend WithEvents lblEspecialidad As Label
    Friend WithEvents lblSexo As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents lblCorreo As Label
    Friend WithEvents txtIdentificacion As TextBox
    Friend WithEvents lblIdentificacion As Label
    Friend WithEvents btnRegresar As Button
    Friend WithEvents btnCrear As Button
    Friend WithEvents cmbEspecialidad As ComboBox
    Friend WithEvents txtEdad As TextBox
    Friend WithEvents lblEdad As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblTelefono As Label
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents lblApellido As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents cmbSexo As ComboBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents lblDireccion As Label
    Friend WithEvents grbEspecialidad As GroupBox
    Friend WithEvents grbUsuario As GroupBox
    Friend WithEvents cmbUsuario As ComboBox
End Class
