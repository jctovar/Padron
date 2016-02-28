Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Class MainWindow
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Title = My.Application.Info.Title


        Me.Login()

        txtUsername.Focus()
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If validateUsername(txtUsername.Text) Then
            Me.GetStudent(txtUsername.Text)
        Else
            MessageBox.Show("Ingresa un número de cuenta valido!", My.Application.Info.Title, MessageBoxButton.OK, MessageBoxImage.Error)

            txtUsername.Focus() 'Return Focus
            txtUsername.Clear() 'Clear TextBox
        End If
    End Sub
    Private Sub GetStudent(username As String)
        Dim request As WebRequest
        Dim response As WebResponse = Nothing
        Dim reader As StreamReader = Nothing
        Dim obj As Container

        Dim geturl As String = String.Format("https://galadriel.ired.unam.mx:3000/padron/{0}", username)

        Try
            ' Create the web request  
            request = DirectCast(WebRequest.Create(geturl), HttpWebRequest)
            request.Headers.Add("Authorization", "Basic " + BasicAuth(My.Settings.Username, My.Settings.Password))

            ' Get response  
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Get the response stream into a reader  
            reader = New StreamReader(response.GetResponseStream())

            ' Console application output  
            Dim jsontext As String = reader.ReadToEnd()
            ' Display the content.
            Console.WriteLine(jsontext)

            obj = JsonConvert.DeserializeObject(Of Container)(jsontext)

            txtFirstname.Text = obj.student(0).firstname.ToString
            txtLastname.Text = obj.student(0).lastname.ToString
            txtEmail.Text = obj.student(0).email.ToString
            txtField.Text = obj.student(0).career_name.ToString
            txtGeneration.Text = obj.student(0).generation.ToString
            txtPhone.Text = obj.student(0).phone.ToString
            txtPostalCode.Text = obj.student(0).postal_code.ToString
            txtPassword.Text = obj.student(0).password.ToString
            txtCurp.Text = obj.student(0).curp.ToString
            txtHeadquarters.Text = obj.student(0).headquarters.ToString

            ' Clean up the streams and the response.

        Catch ex As Exception
            ' Show the exception's message.
            'MessageBox.Show(ex.Message)
            MessageBox.Show("No se encontro un registro valido, verifique!", My.Application.Info.Title, MessageBoxButton.OK, MessageBoxImage.Error) 'Inform User
        Finally
            If Not response Is Nothing Then response.Close()
            txtUsername.Focus() 'Return Focus
            reader.Close()
            response.Close()
        End Try


    End Sub
    Public Class Container
        Public student As List(Of StudentInfo)
    End Class
    Public Class StudentInfo
        Public username As String
        Public firstname As String
        Public lastname As String
        Public email As String
        Public password As String
        Public phone As String
        Public postal_code As String
        Public curp As String
        Public generation As String
        Public headquarters As String
        Public career_name As String
    End Class
    Private Function validateUsername(varUsername As String) As Boolean
        If Not Regex.Match(varUsername, "^[0-9]{9}$", RegexOptions.IgnoreCase).Success Then 'Only Letters
            Return False 'Boolean = False
        Else
            Return True 'Everything Fine
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub MenuItem_Click_2(sender As Object, e As RoutedEventArgs)
        Dim frmAbout As New About

        frmAbout.ShowDialog()
    End Sub

    Public Function BasicAuth(strUsername As String, strPass As String) As String
        Dim authInfo As String = strUsername + ":" + strPass

        authInfo = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authInfo))

        Return authInfo
    End Function

    Private Sub Login()
        Dim frmLogin As New Login

        If frmLogin.ShowDialog = True Then
        Else
            Me.Close()
        End If
    End Sub
End Class
