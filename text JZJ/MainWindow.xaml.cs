using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using ColorFont;

namespace text_JZJ
{
    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow openwin;
        public bool ischanged=true;
        //public bool on = true;
        public string path;
        public string title;
        public string[] arrs = new string[1000];
        public int nownum=0;
        //public int allnum=0;
        public MainWindow()
        {
            openwin = this;
            InitializeComponent();
            settitle();
            arrs[0] = txtRTB.Text;
        }
        public void settitle()
        {
            if (path==null)
            {
                this.Title = "无标题" + "-text JZJ";
            }
            else
            {
                //mainwindow.Title = "111111";//path + "-text JZJ";
                string[] ss = path.Split(new char[] { '\\' }, StringSplitOptions.None);
                //MessageBox.Show(path);
                mainwindow.Title = ss[ss.Length-1] + "-text JZJ";
            }
        }

        private void saveMI_Click(object sender, RoutedEventArgs e)
        {
            if (path!=null)
            {
                //string fname = sfd.FileName;
                string txttext = txtRTB.Text;
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(txtRTB.Text);
                sw.Close();

            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "文本文件|*.txt|所有文件|*.*";
                if (sfd.ShowDialog() == true)
                {
                    string fname = sfd.FileName;
                    string txttext = txtRTB.Text;
                    FileStream file = new FileStream(fname, FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(file);
                    sw.Write(txtRTB.Text);
                    sw.Close();
                }
                //else
                //{
                //    MessageBox.Show("打开错误!");
                //}
                settitle();
                ischanged = true;
            }
            //}
            //else
            //{
            //    FileStream file = new FileStream(fn, FileMode.Create, FileAccess.ReadWrite);
            //    StreamWriter sw = new StreamWriter(file);
            //    sw.Write(txtRTB.Text);
            //    sw.Close();
            //}
        }

        private void newMI_Click(object sender, RoutedEventArgs e)
        {
            if (txtRTB.Text.Trim().Length> 0)
            {
                MessageBoxResult r1=MessageBox.Show("确认要保存该文件吗？", "提示", MessageBoxButton.YesNoCancel);
                if(r1==MessageBoxResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "文本文件|*.txt|所有文件|*.*";
                    if (sfd.ShowDialog() == true)
                    {
                        path = sfd.FileName;
                        string txttext = txtRTB.Text;
                        FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                        StreamWriter sw = new StreamWriter(file);
                        sw.Write(txtRTB.Text);
                        sw.Close();
                    }
                    //else
                    //{
                    //    MessageBox.Show("打开错误!");
                    //}
                }
            }
            settitle();
        }

        private void lcwMI_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (sfd.ShowDialog() == true)
            {
                path = sfd.FileName;
                string txttext = txtRTB.Text;
                FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(txtRTB.Text);
                sw.Close();
            }
            //else
            //{
            //    MessageBox.Show("打开错误!");
            //}
            ischanged = true;
            settitle();
        }

        private void guanyu_Click(object sender, RoutedEventArgs e)
        {
            //mainwindow.Visibility = System.Windows.Visibility.Hidden;
            help x = new help();
            x.ShowDialog();
            //mainwindow.Visibility = System.Windows.Visibility.Hidden;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
                string txttext = txtRTB.Text;
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(file,Encoding.UTF8);
                txtRTB.Text = sr.ReadToEnd();
                sr.Close();
            }
            settitle();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mw = new MainWindow();
            //this.Close();
            if (ischanged == true) { mainwindow.Close(); }
            else
            {
                MessageBoxResult r1=MessageBox.Show("确认要保存该文件吗？", "提示", MessageBoxButton.YesNoCancel);
                if (r1 == MessageBoxResult.Yes)
                {
                    if (path != null)
                    {
                        //string fname = sfd.FileName;
                        string txttext = txtRTB.Text;
                        FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                        StreamWriter sw = new StreamWriter(file);
                        sw.Write(txtRTB.Text);
                        sw.Close();
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "文本文件|*.txt|所有文件|*.*";
                        if (sfd.ShowDialog() == true)
                        {
                            string fname = sfd.FileName;
                            string txttext = txtRTB.Text;
                            FileStream file = new FileStream(fname, FileMode.Create, FileAccess.ReadWrite);
                            StreamWriter sw = new StreamWriter(file);
                            sw.Write(txtRTB.Text);
                            sw.Close();
                        }
                        //else
                        //{
                        //    MessageBox.Show("打开错误!");
                        //}
                    }
                    this.mainwindow.Close();
                }
            }
        }
        private void txtRTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int sum = 0;
            //textstatus.Text = "当前行数:" + this.txtRTB.LineCount;
            //int i = this.txtRTB.LineCount;
            //MessageBox.Show(this.txtRTB.GetLineLength(0).ToString()); //this.txtRTB.SelectionStart
            //settitle();
            //int i = 0;

            //for (int i = 1; i < 10000000; i++)
            //{
            //    sum += this.txtRTB.GetLineLength(i);
            //    if (this.txtRTB.SelectionStart < sum)
            //    {
            //        textstatus.Text = "当前行数:" + i;
            //        break;
            //    }
            //}
            //txtRTB.GetLineLength
            ischanged = false;
            nownum++;
            if (txtRTB.Text != arrs[nownum - 1]) 
            {
                //nownum--;
                arrs[nownum] = txtRTB.Text;
            }
            else { nownum--; }
            //nownum = allnum;
        }

        private void cfont_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            fntDialog.Font = FontInfo.GetControlFont(this.txtRTB);
            if (fntDialog.ShowDialog() == true)
            {
                FontInfo selectedFont = fntDialog.Font;

                if (selectedFont != null)
                {
                    FontInfo.ApplyFont(this.txtRTB, selectedFont);
                }
            }
        }

        private void selectAll_Click(object sender, RoutedEventArgs e)
        {
            txtRTB.SelectAll();
            //txtRTB.Select(0, 3);
            //MainWindow.openwin.txtRTB.SelectionBrush = Brushes.Blue;
            //MainWindow.openwin.txtRTB.SelectionOpacity = 0.5;
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            //txtRTB.Undo();
            //MessageBox.Show(nownum.ToString());
            //for (int i = nownum; i >= 0; i--)
            //{
            //    MessageBox.Show(arrs[i]);
            //}
            if (nownum != 0) { nownum--; }
            txtRTB.Text = arrs[nownum];
        }

        private void lines_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtRTB.LineCount.ToString());
            //txtRTB.Select(0, 3);
            //txtRTB.SelectionStart = 3;
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            text_JZJ.find x = new find();
            x.Visibility = Visibility.Visible;
        }







        /*private void mainwindow_Activated(object sender, EventArgs e)
        {
            if (path==null)
            {
                mainwindow.Title = "未命名-text JZJ";
            }
            else
            {
                mainwindow.Title = path + "-text JZJ";
            }
        }*/

    }
}
