using System;
using System.Collections.Generic;
using System.ComponentModel; // BindingList
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MovieManagerGUI
{
    public partial class Form1 : Form
    {
        private BindingList<Movie> _all = new BindingList<Movie>();
        private string _filePath;

        public Form1()
        {
            InitializeComponent();

            _filePath = Path.Combine(AppContext.BaseDirectory, "movies.xml");

            // Setup combos
            string[] genres = new string[]
            {
                "Action","Drama","Comedy","Sci-Fi","Horror","Romance","Documentary","Animation","Thriller","Other"
            };
            cmbAddGenre.Items.AddRange(genres);
            if (cmbAddGenre.Items.Count > 0) cmbAddGenre.SelectedIndex = 0;

            cmbFilterGenre.Items.Add("All");
            cmbFilterGenre.Items.AddRange(genres);
            cmbFilterGenre.SelectedIndex = 0;

            cmbSort.Items.AddRange(new object[] {
                "Title (A→Z)",
                "Year (Newest)",
                "Year (Oldest)",
                "Rating (High→Low)",
                "Rating (Low→High)"
            });
            cmbSort.SelectedIndex = 0;

            // Grid binding
            dgvMovies.AutoGenerateColumns = false;
            dgvMovies.DataSource = _all;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.MultiSelect = true;

            // Try load
            LoadMovies();

            // Refresh the view initially
            ApplyFilters();

            // Persist on exit
            this.FormClosing += (s, e) => SaveMovies();
        }

        // ------------ Buttons ------------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = (txtTitle.Text ?? "").Trim();
            if (title.Length == 0)
            {
                MessageBox.Show("Please enter a title.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text, out year) || year < 1888 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Please enter a valid year.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return;
            }

            string genre = cmbAddGenre.SelectedItem != null ? cmbAddGenre.SelectedItem.ToString() : "Other";
            double rating = (double)numRating.Value; // 0.0 – 10.0

            var movie = new Movie
            {
                Title = title,
                Year = year,
                Genre = genre,
                Rating = rating
            };

            _all.Add(movie);

            // Clear inputs
            txtTitle.Clear();
            txtYear.Clear();
            cmbAddGenre.SelectedIndex = 0;
            numRating.Value = 7;
            txtTitle.Focus();

            ApplyFilters();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select one or more movies to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Delete selected movie(s)?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            // collect then remove
            var toRemove = new List<Movie>();
            foreach (DataGridViewRow row in dgvMovies.SelectedRows)
            {
                var m = row.DataBoundItem as Movie;
                if (m != null) toRemove.Add(m);
            }
            foreach (var m in toRemove)
            {
                _all.Remove(m);
            }
            ApplyFilters();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMovies();
            MessageBox.Show("Saved ✔", "Movie Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ------------ Filters & Sorting (LINQ) ------------

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<Movie> q = _all;

            // Search by title
            string term = (txtSearch.Text ?? "").Trim();
            if (term.Length > 0)
            {
                q = q.Where(m => IndexOfIgnoreCase(m.Title, term) >= 0);
            }

            // Genre filter
            string g = cmbFilterGenre.SelectedItem != null ? cmbFilterGenre.SelectedItem.ToString() : "All";
            if (g != "All")
            {
                q = q.Where(m => string.Equals(m.Genre, g, StringComparison.OrdinalIgnoreCase));
            }

            // Sort
            string sort = cmbSort.SelectedItem != null ? cmbSort.SelectedItem.ToString() : "Title (A→Z)";
            if (sort == "Title (A→Z)")
                q = q.OrderBy(m => m.Title);
            else if (sort == "Year (Newest)")
                q = q.OrderByDescending(m => m.Year).ThenBy(m => m.Title);
            else if (sort == "Year (Oldest)")
                q = q.OrderBy(m => m.Year).ThenBy(m => m.Title);
            else if (sort == "Rating (High→Low)")
                q = q.OrderByDescending(m => m.Rating).ThenBy(m => m.Title);
            else if (sort == "Rating (Low→High)")
                q = q.OrderBy(m => m.Rating).ThenBy(m => m.Title);

            // Bind (note: list contains references to same Movie objects)
            var view = q.ToList();
            dgvMovies.DataSource = new BindingList<Movie>(view);

            // Stats
            int count = view.Count;
            double avg = count > 0 ? view.Average(m => m.Rating) : 0.0;
            int minYear = count > 0 ? view.Min(m => m.Year) : 0;
            int maxYear = count > 0 ? view.Max(m => m.Year) : 0;
            lblStats.Text = count == 0
                ? "No movies"
                : string.Format("Movies: {0} • Avg Rating: {1:0.0} • Years: {2}-{3}", count, avg, minYear, maxYear);
        }

        private static int IndexOfIgnoreCase(string source, string term)
        {
            if (source == null) return -1;
            return source.IndexOf(term, StringComparison.OrdinalIgnoreCase);
        }

        // ------------ Persistence ------------

        private void LoadMovies()
        {
            try
            {
                if (!File.Exists(_filePath)) return;
                using (var fs = File.OpenRead(_filePath))
                {
                    var xs = new XmlSerializer(typeof(List<Movie>));
                    var list = xs.Deserialize(fs) as List<Movie>;
                    _all = new BindingList<Movie>(list ?? new List<Movie>());
                    dgvMovies.DataSource = _all;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load movies: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveMovies()
        {
            try
            {
                var list = _all.ToList();
                using (var fs = File.Create(_filePath))
                {
                    var xs = new XmlSerializer(typeof(List<Movie>));
                    xs.Serialize(fs, list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save movies: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    // ------------ Model ------------
    public class Movie
    {
        public string Title { get; set; }    // e.g., "Interstellar"
        public int Year { get; set; }        // e.g., 2014
        public string Genre { get; set; }    // e.g., "Sci-Fi"
        public double Rating { get; set; }   // 0.0 - 10.0
    }
}
