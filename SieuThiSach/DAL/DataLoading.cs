﻿using SieuThiSach.SO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiSach.DAL
{
    class DataLoading
    {
        DataAccess dbA = new DataAccess();
        DataSet ct = new DataSet();
        public string NameReturn(string name, string table, string dk)
        {
            if (dk == "") return "";
            String Name = "";
            //DataSet ct = new DataSet();
            string sql = "SELECT " + name + " FROM " + table + " WHERE " + dk;
            try
            {
                ct = dbA.ExecuteAsDataSetSql(sql);
                if (ct.Tables[0].Rows.Count > 0)
                    Name = ct.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Name;
        }

        public void loadData(string columns, string table, ref DataGridView dt)
        {
            //DataSet ct = new DataSet();
            string sql = "SELECT " + columns + " FROM " + table;
            //string sql = "EXEC " + ts;
            try
            {
                ct = dbA.ExecuteAsDataSetSql(sql);
                BindingSource gdSource = new BindingSource();
                gdSource.DataSource = ct.Tables[0];
                dt.DataSource = gdSource;
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int AddNew(string PROC)
        {
            int _ok = 0;
            string sql = "EXEC " + PROC;
            try
            {
                _ok = dbA.vExecuteData(sql);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _ok;
        }

        public int DelData
            (string PROC, ref DataGridView table, string code, string name, string sdung)
        {
            int _ok = 0;
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK);
            }
            else
                foreach (System.Windows.Forms.DataGridViewRow dgvUsersrows in table.SelectedRows)
                {
                    string _code = dgvUsersrows.Cells[code].Value.ToString().Trim();
                    string _name = dgvUsersrows.Cells[name].Value.ToString().Trim();
                    string _sdung = dgvUsersrows.Cells[sdung].Value.ToString().Trim();

                    if (MessageBox.Show("Có chắc chắn xóa/ngưng sử dụng '" + _code + " - " + _name + "' không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = "EXEC " + PROC + " '" + _code + "','" + _sdung + "'";
                        try
                        {
                            _ok = dbA.vExecuteData(sql);
                        }
                        catch (Exception es)
                        {
                            MessageBox.Show("Có lỗi " + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            return _ok;
        }

        public void loadCBB(string sql, ref ComboBox cbb)
        {
            cbb.Items.Clear();
            try
            {
                ct = dbA.ExecuteAsDataSetSql(sql);
                if (ct.Tables[0].Rows.Count > 0)
                {
                    cbb.Items.Add("");
                    for (byte i = 0; i < ct.Tables[0].Rows.Count; i++)
                    {
                        cbb.Items.Add(ct.Tables[0].Rows[i][0].ToString());
                    }
                }

            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCBBfromHeaderText(ref DataGridView dgv, ref ComboBox cbb)
        {
            cbb.Items.Clear();
            try
            {
                if (dgv.Columns.Count > 0)
                {
                    List<string> check = new List<string>();
                    for (byte i = 0; i < dgv.Columns.Count; i++)
                    {
                        cbb.Items.Add(dgv.Columns[i].HeaderText.ToString());
                        check.Add(dgv.Columns[i].HeaderText.ToString());
                    }
                    if (!check.Contains("")) cbb.Items.Add("");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCBBfromColNameNumber(ref DataGridView dgv, ref ComboBox cbb)
        {
            cbb.Items.Clear();
            try
            {
                if (dgv.Columns.Count > 0)
                {
                    for (byte i = 0; i < dgv.Columns.Count; i++)
                    {
                        cbb.Items.Add((Convert.ToInt16(dgv.Columns[i].Name)+1).ToString());
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCBBfromList(List<string> list, ref ComboBox cbb)
        {
            cbb.Items.Clear();
            try
            {
                if (list.Count > 0)
                {
                    for (byte i = 0; i < list.Count; i++)
                    {
                        cbb.Items.Add(list[i]);
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int InsExc(int dt,string tb, ref DataGridView dtv)
        {
            int rw = 0;
            try
            {
                rw = dbA.ImportExcel(dt-1,tb, ref dtv);
                if (rw > 0) MessageBox.Show("Đã nạp thành công " + rw + " dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception es)
            {
                MessageBox.Show("Lỗi tại dòng: " + dbA.RowEr + "\n" +es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rw;
        }
    }
}