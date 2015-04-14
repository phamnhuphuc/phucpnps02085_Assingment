Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frm_Quanlysp
    Dim chuoiketnoi As String = "workstation id=phucpnps02085.mssql.somee.com;packet size=4096;user id=phucpn;pwd=tjpdmagg7;data source=phucpnps02085.mssql.somee.com;persist security info=False;initial catalog=phucpnps02085"
    Dim cosoDL As New DataTable
    Private Sub frm_Quanlysp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Connect As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query1 As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", chuoiketnoi)
        Connect.Open()
        Query1.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtMasp.Text = DataGridView1.Item(0, index).Value
        txtTensp.Text = DataGridView1.Item(1, index).Value
        txtDongia.Text = DataGridView1.Item(2, index).Value
        txtSoluong.Text = DataGridView1.Item(3, index).Value
        txtChitiet.Text = DataGridView1.Item(4, index).Value
        cbbMaloaisp.SelectedItem = DataGridView1.Item(5, index).Value
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query2 As String = "insert into SanPham values (@masp,@tensp,@dongia,@soluong,@chitietsp,@maloaisp)"
        Dim Run As New SqlCommand(Query2, Connection)
        Connection.Open()


        Run.Parameters.AddWithValue("@masp", txtMasp.Text)
        Run.Parameters.AddWithValue("@tensp", txtTensp.Text)
        Run.Parameters.AddWithValue("@dongia", txtDongia.Text)
        Run.Parameters.AddWithValue("@soluong", txtSoluong.Text)
        Run.Parameters.AddWithValue("@chitietsp", txtChitiet.Text)
        Run.Parameters.AddWithValue("@maloaisp", cbbMaloaisp.SelectedItem)

        Run.ExecuteNonQuery()

        MessageBox.Show("Đã thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim Query3 As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", Connection)
        cosoDL.Clear()

        Query3.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
        Connection.Close()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim Query4 As String = "Update SanPham Set MaSP= @masp, TenSP= @tensp, DonGia= @dongia,SoLuong= @soluong,ChiTietSP= @chitietsp,LoaiSanPham_MaLoaiSP= @maloaisp Where MaSP= @masp"
        Dim Run2 As New SqlCommand(Query4, Connection)
        Connection.Open()
        Run2.Parameters.AddWithValue("@masp", txtMasp.Text)
        Run2.Parameters.AddWithValue("@tensp", txtTensp.Text)

        Run2.Parameters.AddWithValue("@dongia", txtDongia.Text)
        Run2.Parameters.AddWithValue("@soluong", txtSoluong.Text)

        Run2.Parameters.AddWithValue("@chitietsp", txtChitiet.Text)
        Run2.Parameters.AddWithValue("@maloaisp", cbbMaloaisp.SelectedItem)
        Run2.ExecuteNonQuery()
        MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim CommandSELECT As SqlDataAdapter = New SqlDataAdapter("select * from SanPham", Connection)
        cosoDL.Clear()

        CommandSELECT.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim Connection As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim CommandQuery As String = " Delete from SanPham Where MaSP=@masp"
        Dim RunCommand As New SqlCommand(CommandQuery, Connection)
        Connection.Open()
        RunCommand.Parameters.AddWithValue("masp", txtMasp.Text)
        RunCommand.ExecuteNonQuery()
        MessageBox.Show("Bạn đã xóa sản phẩm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim Run4 As SqlDataAdapter = New SqlDataAdapter("Select * from SanPham", Connection)
        cosoDL.Clear()
        Run4.Fill(cosoDL)
        DataGridView1.DataSource = cosoDL.DefaultView
    End Sub
End Class
