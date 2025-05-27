namespace WinForms;

public partial class Form1 : Form
{

    private Button btnSelect;

    public RichTextBox rtbDataWindow;

    public void Initialize()
    {
        // tbInput = new TextBox();
        // tbInput.Location = new System.Drawing.Point(0, 100);
        // tbInput.ReadOnly = false;
        // tbInput.Text = "Input box";

        // //Hook up event
        // tbInput.KeyDown += tbInput_KeyDown;
        btnSelect = new Button();
        btnSelect.Location = new System.Drawing.Point(10, 100);
        btnSelect.Text = "Select";

        //Hook up event
        btnSelect.Click += new EventHandler(this.btnSelect_Click);

        rtbDataWindow = new RichTextBox();
        rtbDataWindow.Dock = DockStyle.Top;
        rtbDataWindow.ReadOnly = true;
        //rtbDataWindow.Text = "Just a test";

        this.Controls.Add(btnSelect);
        this.Controls.Add(rtbDataWindow);
    }


    void btnSelect_Click(object sender, EventArgs e)
    {
        //Button clickedButton = (Button)sender;
        //rtbDataWindow.Text = "Fetching data...";

        //Add query to RichTextBox component
        rtbDataWindow.Text = Program.SQLAction();
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
