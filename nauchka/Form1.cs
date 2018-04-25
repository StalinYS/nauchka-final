using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace nauchka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                string prepodfile= dataGridView1.SelectedRows[0].Cells["filename"].Value.ToString();
               
                string lecturerName = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();
                Group gr = new Group(prepodfile,lecturerName);
                gr.Show();             
            }        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet xmldata = new DataSet();
            xmldata.ReadXml("http://timetable.sbmt.by/xml/lecturer.xml");
            dataGridView1.DataSource = xmldata.Tables[0];
            dataGridView1.Columns["filename"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "Имя преподавателя";
            dataGridView1.Columns["department"].HeaderText = "Кафедра";
            dataGridView1.Columns["position"].HeaderText = "Должность";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
