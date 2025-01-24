using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace add_edit_excell_DATAGRID
{
    public partial class Form1 : Form
    {
        private List<Student> students;
        public Form1(List<Student> students)
        {
            InitializeComponent();
            this.students = students;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;

            dataGridView1.Columns[0].ReadOnly = false;
            dataGridView1.Columns[1].ReadOnly = false;
            dataGridView1.Columns[2].ReadOnly = false;
            dataGridView1.Columns[3].ReadOnly = false;

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private object originalValue;

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            string temp;
            if (newValue == null || newValue.ToString() == "")
            {
                MessageBox.Show("Fields should not be empty!");
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = originalValue;
                return;
            }

            if (e.ColumnIndex == 2)
            {
                temp = newValue.ToString();
                if(temp.Length!=8)
                {
                    MessageBox.Show("FN field should contain 8 numbers!");
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = originalValue;
                    return;
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    if (!Char.IsDigit(temp[i]))
                    {
                        MessageBox.Show("FN should only contain numbers");
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = originalValue;
                        return;
                    }
                }
            }

            if (e.ColumnIndex == 3)
            {

                if (double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), out double newGrade))
                {
                    if (newGrade >= 2 && newGrade <= 6)
                    {
                        students[e.RowIndex].grade = newGrade;
                    }
                    else 
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = originalValue;
                        MessageBox.Show("Grade value must be between 2 and 6");
                    } 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student maxGradeStudent = new Student("", "", "");
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No elements!");
                return;
            }
            double maxGrade = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (double.TryParse(row.Cells[3].Value.ToString(), out double grade1))
                {
                    if (grade1 > maxGrade)
                    {
                        if (row.Cells[0].Value.ToString() != null)
                        {
                            maxGradeStudent.name = row.Cells[0].Value.ToString();
                        }

                        if (row.Cells[1].Value.ToString() != null)
                        {
                            maxGradeStudent.mail = row.Cells[1].Value.ToString();
                        }

                        if (row.Cells[2].Value.ToString() != null)
                        {
                            maxGradeStudent.fcNumber = row.Cells[2].Value.ToString();
                        }
                        maxGradeStudent.grade = grade1;
                        maxGrade = grade1;
                    }
                }
            }

            MessageBox.Show("The student with the highest grade is: \n"+maxGradeStudent.name+" \n mail: "+maxGradeStudent.mail+" \n FN: "+maxGradeStudent.fcNumber+"\n grade: "+maxGradeStudent.grade);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            students = students.OrderBy(s => s.name).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
    }
}
