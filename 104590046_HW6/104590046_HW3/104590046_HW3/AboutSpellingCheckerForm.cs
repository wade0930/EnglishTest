using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public class AboutSpellingCheckerForm : Form
    {
        private LinkLabel _link1 = new LinkLabel();
        private LinkLabel _link2 = new LinkLabel();
        private LinkLabel _link3 = new LinkLabel();

        public AboutSpellingCheckerForm()
        {
            const string TEXT4 = "About Spelling Checker";

            GoLine1();
            GoLine2();
            GoLine3();
            GoLine5();
            GoLine6();
            GoLink1();
            GoLink2();
            GoLink3();
            GoButton();
            GoPictureBox();
            Text = TEXT4;
        }

        //按ok關掉視窗
        public void ClickOkHandler(Object sender, EventArgs args)
        {
            this.Close();
        }

        //連到CSIE
        public void ClickLinkHandler(Object sender, EventArgs args)
        {
            _link2.LinkVisited = true;
            System.Diagnostics.Process.Start("http://csie.ntut.edu.tw/csie/index_i.htm");
        }

        //連到NTUT
        public void ClickLinkHandler1(Object sender, EventArgs args)
        {
            _link3.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.ntut.edu.tw/bin/home.php");
        }

        //TEXT1
        public void GoLine1()
        {
            const string TEXT1 = "Spelling Checker 1000 Words";
            const int X = 80;
            const int Y = 30;
            Label line1 = new Label();
            line1.Text = TEXT1;
            line1.AutoSize = true;
            line1.Location = new Point(X, Y);
            Controls.Add(line1);
        }

        //TEXT2
        public void GoLine2()
        {
            Label line2 = new Label();
            const int X = 80;
            const int Y = 70;
            const string TEXT2 = "All rights reserved.";
            line2.Text = TEXT2;
            line2.Location = new Point(X, Y);
            line2.AutoSize = true;
            Controls.Add(line2);
        }

        //TEX3
        public void GoLine3()
        {
            Label line3 = new Label();
            const int X = 80;
            const int Y = 90;
            const string TEXT3 = "Spirit Du";
            line3.Text = TEXT3;
            line3.Location = new Point(X, Y);
            line3.AutoSize = true;
            Controls.Add(line3);
        }

        //TEXT5
        public void GoLine5()
        {
            Label line5 = new Label();
            const string TEXT5 = "@";
            const int X = 110;
            const int Y = 50;
            line5.Text = TEXT5;
            line5.AutoSize = true;
            line5.Location = new Point(X, Y);
            Controls.Add(line5);
        }

        //TEXT6
        public void GoLine6()
        {
            Label line6 = new Label();
            const string TEXT6 = ",";
            const int X = 155;
            const int Y = 50;
            line6.Text = TEXT6;
            line6.Location = new Point(X, Y);
            line6.AutoSize = true;
            Controls.Add(line6);
        }

        //LINK1
        public void GoLink1()
        {
            _link1.Text = "SDTLAB";
            const int X = 80;
            const int Y = 50;
            _link1.Location = new Point(X, Y);
            _link1.AutoSize = true;
            Controls.Add(_link1);
        }

        //LINK2
        public void GoLink2()
        {
            _link2.Text = "CSIE";
            const int X = 130;
            const int Y = 50;
            _link2.Location = new Point(X, Y);
            _link2.AutoSize = true;
            _link2.Click += ClickLinkHandler;
            Controls.Add(_link2);
        }

        //LINK3
        public void GoLink3()
        {
            const int X = 160;
            const int Y = 50;
            _link3.Text = "NTUT";
            _link3.Location = new Point(X, Y);
            _link3.AutoSize = true;
            _link3.Click += ClickLinkHandler1;
            Controls.Add(_link3);
        }

        //按鈕
        public void GoButton()
        {
            const int X = 150;
            const int Y = 150;
            const int X_SIZE = 100;
            const int Y_SIZE = 30;
            Button ok = new Button();
            ok.Text = "ok";
            ok.Location = new Point(X, Y);
            ok.Size = new Size(X_SIZE, Y_SIZE);
            ok.Click += ClickOkHandler;
            Controls.Add(ok);
        }

        //圖片載入
        public void GoPictureBox()
        {
            const int X = 10;
            const int Y = 50;
            PictureBox picture = new PictureBox();
            picture.Image = Image.FromFile("../../book.png");
            picture.Location = new Point(X, Y);
            Controls.Add(picture);
        }
    }
}