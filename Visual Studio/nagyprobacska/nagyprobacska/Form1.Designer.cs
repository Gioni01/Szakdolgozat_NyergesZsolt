namespace nagyprobacska
{
    partial class Dynamics_visualization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dynamics_visualization));
            this.thetimer = new System.Windows.Forms.Timer(this.components);
            this.sorosport = new System.IO.Ports.SerialPort(this.components);
            this.To_the_start = new System.Windows.Forms.CheckBox();
            this.lbl_x = new System.Windows.Forms.Label();
            this.lbl_y = new System.Windows.Forms.Label();
            this.lbl_theta = new System.Windows.Forms.Label();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.CAR = new System.Windows.Forms.PictureBox();
            this.stop = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CAR)).BeginInit();
            this.SuspendLayout();
            // 
            // thetimer
            // 
            this.thetimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sorosport
            // 
            this.sorosport.PortName = "COM7";
            this.sorosport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // To_the_start
            // 
            this.To_the_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.To_the_start.AutoSize = true;
            this.To_the_start.BackColor = System.Drawing.Color.YellowGreen;
            this.To_the_start.Location = new System.Drawing.Point(98, 90);
            this.To_the_start.Name = "To_the_start";
            this.To_the_start.Size = new System.Drawing.Size(71, 23);
            this.To_the_start.TabIndex = 0;
            this.To_the_start.Text = "To the start";
            this.To_the_start.UseVisualStyleBackColor = false;
            this.To_the_start.Click += new System.EventHandler(this.To_the_start_Click);
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Location = new System.Drawing.Point(95, 274);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(35, 13);
            this.lbl_x.TabIndex = 2;
            this.lbl_x.Text = "label1";
            // 
            // lbl_y
            // 
            this.lbl_y.AutoSize = true;
            this.lbl_y.Location = new System.Drawing.Point(95, 304);
            this.lbl_y.Name = "lbl_y";
            this.lbl_y.Size = new System.Drawing.Size(35, 13);
            this.lbl_y.TabIndex = 3;
            this.lbl_y.Text = "label1";
            // 
            // lbl_theta
            // 
            this.lbl_theta.AutoSize = true;
            this.lbl_theta.Location = new System.Drawing.Point(95, 337);
            this.lbl_theta.Name = "lbl_theta";
            this.lbl_theta.Size = new System.Drawing.Size(35, 13);
            this.lbl_theta.TabIndex = 4;
            this.lbl_theta.Text = "label1";
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(213, 269);
            this.btn_left.Margin = new System.Windows.Forms.Padding(2);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(43, 23);
            this.btn_left.TabIndex = 5;
            this.btn_left.Text = "balra";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(213, 300);
            this.btn_right.Margin = new System.Windows.Forms.Padding(2);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(51, 20);
            this.btn_right.TabIndex = 5;
            this.btn_right.Text = "jobbra";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // CAR
            // 
            this.CAR.BackColor = System.Drawing.Color.Transparent;
            this.CAR.Image = global::nagyprobacska.Properties.Resources.car_jo;
            this.CAR.Location = new System.Drawing.Point(56, 24);
            this.CAR.Name = "CAR";
            this.CAR.Size = new System.Drawing.Size(45, 49);
            this.CAR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CAR.TabIndex = 1;
            this.CAR.TabStop = false;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(222, 332);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(42, 23);
            this.stop.TabIndex = 6;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(160, 304);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(34, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Dynamics_visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::nagyprobacska.Properties.Resources.map;
            this.ClientSize = new System.Drawing.Size(617, 442);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.lbl_theta);
            this.Controls.Add(this.lbl_y);
            this.Controls.Add(this.lbl_x);
            this.Controls.Add(this.CAR);
            this.Controls.Add(this.To_the_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dynamics_visualization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamics_visualization";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer thetimer;
        private System.IO.Ports.SerialPort sorosport;
        private System.Windows.Forms.CheckBox To_the_start;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.Label lbl_y;
        private System.Windows.Forms.Label lbl_theta;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.PictureBox CAR;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button exit;
    }
}

