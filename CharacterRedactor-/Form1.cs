using CharacterRedactor;
using MongoDB.Driver;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace CharacterRedactor_
{
    public partial class Form1 : Form
    {
        public CharacterMaker maker = new CharacterMaker();
        Character character;
        double[] param = new double[9];
        int skillGive;

        public Form1()
        {
            InitializeComponent();
            Mongo.FindAll(cbExistingCharacter);
        }

        private void cbCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbLVL.Text = "1";
            tbXP.Text = "0";
            pbLVL.Value = 0;
            skillGive = 1;
            panelSkills.Visible = true;
            panelInventory.Visible = true;
            switch (cbCharacter.Text)
            {
                case "Warrior":
                    tbStrength.Text = maker.GetValue("MinStrength", "Warrior");
                    tbDexterity.Text = maker.GetValue("MinDexterity", "Warrior");
                    tbConstitution.Text = maker.GetValue("MinConstitution", "Warrior");
                    tbIntelligence.Text = maker.GetValue("MinIntelligence", "Warrior");
                    param[0] = double.Parse(maker.GetValue("MinStrength", "Warrior"));
                    param[1] = double.Parse(maker.GetValue("MinDexterity", "Warrior"));
                    param[2] = double.Parse(maker.GetValue("MinConstitution", "Warrior"));
                    param[3] = double.Parse(maker.GetValue("MinIntelligence", "Warrior"));
                    CalcParams();
                    panelWarrior.Visible = true;
                    panelRogue.Visible = false;
                    panelWisard.Visible = false;
                    SkillsRefresh();
                    break;
                case "Rogue":
                    tbStrength.Text = maker.GetValue("MinStrength", "Rogue");
                    tbDexterity.Text = maker.GetValue("MinDexterity", "Rogue");
                    tbConstitution.Text = maker.GetValue("MinConstitution", "Rogue");
                    tbIntelligence.Text = maker.GetValue("MinIntelligence", "Rogue");
                    param[0] = double.Parse(maker.GetValue("MinStrength", "Rogue"));
                    param[1] = double.Parse(maker.GetValue("MinDexterity", "Rogue"));
                    param[2] = double.Parse(maker.GetValue("MinConstitution", "Rogue"));
                    param[3] = double.Parse(maker.GetValue("MinIntelligence", "Rogue"));
                    CalcParams();
                    panelWarrior.Visible = false;
                    panelRogue.Visible = true;
                    panelWisard.Visible = false;
                    SkillsRefresh();
                    break;
                case "Wisard":
                    tbStrength.Text = maker.GetValue("MinStrength", "Wisard");
                    tbDexterity.Text = maker.GetValue("MinDexterity", "Wisard");
                    tbConstitution.Text = maker.GetValue("MinConstitution", "Wisard");
                    tbIntelligence.Text = maker.GetValue("MinIntelligence", "Wisard");
                    param[0] = double.Parse(maker.GetValue("MinStrength", "Wisard"));
                    param[1] = double.Parse(maker.GetValue("MinDexterity", "Wisard"));
                    param[2] = double.Parse(maker.GetValue("MinConstitution", "Wisard"));
                    param[3] = double.Parse(maker.GetValue("MinIntelligence", "Wisard"));
                    CalcParams();
                    panelWarrior.Visible = false;
                    panelRogue.Visible = false;
                    panelWisard.Visible = true;
                    SkillsRefresh();
                    break;
            }
        }

        private void CalcParams()
        {
            double[] parameters = maker.CalcParams(cbCharacter.Text, param);
            tbHealthPoint.Text = parameters[0].ToString();
            tbPhysicalAttake.Text = parameters[1].ToString();
            tbMagicalAttake.Text = parameters[2].ToString();
            tbPhysicalDef.Text = parameters[3].ToString();
            tbManaPool.Text = parameters[4].ToString();
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            if(cbCharacter.Text != "" || cbExistingCharacter.Text != "")
            {
                Button currentButton = (Button)sender;
                switch (currentButton.Tag)
                {
                    case "Strength":
                        if (CheckParamsLimits(tbStrength.Text, -1, "MinStrength"))
                        {
                            tbStrength.Text = tbChangeValue(tbStrength.Text, -1);
                            param[0] = double.Parse(tbStrength.Text);
                            CalcParams();
                        }
                        break;
                    case "Dexterity":
                        if (CheckParamsLimits(tbDexterity.Text, -1, "MinDexterity"))
                        {
                            tbDexterity.Text = tbChangeValue(tbDexterity.Text, -1);
                            param[1] = double.Parse(tbDexterity.Text);
                            CalcParams();
                        }
                        break;
                    case "Constitution":
                        if (CheckParamsLimits(tbConstitution.Text, -1, "MinConstitution"))
                        {
                            tbConstitution.Text = tbChangeValue(tbConstitution.Text, -1);
                            param[2] = double.Parse(tbConstitution.Text);
                            CalcParams();
                        }
                        break;
                    case "Intelligence":
                        if (CheckParamsLimits(tbIntelligence.Text, -1, "MinIntelligence"))
                        {
                            tbIntelligence.Text = tbChangeValue(tbIntelligence.Text, -1);
                            param[3] = double.Parse(tbIntelligence.Text);
                            CalcParams();
                        }
                        break;
                }
            }
        }// кнопка уменьшения характеристик

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (cbCharacter.Text != "" || cbExistingCharacter.Text != "")
            {
                if (int.Parse(tbSkillPoints.Text) <= 0)
                {
                    MessageBox.Show("Не хватает очков навыков");
                    return;
                }

                Button currentButton = (Button)sender;
                switch (currentButton.Tag)
                {
                    case "Strength":
                        if (CheckParamsLimits(tbStrength.Text, 1, "MaxStrength"))
                        {
                            tbStrength.Text = tbChangeValue(tbStrength.Text, 1);
                            param[0] = double.Parse(tbStrength.Text);
                            CalcParams();
                        }
                        break;
                    case "Dexterity":
                        if (CheckParamsLimits(tbDexterity.Text, 1, "MaxDexterity"))
                        {
                            tbDexterity.Text = tbChangeValue(tbDexterity.Text, 1);
                            param[1] = double.Parse(tbDexterity.Text);
                            CalcParams();
                        }
                        break;
                    case "Constitution":
                        if (CheckParamsLimits(tbConstitution.Text, 1, "MaxConstitution"))
                        {
                            tbConstitution.Text = tbChangeValue(tbConstitution.Text, 1);
                            param[2] = double.Parse(tbConstitution.Text);
                            CalcParams();
                        }
                        break;
                    case "Intelligence":
                        if (CheckParamsLimits(tbIntelligence.Text, 1, "MaxIntelligence"))
                        {
                            tbIntelligence.Text = tbChangeValue(tbIntelligence.Text, 1);
                            param[3] = double.Parse(tbIntelligence.Text);
                            CalcParams();
                        }
                        break;
                }
            }
        }// кнопка увеличения характеристик\

        private string tbChangeValue(string textBoxText, double num)
        {
            double textBoxNum = double.Parse(textBoxText);
            tbSkillPoints.Text = (int.Parse(tbSkillPoints.Text) - num).ToString();
            return (textBoxNum + (num)).ToString();
        }

        private bool CheckParamsLimits(string textBoxText, double num, string key)// проверка выхода за границы максимума и минимума характеристик
        {
            switch (cbCharacter.Text)
            {
                case "Warrior":
                    if (num < 0 && int.Parse(textBoxText) == CharacterMaker.Warrior[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    else if (num > 0 && int.Parse(textBoxText) == CharacterMaker.Warrior[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    return true;
                case "Rogue":
                    if (num < 0 && int.Parse(textBoxText) == CharacterMaker.Rogue[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    else if (num > 0 && int.Parse(textBoxText) == CharacterMaker.Rogue[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    return true;
                case "Wisard":
                    if (num < 0 && int.Parse(textBoxText) == CharacterMaker.Wisard[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    else if (num > 0 && int.Parse(textBoxText) == CharacterMaker.Wisard[key])
                    {
                        MessageBox.Show("Дальше нелзя");
                        return false;
                    }
                    return true;
            }
            return false;
        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharactersBase");
            var collection = database.GetCollection<Character>("Character");
            var list = collection.Find(x => true).ToList();
            foreach (var item in list)
            {
                if (item.Name == tbName.Text)
                {
                    MessageBox.Show("Такой ник уже есть!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbCharacter.SelectedIndex != null)
            {
                string[] characterParams = ColectingParams();
                character = maker.Make(cbCharacter.Text, characterParams);
                
                if (character != null)
                {
                    cbExistingCharacter.Items.Add(tbName.Text);
                    Mongo.AddToDB(character);
                }  
                else
                    return;
            }
            TextboxClear();
            SkillsRefresh();
            cbCharacter.SelectedItem = null;
        }

        private string[] ColectingParams()
        {
            string[] characterParams = new string[14];
            characterParams[0] = tbName.Text;
            characterParams[1] = tbStrength.Text;
            characterParams[2] = tbDexterity.Text;
            characterParams[3] = tbConstitution.Text;
            characterParams[4] = tbIntelligence.Text;
            characterParams[5] = tbHealthPoint.Text;
            characterParams[6] = tbPhysicalAttake.Text;
            characterParams[7] = tbMagicalAttake.Text;
            characterParams[8] = tbPhysicalDef.Text;
            characterParams[9] = tbManaPool.Text;
            characterParams[10] = tbLVL.Text;
            characterParams[11] = tbXP.Text;
            characterParams[12] = tbSkillPoints.Text;
            characterParams[13] = tbStarPoints.Text;
            return characterParams;
        }

        private void TextboxClear()
        {
            foreach (Control c in panelParameters.Controls)
                if (c is TextBox)
                    ((TextBox)c).Text = null;
            tbSkillPoints.Text = "0";
            tbName.Text = "";
            tbLVL.Text = "1";
            tbXP.Text = "0";
        }

        private void TextboxFill(Character character)
        {
            tbName.Text = character.Name;
            tbStrength.Text = character.Strength.ToString();
            tbDexterity.Text = character.Dexterity.ToString();
            tbConstitution.Text = character.Constitution.ToString();
            tbIntelligence.Text = character.Intelligence.ToString();
            tbLVL.Text = character.LVL.ToString();
            tbXP.Text = character.XP.ToString();
            tbSkillPoints.Text = character.SkillPoints.ToString();
            tbStarPoints.Text = character.StarPoints.ToString();
            param[0] = character.Strength;
            param[1] = character.Dexterity ;
            param[2] = character.Constitution;
            param[3] = character.Intelligence;
            CalcParams();
        }

        private void cbExistingCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillsRefresh();
            lvEquipment.Items.Clear();
            character = Mongo.Find(cbExistingCharacter.Text);
            switch (character.CharacterClass)
            {
                case "Warrior":
                    cbCharacter.SelectedIndex = 0;
                    break;
                case "Rogue":
                    cbCharacter.SelectedIndex = 1;
                    break;
                case "Wisard":
                    cbCharacter.SelectedIndex = 2;
                    break;
            }
            TextboxFill(character);
            pbLVL.Maximum = character.LVL * 1000;
            int temp = int.Parse(tbXP.Text);
            for (int i = 0; i < character.LVL; i++)
            {
                temp -= i * 1000;
            }

            pbLVL.Value = temp;
            foreach (var skill in character.Skills)
            {
                maker.skills.Add(skill);
                SkillsFill(skill.SkillName);
            }
            foreach (var item in character.Inventory)
            {
                maker.Inventory.Add(item);
            }
            foreach (var item in character.Equipment)
            {
                maker.Equipment.Add(item);
                lvEquipment.Items.Add(item.ItemName);
                ItemBufs(item);
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (cbCharacter.SelectedItem != null && cbExistingCharacter.SelectedItem != null)
            {
                foreach (var item in character.Equipment)
                {
                    ItemBufsDel(item);
                }
                character = maker.Make(cbCharacter.Text, ColectingParams());
                maker.Inventory.Clear();
                maker.Equipment.Clear();
                if (character != null)
                {
                    Mongo.Replace(cbExistingCharacter.Text, character);
                    Mongo.FindAll(cbExistingCharacter);
                }   
                lvEquipment.Items.Clear();
                TextboxClear();
                SkillsRefresh();
                pbLVL.Value = 0;
            }
        }

        private void btnLVLUp_Click(object sender, EventArgs e)
        {
            if ((cbCharacter.SelectedItem != null || cbExistingCharacter.SelectedItem != null) && tbName.Text != "")
            {
                Button currentBtn = (Button)sender;
                int progressBoost = 0;
                pbLVL.Maximum = (int.Parse(tbLVL.Text)) * 1000;
                if (currentBtn.Tag == "+500XP")
                {
                    progressBoost = 500;
                }
                else if (currentBtn.Tag == "LVLUP")
                {
                    progressBoost = (int.Parse(tbLVL.Text)) * 1000 - pbLVL.Value;
                }
                pbLVL.Value += progressBoost;
                tbXP.Text = (int.Parse(tbXP.Text) + progressBoost).ToString();
                if (pbLVL.Value >= pbLVL.Maximum)
                {
                    tbSkillPoints.Text = (int.Parse(tbSkillPoints.Text) + 10).ToString();
                    pbLVL.Value = 0;
                    tbLVL.Text = (int.Parse(tbLVL.Text) + 1).ToString();
                }
                if ((int.Parse(tbLVL.Text)) % 3 == 0 && skillGive == 1)
                {
                    tbStarPoints.Text = (int.Parse(tbStarPoints.Text) + 1).ToString();
                    skillGive = -1;
                }
                else if ((int.Parse(tbLVL.Text)) % 3 != 0 && skillGive == -1)
                    skillGive = 1;
            }
        }

        private void lbSkills_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbStarPoints.Text) >= 3)
            {
                Label lab = (Label)sender;
                if(!CheckSkills(lab))
                    return;
                SkillsFill(lab.Tag.ToString());
                tbStarPoints.Text = (int.Parse(tbStarPoints.Text) - 3).ToString();
                maker.skills.Add(new CharacterSkills(lab.Tag.ToString()));
            }
            else
            {
                MessageBox.Show("Не хватает звёздных очков");
                return;
            }
        }

        private void SkillsFill(string skill)
        {
            switch (skill)
            {
                case "Rage":
                    panelRage.BackColor = Color.Green;
                    break;
                case "Poison":
                    panelPoison.BackColor = Color.Green;
                    break;
                case "DoubleJump":
                    panelDoubleJump.BackColor = Color.Green;
                    break;
                case "SelfCare":
                    panelSelfCare.BackColor = Color.Green;
                    break;
                case "FireStrike":
                    panelFireStrike.BackColor = Color.Green;
                    break;
                case "SpeedBoost":
                    panelSpeedBoost.BackColor = Color.Green;
                    break;
            }
        }

        private void SkillsRefresh()
        {
            foreach (Control c in panelSkills.Controls)
                if (c is Panel)
                    ((Panel)c).BackColor = Color.WhiteSmoke;
            maker.skills.Clear();
        }

        private bool CheckSkills(Label lab)
        {
            if(maker.skills.Count > 0)
            {
                foreach (var i in maker.skills)
                {
                    if (lab.Tag.ToString() == i.SkillName)
                    {
                        MessageBox.Show("Эта способность уже есть!");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (character == null || cbCharacter.SelectedItem == null || tbName.Text == "")
            {
                return;
            }

            Form2 newForm = new Form2();
            newForm.Maker = maker;
            newForm.InventoryFill(character);
            foreach (var item in character.Equipment)
                ItemBufsDel(item);
            newForm.ShowDialog();
            lvEquipment.Items.Clear();
            if(character.Equipment.Count == 0)
                CalcParams();
            foreach (var item in maker.Equipment)
            {
                lvEquipment.Items.Add(item.ItemName);
                ItemBufs(item);
            }
        }

        private void ItemBufs(Item item)
        {
            switch(item.ItemClass)
            {
                case "Helmet":
                    if(item == null)
                    {
                        CalcParams();
                        return;
                    }
                    tbPhysicalDef.Text = (double.Parse(tbPhysicalDef.Text) + item.PhysicalDef).ToString();
                    tbHealthPoint.Text = (double.Parse(tbHealthPoint.Text) + Helmet.HelmetBufs[item.ItemLVL][0]).ToString();
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) + Helmet.HelmetBufs[item.ItemLVL][1]).ToString();
                    break;
                case "Armor":
                    if (item == null)
                    {
                        CalcParams();
                        return;
                    }
                    tbPhysicalDef.Text = (double.Parse(tbPhysicalDef.Text) + item.PhysicalDef).ToString();
                    tbHealthPoint.Text = (double.Parse(tbHealthPoint.Text) + Helmet.HelmetBufs[item.ItemLVL][0]).ToString();
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) + Helmet.HelmetBufs[item.ItemLVL][1]).ToString();
                    break;
                case "Weapon":
                    if (item == null)
                    {
                        CalcParams();
                        return;
                    }
                    if (item.Damage == 0)
                    {
                        tbMagicalAttake.Text = (double.Parse(tbMagicalAttake.Text) + item.MagicalDamage).ToString();
                        tbManaPool.Text = (double.Parse(tbManaPool.Text) + Weapon.MagWeaponBufs[item.ItemLVL][0]).ToString();
                        tbStrength.Text = (double.Parse(tbStrength.Text) + Weapon.MagWeaponBufs[item.ItemLVL][1]).ToString();
                    }    
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) + item.Damage).ToString();
                    tbStrength.Text = (double.Parse(tbStrength.Text) + Weapon.WeaponBufs[item.ItemLVL][0]).ToString();
                    tbDexterity.Text = (double.Parse(tbDexterity.Text) + Weapon.WeaponBufs[item.ItemLVL][1]).ToString();
                    break;
            }
        }

        private void ItemBufsDel(Item item)
        {
            switch (item.ItemClass)
            {
                case "Helmet":
                    if (item == null)
                    {
                        CalcParams();
                        return;
                    }
                    tbPhysicalDef.Text = (double.Parse(tbPhysicalDef.Text) - item.PhysicalDef).ToString();
                    tbHealthPoint.Text = (double.Parse(tbHealthPoint.Text) + Helmet.HelmetBufs[item.ItemLVL][0]).ToString();
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) + Helmet.HelmetBufs[item.ItemLVL][1]).ToString();
                    break;
                case "Armor":
                    if (item == null)
                    {
                        CalcParams();
                        return;
                    }
                    tbPhysicalDef.Text = (double.Parse(tbPhysicalDef.Text) - item.PhysicalDef).ToString();
                    tbHealthPoint.Text = (double.Parse(tbHealthPoint.Text) - Helmet.HelmetBufs[item.ItemLVL][0]).ToString();
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) + Helmet.HelmetBufs[item.ItemLVL][1]).ToString();
                    break;
                case "Weapon":
                    if (item == null)
                    {
                        CalcParams();
                        return;
                    }
                    if (item.Damage == 0)
                    {
                        tbMagicalAttake.Text = (double.Parse(tbMagicalAttake.Text) - item.MagicalDamage).ToString();
                        tbManaPool.Text = (double.Parse(tbManaPool.Text) - Weapon.MagWeaponBufs[item.ItemLVL][0]).ToString();
                        tbStrength.Text = (double.Parse(tbStrength.Text) + Weapon.MagWeaponBufs[item.ItemLVL][1]).ToString();
                    }
                    tbPhysicalAttake.Text = (double.Parse(tbPhysicalAttake.Text) - item.Damage).ToString();
                    tbStrength.Text = (double.Parse(tbStrength.Text) - Weapon.WeaponBufs[item.ItemLVL][0]).ToString();
                    tbDexterity.Text = (double.Parse(tbDexterity.Text) - Weapon.WeaponBufs[item.ItemLVL][1]).ToString();
                    break;
            }
        }
    }
}