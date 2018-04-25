using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nauchka
{
    public partial class Group : Form
    {
        string x;
        string lecName;
        public Group(string y, string lecturerName)
        {
            InitializeComponent();
            x = y;
            lecName = lecturerName;
        }

        private void Group_Load(object sender, EventArgs e)
        {
           
            DataSet group = new DataSet();
            group.ReadXml("http://timetable.sbmt.by/xml/group.xml");
            dataGridView1.DataSource = group.Tables[0];
            dataGridView1.Columns["entranceyear"].Visible = false;
            dataGridView1.Columns["filename"].Visible = false;
            dataGridView1.Columns["xls"].Visible = false;
            dataGridView1.Columns["year"].Visible = false;
            dataGridView1.Columns["faculty"].HeaderText = "Факультет";
            dataGridView1.Columns["form"].HeaderText = "Форма обучения";
            dataGridView1.Columns["course"].HeaderText = "Курс";
            dataGridView1.Columns["speciality"].HeaderText = "Специальность";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {

                string groupfile = dataGridView1.SelectedRows[0].Cells["number"].Value.ToString();
                
                string course = dataGridView1.SelectedRows[0].Cells["course"].Value.ToString();
                string spec = dataGridView1.SelectedRows[0].Cells["speciality"].Value.ToString();

                Result r = new Result(x, groupfile, course, lecName, spec);
                r.Show();

            }

        }
    }
}
