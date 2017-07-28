using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuntingRegistry.Models;

namespace HuntingRegistry
{
    public partial class Form1 : Form
    {
        public AnimalsDocument ad;
        public HuntingDBContext context;

        public Form1()
        {
            InitializeComponent();

            ad = new AnimalsDocument();
            animalsDocumentBindingSource.DataSource = ad;
        }

        public Form1(AnimalsDocument _ad, HuntingDBContext dbContext)
        {
            InitializeComponent();
            context = dbContext;

            

            animalsDocumentBindingSource.DataSource = _ad;

            animalBindingSource.DataSource = context.Animals.OrderBy(b => b.Name).ToList();
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {

            ad = (AnimalsDocument)animalsDocumentBindingSource.Current;

            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void animalBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ((AnimalsDocument) animalsDocumentBindingSource.Current).Animal = (Animal)animalBindingSource.Current;
        }
    }
}
