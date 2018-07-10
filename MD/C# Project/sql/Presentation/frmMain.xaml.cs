using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarriageApp.Presentation
{
    public partial class frmMain : Window
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bride_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmBride m = new MarriageApp.Presentation.frmBride();
            m.Owner = this;
            m.Show();
        }

        private void Catholic_Party_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmCatholic_Party m = new MarriageApp.Presentation.frmCatholic_Party();
            m.Owner = this;
            m.Show();
        }

        private void Dispensation_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmDispensation m = new MarriageApp.Presentation.frmDispensation();
            m.Owner = this;
            m.Show();
        }

        private void Dispensation_Type_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmDispensation_Type m = new MarriageApp.Presentation.frmDispensation_Type();
            m.Owner = this;
            m.Show();
        }

        private void Groom_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmGroom m = new MarriageApp.Presentation.frmGroom();
            m.Owner = this;
            m.Show();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmLog m = new MarriageApp.Presentation.frmLog();
            m.Owner = this;
            m.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmLogin m = new MarriageApp.Presentation.frmLogin();
            m.Owner = this;
            m.Show();
        }

        private void MarriageRec_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmMarriageRec m = new MarriageApp.Presentation.frmMarriageRec();
            m.Owner = this;
            m.Show();
        }

        private void Parish_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmParish m = new MarriageApp.Presentation.frmParish();
            m.Owner = this;
            m.Show();
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmRecord m = new MarriageApp.Presentation.frmRecord();
            m.Owner = this;
            m.Show();
        }

        private void RecordToDispensation_Click(object sender, RoutedEventArgs e)
        {
            MarriageApp.Presentation.frmRecordToDispensation m = new MarriageApp.Presentation.frmRecordToDispensation();
            m.Owner = this;
            m.Show();
        }

    }
}
 
