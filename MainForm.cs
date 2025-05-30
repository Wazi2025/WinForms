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

    public void Initialize()
    {
        lblFirstName = new Label();
        lblFirstName.Text = "First name";
        lblFirstName.AutoSize = true;

        lblLastName = new Label();
        lblPhone = new Label();
        lblEmail = new Label();
        lblStreet = new Label();
        lblCity = new Label();
        lblZip = new Label();
        lblCountry = new Label();

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

        TableLayoutPanel table = new TableLayoutPanel();
        table.RowCount = 30;
        table.ColumnCount = 8;
        table.Dock = DockStyle.Fill;
        table.AutoSize = true;

        // TableLayoutPanel viewTable = new TableLayoutPanel();
        // //table.RowCount = 30;
        // table.ColumnCount = 1;
        // table.Dock = DockStyle.Fill;
        // table.AutoSize = true;

        // Add controls to specific cells
        table.Controls.Add(rtbDataWindow, 0, 0);
        table.SetColumnSpan(rtbDataWindow, 8);

        //viewTable.Controls.Add(rtbDataWindow, 0, 0);
        //viewTable.SetColumnSpan(rtbDataWindow, 3);

        table.Controls.Add(tbFirstName, 0, 10);
        table.Controls.Add(lblFirstName, 0, 5);

        table.Controls.Add(tbLastName, 1, 10);
        table.Controls.Add(tbPhone, 2, 10);
        table.Controls.Add(tbEmail, 3, 10);
        table.Controls.Add(tbStreet, 4, 10);
        table.Controls.Add(tbCity, 5, 10);
        table.Controls.Add(tbZip, 6, 10);
        table.Controls.Add(tbCountry, 7, 10);

        table.Controls.Add(btnSelect, 0, 20);
        table.Controls.Add(btnInsert, 1, 20);

        // Add to form
        this.Controls.Add(table);
    }


    void btnSelect_Click(object sender, EventArgs e)
    {
        //Add query result to RichTextBox component
        rtbDataWindow.Text = Program.SQLSelect();
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
