using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;
using System.Globalization;
using System.ComponentModel;
using System.Resources;
using System.Threading;

namespace Lab_21
{
    public partial class Form1 : Form
    {
        private Document document;
        public Form1()
        {
            InitializeComponent();
        }

        private int number = 1;

        // Кнопка для створення документів (меню)
        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document f = new Document(number);
            number++;
            f.MdiParent = this;
            f.Show();
        }

        // Кнопка для відкриття файлів TXT (меню)
        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Фільтр файлів
            openFileDialog1.RestoreDirectory = true; // Відновлення каталогу вибору файлу

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filePath);
                Document activeDocument = this.ActiveMdiChild as Document;

                if (activeDocument != null)
                {
                    activeDocument.SetText(fileText);
                }
                else
                {
                    MessageBox.Show("No active document to open the file into.");
                }
            }
        }

        // Кнопка для зберігання документів (меню)
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.SaveDocument();
            }
        }

        // Кнопка для збереження як копії (меню)
        private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.SaveAsDocument();
            }
        }

        // Кнопка для виходу з програми (меню)
        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Кнопка для вирізання тексту (меню)
        private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Cut();
            }
        }

        // Кнопка для копіювання тексту (меню)
        private void кToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Copy();
            }
        }

        // Кнопка для вставлення тексту (меню)
        private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Paste();
            }
        }

        // Кнопка для виділення всього тексту (меню)
        private void виділитиВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.SelectAll();
            }
        }

        // Кнопка для видалення тексту (меню)
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Delete();
            }
        }

        // Кнопка для вставки зображення (меню)
        private void обратиЗображенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.InsertImageMenuItem_Click();
            }

        }

        // Кнопка для впорядковування вікон (меню)
        private void розташуватиІконкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        // Кнопка для каскадного розташування вікон (меню)
        private void каскаднеРозташуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        // Кнопка для горизонтального розташування вікон (меню)
        private void горизонтальнеРозташуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        // Кнопка для вертикального розташування вікон (меню)
        private void вертикальнеРозташуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        // Метод для зміни мови
        private void ChangeLanguage(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            ApplyLanguage();
        }

        // Кнопка зміни мови на українську (меню)
        private void українськаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk");
        }

        // Кнопка зміни мови на англійську (меню)
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        // Метод для зміни мови
        private void ApplyLanguage()
        {
            файлToolStripMenuItem.Text = Properties.Resources.menuFile;
            редагуванняToolStripMenuItem.Text = Properties.Resources.menuEdit;
            вставкаToolStripMenuItem.Text = Properties.Resources.menuIn;
            toolStripMenuItem1.Text = Properties.Resources.menuFormat;
            вікноToolStripMenuItem.Text = Properties.Resources.menuWindow;
            мовиToolStripMenuItem.Text = Properties.Resources.menuLeng;

            створитиToolStripMenuItem.Text = Properties.Resources.Create;
            відкритиToolStripMenuItem.Text = Properties.Resources.Open;
            зберегтиToolStripMenuItem.Text = Properties.Resources.String2;
            зберегтиЯкToolStripMenuItem.Text = Properties.Resources.String3;
            вийтиToolStripMenuItem.Text = Properties.Resources.String4;

            вирізатиToolStripMenuItem.Text = Properties.Resources.String5;
            кToolStripMenuItem.Text = Properties.Resources.String6;
            вставитиToolStripMenuItem.Text = Properties.Resources.String7;
            виділитиВсеToolStripMenuItem.Text = Properties.Resources.String8;
            видалитиToolStripMenuItem.Text = Properties.Resources.String9;

            обратиЗображенняToolStripMenuItem.Text = Properties.Resources.String10;

            toolStripMenuItem2.Text = Properties.Resources.String11;
            колірШрифтуToolStripMenuItem.Text = Properties.Resources.String12;
            вирівнюванняToolStripMenuItem.Text = Properties.Resources.String13;

            розташуватиІконкиToolStripMenuItem.Text = Properties.Resources.String14;
            каскаднеРозташуванняToolStripMenuItem.Text = Properties.Resources.String15;
            горизонтальнеРозташуванняToolStripMenuItem.Text = Properties.Resources.String16;
            вертикальнеРозташуванняToolStripMenuItem.Text = Properties.Resources.String17;

            ліворучToolStripMenuItem.Text = Properties.Resources.String1;
            поЦентруToolStripMenuItem.Text = Properties.Resources.String18;
            праворучToolStripMenuItem.Text = Properties.Resources.String19;

            toolStripButton1.Text = Properties.Resources.String20;
            toolStripButton2.Text = Properties.Resources.String21;
            toolStripButton3.Text = Properties.Resources.String22;
            toolStripButton4.Text = Properties.Resources.String23;
            toolStripButton5.Text = Properties.Resources.String24;
            toolStripButton6.Text = Properties.Resources.String25;
            toolStripButton7.Text = Properties.Resources.String26;
            toolStripButton8.Text = Properties.Resources.String27;

            englishToolStripMenuItem.Text = "English";
            українськаToolStripMenuItem.Text = "Українська";
        }

        // Кнопка для вирівнювання тексту ліворуч (меню)
        private void ліворучToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignmentForActiveDocument(HorizontalAlignment.Left);
        }

        // Метод для вирівнювання тексту
        private void SetAlignmentForActiveDocument(HorizontalAlignment alignment)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.SetAlignment(alignment);
            }
        }

        // Кнопка для вирівнювання тексту по центру (меню)
        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignmentForActiveDocument(HorizontalAlignment.Center);
        }

        // Кнопка для вирівнювання тексту праворуч (меню)
        private void праворучToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAlignmentForActiveDocument(HorizontalAlignment.Right);
        }

        // Кнопка для зміни шрифту (меню)
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult result = fontDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Font selectedFont = fontDialog.Font;

                Document activeDoc = this.ActiveMdiChild as Document;
                if (activeDoc != null)
                {
                    activeDoc.SetText(selectedFont);
                }
            }
        }

        // Кнопка для зміни кольору шрифта (меню)
        private void колірШрифтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                Document activeDoc = this.ActiveMdiChild as Document;
                if (activeDoc != null)
                {
                    activeDoc.SetTextColor(selectedColor);
                }
            }
        }

        // Кнопка для створення нового документу (панель інструментів)
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Document f = new Document(number);
            number++;
            f.MdiParent = this;
            f.Show();
        }

        // Кнопка для збереження документу (панель інструментів)
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.SaveDocument();
            }
        }

        // Кнопка для копіювання тексту (панель інструментів)
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Copy();
            }
        }

        // Кнопка для вставки тексту (панель інструментів)
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.Paste();
            }
        }

        // Кнопка для вставки зображення (панель інструментів)
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Document activeDoc = (Document)this.ActiveMdiChild;
            if (activeDoc != null)
            {
                activeDoc.InsertImageMenuItem_Click();
            }
        }

        private bool isFontBold = false;

        // Кнопка для жирності тексту (панель інструпентів)
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Document activeDoc = this.ActiveMdiChild as Document;

            if (activeDoc != null)
            {
                if (!isFontBold)
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Bold));
                    isFontBold = true;
                }
                else
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Regular));
                    isFontBold = false;
                }
            }

        }

        private bool isFontItalic = false;

        // Кнопка для нахилу тексту (панель інструпентів)
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Document activeDoc = this.ActiveMdiChild as Document;

            if (activeDoc != null)
            {
                if (!isFontItalic)
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Italic));
                    isFontItalic = true;
                }
                else
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Regular));
                    isFontItalic = false;
                }
            }
        }

        // Кнопка для підкресленого тексту (панель інструпентів)
        private bool isFontUnderline = false;
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Document activeDoc = this.ActiveMdiChild as Document;

            if (activeDoc != null)
            {
                if (!isFontUnderline)
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Underline));
                    isFontUnderline = true;
                }
                else
                {
                    activeDoc.SelectionFont(new Font(activeDoc.Font, FontStyle.Regular));
                    isFontUnderline = false;
                }
            }
        }
    }

}

