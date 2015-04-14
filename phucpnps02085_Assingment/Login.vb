Imports System.Data.SqlClient
Public Class frm_Login
    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnDangnhap_Click(sender As Object, e As EventArgs) Handles btnDangnhap.Click
        Dim phucpnps02085 As String = "workstation id=phucpnps02085.mssql.somee.com;packet size=4096;user id=phucpn;pwd=tjpdmagg7;data source=phucpnps02085.mssql.somee.com;persist security info=False;initial catalog=phucpnps02085"
        Dim ketnoi As SqlClient.SqlConnection = New SqlConnection(phucpnps02085)
        Dim sqlAdapter As New SqlDataAdapter("Select * from NhanVien where Manhanvien = '" & txt_User.Text & "'and Password= '" & txt_Password.Text & "' ", ketnoi)
        Dim tb As New DataTable
        Try
            ketnoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmMain.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai Username hoặc Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClear_Click(sender As Object, e As EventArgs) Handles txtClear.Click
        txt_User.Clear()
        txt_Password.Clear()
        txt_User.Focus()
    End Sub
End Class
