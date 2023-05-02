using System.Windows.Forms;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop);

            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Введи общее название для файлов:", "Название", "чёта", -1, -1);

            DialogResult result = MessageBox.Show(
            "уверена, бллин?",
            "подтверждуха",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (string folderPath in folders)
                    {
                        FileProcessor.ProcessFolder(folderPath, userInput);
                    }
                    MessageBox.Show("успех.", "удача.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
        }
    }
}