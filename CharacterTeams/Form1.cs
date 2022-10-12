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

            if (CheckCharacter((str[0])))
            {
                if (!CheckLVL())
                {
                    return;
                }
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
            if (CheckCharacter((str[0])))
            {
                if (!CheckLVL())
                {
                    return;
                }
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
            if(character.LVL < globalLVL - 2)
            {
                MessageBox.Show("Не дорос!");
                return false;
            }
            else if(character.LVL > globalLVL + 2)
            {
                MessageBox.Show("Перерос!");
                return false;
            }
            return true;
        }

        private bool CheckCharacter(string name)
        {
            if (RedTeam.Count == 0 && BlueTeam.Count == 0)
            {
                globalLVL = character.LVL;
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

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var a = (ListViewItem)e.Item;
                foreach (var character in RedTeam)
                {
                    if (a.Text == character.Name)
                    {
                        RedTeam.Remove(character);
                        listView1.Items[e.ItemIndex].Remove();
                        break;
                    }
                }
            }
        }
        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var a = (ListViewItem)e.Item;
                foreach (var character in BlueTeam)
                {
                    if (a.Text == character.Name)
                    {
                        BlueTeam.Remove(character);
                        listView1.Items[e.ItemIndex].Remove();
                        break;
                    }
                }
            }
        }

        public bool CheckLVLAuto()
        {
            if (character.LVL < globalLVL - 2)
            {
                return true;
            }
            else if (character.LVL > globalLVL + 2)
            {
                return true;
            }
            return false;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            RedTeam.Clear();
            BlueTeam.Clear();
            Random rnd = new Random();
            int cnt = 1;
            while(true)
            {
                var num = rnd.Next(0, lvCharacters.Items.Count);
                character = Mongo.Find(lvCharacters.Items[num].SubItems[0].Text);
                if(cnt == 1)
                {
                    if (CheckCharacter(character.Name))
                    {
                        if (CheckLVLAuto())
                        {
                            continue;
                        }
                        ListViewItem list = new ListViewItem(new string[] { character.Name, character.LVL.ToString() });
                        listView1.Items.Add(list);
                        RedTeam.Add(character);
                        cnt *= -1;
                    }
                }
                else if (cnt == -1)
                {
                    if (CheckCharacter(character.Name))
                    {
                        if (CheckLVLAuto())
                        {
                            continue;
                        }
                        ListViewItem list = new ListViewItem(new string[] { character.Name, character.LVL.ToString() });
                        listView2.Items.Add(list);
                        BlueTeam.Add(character);
                        cnt *= -1;
                    }
                }
                if(RedTeam.Count == 6 && BlueTeam.Count == 6)
                {
                    break;
                }
            }
        }
    }
}