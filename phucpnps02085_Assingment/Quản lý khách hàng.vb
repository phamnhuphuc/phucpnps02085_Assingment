Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmQuanlykh
    Dim chuoiketnoi As String = "workstation id=phucpnps02085.mssql.somee.com;packet size=4096;user id=phucpn;pwd=tjpdmagg7;data source=phucpnps02085.mssql.somee.com;persist security info=False;initial catalog=phucpnps02085"
    Dim cosoDL As New DataTable
    Private Sub frmQuanlykh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Connect As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query1 As SqlDataAdapter = New SqlDataAdapter("select * from KhachHang", chuoiketnoi)
        Connect.Open()
        Query1.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtMakh.Text = DataGridView1.Item(0, index).Value
        txtTenkh.Text = DataGridView1.Item(1, index).Value
        txtSodt.Text = DataGridView1.Item(2, index).Value
        txtDiachi.Text = DataGridView1.Item(3, index).Value
    End Sub


    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query2 As String = "insert into KhachHang values (@makhachhang,@tenkhachhang,@sodt,@diachi)"
        Dim Run As New SqlCommand(Query2, Connection)
        Connection.Open()


        Run.Parameters.AddWithValue("@makhachhang", txtMakh.Text)
        Run.Parameters.AddWithValue("@tenkhachhang", txtTenkh.Text)
        Run.Parameters.AddWithValue("@sodt", txtSodt.Text)
        Run.Parameters.AddWithValue("@diachi", txtDiachi.Text)

        Run.ExecuteNonQuery()

        MessageBox.Show("Đã thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim Query3 As SqlDataAdapter = New SqlDataAdapter("select * from KhachHang", Connection)
        cosoDL.Clear()

        Query3.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
        Connection.Close()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query4 As String = "Update KhachHang Set Makhachhang= @makhachhang, Tenkhachhang= @tenkhachhang, SoDT= @sodt,DiaChi= @diachi Where Makhachhang= @makhachhang"
        Dim Run2 As New SqlCommand(Query4, Connection)
        Connection.Open()
        Run2.Parameters.AddWithValue("@makhachhang", txtMakh.Text)
        Run2.Parameters.AddWithValue("@tenkhachhang", txtTenkh.Text)

        Run2.Parameters.AddWithValue("@sodt", txtSodt.Text)
        Run2.Parameters.AddWithValue("@diachi", txtDiachi.Text)
        Run2.ExecuteNonQuery()
        MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim CommandSELECT As SqlDataAdapter = New SqlDataAdapter("select * from KhachHang", Connection)
        cosoDL.Clear()

        CommandSELECT.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim CommandQuery As String = " Delete from KhachHang Where Makhachhang=@makhachhang"
        Dim RunCommand As New SqlCommand(CommandQuery, Connection)
        Connection.Open()
        RunCommand.Parameters.AddWithValue("makhachhang", txtMakh.Text)
        RunCommand.ExecuteNonQuery()
        MessageBox.Show("Bạn đã xóa khách hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim Run4 As SqlDataAdapter = New SqlDataAdapter("Select * from KhachHang", Connection)
        cosoDL.Clear()
        Run4.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub
End Class