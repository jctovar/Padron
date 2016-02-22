Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Me.Search()
    End Sub
    Private Sub Search()
        Dim request As WebRequest = WebRequest.Create("https://galadriel.ired.unam.mx:3000/padron/068589242")
        request.ContentType = "application/json; charset=utf-8"
        Dim response As WebResponse = request.GetResponse()

        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Console.WriteLine(responseFromServer)


        responseFromServer = "{""student"":" + responseFromServer + "}"


        Dim obj As Container
        obj = JsonConvert.DeserializeObject(Of Container)(responseFromServer)

        txtUsername.Text = obj.student(0).username.ToString
        txtFirstname.Text = obj.student(0).firstname.ToString
        txtLastname.Text = obj.student(0).lastname.ToString
        txtEmail.Text = obj.student(0).email.ToString
        txtField.Text = obj.student(0).career_name.ToString
        txtGeneration.Text = obj.student(0).generation.ToString
        'txtUsername.Text = obj.student(0).curp.ToString



        ' Clean up the streams and the response.
        reader.Close()
        response.Close()

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
End Class
