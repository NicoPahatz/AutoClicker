Option Explicit On
Imports System
Imports System.Net

Public Class MainForm

    Dim vbKeyUp As Long
    Dim vbKeyDown As Long
    Dim wb As New WebClient
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8
    Private Const MOUSEEVENTF_RIGHTUP = &H10
    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Private Sub MainForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Label5.Text = "Läuft..."
        Timer1.Start()
        Me.BackColor = Color.Lime
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Label5.Text = "Gestoppt"
        Timer1.Stop()
        Label4.Text = "0"
        Me.BackColor = Color.Red
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Label4.Text + 1
        Timer1.Interval = SettingsForm.TextBox1.Text
        If SettingsForm.RadioButton1.Checked Then
            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        ElseIf SettingsForm.RadioButton2.Checked Then
            Call apimouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
            Call apimouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
        End If

    End Sub

    Private Sub KlickEinstellungenÄndernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KlickEinstellungenÄndernToolStripMenuItem.Click
        SettingsForm.ShowDialog()
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        InfoForm.ShowDialog()
    End Sub
End Class
