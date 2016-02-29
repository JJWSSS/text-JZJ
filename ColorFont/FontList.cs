using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ColorFont
{
    public class FontList : ObservableCollection<FontFamily>
    {
        public FontList()
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (System.Drawing.FontFamily f in fonts.Families) //遍历字体集合中德字体 
            {
                FontFamily font = new FontFamily(f.Name);
                Add(font);//将参数传递到自定义控件 
            }
        }
    }
}
