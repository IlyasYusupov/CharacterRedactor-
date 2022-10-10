using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Xml.Linq;
using CharacterRedactor;
using System.Diagnostics.Metrics;

namespace CharacterRedactor_
{
    public partial class Form2 : Form
    {
        Character character;
        public CharacterMaker Maker;
        List<Item> Inventory = new List<Item>();
        Item[] Equip = new Item[3];

        public Form2()
        {
            InitializeComponent();
            Inventory.Clear();
        }

        public void InventoryFill(Character character)
        {
            this.character = character;
            Inventory.Clear();
            Equip = new Item[3];
            if (character.Inventory != null)
            {
                foreach (var item in character.Inventory)
                {
                    lvInventory.Items.Add(item.ItemName);
                    Inventory.Add(item);
                    cbAddItem(item.ItemClass, item.ItemName);
                }
                foreach(var item in character.Equipment)
                {
                    switch (item.ItemClass)
                    {
                        case "Helmet":
                            Equip[0] = item;
                            break;
                        case "Armor":
                            Equip[1] = item;
                            break;
                        case "Weapon":
                            Equip[2] = item;
                            break;
                    }
                }
            }
            //Maker.Equipment.Clear();
           // Maker.Inventory.Clear();
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (character.Strength < double.Parse(lvItems.Items[e.ItemIndex].SubItems[1].Text) || character.Dexterity < double.Parse(lvItems.Items[e.ItemIndex].SubItems[2].Text) ||
                    character.Constitution < double.Parse(lvItems.Items[e.ItemIndex].SubItems[3].Text) || character.Intelligence < double.Parse(lvItems.Items[e.ItemIndex].SubItems[4].Text))
                {
                    MessageBox.Show("Не дорос!");
                    return;
                }
                string[] parameters = GerParams(e);
                switch(lvItems.Items[e.ItemIndex].SubItems[8].Text)
                {
                    case "Helmet":
                        Inventory.Add(new Helmet(parameters[0], parameters[1], int.Parse(parameters[2]), double.Parse(parameters[3])));
                        break;
                    case "Armor":
                        Inventory.Add(new Armor(parameters[0], parameters[1], int.Parse(parameters[2]), double.Parse(parameters[3])));
                        break;
                    case "Weapon":
                        if(lvItems.Items[e.ItemIndex].Tag.ToString() == "Wisard")
                        {
                            Inventory.Add(new Weapon(parameters[0], double.Parse(parameters[2]), parameters[1], int.Parse(parameters[3])));
                            break;
                        }
                        Inventory.Add(new Weapon(parameters[0], parameters[1], double.Parse(parameters[2]), int.Parse(parameters[3])));
                        break;
                }
                lvInventory.Items.Add(parameters[0]);
                cbAddItem(parameters[1], parameters[0]);
            }
        }
        
        public string[] GerParams(ListViewItemSelectionChangedEventArgs e)
        {
            string[] param = new string[4];
            if (lvItems.Items[e.ItemIndex].SubItems[8].Text == "Weapon")
            {
                if(lvItems.Items[e.ItemIndex].Tag.ToString() == "Wisard")
                {
                    param[0] = lvItems.Items[e.ItemIndex].SubItems[0].Text;
                    param[2] = lvItems.Items[e.ItemIndex].SubItems[6].Text;
                    param[1] = lvItems.Items[e.ItemIndex].SubItems[8].Text;
                    param[3] = lvItems.Items[e.ItemIndex].SubItems[9].Text;
                    return param;
                }
                param[0] = lvItems.Items[e.ItemIndex].SubItems[0].Text;
                param[1] = lvItems.Items[e.ItemIndex].SubItems[8].Text;
                param[2] = lvItems.Items[e.ItemIndex].SubItems[5].Text;
                param[3] = lvItems.Items[e.ItemIndex].SubItems[9].Text;
                return param;
            }
            param[0] = lvItems.Items[e.ItemIndex].SubItems[0].Text;
            param[1] = lvItems.Items[e.ItemIndex].SubItems[8].Text;
            param[2] = lvItems.Items[e.ItemIndex].SubItems[9].Text;
            param[3] = lvItems.Items[e.ItemIndex].SubItems[7].Text;
            return param;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Maker.Inventory.Clear();
            foreach (var item in Inventory)
            {
                Maker.Inventory.Add(item);
            }
            Maker.Equipment.Clear();
            foreach (var item in Equip)
            {
                if(item != null)
                    Maker.Equipment.Add(item);
            }
            Mongo.UpgradeOne(character.Name, "Inventory", Maker.Inventory);
            Mongo.UpgradeOne(character.Name, "Equipment", Maker.Equipment);
            this.Close();
        }

        private void lvInventory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var a = (ListViewItem)e.Item;
                foreach (var item in character.Inventory)
                {
                    if (a.Text == item.ItemName)
                    {
                        character.Inventory.Remove(item);
                        break;
                    }
                }
                foreach (var item in Inventory)
                {
                    if (a.Text == item.ItemName)
                    {
                        Inventory.Remove(item);
                        cbDeletItem(item.ItemClass, item.ItemName);
                        break;
                    }
                }
                foreach(var item in Equip)
                {
                    if (item != null)
                    {
                        if (a.Text == item.ItemName)
                        {
                            switch (item.ItemClass)
                            {
                                case "Helmet":
                                    Equip[0] = null;
                                    break;
                                case "Armor":
                                    Equip[1] = null;
                                    break;
                                case "Weapon":
                                    Equip[2] = null;
                                    break;
                            }
                        }
                    }
                }
                a.Remove();
            }
        }

        private void cbAddItem(string Class, string Name)
        {
            switch (Class)
            {
                case "Helmet":
                    cbHelmets.Items.Add(Name);
                    break;
                case "Armor":
                    cbArmors.Items.Add(Name);
                    break;
                case "Weapon":
                    cbWeapons.Items.Add(Name);
                    break;
            }
        }

        private void cbDeletItem(string Class, string Name)
        {
            switch (Class)
            {
                case "Helmet":
                    cbHelmets.Items.Remove(Name);
                    break;
                case "Armor":
                    cbArmors.Items.Remove(Name);
                    break;
                case "Weapon":
                    cbWeapons.Items.Remove(Name);
                    break;
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = (ComboBox)sender;
            int num = int.Parse(a.Tag.ToString());
            foreach (var item in Inventory)
            {
                if(a.Text == item.ItemName)
                {
                    Equip[num] = item;
                }
            }    
        }
    }
}
