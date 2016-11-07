Imports Entity._0App.SettingsViews
Imports Entity._0App
Imports Entity._0App.Views
Imports Entity._4Classes.Types
Imports Entity._6Misc
Namespace _3Modules
    Module Tabs
        ' cache for settings tabs
        Public SettingsCache(2) As Control
        ' caches for speeding up view load time
        Public ViewCache(4) As Control

        ''' <summary>
        '''     The currently opened view
        ''' </summary>
        ''' <remarks></remarks>
        Public CurView As EntityView = EntityView.Null

        Public Enum EntityView
            Home = 0
            Lights = 1
            Audio = 2
            Images = 3
            Cues = 4
            Null = 5
        End Enum
        ''' <summary>
        '''     Initialize all views. Must be called before app can be used.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitViews()
            Try
                ViewCache(0) = New Vw0Home
                ViewCache(1) = New Vw1Light
                ViewCache(2) = New Vw2Audio
                ViewCache(3) = New Vw3Images
                ViewCache(4) = New Vw4Cues
                ViewCache(4).Dock = DockStyle.Fill
            Catch ex As Exception
                MsgBox(
                    "UI Init Error 1: Failed to initialize main UI. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     Initializes all settings form views. Must be called before settings form can be used.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitSettings()
            Try
                SettingsCache(0) = New Svw0Projection
                SettingsCache(1) = New Svw1Resources
                SettingsCache(2) = New svw2Admin
            Catch ex As Exception
                MsgBox(
                    "UI Init Error 2: Failed to initialize settings UI. Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     Checks all settings form views and re-initializes them if they are null.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ReInitSettings()
            Try
                If SettingsCache(0) Is Nothing Then SettingsCache(0) = New Svw0Projection
                If SettingsCache(1) Is Nothing Then SettingsCache(1) = New Svw1Resources
                If SettingsCache(2) Is Nothing Then SettingsCache(2) = New svw2Admin
            Catch ex As Exception
                MsgBox(
                    "UI Init Error 3: Failed to renew settings UI. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub

        ''' <summary>
        '''     Changes the currently displayed view in frmViewer
        ''' </summary>
        ''' <param name="view">the view to change to</param>
        ''' <remarks></remarks>
        Public Sub ChangeView(ByVal view As EntityView)
            Try
                'doesn't do anything if the view is already set to the intended view
                If view = CurView Then Exit Sub
                'black out lights
                For i As Integer = 0 To 511
                    DmxEngine.SetDmxValue(i, 0)
                Next

                'unselect all tabs
                For Each c As Control In Frm3Viewer.tabsflow.Controls
                    If CInt(c.Tag) <> 2 Then
                        selectTab(DirectCast(c, Button), False)
                    End If
                Next
                'clears the viewer
                Frm3Viewer.viewer.Controls.Clear()
                Select Case view
                    Case EntityView.Home
                        Frm3Viewer.viewer.Controls.Add(ViewCache(0))
                        selectTab(Frm3Viewer.tabHome)
                    Case EntityView.Lights
                        Frm3Viewer.viewer.Controls.Add(ViewCache(1))
                        selectTab(Frm3Viewer.tabSubs)
                    Case EntityView.Audio
                        Frm3Viewer.viewer.Controls.Add(ViewCache(2))
                        selectTab(Frm3Viewer.tabAud)
                    Case EntityView.Images
                        Frm3Viewer.viewer.Controls.Add(ViewCache(3))
                        selectTab(Frm3Viewer.tabImg)
                    Case EntityView.Cues
                        Frm3Viewer.viewer.Controls.Add(ViewCache(4))
                        Dim vw As Vw4Cues = DirectCast(ViewCache(4), Vw4Cues)
                        If vw.lv.SelectedItems.Count = 1 Then
                            Dim i As ListViewItem = vw.lv.SelectedItems(0)
                            i.Selected = False
                            i.Selected = True
                        End If
                        selectTab(Frm3Viewer.tabCues)
                    Case Else
                        'exit so current view is not set
                        Exit Sub
                End Select
                Frm3Viewer.viewer.Refresh()
                If Not (view = EntityView.Images Or view = EntityView.Cues) Then
                    SecondMonitor.pb.Image = Nothing
                    SecondMonitor.pb.BackgroundImage = Nothing
                    GC.Collect()
                End If
                'set current view
                CurView = view
            Catch ex As Exception
                MsgBox(
                    "Viewer Error 1: Failed to change tab. Detailed info displayed below:" & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     styles a tab in frmViewer to selected or deselected
        ''' </summary>
        ''' <param name="tab">the tab to select or deselect</param>
        ''' <param name="selected">optional. if false, deselects the tab</param>
        ''' <remarks></remarks>
        Private Sub selectTab(ByVal tab As Button, Optional ByVal selected As Boolean = True)
            Try
                Frm3Viewer.viewer.Focus()
                If selected = True Then
                    tab.BackColor = Color.WhiteSmoke
                    tab.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                    tab.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                    tab.Height = 38
                    tab.Margin = New Padding(0, 7, 0, 3)
                Else
                    tab.BackColor = Color.Gainsboro
                    tab.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100)
                    tab.FlatAppearance.MouseOverBackColor = Color.FromArgb(170, 170, 170)
                    tab.Margin = New Padding(0, 10, 0, 3)
                    tab.Height = 35
                End If
            Catch ex As Exception
                MsgBox(
                    "Viewer Error 2: Failed to apply style on tab. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub
    End Module
End Namespace