using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator;
using MongoDB.Driver;
using System.Xml.Linq;
using CharacterRedactor;

namespace CharacterRedactor_
{
    public partial class Form2 : Form
    {
        ItemMaker maker = new ItemMaker();
        Character character;
        List<Item> item = new List<Item>();

        public Form2()
        {
            InitializeComponent();
            item.Clear();
        }

        public void InventoryFill(Character character)
        {

            this.character = character;
            if (character.Inventory != null)
            {
                foreach (var item in character.Inventory)
                {
                    lvInventory.Items.Add(item.ItemName);
                }
            }
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string[] parameters = GerParams(e);
                item.Add(new Item(parameters[0], parameters[1], int.Parse(parameters[2]), double.Parse(parameters[3])));
                lvInventory.Items.Add(parameters[0]);
            }
        }
        
        public string[] GerParams(ListViewItemSelectionChangedEventArgs e)
        {
            string[] param = new string[4];
            param[0] = lvItems.Items[e.ItemIndex].SubItems[0].Text;
            param[1] = lvItems.Items[e.ItemIndex].SubItems[8].Text;
            param[2] = lvItems.Items[e.ItemIndex].SubItems[9].Text;
            param[3] = lvItems.Items[e.ItemIndex].SubItems[7].Text;
            return param;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(var item in item)
            {
                character.AddItem(item);
                Mongo.UpgradeOne(character.Name, character);
                this.Close();
            }  
        }

        private void lvInventory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var a = (ListViewItem)e.Item;
            a.Remove();
            foreach(c)
        }
    }
}
