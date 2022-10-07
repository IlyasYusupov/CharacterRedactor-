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
        public Form2()
        {
            InitializeComponent();
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Character character = Mongo.Find(CharacterName);
            string[] parameters = GerParams(e);
            Item item = maker.Make(parameters);
            character.AddItem(item);
            Mongo.UpgradeOne(CharacterName, character);
            foreach(var i in character.Inventory)
            {
                lvInventory.Items.Add(i.ItemName);
            }
        }
        
        public string[] GerParams(ListViewItemSelectionChangedEventArgs e)
        {
            string[] param = new string[4];
            param[0] = lvItems.Items[e.ItemIndex].SubItems[0].Text;
            param[1] = lvItems.Items[e.ItemIndex].SubItems[8].Text;
            param[2] = lvItems.Items[e.ItemIndex].SubItems[7].Text;
            param[3] = lvItems.Items[e.ItemIndex].SubItems[1].Text;

            return param;
        }


        private void btnDeletItem_Click(object sender, EventArgs e)
        {

        }


    }
}
