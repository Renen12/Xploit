using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

//The C# API can be re-downloaded at https://wearedevs.net/d/Exploit%20API
//Make sure it is added as a reference if you decide to re-download
using WeAreDevs_API;

//The exploit itself auto updates. You never need to do work yourself!
//Just create the project once and let WeAreDevs do the work for you.
//Why is this free? Its because of the non-intrusive watermark the API adds
namespace Exploit_Template_with_WRDAPI
{
    public partial class Form1 : Form
    {
        //Creates object so we can make calls to WeAreDevs_API.
        readonly ExploitAPI api = new ExploitAPI();
        /*To see methods you can call, go to 
        The project in the solution explorer -> References -> Right click on WeAreDevs_API.dll ->
        View in Object Browser -> WeAreDevs_API -> WeAreDevs_API -> click Exploit API.
        This will then show a list of all functions you can use!*/

        public Form1()
        {
            InitializeComponent();
        }
        Point lastpoint;

        //The exploit must be injected before calling any other function!
        private void BtnInject_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        //Executes the lua script
        private void BtnExecute_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;
            api.SendLuaScript(script);
        }


        //Example usage of a dynamic command
        //Quick command button using a pre-built command, but this one grab's the user input
        //Teleports the player to a player of the specified username


        //Changes UI text to say if the exploit is injected or not
        //Challenge: Try making the attach button only show if the exploit is not injected
        private void CheckInjected()
        {
            if (api.isAPIAttached())
            {
                //The exploit is injected and now ready to execute scripts/commands
                textBox1.Text = "Xploit is injected!";
            }
            else
            {
                //The exploit is not injected... The client must inject
                textBox1.Text = "Xploit is not injected!";
            }
        }

        //Check if the exploit is injected on load
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckInjected();
        }

        //Check if the exploit is injected every 3 seconds
        private void InjectedChecker_Tick(object sender, EventArgs e)
        {
            CheckInjected();
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            api.SendLuaScript("loadstring(game:HttpGet('https://raw.githubusercontent.com/EdgeIY/infiniteyield/master/source'))()");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            api.SendLuaScript("loadstring(game:HttpGet('https://raw.githubusercontent.com/1201for/littlegui/main/Field-Trip-Z'))()");
        }


    }
}
