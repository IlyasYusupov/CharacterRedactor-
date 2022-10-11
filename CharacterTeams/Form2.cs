using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using CharacterRedactor_;
using CharacterRedactor;

namespace CharacterTeams
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void lvCharacters_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

    }
}
