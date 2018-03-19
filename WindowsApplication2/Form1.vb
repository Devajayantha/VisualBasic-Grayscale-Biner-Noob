Public Class Form1

    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Dim ofdlg As OpenFileDialog = New OpenFileDialog()
        ofdlg.Filter = "Picture Files(*.jpg;*.bmp)|*.jpg;*.bmp"
        ofdlg.FilterIndex = 1
        If ofdlg.ShowDialog() = DialogResult.OK Then
            PictureBox1.ImageLocation = ofdlg.FileName

        End If
    End Sub

    Private Sub BtnGrayscale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrayscale.Click
        Dim gy As New Bitmap(PictureBox1.Image)
        Dim x As Integer
        Dim y As Integer
        Dim clr As Integer

        For x = 0 To gy.Width - 1
            For y = 0 To gy.Height - 1
                clr = (CInt(gy.GetPixel(x, y).R) + _
                    gy.GetPixel(x, y).G + _
                    gy.GetPixel(x, y).B) \ 3
                gy.SetPixel(x, y, Color.FromArgb(clr, clr, clr))
            Next
        Next
        PictureBox2.Image = gy

    End Sub

    Private Sub BtnBiner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBiner.Click
        Dim bnr As New Bitmap(PictureBox1.Image)
        Dim x As Integer
        Dim y As Integer
        Dim r, g, b, total As Integer
        Dim col As Color


        For x = 1 To bnr.Width - 1
            For y = 1 To bnr.Height - 1
                col = bnr.GetPixel(x, y)
                r = col.R
                g = col.G
                b = col.B
                total = (r + g + b) / 3
                If total > 128 Then
                    bnr.SetPixel(x, y, Color.White)
                Else
                    bnr.SetPixel(x, y, Color.Black)
                End If

            Next y
        Next x
        PictureBox3.Image = bnr
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

End Class
