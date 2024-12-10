using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nagyprobacska
{
    public partial class Dynamics_visualization : Form
    {
        public Dynamics_visualization()
        {
            InitializeComponent();
        }

        //variables
        int x=0 , y =0;
        double theta=0;
        double prev_theta = 0;
        double prev_x = 0;
        double prev_y = 0;
        double delta_theta = 0;
        double delta_x = 0;
        double delta_y = 0;
        bool new_angle = false;
        int posx=0, posy=0;
        bool allj=false;

        private void Form1_Load(object sender, EventArgs e)
        {
            sorosport.Open();
            thetimer.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

/*
            if (new_angle)
            {
                RotatePictureBox(CAR, (float)delta_theta);
                new_angle = false;
            }


            int targetX = x + 70;
            int targetY = y + 35;
            int currentX = CAR.Location.X;
            int currentY = CAR.Location.Y;

            int stepX = (targetX - currentX) / 10;
            int stepY = (targetY - currentY) / 10;

            CAR.Location = new Point(currentX + stepX, currentY + stepY);



            lbl_x.Text = x.ToString();
            lbl_y.Text = y.ToString();
            lbl_theta.Text = theta.ToString();*/




/*
            if (new_angle)
            {
                RotatePictureBox(CAR, (float)delta_theta);
                new_angle = false;
            }
            lbl_x.Text = x.ToString();
            lbl_y.Text = y.ToString();
            lbl_theta.Text = theta.ToString();

            if (x == 0)
            {
                CAR.Location = new Point((int)prev_x + 70, (int)prev_y + 35);
            }
            else
            {
                CAR.Location = new Point(x + 70, y + 35);
            }*/
            //CAR.Location = new Point(x+70, y+35);

            lbl_x.Text = x.ToString();
            lbl_y.Text = y.ToString();
            lbl_theta.Text = theta.ToString();
        }

        private void RotatePictureBox(PictureBox pictureBox, float angle)
        {
            if (pictureBox.Image == null) return;

            Image originalImage = pictureBox.Image;

            Bitmap rotatedBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            rotatedBitmap.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                
                g.TranslateTransform((float)originalImage.Width / 2, (float)originalImage.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)originalImage.Width / 2, -(float)originalImage.Height / 2);

               
                g.DrawImage(originalImage, new Point(0, 0));
            }

            
            pictureBox.Image = rotatedBitmap;

            
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (allj) return;
            Thread.Sleep(50);
            int data_length = 20;
            byte[] ubx_rx = new byte[data_length];
            sorosport.Read(ubx_rx, 0, data_length);

            bool x_signed = (ubx_rx[17] & (1 << 2)) != 0;
            bool y_signed = (ubx_rx[17] & (1 << 1)) != 0;
            bool theta_signed = (ubx_rx[9] & (1 << 0)) != 0;
            int temp_x1 = (int)(ubx_rx[5] << 24 | ubx_rx[6] << 16 | ubx_rx[7] << 8 | ubx_rx[8]);
            int temp_y1 = (int)(ubx_rx[9] << 24 | ubx_rx[10] << 16 | ubx_rx[11] << 8 | ubx_rx[12]);
            int temp_theta1 = (int)(ubx_rx[13] << 24 | ubx_rx[14] << 16 | ubx_rx[15] << 8 | ubx_rx[16]);

            double temp_theta = (double)temp_theta1 / 10000;


            x = temp_x1;
            y=temp_y1*10;
            theta = temp_theta*180/Math.PI*10;

            if (x_signed)
            {
                x = -1 * x;
            }
            if (y_signed)
            {
                y = -1 * y;
            }

            if (theta_signed)
            {
                theta = -1 * theta;
                if (prev_theta > 0)
                {
                    delta_theta = theta - prev_theta;
                }
                else
                {
                    delta_theta = theta + prev_theta;
                }
            }
            else
            {
                delta_theta = theta - prev_theta;
            }
            delta_x = Math.Abs(x - prev_x);
            delta_y= Math.Abs(y - prev_y);
            prev_x = x; prev_y = y;
            prev_theta = theta;
            posx += ((int)delta_x / 10000 + x + 75);
            posy += ((int)delta_y / 10000 + y + 30);
            new_angle = true;


            CAR.Invoke(new Action(() =>
            {



/*
                if (new_angle)
                {
                    RotatePictureBox(CAR, (float)delta_theta);
                    new_angle = false;
                }


                int targetX = x + 70;
                int targetY = y + 35;
                int currentX = CAR.Location.X;
                int currentY = CAR.Location.Y;

                int stepX = (targetX - currentX) / 10;
                int stepY = (targetY - currentY) / 10;

                CAR.Location = new Point(currentX + stepX, currentY + stepY);



                lbl_x.Text = x.ToString();
                lbl_y.Text = y.ToString();
                lbl_theta.Text = theta.ToString();*/





                if (new_angle)
                {
                    RotatePictureBox(CAR, (float)delta_theta);
                    new_angle = false;
                }
                lbl_x.Text = x.ToString();
                lbl_y.Text = y.ToString();
                lbl_theta.Text = theta.ToString();

                if (x == 0)
                {
                    CAR.Location = new Point((int)prev_x + 70, (int)prev_y + 35);
                }
                else
                {
                    CAR.Location = new Point(x + 70, y + 35);
                }

            }));
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            RotatePictureBox(CAR, 10);
        }


        private void stop_Click(object sender, EventArgs e)
        {
            if (allj==false)
            {
                allj = true;
            }
            else
            {
                allj = false;
            }    
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            RotatePictureBox(CAR, -10);
        }

        void To_the_start_Click(object sender, EventArgs e)
        {
            x = 0; y = 0;
            CAR.Location=new Point(x+70, y+35);
            delta_theta = 0;
            theta = 0;
            string path = Path.Combine(Application.StartupPath, "Resources", "car_jo.png");
            CAR.Image = Image.FromFile(path);

        }
    }
}
