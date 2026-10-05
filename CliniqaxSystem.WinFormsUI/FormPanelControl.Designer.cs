namespace CliniqaxSystem.WinFormsUI
{
    partial class FormPanelControl
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
            components = new System.ComponentModel.Container();
            picIconLogout = new PictureBox();
            panelTopBar = new Panel();
            flowLayoutPanelMenu = new FlowLayoutPanel();
            panelBrand = new Panel();
            pictureBoxLogo = new PictureBox();
            panelFooter = new Panel();
            pictureBoxUserIcon = new PictureBox();
            labelSessionUser = new Label();
            labelRoleName = new Label();
            labelClockTime = new Label();
            buttonLogout = new Button();
            panelMainContainer = new Panel();
            timerClock = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picIconLogout).BeginInit();
            panelTopBar.SuspendLayout();
            panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserIcon).BeginInit();
            SuspendLayout();
            // 
            // picIconLogout
            // 
            picIconLogout.BackColor = Color.FromArgb(239, 68, 68);
            picIconLogout.Cursor = Cursors.Hand;
            picIconLogout.Image = Icons.nav_cerrar_sesion;
            picIconLogout.Location = new Point(1100, 0);
            picIconLogout.Name = "picIconLogout";
            picIconLogout.Size = new Size(39, 45);
            picIconLogout.SizeMode = PictureBoxSizeMode.Zoom;
            picIconLogout.TabIndex = 99;
            picIconLogout.TabStop = false;
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(235, 238, 242);
            panelTopBar.Controls.Add(flowLayoutPanelMenu);
            panelTopBar.Controls.Add(panelBrand);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1280, 90);
            panelTopBar.TabIndex = 0;
            // 
            // flowLayoutPanelMenu
            // 
            flowLayoutPanelMenu.AutoScroll = true;
            flowLayoutPanelMenu.Dock = DockStyle.Fill;
            flowLayoutPanelMenu.Location = new Point(180, 0);
            flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            flowLayoutPanelMenu.Padding = new Padding(10, 6, 10, 0);
            flowLayoutPanelMenu.Size = new Size(1100, 90);
            flowLayoutPanelMenu.TabIndex = 1;
            flowLayoutPanelMenu.WrapContents = false;
            // 
            // panelBrand
            // 
            panelBrand.BackColor = Color.White;
            panelBrand.Controls.Add(pictureBoxLogo);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(180, 90);
            panelBrand.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Icons.logo_cliniqax;
            pictureBoxLogo.Location = new Point(15, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(150, 66);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.Silver;
            panelFooter.Controls.Add(pictureBoxUserIcon);
            panelFooter.Controls.Add(labelSessionUser);
            panelFooter.Controls.Add(labelRoleName);
            panelFooter.Controls.Add(labelClockTime);
            panelFooter.Controls.Add(picIconLogout);
            panelFooter.Controls.Add(buttonLogout);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 755);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(1280, 45);
            panelFooter.TabIndex = 1;
            // 
            // pictureBoxUserIcon
            // 
            pictureBoxUserIcon.Image = Icons.nav_mi_perfil;
            pictureBoxUserIcon.Location = new Point(0, 0);
            pictureBoxUserIcon.Name = "pictureBoxUserIcon";
            pictureBoxUserIcon.Size = new Size(51, 45);
            pictureBoxUserIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserIcon.TabIndex = 0;
            pictureBoxUserIcon.TabStop = false;
            // 
            // labelSessionUser
            // 
            labelSessionUser.AutoSize = true;
            labelSessionUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSessionUser.ForeColor = Color.FromArgb(2, 132, 199);
            labelSessionUser.Location = new Point(57, 12);
            labelSessionUser.Name = "labelSessionUser";
            labelSessionUser.Size = new Size(81, 21);
            labelSessionUser.TabIndex = 1;
            labelSessionUser.Text = "USUARIO";
            // 
            // labelRoleName
            // 
            labelRoleName.AutoSize = true;
            labelRoleName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRoleName.ForeColor = Color.FromArgb(2, 132, 199);
            labelRoleName.Location = new Point(285, 12);
            labelRoleName.Name = "labelRoleName";
            labelRoleName.Size = new Size(156, 21);
            labelRoleName.TabIndex = 2;
            labelRoleName.Text = "[ADMINISTRADOR]";
            // 
            // labelClockTime
            // 
            labelClockTime.Dock = DockStyle.Right;
            labelClockTime.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelClockTime.ForeColor = Color.White;
            labelClockTime.Location = new Point(940, 0);
            labelClockTime.Name = "labelClockTime";
            labelClockTime.Size = new Size(160, 45);
            labelClockTime.TabIndex = 3;
            labelClockTime.Text = "00:00:00";
            labelClockTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(239, 68, 68);
            buttonLogout.Cursor = Cursors.Hand;
            buttonLogout.Dock = DockStyle.Right;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(1100, 0);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Padding = new Padding(28, 0, 0, 0);
            buttonLogout.Size = new Size(180, 45);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "CERRAR SESIÓN";
            buttonLogout.UseVisualStyleBackColor = false;
            // 
            // panelMainContainer
            // 
            panelMainContainer.BackColor = Color.FromArgb(248, 250, 252);
            panelMainContainer.Dock = DockStyle.Fill;
            panelMainContainer.Location = new Point(0, 90);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new Size(1280, 665);
            panelMainContainer.TabIndex = 2;
            // 
            // FormPanelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 800);
            Controls.Add(panelMainContainer);
            Controls.Add(panelFooter);
            Controls.Add(panelTopBar);
            Name = "FormPanelControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cliniqax - Panel de Control";
            ((System.ComponentModel.ISupportInitialize)picIconLogout).EndInit();
            panelTopBar.ResumeLayout(false);
            panelBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopBar;
        private Panel panelBrand;
        private PictureBox pictureBoxLogo;
        private FlowLayoutPanel flowLayoutPanelMenu;
        private Panel panelFooter;
        private PictureBox pictureBoxUserIcon;
        private Label labelSessionUser;
        private Label labelRoleName;
        private Label labelClockTime;
        private Button buttonLogout;
        private PictureBox picIconLogout;
        private Panel panelMainContainer;
        private System.Windows.Forms.Timer timerClock;
    }
}