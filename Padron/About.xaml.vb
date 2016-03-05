Imports System.Deployment.Application
Public Class About
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Title = My.Application.Info.Title

        'Información de Copyright
        Copyright.Text = My.Application.Info.Copyright

        ' Version.Text = My.Application.

        If System.Diagnostics.Debugger.IsAttached = False Then
            Me.Version.Text = String.Format("Versión {0}", Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString)
        Else
            Me.Version.Text = String.Format("Versión {0}", "Debug mode")
        End If
    End Sub
End Class