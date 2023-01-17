Imports BackendlessAPI


Public Class TestRT

    Public Shared Sub Init()
        Backendless.InitApp("4091BABD-BE94-1AF8-FF1C-E1CAB65DA400", "F54E5FC0-137E-45DE-AEA2-69804FD28294")
    End Sub

    Public Shared Sub Subscribe()
        Log("Subscribing")

        Dim eventHandler = Backendless.Data.Of("Test").RT

        Backendless.RT.AddConnectListener(New RT.ConnectListener(Sub()
                                                                     Log("Connected")
                                                                 End Sub))

        Backendless.RT.AddConnectErrorListener(New RT.ConnectErrorListener(Sub(a)
                                                                               Log($"Connect Error :{a.Message}")
                                                                           End Sub))

        Backendless.RT.AddDisconnectListener(New RT.DisconnectListener(Sub(reason)
                                                                           Log($"Disconnected - {reason}")
                                                                       End Sub))

        eventHandler.AddCreateListener(Sub(a)
                                           Log($"Created: {a}")
                                       End Sub)

        eventHandler.AddUpdateListener(Sub(a)
                                           Log($"Updated: {a}")
                                       End Sub)


        Log("Subscribed")

    End Sub

    Private Shared Sub Log(text As String)
        Debug.WriteLine($"{Date.Now:F} {text}")
    End Sub

End Class