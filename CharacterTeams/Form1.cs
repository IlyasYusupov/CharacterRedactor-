using CharacterRedactor;
using CharacterRedactor_;
using System.Windows.Forms;

namespace CharacterTeams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddtoList();
        }
        public static Character character;
        List<Character> RedTeam = new List<Character>();
        List<Character> BlueTeam = new List<Character>();
        bool moove_character;
        int selected_item;

        private void btnManual_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void AddtoList()
        {
            List<Character> characters = new List<Character>();
            Mongo.FindAll(characters);
            foreach (var character in characters)
            {
                ListViewItem list = new ListViewItem(new string[] { character.Name, (character.LVL).ToString() });
                lvCharacters.Items.Add(list);
            }
        }

        private void lvCharacters_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selected_item = int.Parse(lvCharacters.Items[e.ItemIndex].Text) - 1;
        }

        private void lvCharacters_MouseDown(object sender, MouseEventArgs e)
        {
            moove_character = true;
        }

        private void lvCharacters_MouseMove(object sender, MouseEventArgs e)
        {
            if (moove_character)
            {
                try
                {
                    var a = new ListView();
                    a.Text = $"{lvCharacters.Items[selected_item].SubItems[0].Text} {lvCharacters.Items[selected_item].SubItems[1].Text}";
                    a.DoDragDrop(a.Text, DragDropEffects.Copy);
                }
                catch
                { }
            }
            moove_character = false;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (RedTeam.Count == 6)
            {
                MessageBox.Show("В этой команде нет места!");
                return;
            }
            string[] str = ((string)e.Data.GetData(DataFormats.Text)).Split(" ");
            ListViewItem list = new ListViewItem((new string[] { str[0], str[1] }));
            character = Mongo.Find(str[0]);
            if (CheckCharacter(str[0]), character)
            {
                listView1.Items.Add(list);
                RedTeam.Add(character);
            }
            else
                MessageBox.Show("У этот персонаж уже есть команда!");
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            if (BlueTeam.Count == 6)
            {
                MessageBox.Show("В этой команде нет места!");
                return;
            }
            string[] str = ((string)e.Data.GetData(DataFormats.Text)).Split(" ");
            ListViewItem list = new ListViewItem((new string[] { str[0], str[1]}));
            character = Mongo.Find(str[0]);
            if (CheckCharacter(str[0]), character)
            {
                listView2.Items.Add(list);
                BlueTeam.Add(character);
            }
            else
                MessageBox.Show("У этот персонаж уже есть команда!");
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        int globalLVL;
        public bool CheckLVL()
        {

            return true;
        }

        private bool CheckCharacter(string name, Character s)
        {
            if (RedTeam.Count == 0 && BlueTeam.Count == 0)
            {
                globalLVL = s.LVL;
                return true;
            }
            foreach (var i in RedTeam)
            {
                if(i.Name == name)
                {
                    return false;
                }
            }
            foreach (var i in BlueTeam)
            {
                if (i.Name == name)
                {
                    return false;
                }
            }
            return true;
        }
        //private bool CheckCharacter(string name)
        //{
        //    if (RedTeam.Count == 0 && BlueTeam.Count == 0)
        //    {
        //        return true;
        //    }
        //    if (Сycle(RedTeam, name))
        //        return true;

        //    if (Сycle(BlueTeam, name))
        //        return true;

        //    return false;
        //}
        //private bool Сycle(List<Character> list, string name)
        //{
        //    foreach (var i in list)
        //    {
        //        if (name == i.Name)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}