using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace add_edit_excell_DATAGRID
{
    public partial class Add : Form
    {
        private List<Student> students;
        public Add(List<Student> studentsList)
        {
            InitializeComponent();
            this.students = studentsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || numericUpDown1.Text.Length != 8))
            {
                string nameField = textBox1.Text;
                string mailField = textBox2.Text;
                string fcField = numericUpDown1.Text;
                

                students.Add(new Student(nameField, mailField, fcField));
                this.Close();
            }
            else MessageBox.Show("There shouldnt be empty fields!");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
