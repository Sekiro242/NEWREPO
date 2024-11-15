using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudOperations
{
    /// <summary>
    /// Interaction logic for Crud.xaml
    /// </summary>
    public partial class Crud : Page
    {
        TestEntities db = new TestEntities();
        test tast = new test();
        public Crud()
        {
            InitializeComponent();
            Dg2.ItemsSource = db.tests.ToList();
        }

        public void refresh()
        {

            Dg2.ItemsSource = db.tests.ToList();

        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
        
            tast.EmpName = NameB.Text;
            tast.EmpPosition = StateB.Text;
            db.tests.Add(tast);
            db.SaveChanges();
            refresh();
            MessageBox.Show("Saved Successfuly!");

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDBox.Text);
            tast = db.tests.Remove(db.tests.FirstOrDefault(x => x.ID == id));
            db.SaveChanges();
            refresh();
            MessageBox.Show("Deleted");

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDBox.Text);
            tast = db.tests.FirstOrDefault(x => x.ID == id);
            tast.EmpName = NameB.Text;
            tast.EmpPosition = StateB.Text;
            db.SaveChanges();
            refresh();
            MessageBox.Show("Updated Ya habibi");


        }
    }
}
