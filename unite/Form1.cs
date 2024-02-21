using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace unite
{
    public partial class Form1 : Form
    {
        public string connectionStr = "server=localhost;username=postgres;database=museum;port=5432;password=1234";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Size = new System.Drawing.Size(Width - 210, Height - 155);
            button5.Location = new System.Drawing.Point(dataGridView1.Location.X, dataGridView1.Location.Y + dataGridView1.Height + 5);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new System.Drawing.Size(Width - 210, Height - 155);
            button5.Location = new System.Drawing.Point(dataGridView1.Location.X, dataGridView1.Location.Y + dataGridView1.Height + 5);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                string query1 = "select t.name as Предмет, s.name as Название, s.date_start as Дата_Начала, s.date_end as Дата_Окончания, s.museum as Музей from things t\r\njoin ts on thing_id = fk_thing_id\r\njoin shows s on fk_show_id = show_id";
                NpgsqlCommand select = new NpgsqlCommand(query1, connection);
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(select);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                string query1 = "select fio as ФИО, job_title as Профессия, t.name as Название, t.description as Описание_Объекта, t.restoration as Тип_Реставрации, t.date_restoration as Дата_Реставрации, t.status as Статус, t.number_hall as Номер_Зала from employees\r\njoin et on employee_id = fk_employee_id\r\njoin things t on thing_id = fk_thing_id";
                NpgsqlCommand select = new NpgsqlCommand(query1, connection);
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(select);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                string query1 = "select p.name as Название_Журнала, p.category as Категория, p.date_published as Дата_Публикации, p.isbn as ИСБН,  t.name as Объект, t.description as Описание from publications p\r\njoin tp on publication_id = fk_publication_id\r\njoin things t on thing_id = fk_thing_id";
                NpgsqlCommand select = new NpgsqlCommand(query1, connection);
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(select);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                string query1 = "select name as Название, description as Описание, date_created as Дата_Создания, date_of_entry as Дата_Поступления, category as Категория, fio as ФИО, restoration as Тип_Реставрации, date_restoration as Дата_Реставрации, status as Статус, number_hall as Номер_Зала from things\r\njoin et on thing_id = fk_thing_id\r\njoin employees on employee_id = fk_employee_id";
                NpgsqlCommand select = new NpgsqlCommand(query1, connection);
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(select);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }
        

    }
}
