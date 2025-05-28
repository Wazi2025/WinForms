using Azure.Messaging;
using Microsoft.IdentityModel.Tokens;

namespace WinForms;

public partial class Form1 : Form
{
    private TextBox tbFirstName;
    private TextBox tbLastName;
    private TextBox tbEmail;
    private Button btnSelect;
    private Button btnInsert;

    public RichTextBox rtbDataWindow;

    public void Initialize()
    {
        tbFirstName = new TextBox();
        tbLastName = new TextBox();
        tbEmail = new TextBox();

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
        //rtbDataWindow.Width = 400;

        TableLayoutPanel table = new TableLayoutPanel();
        table.RowCount = 100;
        table.ColumnCount = 3;
        table.Dock = DockStyle.Fill;
        table.AutoSize = true;

        // Add controls to specific cells
        table.Controls.Add(rtbDataWindow, 0, 0);
        table.SetColumnSpan(rtbDataWindow, 3);
        table.Controls.Add(tbFirstName, 0, 10);
        table.Controls.Add(tbLastName, 1, 10);
        table.Controls.Add(tbEmail, 2, 10);
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
        data.Add(tbEmail.Text);

        if (data.Contains(""))
        {
            MessageBox.Show("Fields cannot be empty!", "Warning");
            return;
        }

        //Send TextBox values as parameters to SQLInsert method
        Program.SQLInsert(data);

        tbFirstName.Text = "";
        tbLastName.Text = "";
        tbEmail.Text = "";

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
