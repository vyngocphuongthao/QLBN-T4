using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using System.Messaging;

namespace FormBenhNhan
{
    public partial class FormBenhNhan : Form
    {
        MessageQueue queue = null;
        QLBNDataContext db;
        public FormBenhNhan()
        {
            InitializeComponent();
            db = new QLBNDataContext();
            init();
        }

        private void init()
        {
            string path = @".\private$\phongkehoach";
            //string path = @"hbmnl\private$\phongkehoach";
            if (MessageQueue.Exists(path))
            {
                queue = new MessageQueue(path, QueueAccessMode.Send);
            }
            else
                queue = MessageQueue.Create(path, true);
            queue.Label = "queue cho phong ke hoach";
        }
        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            if (tbMaBN.Text == "" || tbCMND.Text == "" || tbCMND.Text == "" || tbCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
            }
            else
            {
                BenhNhan bn = new BenhNhan();
                bn.msbn = tbMaBN.Text;
                bn.scmnd = tbCMND.Text;
                bn.hoten = tbHoTen.Text;
                bn.diachi = tbDiaChi.Text;

                KhamBenh kb = new KhamBenh();
                kb.msbacsy = "REREW";
                kb.msbn = tbMaBN.Text;
                kb.ghichu = "";

                BacSy bs = new BacSy();
                bs.msbacsy = "REREW";
                bs.hotenbacsy= "Quang";


                db.BenhNhans.InsertOnSubmit(bn);
               // db.BacSies.InsertOnSubmit(bs);
            
                db.SubmitChanges();

                db.KhamBenhs.InsertOnSubmit(kb);
                db.SubmitChanges();

                string message = "ok";
                MessageQueueTransaction transaction = new MessageQueueTransaction();
                transaction.Begin();
                queue.Send(message, transaction);
                transaction.Commit();


                MessageBox.Show("Thêm thành công !");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    } 
}
