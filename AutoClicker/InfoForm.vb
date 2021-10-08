Public Class InfoForm
    Private Sub InfoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ProductName
        Label2.Text = ProductVersion
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub InfoForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class