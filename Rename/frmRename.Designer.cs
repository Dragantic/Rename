namespace Rename
{
    partial class frmRename
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
            if (disposing && components != null)
                components.Dispose();
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
			this.chkSubFolders = new System.Windows.Forms.CheckBox();
			this.lblMates = new System.Windows.Forms.Label();
			this.lsvBlimps = new System.Windows.Forms.ListView();
			this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colRename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.rowHeight = new System.Windows.Forms.ImageList(this.components);
			this.btnRescan = new System.Windows.Forms.Button();
			this.btnCommit = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.txtAfter = new System.Windows.Forms.TextBox();
			this.lblSyntax = new System.Windows.Forms.Label();
			this.chkDuplicates = new System.Windows.Forms.CheckBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtBefore = new System.Windows.Forms.TextBox();
			this.chkSearch = new System.Windows.Forms.CheckBox();
			this.chkNameSwap = new System.Windows.Forms.CheckBox();
			this.chkFolderName = new System.Windows.Forms.CheckBox();
			this.pbar = new System.Windows.Forms.ProgressBar();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnRecycle = new System.Windows.Forms.Button();
			this.btnNames = new System.Windows.Forms.Button();
			this.chkExtChecker = new System.Windows.Forms.CheckBox();
			this.btnPath = new System.Windows.Forms.Button();
			this.chkForce = new System.Windows.Forms.CheckBox();
			this.lblForce = new System.Windows.Forms.Label();
			this.cxtBlimps = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmOriginal = new System.Windows.Forms.ToolStripMenuItem();
			this.cxtBlimps.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkSubFolders
			// 
			this.chkSubFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSubFolders.AutoSize = true;
			this.chkSubFolders.Location = new System.Drawing.Point(490, 364);
			this.chkSubFolders.Name = "chkSubFolders";
			this.chkSubFolders.Size = new System.Drawing.Size(82, 17);
			this.chkSubFolders.TabIndex = 9;
			this.chkSubFolders.Text = "Sub Folders";
			this.chkSubFolders.UseVisualStyleBackColor = true;
			// 
			// lblMates
			// 
			this.lblMates.AutoSize = true;
			this.lblMates.Location = new System.Drawing.Point(14, 6);
			this.lblMates.MaximumSize = new System.Drawing.Size(520, 13);
			this.lblMates.Name = "lblMates";
			this.lblMates.Size = new System.Drawing.Size(0, 13);
			this.lblMates.TabIndex = 14;
			// 
			// lsvBlimps
			// 
			this.lsvBlimps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lsvBlimps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colRename});
			this.lsvBlimps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lsvBlimps.FullRowSelect = true;
			this.lsvBlimps.Location = new System.Drawing.Point(13, 29);
			this.lsvBlimps.Name = "lsvBlimps";
			this.lsvBlimps.Size = new System.Drawing.Size(559, 313);
			this.lsvBlimps.SmallImageList = this.rowHeight;
			this.lsvBlimps.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvBlimps.TabIndex = 0;
			this.lsvBlimps.UseCompatibleStateImageBehavior = false;
			this.lsvBlimps.View = System.Windows.Forms.View.Details;
			this.lsvBlimps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvBlimps_ColumnClick);
			this.lsvBlimps.SelectedIndexChanged += new System.EventHandler(this.lsvBlimps_SelectedIndexChanged);
			this.lsvBlimps.DoubleClick += new System.EventHandler(this.lsvBlimps_DoubleClick);
			this.lsvBlimps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsvBlimps_MouseClick);
			// 
			// colDate
			// 
			this.colDate.Text = "ModDate";
			this.colDate.Width = 85;
			// 
			// colRename
			// 
			this.colRename.Text = "Name Change";
			this.colRename.Width = 100;
			// 
			// rowHeight
			// 
			this.rowHeight.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.rowHeight.ImageSize = new System.Drawing.Size(1, 60);
			this.rowHeight.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnRescan
			// 
			this.btnRescan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRescan.Location = new System.Drawing.Point(226, 363);
			this.btnRescan.Name = "btnRescan";
			this.btnRescan.Size = new System.Drawing.Size(75, 23);
			this.btnRescan.TabIndex = 1;
			this.btnRescan.Text = "Rescan";
			this.btnRescan.UseVisualStyleBackColor = true;
			this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
			// 
			// btnCommit
			// 
			this.btnCommit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCommit.Location = new System.Drawing.Point(307, 363);
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Size = new System.Drawing.Size(75, 23);
			this.btnCommit.TabIndex = 2;
			this.btnCommit.Text = "Commit";
			this.btnCommit.UseVisualStyleBackColor = true;
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(226, 392);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// txtAfter
			// 
			this.txtAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtAfter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAfter.Location = new System.Drawing.Point(93, 392);
			this.txtAfter.Name = "txtAfter";
			this.txtAfter.Size = new System.Drawing.Size(127, 23);
			this.txtAfter.TabIndex = 6;
			this.txtAfter.Text = "[artist]_[title]~[tag]";
			this.txtAfter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressEnter);
			// 
			// lblSyntax
			// 
			this.lblSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSyntax.AutoSize = true;
			this.lblSyntax.Location = new System.Drawing.Point(15, 396);
			this.lblSyntax.Name = "lblSyntax";
			this.lblSyntax.Size = new System.Drawing.Size(72, 13);
			this.lblSyntax.TabIndex = 17;
			this.lblSyntax.Text = "Replace with:";
			// 
			// chkDuplicates
			// 
			this.chkDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkDuplicates.AutoSize = true;
			this.chkDuplicates.Location = new System.Drawing.Point(395, 364);
			this.chkDuplicates.Name = "chkDuplicates";
			this.chkDuplicates.Size = new System.Drawing.Size(76, 17);
			this.chkDuplicates.TabIndex = 8;
			this.chkDuplicates.Text = "Duplicates";
			this.chkDuplicates.UseVisualStyleBackColor = true;
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(30, 367);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(59, 13);
			this.lblSearch.TabIndex = 16;
			this.lblSearch.Tag = "";
			this.lblSearch.Text = "Search for:";
			// 
			// txtBefore
			// 
			this.txtBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtBefore.Enabled = false;
			this.txtBefore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBefore.Location = new System.Drawing.Point(93, 363);
			this.txtBefore.Name = "txtBefore";
			this.txtBefore.Size = new System.Drawing.Size(127, 23);
			this.txtBefore.TabIndex = 5;
			this.txtBefore.Text = "[title]_by_[artist]-[tag]";
			this.txtBefore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PressEnter);
			// 
			// chkSearch
			// 
			this.chkSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkSearch.AutoSize = true;
			this.chkSearch.Location = new System.Drawing.Point(13, 367);
			this.chkSearch.Name = "chkSearch";
			this.chkSearch.Size = new System.Drawing.Size(15, 14);
			this.chkSearch.TabIndex = 7;
			this.chkSearch.UseVisualStyleBackColor = true;
			this.chkSearch.CheckedChanged += new System.EventHandler(this.chkSearch_CheckedChanged);
			// 
			// chkNameSwap
			// 
			this.chkNameSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkNameSwap.AutoSize = true;
			this.chkNameSwap.Location = new System.Drawing.Point(395, 387);
			this.chkNameSwap.Name = "chkNameSwap";
			this.chkNameSwap.Size = new System.Drawing.Size(84, 17);
			this.chkNameSwap.TabIndex = 10;
			this.chkNameSwap.Text = "Name Swap";
			this.chkNameSwap.UseVisualStyleBackColor = true;
			this.chkNameSwap.CheckedChanged += new System.EventHandler(this.chkNameSwap_CheckedChanged);
			// 
			// chkFolderName
			// 
			this.chkFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkFolderName.AutoSize = true;
			this.chkFolderName.Location = new System.Drawing.Point(490, 387);
			this.chkFolderName.Name = "chkFolderName";
			this.chkFolderName.Size = new System.Drawing.Size(86, 17);
			this.chkFolderName.TabIndex = 11;
			this.chkFolderName.Text = "Folder Name";
			this.chkFolderName.UseVisualStyleBackColor = true;
			// 
			// pbar
			// 
			this.pbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbar.Location = new System.Drawing.Point(13, 346);
			this.pbar.Name = "pbar";
			this.pbar.Size = new System.Drawing.Size(559, 12);
			this.pbar.Step = 1;
			this.pbar.TabIndex = 15;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.BackColor = System.Drawing.SystemColors.Menu;
			this.txtPath.Enabled = false;
			this.txtPath.Location = new System.Drawing.Point(167, 3);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(405, 20);
			this.txtPath.TabIndex = 13;
			// 
			// btnRecycle
			// 
			this.btnRecycle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRecycle.Enabled = false;
			this.btnRecycle.Location = new System.Drawing.Point(307, 392);
			this.btnRecycle.Name = "btnRecycle";
			this.btnRecycle.Size = new System.Drawing.Size(75, 23);
			this.btnRecycle.TabIndex = 4;
			this.btnRecycle.Text = "Recycle";
			this.btnRecycle.UseVisualStyleBackColor = true;
			this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
			// 
			// btnNames
			// 
			this.btnNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNames.Location = new System.Drawing.Point(394, 405);
			this.btnNames.Name = "btnNames";
			this.btnNames.Size = new System.Drawing.Size(24, 24);
			this.btnNames.TabIndex = 12;
			this.btnNames.Text = "...";
			this.btnNames.UseVisualStyleBackColor = true;
			this.btnNames.Click += new System.EventHandler(this.btnNames_Click);
			// 
			// chkExtChecker
			// 
			this.chkExtChecker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkExtChecker.AutoSize = true;
			this.chkExtChecker.Location = new System.Drawing.Point(490, 410);
			this.chkExtChecker.Name = "chkExtChecker";
			this.chkExtChecker.Size = new System.Drawing.Size(87, 17);
			this.chkExtChecker.TabIndex = 18;
			this.chkExtChecker.Text = "Ext. Checker";
			this.chkExtChecker.UseVisualStyleBackColor = true;
			// 
			// btnPath
			// 
			this.btnPath.Location = new System.Drawing.Point(137, 1);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(24, 24);
			this.btnPath.TabIndex = 19;
			this.btnPath.Text = "...";
			this.btnPath.UseVisualStyleBackColor = true;
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// chkForce
			// 
			this.chkForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkForce.AutoSize = true;
			this.chkForce.Location = new System.Drawing.Point(474, 411);
			this.chkForce.Name = "chkForce";
			this.chkForce.Size = new System.Drawing.Size(15, 14);
			this.chkForce.TabIndex = 20;
			this.chkForce.UseVisualStyleBackColor = true;
			// 
			// lblForce
			// 
			this.lblForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblForce.AutoSize = true;
			this.lblForce.Location = new System.Drawing.Point(464, 411);
			this.lblForce.Name = "lblForce";
			this.lblForce.Size = new System.Drawing.Size(10, 13);
			this.lblForce.TabIndex = 21;
			this.lblForce.Text = "!";
			// 
			// cxtBlimps
			// 
			this.cxtBlimps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOriginal});
			this.cxtBlimps.Name = "cxtBlimps";
			this.cxtBlimps.Size = new System.Drawing.Size(181, 48);
			// 
			// tsmOriginal
			// 
			this.tsmOriginal.Name = "tsmOriginal";
			this.tsmOriginal.Size = new System.Drawing.Size(180, 22);
			this.tsmOriginal.Text = "Show Original";
			this.tsmOriginal.Click += new System.EventHandler(this.tsmOriginal_Click);
			// 
			// frmRename
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.lblForce);
			this.Controls.Add(this.chkForce);
			this.Controls.Add(this.btnPath);
			this.Controls.Add(this.chkExtChecker);
			this.Controls.Add(this.btnNames);
			this.Controls.Add(this.btnRecycle);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.pbar);
			this.Controls.Add(this.chkFolderName);
			this.Controls.Add(this.chkNameSwap);
			this.Controls.Add(this.chkDuplicates);
			this.Controls.Add(this.chkSubFolders);
			this.Controls.Add(this.chkSearch);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.txtBefore);
			this.Controls.Add(this.lblSyntax);
			this.Controls.Add(this.txtAfter);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnCommit);
			this.Controls.Add(this.btnRescan);
			this.Controls.Add(this.lsvBlimps);
			this.Controls.Add(this.lblMates);
			this.MinimumSize = new System.Drawing.Size(600, 200);
			this.Name = "frmRename";
			this.Text = "Rename";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRename_FormClosing);
			this.Load += new System.EventHandler(this.frmRename_Load);
			this.Shown += new System.EventHandler(this.frmRename_Shown);
			this.cxtBlimps.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSubFolders;
        private System.Windows.Forms.Label lblMates;
        private System.Windows.Forms.ListView lsvBlimps;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colRename;
        private System.Windows.Forms.TextBox txtAfter;
        private System.Windows.Forms.Label lblSyntax;
        private System.Windows.Forms.ImageList rowHeight;
        private System.Windows.Forms.CheckBox chkDuplicates;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtBefore;
        private System.Windows.Forms.CheckBox chkSearch;
        private System.Windows.Forms.CheckBox chkNameSwap;
        private System.Windows.Forms.CheckBox chkFolderName;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.Button btnNames;
		private System.Windows.Forms.CheckBox chkExtChecker;
		private System.Windows.Forms.Button btnPath;
		private System.Windows.Forms.CheckBox chkForce;
		private System.Windows.Forms.Label lblForce;
		private System.Windows.Forms.ContextMenuStrip cxtBlimps;
		private System.Windows.Forms.ToolStripMenuItem tsmOriginal;
	}
}

