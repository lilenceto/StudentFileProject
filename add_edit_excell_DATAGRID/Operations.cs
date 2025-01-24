namespace add_edit_excell_DATAGRID
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public partial class Operations : Form
    {
        private List<Student> studentsList;
        private string xmlFilePath = "students.xml";


        public Operations()
        {
            studentsList = new List<Student>();
            LoadStudentsFromXML();
            InitializeComponent();
            
        }
        public Operations(List<Student> students)
        {
            InitializeComponent();
            studentsList = students;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add addForm = new Add(studentsList);
            addForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 editForm = new Form1(studentsList);
            editForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveStudentsToXML();
            MessageBox.Show("Successfully saved students into an XML file");
        }

        private bool LoadStudentsFromXML()
        {
            if (!File.Exists(xmlFilePath))
            {
                MessageBox.Show("ERROR");
                return false;
            }
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                studentsList = (List<Student>)serializer.Deserialize(fs);
            }

            return true;
        }

        private bool SaveStudentsToXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, studentsList);
            }

            return true;
        }
    }
}


