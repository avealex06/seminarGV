using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulackaUkol
{
    public partial class Form1 : Form
    {

        Graphics g;
        int x, y = 0;
        bool moving = false;
        bool shape = false;
        bool fillShape = false;
        Point start;
        Pen pen;
        SolidBrush brush;
        Image image;
        PictureBox picture; 
        string drawMode = "pen";
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; // zaridi plynulost cary
            brush = new SolidBrush(Color.Black);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            brush.Color = p.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            if (shape)
            {
                start = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x!=0 && y!=0)
            {
                switch (drawMode)
                {
                    case "pen":
                        g.DrawLine(pen, new Point(x, y), e.Location);
                        x = e.X;
                        y = e.Y;
                        break;
                    
                    case "spray":
                        //modifikovany kod z chatGPT, pri vyssich sirkach nevypada jako spray
                        Random random = new Random();
                        for (int i = 0; i < 10; i++) 

                        {
                            int offsetX = random.Next(-5, 5); 
                            int offsetY = random.Next(-5, 5); 
                            int minSize = penWidth.Value - 1; 
                            int maxSize = penWidth.Value + 1; 
                            int size = random.Next(minSize, maxSize);
                            Color sprayColor;
                            if (size<5)
                            {
                                sprayColor = Color.FromArgb(50, pen.Color.R, pen.Color.G, pen.Color.B);
                            }
                            else if (size>5 && size<25)
                            {
                                sprayColor = Color.FromArgb(5, pen.Color.R, pen.Color.G, pen.Color.B);
                            }
                            else
                            {
                                sprayColor = Color.FromArgb(1, pen.Color.R, pen.Color.G, pen.Color.B);
                            }
                            SolidBrush brush = new SolidBrush(sprayColor);
                            g.FillEllipse(brush,new Rectangle(e.X + offsetX, e.Y + offsetY, size, size));
                            
                        }
                        break;
                    case "marker":
                        // snizi opacity barvy a nastavi endcap a start na ctverec
                        Color markerColor = Color.FromArgb(10, pen.Color.R, pen.Color.G, pen.Color.B);
                        Pen marker = new Pen(markerColor, penWidth.Value);
                        marker.StartCap = marker.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                        g.DrawLine(marker, new Point(x, y), e.Location);
                        x = e.X;
                        y = e.Y;
                        break;



                }
            }   
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
            brush.Color = Color.White;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            panel1.Controls.Remove(picture);
        }

        private void penWidth_Scroll(object sender, EventArgs e)
        {
            pen.Width = penWidth.Value;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            drawMode = "pen";
            shape = false;
        }

        private void rectangleMode_Click(object sender, EventArgs e)
        {
            drawMode = "rectangle";
            shape = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            drawMode = "ellipse";
            shape = true;
        }

        private void line_Click(object sender, EventArgs e)
        {
            drawMode = "line";
            shape = true;
        }

        private void fill_CheckedChanged(object sender, EventArgs e)
        {
            if (fill.Checked)
            {
                fillShape = true;
            }
            else
            {
                fillShape = false;
            }
        }

        private void spray_Click(object sender, EventArgs e)
        {
            drawMode = "spray";
        }

        private void insert_Click(object sender, EventArgs e)
        {
            //pokus o vkladani obrazku, nefunguje tak jak bych si predstavoval
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                Point imageLoc = new Point(Convert.ToInt32(textBoxX.Text), Convert.ToInt32(textBoxY.Text));
                picture = new PictureBox();
                picture.Image = image;
                picture.Location = imageLoc;
                panel1.Controls.Add(picture);
                
                picture.BringToFront();
            }

        }

        private void marker_Click(object sender, EventArgs e)
        {
            drawMode = "marker";
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (shape) 
            {
                int width = e.X - start.X;
                int height = e.Y - start.Y;
                if (drawMode =="rectangle")
                {
                    if (fillShape)
                    {
                        g.FillRectangle(brush, start.X, start.Y, width, height);
                    }
                    else
                    {
                        g.DrawRectangle(pen, start.X, start.Y, width, height);
                    }
                    
                }
                else if (drawMode == "ellipse")
                {
                    if (fillShape)
                    {
                        g.FillEllipse(brush, start.X, start.Y, width, height);
                    }
                    else
                    {
                        g.DrawEllipse(pen, start.X, start.Y, width, height);
                    }
                    
                }
                else if (drawMode=="line")
                {
                    g.DrawLine(pen, start, e.Location);
                }
                
                
            }
            moving = false;
            x = 0;
            y = 0;
            
            
            
        }
    }
}
