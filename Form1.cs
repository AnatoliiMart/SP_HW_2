using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SP_HW_2
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1() => InitializeComponent();
        

        private void btn_Search_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(Search));
            thread.Start();
        }
        private void Search()
        {
            string path = txtBox_FilePath.Text.Trim('"');

            if (!File.Exists(path))
            {
                MessageBox.Show("Такого файла не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox_FilePath.Text = string.Empty;
                return;
            }

            if (txtBox_SearchValue.Text == string.Empty)
            {
                MessageBox.Show("Значение для поиска не задано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int counter = 0;

            foreach (var item in File.ReadAllText(path).Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }))
                if (item.Contains(txtBox_SearchValue.Text))
                    counter++;

            MessageBox.Show($"Количество искомых символов/строк в файле: {counter}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
