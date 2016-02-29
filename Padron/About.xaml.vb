Imports System.Deployment
Public Class About
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Title = My.Application.Info.Title

        'Información de Copyright
        Copyright.Text = My.Application.Info.Copyright
    End Sub
End Class