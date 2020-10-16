namespace CoreVisual
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape9 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape8 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape7 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPFID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage7 = new System.Windows.Forms.Label();
            this.lblErrorMessage6 = new System.Windows.Forms.Label();
            this.lblErrorMessage5 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage4 = new System.Windows.Forms.Label();
            this.lblErrorMessage3 = new System.Windows.Forms.Label();
            this.lblErrorMessage2 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.PBWELCOME = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnMin = new System.Windows.Forms.PictureBox();
            this.btnCls = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBWELCOME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCls)).BeginInit();
            this.SuspendLayout();
            // 
            // txtN
            // 
            this.txtN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtN.ForeColor = System.Drawing.Color.DimGray;
            this.txtN.Location = new System.Drawing.Point(347, 87);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(536, 20);
            this.txtN.TabIndex = 25;
            this.txtN.Text = "NOMBRE";
            this.txtN.Enter += new System.EventHandler(this.txtN_Enter);
            this.txtN.Leave += new System.EventHandler(this.txtN_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(550, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 33);
            this.label5.TabIndex = 0;
            this.label5.Text = "USUARIO";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dGV1
            // 
            this.dGV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dGV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGV1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dGV1.GridColor = System.Drawing.Color.DimGray;
            this.dGV1.Location = new System.Drawing.Point(278, 565);
            this.dGV1.MultiSelect = false;
            this.dGV1.Name = "dGV1";
            this.dGV1.Size = new System.Drawing.Size(651, 181);
            this.dGV1.TabIndex = 13;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape9,
            this.lineShape8,
            this.lineShape7,
            this.lineShape6,
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1000, 861);
            this.shapeContainer1.TabIndex = 15;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape9
            // 
            this.lineShape9.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape9.Enabled = false;
            this.lineShape9.Name = "lineShape9";
            this.lineShape9.X1 = 341;
            this.lineShape9.X2 = 876;
            this.lineShape9.Y1 = 520;
            this.lineShape9.Y2 = 520;
            // 
            // lineShape8
            // 
            this.lineShape8.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape8.Enabled = false;
            this.lineShape8.Name = "lineShape8";
            this.lineShape8.X1 = 344;
            this.lineShape8.X2 = 879;
            this.lineShape8.Y1 = 463;
            this.lineShape8.Y2 = 463;
            // 
            // lineShape7
            // 
            this.lineShape7.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape7.Enabled = false;
            this.lineShape7.Name = "lineShape7";
            this.lineShape7.X1 = 342;
            this.lineShape7.X2 = 877;
            this.lineShape7.Y1 = 409;
            this.lineShape7.Y2 = 409;
            // 
            // lineShape6
            // 
            this.lineShape6.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape6.Enabled = false;
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 342;
            this.lineShape6.X2 = 877;
            this.lineShape6.Y1 = 350;
            this.lineShape6.Y2 = 350;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape5.Enabled = false;
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 493;
            this.lineShape5.X2 = 745;
            this.lineShape5.Y1 = 66;
            this.lineShape5.Y2 = 66;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape4.Enabled = false;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 343;
            this.lineShape4.X2 = 878;
            this.lineShape4.Y1 = 291;
            this.lineShape4.Y2 = 291;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape3.Enabled = false;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 346;
            this.lineShape3.X2 = 881;
            this.lineShape3.Y1 = 232;
            this.lineShape3.Y2 = 232;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 348;
            this.lineShape2.X2 = 883;
            this.lineShape2.Y1 = 174;
            this.lineShape2.Y2 = 174;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.DimGray;
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 346;
            this.lineShape1.X2 = 881;
            this.lineShape1.Y1 = 110;
            this.lineShape1.Y2 = 110;
            // 
            // txtLN
            // 
            this.txtLN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtLN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLN.ForeColor = System.Drawing.Color.DimGray;
            this.txtLN.Location = new System.Drawing.Point(346, 154);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(536, 20);
            this.txtLN.TabIndex = 16;
            this.txtLN.Text = "APELLIDO";
            this.txtLN.Enter += new System.EventHandler(this.txtLN_Enter);
            this.txtLN.Leave += new System.EventHandler(this.txtLN_Leave);
            // 
            // txtC
            // 
            this.txtC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.Color.DimGray;
            this.txtC.Location = new System.Drawing.Point(347, 210);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(536, 20);
            this.txtC.TabIndex = 17;
            this.txtC.Text = "CÉDULA";
            this.txtC.Enter += new System.EventHandler(this.txtC_Enter);
            this.txtC.Leave += new System.EventHandler(this.txtC_Leave);
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.ForeColor = System.Drawing.Color.DimGray;
            this.txtTel.Location = new System.Drawing.Point(346, 269);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(536, 20);
            this.txtTel.TabIndex = 18;
            this.txtTel.Text = "TELÉFONO";
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.Enter += new System.EventHandler(this.txtTel_Enter);
            this.txtTel.Leave += new System.EventHandler(this.txtTel_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.PBWELCOME);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 861);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(822, 749);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 33);
            this.label1.TabIndex = 34;
            this.label1.Text = "CLIENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(263, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 33);
            this.label2.TabIndex = 36;
            this.label2.Text = "CAJA";
            // 
            // myTimer
            // 
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTimer.Location = new System.Drawing.Point(265, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(306, 23);
            this.lblTimer.TabIndex = 39;
            this.lblTimer.Text = "label3";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.DimGray;
            this.txtUserName.Location = new System.Drawing.Point(343, 329);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(536, 20);
            this.txtUserName.TabIndex = 40;
            this.txtUserName.Text = "USERNAME";
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtPass.Location = new System.Drawing.Point(342, 387);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(536, 20);
            this.txtPass.TabIndex = 42;
            this.txtPass.Text = "PASSWORD";
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // txtPFID
            // 
            this.txtPFID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtPFID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPFID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPFID.ForeColor = System.Drawing.Color.DimGray;
            this.txtPFID.Location = new System.Drawing.Point(343, 443);
            this.txtPFID.Name = "txtPFID";
            this.txtPFID.Size = new System.Drawing.Size(536, 20);
            this.txtPFID.TabIndex = 44;
            this.txtPFID.Text = "PERFIL_ID";
            this.txtPFID.Enter += new System.EventHandler(this.txtPFID_Enter);
            this.txtPFID.Leave += new System.EventHandler(this.txtPFID_Leave);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.DimGray;
            this.txtID.Location = new System.Drawing.Point(344, 500);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(107, 20);
            this.txtID.TabIndex = 46;
            this.txtID.Text = "ID";
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.Enter += new System.EventHandler(this.txtID_Enter);
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::CoreVisual.Properties.Resources.ID2;
            this.pictureBox9.Location = new System.Drawing.Point(247, 442);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(91, 80);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 48;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CoreVisual.Properties.Resources.personcircleicon;
            this.pictureBox3.Location = new System.Drawing.Point(247, 350);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(90, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 47;
            this.pictureBox3.TabStop = false;
            // 
            // lblErrorMessage7
            // 
            this.lblErrorMessage7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage7.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage7.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage7.Location = new System.Drawing.Point(343, 468);
            this.lblErrorMessage7.Name = "lblErrorMessage7";
            this.lblErrorMessage7.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage7.TabIndex = 45;
            this.lblErrorMessage7.Text = "Error, Perfil_ID no encontrado.";
            this.lblErrorMessage7.Visible = false;
            // 
            // lblErrorMessage6
            // 
            this.lblErrorMessage6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage6.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage6.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage6.Location = new System.Drawing.Point(343, 410);
            this.lblErrorMessage6.Name = "lblErrorMessage6";
            this.lblErrorMessage6.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage6.TabIndex = 43;
            this.lblErrorMessage6.Text = "Error, Password no encontrado.";
            this.lblErrorMessage6.Visible = false;
            // 
            // lblErrorMessage5
            // 
            this.lblErrorMessage5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage5.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage5.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage5.Location = new System.Drawing.Point(343, 354);
            this.lblErrorMessage5.Name = "lblErrorMessage5";
            this.lblErrorMessage5.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage5.TabIndex = 41;
            this.lblErrorMessage5.Text = "Error, Username no encontrado.";
            this.lblErrorMessage5.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::CoreVisual.Properties.Resources.BanCovid2;
            this.pictureBox7.Location = new System.Drawing.Point(373, 749);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(443, 100);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 38;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::CoreVisual.Properties.Resources.paymentsbilling;
            this.pictureBox6.Location = new System.Drawing.Point(254, 785);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(107, 64);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 37;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::CoreVisual.Properties.Resources.Client;
            this.pictureBox5.Location = new System.Drawing.Point(822, 785);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(107, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 35;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CoreVisual.Properties.Resources.telephones_animation_gif_261340;
            this.pictureBox4.Location = new System.Drawing.Point(254, 269);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 68);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CoreVisual.Properties.Resources.USER;
            this.pictureBox2.Location = new System.Drawing.Point(254, 103);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CoreVisual.Properties.Resources.Student_id_icon;
            this.pictureBox1.Location = new System.Drawing.Point(254, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // lblErrorMessage4
            // 
            this.lblErrorMessage4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage4.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage4.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage4.Location = new System.Drawing.Point(341, 296);
            this.lblErrorMessage4.Name = "lblErrorMessage4";
            this.lblErrorMessage4.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage4.TabIndex = 30;
            this.lblErrorMessage4.Text = "Error, teléfono no encontrado.";
            this.lblErrorMessage4.Visible = false;
            // 
            // lblErrorMessage3
            // 
            this.lblErrorMessage3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage3.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage3.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage3.Location = new System.Drawing.Point(348, 236);
            this.lblErrorMessage3.Name = "lblErrorMessage3";
            this.lblErrorMessage3.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage3.TabIndex = 29;
            this.lblErrorMessage3.Text = "Error, cédula no encontrada.";
            this.lblErrorMessage3.Visible = false;
            // 
            // lblErrorMessage2
            // 
            this.lblErrorMessage2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage2.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage2.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage2.Location = new System.Drawing.Point(344, 177);
            this.lblErrorMessage2.Name = "lblErrorMessage2";
            this.lblErrorMessage2.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage2.TabIndex = 28;
            this.lblErrorMessage2.Text = "Error, apellido no encontrado.";
            this.lblErrorMessage2.Visible = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Image = global::CoreVisual.Properties.Resources._24px;
            this.lblErrorMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage.Location = new System.Drawing.Point(348, 113);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(209, 30);
            this.lblErrorMessage.TabIndex = 27;
            this.lblErrorMessage.Text = "Error, nombre no encontrado.";
            this.lblErrorMessage.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Image = global::CoreVisual.Properties.Resources.ADD;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(278, 532);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 27);
            this.btnAgregar.TabIndex = 26;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // PBWELCOME
            // 
            this.PBWELCOME.Image = global::CoreVisual.Properties.Resources.GrimyBetterAdder_size_restricted;
            this.PBWELCOME.Location = new System.Drawing.Point(0, 26);
            this.PBWELCOME.Name = "PBWELCOME";
            this.PBWELCOME.Size = new System.Drawing.Size(243, 143);
            this.PBWELCOME.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBWELCOME.TabIndex = 2;
            this.PBWELCOME.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::CoreVisual.Properties.Resources.CORE;
            this.pictureBox8.Location = new System.Drawing.Point(-8, 248);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(251, 290);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 1;
            this.pictureBox8.TabStop = false;
            // 
            // btnMin
            // 
            this.btnMin.Image = global::CoreVisual.Properties.Resources.Minimize_Icon;
            this.btnMin.Location = new System.Drawing.Point(946, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(20, 20);
            this.btnMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMin.TabIndex = 23;
            this.btnMin.TabStop = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnCls
            // 
            this.btnCls.Image = global::CoreVisual.Properties.Resources.Close_Icon;
            this.btnCls.Location = new System.Drawing.Point(972, 0);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(20, 20);
            this.btnCls.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCls.TabIndex = 22;
            this.btnCls.TabStop = false;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.LightGray;
            this.btnSearch.Image = global::CoreVisual.Properties.Resources.Lens;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(822, 532);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 27);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.LightGray;
            this.btnDelete.Image = global::CoreVisual.Properties.Resources.Remove;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(653, 532);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 27);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.LightGray;
            this.btnUpdate.Image = global::CoreVisual.Properties.Resources.UPDATE;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(450, 532);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(107, 27);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1000, 861);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblErrorMessage7);
            this.Controls.Add(this.txtPFID);
            this.Controls.Add(this.lblErrorMessage6);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblErrorMessage5);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblErrorMessage4);
            this.Controls.Add(this.lblErrorMessage3);
            this.Controls.Add(this.lblErrorMessage2);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnCls);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.92D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBWELCOME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dGV1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtLN;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox btnCls;
        private System.Windows.Forms.PictureBox btnMin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblErrorMessage2;
        private System.Windows.Forms.Label lblErrorMessage3;
        private System.Windows.Forms.Label lblErrorMessage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox PBWELCOME;
        private System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox txtUserName;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape7;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private System.Windows.Forms.Label lblErrorMessage5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblErrorMessage6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape8;
        private System.Windows.Forms.TextBox txtPFID;
        private System.Windows.Forms.Label lblErrorMessage7;
        private System.Windows.Forms.TextBox txtID;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox9;
    }
}

