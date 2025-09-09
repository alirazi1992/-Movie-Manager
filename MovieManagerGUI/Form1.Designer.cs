namespace MovieManagerGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterGenre;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.DataGridView dgvMovies;
        private System.Windows.Forms.Label lblStats;

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cmbAddGenre;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRating;

        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRating;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterGenre = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            this.lblStats = new System.Windows.Forms.Label();

            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.cmbAddGenre = new System.Windows.Forms.ComboBox();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblSort = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();

            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRating = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();

            // Search label + box
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(16, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.Text = "Search:";
            this.txtSearch.Location = new System.Drawing.Point(66, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 20);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // Filter label + combo
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(260, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(36, 13);
            this.lblFilter.Text = "Genre:";
            this.cmbFilterGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterGenre.Location = new System.Drawing.Point(302, 13);
            this.cmbFilterGenre.Name = "cmbFilterGenre";
            this.cmbFilterGenre.Size = new System.Drawing.Size(120, 21);
            this.cmbFilterGenre.SelectedIndexChanged += new System.EventHandler(this.cmbFilterGenre_SelectedIndexChanged);

            // Sort label + combo
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(436, 16);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(29, 13);
            this.lblSort.Text = "Sort:";
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Location = new System.Drawing.Point(471, 13);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(160, 21);
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // Add panel controls (Title, Year, Genre, Rating, Add)
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 48);
            this.lblTitle.Text = "Title:";
            this.txtTitle.Location = new System.Drawing.Point(66, 45);
            this.txtTitle.Size = new System.Drawing.Size(260, 20);

            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(340, 48);
            this.lblYear.Text = "Year:";
            this.txtYear.Location = new System.Drawing.Point(374, 45);
            this.txtYear.Size = new System.Drawing.Size(60, 20);

            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(446, 48);
            this.lblGenre.Text = "Genre:";
            this.cmbAddGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddGenre.Location = new System.Drawing.Point(492, 45);
            this.cmbAddGenre.Size = new System.Drawing.Size(120, 21);

            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(620, 48);
            this.lblRating.Text = "Rating:";
            this.numRating.Location = new System.Drawing.Point(665, 45);
            this.numRating.DecimalPlaces = 1;
            this.numRating.Increment = 0.1M;
            this.numRating.Minimum = 0M;
            this.numRating.Maximum = 10M;
            this.numRating.Value = 7.0M;
            this.numRating.Size = new System.Drawing.Size(60, 20);

            this.btnAdd.Location = new System.Drawing.Point(735, 43);
            this.btnAdd.Size = new System.Drawing.Size(80, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Grid
            this.dgvMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                      | System.Windows.Forms.AnchorStyles.Left)
                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovies.Location = new System.Drawing.Point(19, 78);
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.Size = new System.Drawing.Size(796, 360);
            this.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colTitle, this.colYear, this.colGenre, this.colRating
            });

            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";

            this.colYear.DataPropertyName = "Year";
            this.colYear.HeaderText = "Year";

            this.colGenre.DataPropertyName = "Genre";
            this.colGenre.HeaderText = "Genre";

            this.colRating.DataPropertyName = "Rating";
            this.colRating.HeaderText = "Rating";

            // Delete / Save buttons + Stats
            this.btnDelete.Location = new System.Drawing.Point(19, 447);
            this.btnDelete.Size = new System.Drawing.Size(110, 26);
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnSave.Location = new System.Drawing.Point(139, 447);
            this.btnSave.Size = new System.Drawing.Size(90, 26);
            this.btnSave.Text = "Save Now";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(246, 453);
            this.lblStats.Text = "Movies: 0";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(834, 486);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.cmbAddGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.cmbFilterGenre);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Manager (Day 19)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
