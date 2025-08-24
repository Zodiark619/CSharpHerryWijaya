namespace CSharpHerryWijaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int counter = 0;
        List<string> currentList = new ();
        List<int> checkedBox = new();
        private void PostBackClick1()
        {
            counter = 0;
            checkedBox.Clear();
            currentList.Clear();
        }
        private void PostBackClick2()
        {
            foreach (CheckBox cb in groupBox1.Controls.OfType<CheckBox>())
            {
                if (cb.Checked)
                {
                    checkedBox.Add(1);
                    counter++;
                }
                else
                {
                    checkedBox.Add(0);
                }
            }
            foreach (Label cb in groupBox2.Controls.OfType<Label>())
            {
                currentList.Add(cb.Text);
            }
        }
        private void PostBackClick3()
        {
            int index = 0;
            foreach (Label cb in groupBox2.Controls.OfType<Label>())
            {
                if (checkedBox[index] == 1)
                {
                    index++;

                    continue;
                }
                else
                {
                    var result = WeaponReadjusment.GeneratePercentage();
                    if (currentList[index] == "Recoil")
                    {
                    cb.Text = currentList[index] +" -"+ result.Item2+"%";

                    }
                    else
                    {
                        cb.Text = currentList[index] + " " + result.Item2 + "%";

                    }
                    cb.BackColor = Color.FromName(result.Item1);
                index++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                PostBackClick1();
                PostBackClick2();
            if (counter < 4)
            {
                currentList = WeaponReadjusment.GenerateReadjustment(currentList, checkedBox);

                PostBackClick3();
            }
            


        }
    }
}
