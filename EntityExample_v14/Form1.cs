using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityExample_v14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "localDbDataSet.Music". При необходимости она может быть перемещена или удалена.
            this.musicTableAdapter.Fill(this.localDbDataSet.Music);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Music music = new Music();
            music.name = textBox1.Text;
            music.author = textBox2.Text;
            music.release_date = DateTime.Parse(textBox3.Text);

            localDbEntities _db = new localDbEntities();
            _db.Musics.Add(music);
            _db.SaveChanges();

            List<Music> musicsList = new List<Music>();
            musicsList = _db.Musics.ToList();
            dataGridView1.DataSource = musicsList;

        }
    }
}
