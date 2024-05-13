using System.Windows.Forms;
using ChessModel;
namespace ChessGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Resize += Form1_Resize; // += -> handler de eveniment
            
            this.BackgroundImage = Properties.Resources.BackgroundPhoto;
            this.BackgroundImageLayout = ImageLayout.Stretch;
         
            this.buttonStart.Left = (this.ClientSize.Width - this.buttonStart.Width) / 2; //Centrare buton Start
            this.buttonStart.Top = (this.ClientSize.Height - this.buttonStart.Height) / 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.buttonStart.Left = (this.ClientSize.Width - this.buttonStart.Width) / 2; //Centrare buton Start
            this.buttonStart.Top = (this.ClientSize.Height - this.buttonStart.Height) / 2;
        }


        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GameStarted();
        }

        private void GameStarted()
        {
            this.Hide();
            
            Form3 state = new Form3();
            Form2 game = new Form2(state);
            game.Closed += (s, args) => this.Close();
            game.Show();
            state.Show();
        }

    }
}
