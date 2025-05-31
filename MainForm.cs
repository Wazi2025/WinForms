using System.Data;
using Azure.Messaging;
using Microsoft.IdentityModel.Tokens;

namespace WinForms;

public partial class Form1 : Form
{
    //Add fields to the Form class so we can access them directly instead of having to iterate
    //through the Form's controls
    private Label lblFirstName;
    private Label lblLastName;
    private Label lblPhone;
    private Label lblEmail;
    private Label lblStreet;
    private Label lblCity;
    private Label lblZip;
    private Label lblCountry;
    private TextBox tbFirstName;
    private TextBox tbLastName;
    private TextBox tbPhone;
    private TextBox tbEmail;
    private TextBox tbStreet;
    private TextBox tbCity;
    private TextBox tbZip;
    private TextBox tbCountry;
    private Button btnSelect;
    private Button btnInsert;

    public RichTextBox rtbDataWindow;
    public DataGridView dataWindow;

    public void Initialize()
    {
        lblFirstName = new Label();
        lblFirstName.Text = "First name";
        lblFirstName.AutoSize = true;

        lblLastName = new Label();
        lblLastName.Text = "Last name";
        lblLastName.AutoSize = true;

        lblPhone = new Label();
        lblPhone.Text = "Phone";
        lblPhone.AutoSize = true;

        lblEmail = new Label();
        lblEmail.Text = "E-mail";
        lblEmail.AutoSize = true;

        lblStreet = new Label();
        lblStreet.Text = "Address";
        lblStreet.AutoSize = true;

        lblCity = new Label();
        lblCity.Text = "City";
        lblCity.AutoSize = true;

        lblZip = new Label();
        lblZip.Text = "Zip code";
        lblZip.AutoSize = true;

        lblCountry = new Label();
        lblCountry.Text = "Country";
        lblCountry.AutoSize = true;

        tbFirstName = new TextBox();
        tbLastName = new TextBox();
        tbPhone = new TextBox();
        tbEmail = new TextBox();
        tbStreet = new TextBox();
        tbCity = new TextBox();
        tbZip = new TextBox();
        tbCountry = new TextBox();

        btnInsert = new Button();
        btnInsert.Text = "Insert";
        btnInsert.AutoSize = true;

        //Hook up event
        btnInsert.Click += new EventHandler(this.btnInsert_Click);

        btnSelect = new Button();
        btnSelect.Text = "Select";
        btnSelect.AutoSize = true;

        //Hook up event
        btnSelect.Click += new EventHandler(this.btnSelect_Click);

        rtbDataWindow = new RichTextBox();
        rtbDataWindow.Dock = DockStyle.Top;
        rtbDataWindow.ReadOnly = true;
        rtbDataWindow.Height = 300;
        //rtbDataWindow.Width = 800;

        dataWindow = new DataGridView();
        dataWindow.Dock = DockStyle.Top;
        //dataWindow.View = View.Details;

        dataWindow.Height = 300;
        // dataWindow.Columns.Add("First Name");
        // dataWindow.Columns.Add("Last Name");
        // dataWindow.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        TableLayoutPanel table = new TableLayoutPanel();
        table.RowCount = 30;
        table.ColumnCount = 8;
        table.Dock = DockStyle.Fill;
        table.AutoSize = true;

        // Add controls to specific cells in table
        // table.Controls.Add(rtbDataWindow, 0, 0);
        // table.SetColumnSpan(rtbDataWindow, 8);
        table.Controls.Add(dataWindow, 0, 0);
        table.SetColumnSpan(dataWindow, 8);

        table.Controls.Add(tbFirstName, 0, 10);
        table.Controls.Add(lblFirstName, 0, 5);

        table.Controls.Add(tbLastName, 1, 10);
        table.Controls.Add(lblLastName, 1, 5);

        table.Controls.Add(tbPhone, 2, 10);
        table.Controls.Add(lblPhone, 2, 5);

        table.Controls.Add(tbEmail, 3, 10);
        table.Controls.Add(lblEmail, 3, 5);

        table.Controls.Add(tbStreet, 4, 10);
        table.Controls.Add(lblStreet, 4, 5);

        table.Controls.Add(tbCity, 5, 10);
        table.Controls.Add(lblCity, 5, 5);

        table.Controls.Add(tbZip, 6, 10);
        table.Controls.Add(lblZip, 6, 5);

        table.Controls.Add(tbCountry, 7, 10);
        table.Controls.Add(lblCountry, 7, 5);

        table.Controls.Add(btnSelect, 0, 20);
        table.Controls.Add(btnInsert, 1, 20);

        // Add to form
        this.Controls.Add(table);
    }


    void btnSelect_Click(object sender, EventArgs e)
    {
        //Add query result to DataSource component        
        dataWindow.DataSource = Program.SQLSelect();

        // dataWindow.Items.Add("Jon");
        // dataWindow.Items.Add("Petter");
    }

    void btnInsert_Click(object sender, EventArgs e)
    {
        List<string> data = new List<string>();

        //Add values from TextBoxes to List
        data.Add(tbFirstName.Text);
        data.Add(tbLastName.Text);
        data.Add(tbPhone.Text);
        data.Add(tbEmail.Text);
        data.Add(tbStreet.Text);
        data.Add(tbCity.Text);
        data.Add(tbZip.Text);
        data.Add(tbCountry.Text);

        if (data.Contains(""))
        {
            MessageBox.Show("Fields cannot be empty!", "Warning");
            return;
        }

        //Send TextBox values as parameters to SQLInsert method
        Program.SQLInsert(data);

        tbFirstName.Clear();
        tbLastName.Clear();
        tbPhone.Clear();
        tbEmail.Clear();
        tbStreet.Clear();
        tbCity.Clear();
        tbZip.Clear();
        tbCountry.Clear();
    }

    public Form1()
    {
        InitializeComponent();
        this.Name = "MainForm";
        this.Text = "Main";
        this.Size = new System.Drawing.Size(900, 500);
        this.StartPosition = FormStartPosition.CenterScreen;

        Initialize();
    }
}
