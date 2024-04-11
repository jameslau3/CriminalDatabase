// Criminal Database to display tables
// By James Lau
using System.Data;
using System.Data.SqlClient;

namespace CriminalDatabaseUI___James
{
    public partial class Form1 : Form
    {
        /*
         * 
         * README: Change connection string as according to database location.
         * 
         */
        string connectionString = @"Server=Jameson-Zenbook\JAMESLAUSQL; Database=lau_singh_james_virat_db; Trusted_Connection=true;";
        public Form1()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Initialize to show all the tables when first compiling.
                // First Grid shows PersonOfInterest Table
                connection.Open();
                SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT * FROM PersonOfInterest", connection);
                DataTable table1 = new DataTable();
                sqlDa1.Fill(table1);
                dataGridView1.DataSource = table1;

                // Second Grid shows PhysicalAttributes Table
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT * FROM PhysicalAttributes", connection);
                DataTable table2 = new DataTable();
                sqlDa2.Fill(table2);
                dataGridView2.DataSource = table2;

                // Third Grid shows PhysicalOffenses Table
                SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT * FROM PreviousOffenses", connection);
                DataTable table3 = new DataTable();
                sqlDa3.Fill(table3);
                dataGridView3.DataSource = table3;

                // Fourth Grid shows FirearmPossession Table
                SqlDataAdapter sqlDa4 = new SqlDataAdapter("SELECT * FROM FirearmPossession", connection);
                DataTable table4 = new DataTable();
                sqlDa4.Fill(table4);
                dataGridView4.DataSource = table4;
            }
        }

        // Button that resets to the original view of showing all tables.
        private void DisplayAllButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Initialize to show all the tables when first compiling.
                // First Grid shows PersonOfInterest Table
                connection.Open();
                SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT * FROM PersonOfInterest", connection);
                DataTable table1 = new DataTable();
                sqlDa1.Fill(table1);
                dataGridView1.DataSource = table1;

                // Second Grid shows PhysicalAttributes Table
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT * FROM PhysicalAttributes", connection);
                DataTable table2 = new DataTable();
                sqlDa2.Fill(table2);
                dataGridView2.DataSource = table2;

                // Third Grid shows PhysicalOffenses Table
                SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT * FROM PreviousOffenses", connection);
                DataTable table3 = new DataTable();
                sqlDa3.Fill(table3);
                dataGridView3.DataSource = table3;

                // Fourth Grid shows FirearmPossession Table
                SqlDataAdapter sqlDa4 = new SqlDataAdapter("SELECT * FROM FirearmPossession", connection);
                DataTable table4 = new DataTable();
                sqlDa4.Fill(table4);
                dataGridView4.DataSource = table4;

                // Clear the textboxes
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
        }

        // Direct Search that finds an exact value for a column depending on all tables.
        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string columnInput = textBox2.Text;
                string valueInput = textBox1.Text;

                // Define mappings of columns to corresponding tables
                Dictionary<string, string> tableMappings = new Dictionary<string, string>()
                {
                    { "ID", "All" },
                    { "Name", "PersonOfInterest" },
                    { "Age", "PersonOfInterest" },
                    { "Address", "PersonOfInterest" },
                    { "Blood_Type", "PersonOfInterest" },
                    { "Status", "PersonOfInterest" },
                    { "Eye_Color", "PhysicalAttributes" },
                    { "Hair_Color", "PhysicalAttributes" },
                    { "Height", "PhysicalAttributes" },
                    { "RaceEthnicity", "PhysicalAttributes" },
                    { "Case_Number", "PreviousOffenses" },
                    { "Crime", "PreviousOffenses" },
                    { "Punishment", "PreviousOffenses" },
                    { "DateOfCrime", "PreviousOffenses" },
                    { "Serial_Number", "FirearmPossession" },
                    { "Make", "FirearmPossession" },
                    { "Model", "FirearmPossession" },
                    { "Type", "FirearmPossession" },
                    { "Registered", "FirearmPossession" }
                };

                // Clear all DataGridViews (so they are not shown when not used)
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                dataGridView3.DataSource = null;
                dataGridView4.DataSource = null;

                // Check if columnInput exists in the mappings
                if (tableMappings.ContainsKey(columnInput))
                {
                    string tableName = tableMappings[columnInput];
                    SqlDataAdapter sqlDa;
                    string query;

                    if (columnInput == "Age")
                    {
                        // Check if valueInput is a single age or age range
                        int minValue;
                        int maxValue;

                        if (int.TryParse(valueInput, out int age))
                        {
                            // Perform search based on a single age value
                            query = $"SELECT * FROM {tableName} WHERE {columnInput} = {age}";
                        }
                        else if (int.TryParse(textBox3.Text, out minValue) && int.TryParse(textBox4.Text, out maxValue))
                        {
                            // Perform search based on age range
                            query = $"SELECT * FROM {tableName} WHERE {columnInput} BETWEEN {minValue} AND {maxValue}";
                        }
                        else
                        {
                            MessageBox.Show("Invalid input for age.");
                            return;
                        }
                    }
                    else if (columnInput == "ID")
                    {
                        // Perform search based on ID for all tables
                        SqlDataAdapter sqlDaPerson = new SqlDataAdapter($"SELECT * FROM PersonOfInterest WHERE ID = '{valueInput}'", connection);
                        DataTable personTable = new DataTable();
                        sqlDaPerson.Fill(personTable);
                        dataGridView1.DataSource = personTable;

                        SqlDataAdapter sqlDaPhysical = new SqlDataAdapter($"SELECT * FROM PhysicalAttributes WHERE ID = '{valueInput}'", connection);
                        DataTable physicalTable = new DataTable();
                        sqlDaPhysical.Fill(physicalTable);
                        dataGridView2.DataSource = physicalTable;

                        SqlDataAdapter sqlDaPrevious = new SqlDataAdapter($"SELECT * FROM PreviousOffenses WHERE ID = '{valueInput}'", connection);
                        DataTable previousTable = new DataTable();
                        sqlDaPrevious.Fill(previousTable);
                        dataGridView3.DataSource = previousTable;

                        SqlDataAdapter sqlDaFirearm = new SqlDataAdapter($"SELECT * FROM FirearmPossession WHERE ID = '{valueInput}'", connection);
                        DataTable firearmTable = new DataTable();
                        sqlDaFirearm.Fill(firearmTable);
                        dataGridView4.DataSource = firearmTable;

                        return;
                    }
                    else
                    {
                        // Perform LIKE query for other columns
                        query = $"SELECT * FROM {tableName} WHERE {columnInput} LIKE '%{valueInput}%'";

                        // Check for AND/OR condition
                        if (!string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            string ANDOR = textBox5.Text;
                            string columnInput2 = textBox6.Text.Trim();
                            string valueInput2 = textBox7.Text.Trim();
                            if (tableMappings.ContainsKey(columnInput2))
                            {
                                string conditionTableName = tableMappings[columnInput2];

                                // Append AND/OR condition to the query
                                if (ANDOR == "AND")
                                    query += $" AND {columnInput2} LIKE '%{valueInput2}%'";
                                else if (ANDOR == "OR")
                                    query += $" OR {columnInput2} LIKE '%{valueInput2}%'";
                                else
                                {
                                    MessageBox.Show("Invalid logical operator.");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid column input for condition.");
                                return;
                            }
                        }
                    }

                    sqlDa = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    sqlDa.Fill(table);

                    // Assign DataTable to corresponding DataGridView based on the tableName
                    switch (tableName)
                    {
                        case "PersonOfInterest":
                            dataGridView1.DataSource = table;
                            break;
                        case "PhysicalAttributes":
                            dataGridView2.DataSource = table;
                            break;
                        case "PreviousOffenses":
                            dataGridView3.DataSource = table;
                            break;
                        case "FirearmPossession":
                            dataGridView4.DataSource = table;
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid column input.");
                }
            }

        }
    }
}
