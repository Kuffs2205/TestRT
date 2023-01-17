Imports BackendlessAPI

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        TestRT.Init()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TestRT.Subscribe()
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim NewTest = New Test() With {.Name = $"Test{CInt(Random.Shared.NextDouble * 1000)}", .Age = Random.Shared.NextDouble * 1000}
        Await Backendless.Data.Of(Of Test).SaveAsync(NewTest)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim NewTest = New Test() With {.Name = $"BlockingTest{CInt(Random.Shared.NextDouble * 1000)}", .Age = Random.Shared.NextDouble * 1000}
        'Backendless.Data.Of(Of Test).Save(NewTest)
        'MsgBox("Call has returned")

        Dim res = Backendless.Data.Of("Test").Save(New Dictionary(Of String, Object) From {{"foo", "gggg"}})
        MsgBox("Call has returned")

    End Sub
End Class

Public Class Test

    Public Property objectId As String
    Public Property Name As String
    Public Property Age As Integer
End Class
