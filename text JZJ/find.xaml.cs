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
using System.Windows.Shapes;

namespace text_JZJ
{
    /// <summary>
    /// find.xaml 的交互逻辑
    /// </summary>
    public partial class find : Window
    {
        public bool iscd = false;
        public int len;
        public int[] a = new int[1000];
        public int i;
        public find()
        {
            InitializeComponent();
        }
        public void KMP(string s, string p)//KMP算法
        {
            int[] next = new int[100000];
            int i = 0, j = 0;
            //int[] a = new int[10000]; 
            len = 0;//统计匹配成功的次数。
            bool flag = false;
            int lens = s.Length;//主串长度。
            int lenp = p.Length;//模式串长度。
            int k = -1;
            next[0] = -1;//初始化next数组。
            while (i < lenp)
            {
                if (k == -1 || p[i] == p[k])//若p[i]==p[k]，则有p[0..k]==p[i-k,i]，很显然，next[i+1]=next[i]+1=k+1;
                {
                    i++;
                    k++;
                    next[i] = k;
                }
                else k = next[k];//若p[i]!=p[k]，则可以把其看做模式匹配的问题，即匹配失败的时候，k值如何移动，显然k=next[k]。
            }
            i = j = 0;
            while (i < lens)
            {
                if (j == -1 || (j >= 0 && i >= 0 && i < lens && j < lenp && s[i] == p[j])) //这一位相同，就往后一位匹配。
                {
                    i++;
                    j++;
                }
                else j = next[j];//匹配不上，从next数组中取出模式串
                if (j == lenp)//判断匹配上的长度是否等于模式串长度。
                {
                    if (!flag)
                    {
                        //QueryPerformanceCounter(ref count1);
                        //count = count1 - count;
                        //result = (double)(count) / (double)freq;
                    }
                    flag = true;
                    a[++len] = i - lenp;
                }
            }
            //return result;
        }

        private void find1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(MainWindow.openwin.txtRTB.Text);
            //MainWindow x = new MainWindow();
            //MessageBox.Show(x.txtRTB.Text);
            if (findtxt.Text!=null)
            {
                if(iscd)
                {
                    KMP(MainWindow.openwin.txtRTB.Text, findtxt.Text);
                    i = 1;
                    if (len == 0) { MessageBox.Show("没有找到" + findtxt.Text); }
                    else if (i > len) { MessageBox.Show("没有找到" + findtxt.Text); }
                    else { MainWindow.openwin.txtRTB.Select(a[i], findtxt.Text.Length); MainWindow.openwin.txtRTB.Focus(); }
                    iscd = false;
                }
                else 
                {
                    i++;
                    //MessageBox.Show(i.ToString());
                    //MessageBox.Show(a[i].ToString());
                    if (len == 0) { MessageBox.Show("没有找到" + findtxt.Text); }
                    else if (i > len) { MessageBox.Show("没有找到" + findtxt.Text); }
                    else 
                    { 
                        MainWindow.openwin.txtRTB.Select(a[i], findtxt.Text.Length);
                        //MainWindow.openwin.txtRTB.SelectionBrush = Brushes.Blue;
                        //MainWindow.openwin.txtRTB.SelectionOpacity = 0.5;
                        //findtxt.Select(0, 3);
                        //findtxt.SelectionBrush = Brushes.Blue;
                        //findtxt.SelectionOpacity = 0.5;
                        MainWindow.openwin.txtRTB.Focus();

                    }
                }
            }
            else { MessageBox.Show("请输入要查找的内容!"); }
        }

        private void findtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            iscd = true;
        }

        private void tihuan_Click(object sender, RoutedEventArgs e)
        {
            if (tihuantxt.Text == null) { MessageBox.Show("请输入替换后的内容！"); }
            else if(MainWindow.openwin.txtRTB.SelectedText==null)
            {
                MessageBox.Show("请选定替换内容！");
            }
            else
            {
                //MessageBox.Show(MainWindow.openwin.txtRTB.SelectedText);
                MainWindow.openwin.txtRTB.SelectedText=tihuantxt.Text;
            }
        }
    }
}
