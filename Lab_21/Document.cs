using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_21
{
    public partial class Document : Form
    {
        public Document(int number)
        {
            InitializeComponent();
            Text = "Документ " + number.ToString();

        }

        // Метод для встановлення тексту у RichTextBox
        public void SetText(string text)
        {
            richTextBox1.Text = text;
        }

        // Метод для збереження документу
        public void SaveDocument()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                if (filePath.EndsWith(".rtf"))
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
            }
        }
        // Метод для збереження як копії
        public void SaveAsDocument()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                if (filePath.EndsWith(".rtf"))
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }
            }
        }

        // Метод для вирізання тексту
        public void Cut()
        {
            richTextBox1.Cut();
        }

        // Метод для копіювання тексту
        public void Copy()
        {
            richTextBox1.Copy();
        }

        // Метод для вставлення тексту
        public void Paste()
        {
            richTextBox1.Paste();
        }
        // Метод для виділення всього тексту
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        // Метод для видалення тексту
        public void Delete()
        {
            richTextBox1.SelectedText = "";
        }

        // Метод для додавання зображення в обраному місці
          public void InsertImageMenuItem_Click()

          {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                Image image = Image.FromFile(imagePath);

                Clipboard.SetImage(image);
                richTextBox1.Paste();
            }
          }


        // Метод для вирівнювання тексту
        public void SetAlignment(HorizontalAlignment alignment)
        {
            richTextBox1.SelectionAlignment = alignment;
        }

        // Метод для зміни шрифту
        public void SetText(Font newFont)
        {
            richTextBox1.SelectionFont = newFont;
        }

        // Метод для зміни кольору шрифта
        public void SetTextColor(Color selectedColor)
        {
            richTextBox1.SelectionColor = selectedColor;
        }

        // Метод для редагування тексту з панелі інструментів
        public void SelectionFont(Font selectedFont)
        {
            richTextBox1.SelectionFont = selectedFont;
        }


    }

}
