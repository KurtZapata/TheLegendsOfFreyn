using Microsoft.VisualBasic;
using System.Numerics;

namespace RPG_FinalProj
{
    public partial class JuraForestForm1 : Form
    {
        private readonly LocItems _items;

        int[,] obstacles = new int[25, 4];
        PictureBox[] obstacle = new PictureBox[25];
        PictureBox[] mob = new PictureBox[5];
        int[,] moblocation = new int[5, 4];
        string[] mobnames = new string[5];


        public JuraForestForm1()
        { 
            InitializeComponent();
            _items = Program.items;
        }


        private void TeleportChecker(int[] newPosition, int[,] moblocation, string[] mob)
        {
            for (int i = 0; i < moblocation.GetLength(0); i++)
            {
                if ((newPosition[1] <= moblocation[i, 3] + 5 && newPosition[1] >= moblocation[i, 1] - 5) &&
                    ((newPosition[0] > moblocation[i, 0] && newPosition[2] < moblocation[i, 2]) ||
                    (newPosition[0] <= moblocation[i, 0] && newPosition[2] >= moblocation[i, 0]) ||
                    (newPosition[2] >= moblocation[i, 2] && newPosition[0] <= moblocation[i, 2])))
                {
                    if (mob[i] == "TeleportTop")
                    {
                        Program.items.location[0] = 700;
                        Program.items.location[1] = 840;
                        JuraForestForm1 JFF = new JuraForestForm1();
                        this.Hide();
                        JFF.ShowDialog();
                        this.Close();
                        break;
                    }
                    break;
                }

                else if (newPosition[0] <= moblocation[i, 2] + 5 && newPosition[0] >= moblocation[i, 0] - 5 &&
                   ((newPosition[1] > moblocation[i, 1] && newPosition[3] < moblocation[i, 3]) ||
                   (newPosition[1] <= moblocation[i, 1] && newPosition[3] >= moblocation[i, 1]) ||
                   (newPosition[3] >= moblocation[i, 3] && newPosition[1] <= moblocation[i, 3])))
                {
                    if (mob[i] == "TeleportLeft")
                    {

                        Program.items.location[0] = 1286;
                        Program.items.location[1] = 497;
                        JuraForestForm3 JFF = new JuraForestForm3();
                        this.Hide();
                        JFF.ShowDialog();
                        this.Close();
                    }
                    break;
                }

                else if (newPosition[3] >= moblocation[i, 1] - 5 && newPosition[3] <= moblocation[i, 3] + 5 &&
                   ((newPosition[0] > moblocation[i, 0] && newPosition[2] < moblocation[i, 2]) ||
                   (newPosition[0] <= moblocation[i, 0] && newPosition[2] >= moblocation[i, 0]) ||
                   (newPosition[2] >= moblocation[i, 2] && newPosition[0] <= moblocation[i, 2])))
                {
                    if (mob[i] == "TeleportBottom")
                    {
                        Program.items.location[0] = 750;
                        Program.items.location[1] = 110;
                        JuraForestForm3 JFF = new JuraForestForm3();
                        this.Hide();
                        JFF.ShowDialog();
                        this.Close();
                    }
                    break;
                }

                else if (newPosition[2] >= moblocation[i, 0] - 5 && newPosition[2] <= moblocation[i, 2] + 5 &&
                   ((newPosition[1] > moblocation[i, 1] && newPosition[3] < moblocation[i, 3]) ||
                   (newPosition[1] <= moblocation[i, 1] && newPosition[3] >= moblocation[i, 1]) ||
                   (newPosition[3] >= moblocation[i, 3] && newPosition[1] <= moblocation[i, 3])))
                {
                    if (mob[i] == "TeleportRight")
                    {

                        Program.items.location[0] = 205;
                        Program.items.location[1] = 489;
                        JuraForestForm2 JFF = new JuraForestForm2();
                        this.Hide();
                        JFF.ShowDialog();
                        this.Close();
                    }
                    break;
                }
            }
        }



        private void JuraForestForm1_Load(object sender, EventArgs e)
        {

            for (int i = 1; i <= 100; i++)
            {
                Control control = this.Controls["obstacle" + i];
                if (control != null && control is PictureBox)
                {
                    ((PictureBox)control).BackColor = Color.Transparent;
                }
            }
            int counterObstacle = 0;
            //naming of variable para hindi mano mano
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name.StartsWith("obstacle"))
                {
                    obstacle[counterObstacle] = (PictureBox)ctrl;
                    counterObstacle++;
                }
            }


            int counterMob = 0;


            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name.StartsWith("mob"))
                {
                    mob[counterMob] = (PictureBox)ctrl;
                    counterMob++;
                }
            }

            for (int i = 0; i < obstacle.Length; i++)
            {
                obstacles[i, 0] = obstacle[i].Location.X;
                obstacles[i, 1] = obstacle[i].Location.Y;
                obstacles[i, 2] = obstacle[i].Location.X + obstacle[i].Size.Width;
                obstacles[i, 3] = obstacle[i].Location.Y + obstacle[i].Size.Height;
            }

            for (int x = 0; x < moblocation.GetLength(0); x++)
            {
                moblocation[x, 0] = mob[x].Location.X;
                moblocation[x, 1] = mob[x].Location.Y;
                moblocation[x, 2] = mob[x].Location.X + mob[x].Size.Width;
                moblocation[x, 3] = mob[x].Location.Y + mob[x].Size.Height;
                mobnames[x] = mob[x].AccessibleName;
            }
            Player.Location = new Point(Program.items.location[0], Program.items.location[1]);

        }

        private void JuraForestForm1_KeyDown_1(object sender, KeyEventArgs e)
        {
            int leftPosition, topPosition, rightPosition, bottomPosition;
            int[] movement = { 0, 0, 0, 0 };
            leftPosition = Player.Location.X;
            topPosition = Player.Location.Y;
            rightPosition = Player.Location.X + Player.Size.Width;
            bottomPosition = Player.Location.Y + Player.Size.Height;
            int keypressed = (int)e.KeyCode;
            MovementPlayer newPosition = new MovementPlayer();
            movement = newPosition.Movement(leftPosition, topPosition, rightPosition, bottomPosition, keypressed, obstacles);
            Player.Location = new Point(movement[0], movement[1]);
            int[] newPos = { 0, 0, 0, 0 };
            newPos[0] = Player.Location.X;
            newPos[1] = Player.Location.Y;
            newPos[2] = Player.Location.X + Player.Size.Width;
            newPos[3] = Player.Location.Y + Player.Size.Height;
            newPosition.collisionChecker(newPos, moblocation, mobnames);
            TeleportChecker(newPos, moblocation, mobnames);
            InteractionChecker();
        }

        int entityType = 0;
        private void InteractionChecker()
        {
            if (entityType == 1)
            {
                MessageBox.Show("Combat");
            }
            else if (entityType == 2)
            {

            }
        }



    }
}
