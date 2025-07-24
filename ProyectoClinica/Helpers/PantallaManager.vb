Public Class PantallaManager

  Private Shared stackPantallas As New Stack(Of Form)
  Private Shared panelContenedor As Panel

  ''' <summary>
  ''' Inicializa el panel contenedor donde se empotrarán los formularios hijos.
  ''' </summary>
  ''' <param name="panel">Panel del formulario principal.</param>
  Public Shared Sub Inicializar(panel As Panel)
    panelContenedor = panel
  End Sub

  ''' <summary>
  ''' Empotra un formulario hijo dentro del panel definido, con validación para no cargar duplicados.
  ''' </summary>
  ''' <param name="pantallaHija">Formulario a mostrar.</param>
  ''' <param name="pantallaPadre">Formulario desde donde se llama, se almacena en Tag.</param>
  Public Shared Sub LlamarPantallaHija(pantallaHija As Form, pantallaPadre As Form)
    If panelContenedor Is Nothing Then
      Throw New InvalidOperationException("El panel contenedor no ha sido inicializado.")
    End If

    ' Validación de doble carga: si ya está mostrado ese mismo formulario, salir
    If stackPantallas.Count > 0 AndAlso stackPantallas.Peek().GetType() Is pantallaHija.GetType() Then
      Return
    End If

    ' Asignar el formulario padre como referencia
    pantallaHija.Tag = pantallaPadre

    ' Preparar el formulario para ser embebido
    pantallaHija.TopLevel = False
    pantallaHija.FormBorderStyle = FormBorderStyle.None
    pantallaHija.Dock = DockStyle.None
    pantallaHija.Location = New Point(0, 0)

    ' Agregar al stack de navegación
    stackPantallas.Push(pantallaHija)

    ' Limpiar el panel y mostrar nuevo formulario
    panelContenedor.AutoScroll = True
    panelContenedor.Controls.Clear()
    'Para forzar el scroll
    'Dim dummy As New Label()
    'dummy.Location = New Point(800, 750)
    'dummy.Size = New Size(1, 1)
    'panelContenedor.Controls.Add(dummy)
    panelContenedor.Controls.Add(pantallaHija)

    ' Si implementa la interfaz, ajustar la pantalla
    If TypeOf pantallaHija Is IFormularios Then
      CType(pantallaHija, IFormularios).AjustarPantalla()
    End If

    pantallaHija.Show()
  End Sub

  ''' <summary>
  ''' Retorna al formulario anterior si existe en el stack.
  ''' </summary>
  Public Shared Sub VolverAtras()
    If stackPantallas.Count > 1 Then
      ' Eliminar la pantalla actual
      Dim pantallaActual As Form = stackPantallas.Pop()
      pantallaActual.Close()

      ' Recuperar la anterior
      Dim anterior As Form = stackPantallas.Peek()

      panelContenedor.Controls.Clear()
      panelContenedor.Controls.Add(anterior)
      anterior.Show()
    End If
  End Sub

  ''' <summary>
  ''' Cierra el formulario actual y vuelve al anterior en el stack.
  ''' </summary>
  Public Shared Sub RegresarDesdeFormularioHijo()
    If stackPantallas.Count > 1 Then
      Dim pantallaActual As Form = stackPantallas.Pop()
      pantallaActual.Close()

      Dim pantallaAnterior As Form = stackPantallas.Peek()
      panelContenedor.Controls.Clear()
      panelContenedor.Controls.Add(pantallaAnterior)
      pantallaAnterior.Show()
      If TypeOf pantallaAnterior Is IFormularios Then
        CType(pantallaAnterior, IFormularios).AjustarPantalla()
      End If
    Else
      Dim pantallaActual As Form = stackPantallas.Pop()
      pantallaActual.Close()
      panelContenedor.Controls.Clear()
    End If
  End Sub

  ''' <summary>
  ''' Cierra todos los formularios contenidos en la pila de navegación sin eliminar la referencia al panel contenedor.
  ''' </summary>
  ''' <remarks>
  ''' Este método se utiliza cuando se desea limpiar las pantallas embebidas actualmente mostradas,
  ''' pero manteniendo disponible el panel para futuras operaciones.
  ''' No establece en Nothing el panel contenedor, a diferencia del método <c>Finalizar</c>.
  ''' </remarks>
  Public Shared Sub Limpiar()
    ' Cerrar formularios del stack
    While stackPantallas.Count > 0
      Dim form As Form = stackPantallas.Pop()
      If form IsNot Nothing AndAlso Not form.IsDisposed Then
        form.Close()
      End If
    End While

    ' Limpiar el contenido del panel si está seteado
    If panelContenedor IsNot Nothing Then
      panelContenedor.Controls.Clear()
    End If
  End Sub

  ''' <summary>
  ''' Libera todos los formularios actualmente almacenados en la pila de navegación.
  ''' Cierra cada formulario (si aún no ha sido cerrado) y limpia la referencia al panel contenedor.
  ''' </summary>
  ''' <remarks>
  ''' Este método debe utilizarse cuando se desea terminar completamente el flujo de navegación de pantallas,
  ''' como por ejemplo al cerrar la aplicación, cerrar sesión o reiniciar la interfaz.
  ''' </remarks>
  Public Shared Sub Finalizar()
    ' Cerrar formularios del stack
    While stackPantallas.Count > 0
      Dim form As Form = stackPantallas.Pop()
      If form IsNot Nothing AndAlso Not form.IsDisposed Then
        form.Close()
      End If
    End While

    ' Limpiar el contenido del panel si está seteado
    If panelContenedor IsNot Nothing Then
      panelContenedor.Controls.Clear()
      panelContenedor = Nothing
    End If
  End Sub

End Class
