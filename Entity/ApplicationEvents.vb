Imports Entity._1Dialogs.Popups
Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApp_NetChange(sender As Object, e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) _
            Handles Me.NetworkAvailabilityChanged
            If e.IsNetworkAvailable Then
                Try
                    If Not DiagCOM.Visible Then
                        DiagCOM.Show()
                        DiagCOM.Hide()
                    End If
                Catch ex As Exception
                End Try
            End If
        End Sub
    End Class


End Namespace

