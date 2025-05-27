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
        tbFirstName.Location = new System.Drawing.Point(10, 170);

        tbLastName = new TextBox();
        tbLastName.Location = new System.Drawing.Point(120, 170);

        tbEmail = new TextBox();
        tbEmail.Location = new System.Drawing.Point(230, 170);

        btnInsert = new Button();
        btnInsert.Location = new System.Drawing.Point(10, 200);
        btnInsert.Text = "Insert";

        //Hook up event
        btnInsert.Click += new EventHandler(this.btnInsert_Click);

        btnSelect = new Button();
        btnSelect.Location = new System.Drawing.Point(10, 100);
        btnSelect.Text = "Select";

        //Hook up event
        btnSelect.Click += new EventHandler(this.btnSelect_Click);

        rtbDataWindow = new RichTextBox();
        rtbDataWindow.Dock = DockStyle.Top;
        rtbDataWindow.ReadOnly = true;

        this.Controls.Add(btnSelect);
        this.Controls.Add(btnInsert);
        this.Controls.Add(rtbDataWindow);
        this.Controls.Add(tbFirstName);
        this.Controls.Add(tbLastName);
        this.Controls.Add(tbEmail);
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

    }

    public Form1()
    {
        InitializeComponent();
        this.Name = "MainForm";
        this.Text = "Main";
        this.Size = new System.Drawing.Size(500, 500);
        this.StartPosition = FormStartPosition.CenterScreen;

        Initialize();
    }
}
