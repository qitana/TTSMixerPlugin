// 
// This file is part of OverlayPlugin.
// 
// This file has been copied and modified from the original source.
// Original source: https://github.com/OverlayPlugin/OverlayPlugin
// Original author(s): ngld
// 
// The original code is licensed under the MIT License. Below is the original license notice:
//
// MIT License
// 
// Copyright (c) 2014 RainbowMage, hibiyasleep, ngld
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public class TabControlExt : TabControl
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(SystemColors.ControlLightLight);
            e.Graphics.FillRectangle(SystemBrushes.ControlLight, 4, 4, (ItemSize.Height * RowCount) - 4, Height - 8);

            int inc = 0;

            foreach (TabPage tp in TabPages)
            {
                Color fore = Color.Black;
                Font fontF = Font;
                Font fontFSmall = new Font(Font.FontFamily, (float)(Font.Size * 0.85));
                Rectangle tabrect = GetTabRect(inc);
                Rectangle rect = new Rectangle(tabrect.X + 4, tabrect.Y + 4, tabrect.Width - 8, tabrect.Height - 2);
                Rectangle textrect1 = new Rectangle(tabrect.X + 4, tabrect.Y + 4, tabrect.Width - 8, tabrect.Height - 20);
                Rectangle textrect2 = new Rectangle(tabrect.X + 4, tabrect.Y + 20, tabrect.Width - 8, tabrect.Height - 20);

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                if (inc == SelectedIndex)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), rect);
                    fore = SystemColors.HighlightText;
                    fontF = new Font(Font, FontStyle.Bold);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, rect);
                }

                e.Graphics.DrawString(tp.Name, fontF, new SolidBrush(fore), textrect1, sf);
                e.Graphics.DrawString(tp.Text, fontFSmall, new SolidBrush(fore), textrect2, sf);
                inc++;
            }
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
            Invalidate();
        }

        public TabControlExt() : base()
        {
            Alignment = TabAlignment.Left;

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            DoubleBuffered = true;

            ItemSize = new Size(46, 140);
            SizeMode = TabSizeMode.Fixed;
            BackColor = Color.Transparent;
        }
    }
}
