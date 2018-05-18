﻿using SieuThiSach.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiSach.AllForm
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        DataLoading DatLoa = new DataLoading();
        DesignForm DesFor = new DesignForm();
        public string _Filter = "";
        private void loadDataMHforMonth()
        {
            if (_Filter == "")
                _Filter = " where thang = '" + txtMonth.Text + "' and nam = '" + txtYear.Text + "' and MA_DVI like '%" + txtMaDV.Text + 
                            "%' and (MA_HANG like '%" + txtMaHang.Text + "%' or TEN_HANG like N'%"+ txtMaHang.Text + "%') group by MA_DVI,MA_HANG,TEN_HANG,THANG,NAM ORDER BY NAM, THANG";
            DatLoa.loadData("MA_DVI,MA_HANG,TEN_HANG,THANG,NAM,sum(SL_NHAP) as SL_NHAP,sum(SL_XUAT) as SL_XUAT,sum(TONG_TIEN_NHAP)" +
                            " as TIEN_NHAP,sum(TONG_TIEN_XUAT) as TIEN_XUAT,sum(TONG_TIEN_XUAT) - sum(TONG_TIEN_NHAP) as DOANH_THU",
                            "V_BC_DoanhThu_MatHang " + _Filter, ref dataGridView1);
            DesFor.EditCollum(ref dataGridView1, "MA_DVI", true, "Mã đơn vị");
            DesFor.EditCollum(ref dataGridView1, "MA_HANG", true, "Mã hàng");
            DesFor.EditCollum(ref dataGridView1, "TEN_HANG", true, "Tên hàng");
            DesFor.EditCollum(ref dataGridView1, "THANG", true, "Tháng");
            DesFor.EditCollum(ref dataGridView1, "NAM", true, "Năm");
            DesFor.EditCollum(ref dataGridView1, "SL_NHAP", true, "SL Nhập");
            DesFor.EditCollum(ref dataGridView1, "SL_XUAT", true, "SL Xuất");
            DesFor.EditCollum(ref dataGridView1, "TIEN_NHAP", true, "Chi phí hàng");
            DesFor.EditCollum(ref dataGridView1, "TIEN_XUAT", true, "Doanh thu thuần");
            DesFor.EditCollum(ref dataGridView1, "DOANH_THU", true, "Lợi nhuận");
            _Filter = "";
        }

        private void loadDataMHforYear()
        {
            if (_Filter == "")
                _Filter = "  where nam = '" + txtYear.Text + "' and MA_DVI like '%" + txtMaDV.Text +
                            "%' and (MA_HANG like '%" + txtMaHang.Text + "%' or TEN_HANG like N'%" + txtMaHang.Text + "%') group by MA_DVI,MA_HANG,TEN_HANG,NAM ORDER BY NAM";
            DatLoa.loadData("MA_DVI,MA_HANG,TEN_HANG,NAM," +
                            "sum(SL_NHAP) as SL_NHAP, sum(SL_XUAT) as SL_XUAT, sum(TONG_TIEN_NHAP) as TIEN_NHAP, sum(TONG_TIEN_XUAT) as TIEN_XUAT," +
                            "sum(TONG_TIEN_XUAT) - sum(TONG_TIEN_NHAP) as DOANH_THU  ",
                            "V_BC_DoanhThu_MatHang " + _Filter, ref dataGridView1);
            DesFor.EditCollum(ref dataGridView1, "MA_DVI", true, "Mã đơn vị");
            DesFor.EditCollum(ref dataGridView1, "MA_HANG", true, "Mã hàng");
            DesFor.EditCollum(ref dataGridView1, "TEN_HANG", true, "Tên hàng");
            DesFor.EditCollum(ref dataGridView1, "NAM", true, "Năm");
            DesFor.EditCollum(ref dataGridView1, "SL_NHAP", true, "SL Nhập");
            DesFor.EditCollum(ref dataGridView1, "SL_XUAT", true, "SL Xuất");
            DesFor.EditCollum(ref dataGridView1, "TIEN_NHAP", true, "Chi phí hàng");
            DesFor.EditCollum(ref dataGridView1, "TIEN_XUAT", true, "Doanh thu thuần");
            DesFor.EditCollum(ref dataGridView1, "DOANH_THU", true, "Lợi nhuận");
            _Filter = "";
        }

        private void loadDataNHforMonth()
        {
            if (_Filter == "")
                _Filter = " where thang = '" + txtMonth.Text + "' and nam = '" + txtYear.Text + "' and MA_DVI like '%" + txtMaDV.Text +
                            "%' and (NHOM_HANG like '%" + txtNhomHang.Text + "%' or TEN_NHOM_HANG like N'%" + txtNhomHang.Text + "%') group by MA_DVI,NHOM_HANG,TEN_NHOM_HANG,NAM,THANG ORDER BY NAM, THANG";
            DatLoa.loadData("MA_DVI,NHOM_HANG,TEN_NHOM_HANG,THANG,NAM,sum(SL_NHAP) as SL_NHAP, sum(SL_XUAT) as SL_XUAT, sum(TONG_TIEN_NHAP) as TIEN_NHAP, sum(TONG_TIEN_XUAT) as TIEN_XUAT,sum(TONG_TIEN_XUAT) - sum(TONG_TIEN_NHAP) as DOANH_THU ",
                            "V_BC_DoanhThu_MatHang " + _Filter, ref dataGridView1);
            DesFor.EditCollum(ref dataGridView1, "MA_DVI", true, "Mã đơn vị");
            DesFor.EditCollum(ref dataGridView1, "NHOM_HANG", true, "Mã hàng");
            DesFor.EditCollum(ref dataGridView1, "TEN_NHOM_HANG", true, "Tên hàng");
            DesFor.EditCollum(ref dataGridView1, "THANG", true, "Tháng");
            DesFor.EditCollum(ref dataGridView1, "NAM", true, "Năm");
            DesFor.EditCollum(ref dataGridView1, "SL_NHAP", true, "SL Nhập");
            DesFor.EditCollum(ref dataGridView1, "SL_XUAT", true, "SL Xuất");
            DesFor.EditCollum(ref dataGridView1, "TIEN_NHAP", true, "Chi phí hàng");
            DesFor.EditCollum(ref dataGridView1, "TIEN_XUAT", true, "Doanh thu thuần");
            DesFor.EditCollum(ref dataGridView1, "DOANH_THU", true, "Lợi nhuận");
            _Filter = "";
        }

        private void loadDataNHforYear()
        {
            if (_Filter == "")
                _Filter = " where nam = '" + txtYear.Text + "' and MA_DVI like '%" + txtMaDV.Text +
                            "%' and (NHOM_HANG like '%" + txtNhomHang.Text + "%' or TEN_NHOM_HANG like N'%" + txtNhomHang.Text + "%') group by MA_DVI,NHOM_HANG,TEN_NHOM_HANG,NAM ORDER BY NAM";
            DatLoa.loadData("MA_DVI,NHOM_HANG,TEN_NHOM_HANG,NAM,sum(SL_NHAP) as SL_NHAP, sum(SL_XUAT) as SL_XUAT, sum(TONG_TIEN_NHAP) as TIEN_NHAP, sum(TONG_TIEN_XUAT) as TIEN_XUAT,sum(TONG_TIEN_XUAT) - sum(TONG_TIEN_NHAP) as DOANH_THU ",
                            "V_BC_DoanhThu_MatHang " + _Filter, ref dataGridView1);
            DesFor.EditCollum(ref dataGridView1, "MA_DVI", true, "Mã đơn vị");
            DesFor.EditCollum(ref dataGridView1, "NHOM_HANG", true, "Mã hàng");
            DesFor.EditCollum(ref dataGridView1, "TEN_NHOM_HANG", true, "Tên hàng");
            DesFor.EditCollum(ref dataGridView1, "NAM", true, "Năm");
            DesFor.EditCollum(ref dataGridView1, "SL_NHAP", true, "SL Nhập");
            DesFor.EditCollum(ref dataGridView1, "SL_XUAT", true, "SL Xuất");
            DesFor.EditCollum(ref dataGridView1, "TIEN_NHAP", true, "Chi phí hàng");
            DesFor.EditCollum(ref dataGridView1, "TIEN_XUAT", true, "Doanh thu thuần");
            DesFor.EditCollum(ref dataGridView1, "DOANH_THU", true, "Lợi nhuận");
            _Filter = "";
        }

        private void TestLoad()
        {
            dataGridView1.DataSource = "";
            switch (cbbKyHan.Text)
            {
                case "Theo Ngày":
                    txtDay.Enabled = true;
                    if (txtDay.Text == "") txtDay.Text = DateTime.Now.Day.ToString();
                    txtMonth.Enabled = true;
                    if (txtMonth.Text == "") txtMonth.Text = DateTime.Now.Month.ToString();
                    if (cbbPhanLoai.Text == "Mặt Hàng")
                        loadDataMHforMonth();
                    if (cbbPhanLoai.Text == "Nhóm Hàng")
                        loadDataNHforMonth();
                    break;
                case "Theo Tháng":
                    txtDay.Enabled = false; txtDay.Text = "";
                    txtMonth.Enabled = true;
                    if (txtMonth.Text == "") txtMonth.Text = DateTime.Now.Month.ToString();
                    if (cbbPhanLoai.Text == "Mặt Hàng")
                        loadDataMHforMonth();
                    if (cbbPhanLoai.Text == "Nhóm Hàng")
                        loadDataNHforMonth();
                    break;
                case "Theo Năm":
                    txtDay.Enabled = false; txtDay.Text = "";
                    txtMonth.Enabled = false; txtMonth.Text = "";
                    if (cbbPhanLoai.Text == "Mặt Hàng")
                        loadDataMHforYear();
                    if (cbbPhanLoai.Text == "Nhóm Hàng")
                        loadDataNHforYear();
                    break;
            }
        }

        private void TestLoc()
        {
            switch (cbbPhanLoai.Text)
            {
                case "Mặt Hàng":
                    txtNhomHang.Enabled = false; txtNhomHang.Text = "";
                    txtMaHang.Enabled = true;
                    break;
                case "Nhóm Hàng":
                    txtMaHang.Enabled = false; txtMaHang.Text = "";
                    txtNhomHang.Enabled = true;
                    break;
            }
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            txtDay.Text = DateTime.Now.Day.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
            cbbKyHan.Text = "Theo Tháng";
            cbbPhanLoai.Text = "Nhóm Hàng";
        }

        private void cbbKyHan_TextChanged(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void cbbPhanLoai_TextChanged(object sender, EventArgs e)
        {
            TestLoc();
            TestLoad();
        }

        private void txtDay_Validated(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void txtMonth_Validated(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void txtYear_Validated(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void txtNhomHang_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    e.SuppressKeyPress = true;
                    using (frmNhomhang f = new frmNhomhang())
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            txtNhomHang.Text = f.NH_ID;
                        }
                        DesignForm.vForm = this;
                    }
                    break;
            }
        }

        private void txtMaHang_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    e.SuppressKeyPress = true;
                    using (frmMatHang f = new frmMatHang())
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            txtMaHang.Text = f.MH_ID;
                        }
                        DesignForm.vForm = this;
                    }
                    break;
            }
        }

        private void txtMaDV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    e.SuppressKeyPress = true;
                    using (frmChiNhanh f = new frmChiNhanh())
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            txtMaDV.Text = f.DVI_ID;
                        }
                        DesignForm.vForm = this;
                    }
                    break;
            }
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            TestLoad();
        }

        private void txtNhomHang_TextChanged(object sender, EventArgs e)
        {
            TestLoad();
        }
    }
}