Public Class Login
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Title = My.Application.Info.Title

        txtUsername.Focus()

        txtUsername.Text = "jctovar@ired.unam.mx"
        txtPassword.Password = "12345678"

    End Sub
    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        Me.DialogResult = True
        Me.SaveConfig()
        Me.Close()
    End Sub
    Private Sub SaveConfig()


        My.Settings.Username = txtUsername.Text
        My.Settings.Password = txtPassword.Password

        My.Settings.Save()
    End Sub
End Class
