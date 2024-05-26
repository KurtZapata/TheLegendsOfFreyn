namespace RPG_FinalProj
{
    public partial class JuraForestForm1 : Form
    {

        private PictureBox[] obstacle = new PictureBox[100];

        public JuraForestForm1()
        {
            InitializeComponent();
            int counter = 0;
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name.StartsWith("obstacle"))
                {
                    obstacle[counter] = (PictureBox)ctrl;
                    counter++;
                }
            }






        }
    }
}
