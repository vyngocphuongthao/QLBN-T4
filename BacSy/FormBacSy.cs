using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using DAL;
using System.Messaging;

namespace FormBacSy
{
    public partial class FormBacSy : Form
    {
        private MessageQueue queue;
        QLBNDataContext db;
        public FormBacSy()
        {
            InitializeComponent();
            db = new QLBNDataContext();
            init_queue();

        }

        public void LoadDataBenhNhan()
        {
            dataGridView1.DataSource = (from a in db.BenhNhans
                                        select new
                                        {
                                            a.msbn
                                        });
        }

        private void Queue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = e.Message;
            int type = msg.BodyType;
            XmlMessageFormatter fmt = new XmlMessageFormatter(
            new System.Type[] { typeof(string) }
            );
            msg.Formatter = fmt;
            var result = msg.Body;
            var t = result.GetType();
           
                SetText("" + result);
            queue.BeginReceive();//loop back
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            //LoadDataBenhNhan();
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.MessagesRichTextBox.InvokeRequired)
            //{
            //    SetTextCallback callback = new SetTextCallback(SetText);
            //    this.Invoke(callback, new object[] { text });
            //}
            //else
            //{
            //    this.MessagesRichTextBox.AppendText(text + "\n");
            //}
        }
        void init_queue()
        {
            string path = @".\private$\phongkehoach";
            queue = new MessageQueue(path);
            queue.BeginReceive();
            queue.ReceiveCompleted += Queue_ReceiveCompleted;
        }
        private void FormBacSy_Load(object sender, EventArgs e)
        {
            LoadDataBenhNhan();
        }

        public void LoadThongTinBenhNhan()
        {
            String id = dataGridView1.CurrentCell.Value.ToString();
            BenhNhan bn = db.BenhNhans.FirstOrDefault(i => i.msbn == id);
             KhamBenh kb = db.KhamBenhs.FirstOrDefault(i => i.msbn == id);
            tbMaBN.Text = bn.msbn;
            tbCMND.Text = bn.scmnd;
            tbHoTen.Text = bn.hoten;
            tbDiaChi.Text = bn.diachi;
              tbNoiDungKham.Text = kb.ghichu;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadThongTinBenhNhan();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadThongTinBenhNhan();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataBenhNhan();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            String id = tbMaBN.Text.ToString();
            KhamBenh kb = db.KhamBenhs.FirstOrDefault(i => i.msbn == id);       
          //  kb.msbacsy = "REREW";
          //  kb.msbn = tbMaBN.Text;
            kb.ghichu = tbNoiDungKham.Text;
            db.SubmitChanges();
            MessageBox.Show("Luu thanh cong !");

        }
    }
}
