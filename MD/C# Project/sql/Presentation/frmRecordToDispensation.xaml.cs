using System.Data;
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
    public partial class frmRecordToDispensation : Window
    {
        public frmRecordToDispensation()
        {
            InitializeComponent();
        }

        private bool AddMode = false;
        private bool EditMode = false;
        private bool DeleteMode = false;
        private int Row = 0;

        MarriageData clsMarriageData = new MarriageData();
        
        private void frmRecordToDispensation_Loaded(object sender, RoutedEventArgs e)
        {
            cmbFields.Items.Add("Id");
            cmbFields.Items.Add("Record Id");
            cmbFields.Items.Add("Dispensation Id");

            cmbCondition.Items.Add("Contains");
            cmbCondition.Items.Add("Equals");
            cmbCondition.Items.Add("Starts with...");
            cmbCondition.Items.Add("More than...");
            cmbCondition.Items.Add("Less than...");
            cmbCondition.Items.Add("Equal or more than...");
            cmbCondition.Items.Add("Equal or less than...");

            InitToolBarItems();
            tiGrid.Height = 0;
            tiDetail.Height = 0;
            LoadRecordToDispensation_RecordComboBox70();
            LoadRecordToDispensation_DispensationComboBox71();
            LoadGrid(true);
            tiGrid.IsSelected = true;
        }

        private void LoadRecordToDispensation_RecordComboBox70()
        {
            using (new WaitCursor())
            {
                List<RecordToDispensation_Record70> RecordToDispensation_RecordList = new  List<RecordToDispensation_Record70>();
                try
                {
                    RecordToDispensation_RecordList = RecordToDispensation_RecordData70.List();
                    cbRecord_Id.ItemsSource = RecordToDispensation_RecordList;
                    cbRecord_Id.DisplayMemberPath = "Record_ID";
                    cbRecord_Id.SelectedValuePath = "Record_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecordToDispensation_DispensationComboBox71()
        {
            using (new WaitCursor())
            {
                List<RecordToDispensation_Dispensation71> RecordToDispensation_DispensationList = new  List<RecordToDispensation_Dispensation71>();
                try
                {
                    RecordToDispensation_DispensationList = RecordToDispensation_DispensationData71.List();
                    cbDispensation_Id.ItemsSource = RecordToDispensation_DispensationList;
                    cbDispensation_Id.DisplayMemberPath = "Dispensation_ID";
                    cbDispensation_Id.SelectedValuePath = "Dispensation_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadGrid(bool SelectRow)
        {
            using (new WaitCursor())
            {
                try
                {
                    DataTable dt = RecordToDispensationData.SelectAll();
                    Grid.ItemsSource = dt.DefaultView;
                    Grid.CanUserAddRows = false;
                    Grid.CanUserDeleteRows = false;
                    Grid.IsReadOnly = true;
                    if (Grid.Items.Count > 0 & SelectRow == true)
                    {
                        Grid.SelectedItem = Grid.Items[0];
                        Grid.ScrollIntoView(Grid.SelectedItem);
                    }
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                finally
                {
                }
            }
        }

        private void Grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();
            DataGridTextColumn txtCol = e.Column as DataGridTextColumn;
        }

        private void tbiAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
            tiDetail.IsSelected = true;

            InitToolBarItems();
            tbiAdd.IsEnabled = false;
            tbiEdit.IsEnabled = false;
            tbiDelete.IsEnabled = false;
            tbiApply.IsEnabled = true;
            tbiCancel.IsEnabled = true;
            tbiRefresh.IsEnabled = false;
        }

        private void tbiEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
            tiDetail.IsSelected = true;

            InitToolBarItems();
            tbiAdd.IsEnabled = false;
            tbiEdit.IsEnabled = false;
            tbiDelete.IsEnabled = false;
            tbiApply.IsEnabled = true;
            tbiCancel.IsEnabled = true;
            tbiRefresh.IsEnabled = false;
        }

        private void tbiDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            tiDetail.IsSelected = true;

            InitToolBarItems();
            tbiAdd.IsEnabled = false;
            tbiEdit.IsEnabled = false;
            tbiDelete.IsEnabled = false;
            tbiApply.IsEnabled = true;
            tbiCancel.IsEnabled = true;
            tbiRefresh.IsEnabled = false;
        }

        private void tbiApply_Click(object sender, RoutedEventArgs e)
        {
            if (this.AddMode == true)
            {
                this.InsertRecord();
            }
            else if (this.EditMode == true)
            {
                this.UpdateRecord();
            }
            else if (this.DeleteMode == true)
            {
                this.DeleteRecord();
            }
        }

        private void tbiCancel_Click(object sender, RoutedEventArgs e)
        {
            tiGrid.IsSelected = true;
            InitToolBarItems();
        }

        private void tbiRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadGrid(true);
        }

        private void tbiClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Row = Grid.SelectedIndex;
        }
        
        private void InitToolBarItems()
        {
            tbiAdd.IsEnabled = true;
            tbiEdit.IsEnabled = true;
            tbiDelete.IsEnabled = true;
            tbiApply.IsEnabled = false;
            tbiCancel.IsEnabled = false;
            tbiRefresh.IsEnabled = true;
            tbiClose.IsEnabled = true;
        }

        private void GetData()
        {
            using (new WaitCursor())
            {
                ClearRecord();

                RecordToDispensation clsRecordToDispensation = new RecordToDispensation();
                clsRecordToDispensation.id = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                clsRecordToDispensation = RecordToDispensationData.Select_Record(clsRecordToDispensation);

                if ((clsRecordToDispensation != null))
                {
                    try
                    {
                        nudid.Text = System.Convert.ToInt32(clsRecordToDispensation.id).ToString();
                        cbRecord_Id.SelectedValue = System.Convert.ToInt32(clsRecordToDispensation.Record_Id);
                        cbDispensation_Id.SelectedValue = System.Convert.ToInt32(clsRecordToDispensation.Dispensation_Id);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void SetData(RecordToDispensation clsRecordToDispensation)
        {
            using (new WaitCursor())
            {
                clsRecordToDispensation.Record_Id = System.Convert.ToInt32(cbRecord_Id.SelectedValue);
                clsRecordToDispensation.Dispensation_Id = System.Convert.ToInt32(cbDispensation_Id.SelectedValue);
            }
        }

        private void Add()
        {
            this.AddMode = true;
            this.EditMode = false;
            this.DeleteMode = false;

            ClearRecord();
            IsReadOnlyRecord(true);
            cbRecord_Id.Focus();
            nudid.Text = System.Convert.ToString(clsMarriageData.getAutoID("New", "RecordToDispensation"));
        }

        private void Edit()
        {
            AddMode = false;
            EditMode = true;
            DeleteMode = false;

            GetData();

            IsReadOnlyRecord(true);
            cbRecord_Id.Focus();
        }

        private void Delete()
        {
            AddMode = false;
            EditMode = false;
            DeleteMode = true;

            GetData();

            IsReadOnlyRecord(false);
        }

        private void IsReadOnlyRecord(bool YesNo)
        {
            cbRecord_Id.IsEnabled = YesNo;
            cbDispensation_Id.IsEnabled = YesNo;
        }

        private void ClearRecord()
        {
            nudid.Text = "0";
            cbRecord_Id.SelectedIndex = -1;
            cbDispensation_Id.SelectedIndex = -1;
        }

        private void GoBack_To_Grid()
        {
            int LastRow = Row;
            bool gridOK = false;
            try
            {
                LoadGrid(false);
                Grid.SelectedItems.Clear();
                Grid.SelectedItem = Grid.Items[LastRow];
                Grid.ScrollIntoView(Grid.Items[LastRow]);
            	tiGrid.IsSelected = true;
            	InitToolBarItems();
            	gridOK = true;
            }
            catch
            {
                //Hide error message.
            }
            finally
            {
                if (gridOK == false)
                {
                    LoadGrid(true);
                    tiGrid.IsSelected = true;
                    InitToolBarItems();
                }
            }
        }

        private void InsertRecord()
        {
            using (new WaitCursor())
            {
            RecordToDispensation clsRecordToDispensation = new RecordToDispensation();
                if (VerifyData() == true) {
                    SetData(clsRecordToDispensation);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordToDispensationData.Add(clsRecordToDispensation);
                    if (bSucess == true) {
                        GoBack_To_Grid(); }
                    else {
                        MessageBox.Show("Insert failed.", "Error"); }
                }
            }
        }

        private void UpdateRecord()
        {
            using (new WaitCursor())
            {
                RecordToDispensation oclsRecordToDispensation = new RecordToDispensation();
                RecordToDispensation clsRecordToDispensation = new RecordToDispensation();

                oclsRecordToDispensation.id = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                oclsRecordToDispensation = RecordToDispensationData.Select_Record(oclsRecordToDispensation);

                if (VerifyData() == true) {
                    SetData(clsRecordToDispensation);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordToDispensationData.Update(oclsRecordToDispensation, clsRecordToDispensation);
                    if (bSucess == true) {
                        GoBack_To_Grid(); }
                    else {
                        MessageBox.Show("Update failed.", "Error");}
                }
            }
        } 

        private void DeleteRecord()
        {
            using (new WaitCursor())
            {
                RecordToDispensation clsRecordToDispensation = new RecordToDispensation();
                clsRecordToDispensation.id = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                if (MessageBox.Show("Are you sure? Delete this record?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    SetData(clsRecordToDispensation);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordToDispensationData.Delete(clsRecordToDispensation);
                    if (bSucess == true) {
                        GoBack_To_Grid(); }
                    else {
                        MessageBox.Show("Delete failed.", "Error"); }
                }
            }
        }  

        private Boolean VerifyData()
        {
            if (cbRecord_Id.SelectedIndex == -1) {
                MessageBox.Show("Record Id is Required", "Error");
                cbRecord_Id.Focus();
                return false;}          
            if (cbDispensation_Id.SelectedIndex == -1) {
                MessageBox.Show("Dispensation Id is Required", "Error");
                cbDispensation_Id.Focus();
                return false;}          
            return true;
        }

        private void nudid_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(Convert.ToChar(e.Text)))
                e.Handled = true;
        }


        private void cbExport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (new WaitCursor())
            {
                try
                {
                    MarriageData clsMarriageData = new MarriageData();
                    if (cbiPDF.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToPdf("Many", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToPdf("One", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiExcel.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("Many", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("One", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiWord.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToWord("Many", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToWord("One", 
                                                     "Dbo. Record To Dispensation", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    cbiExport.IsSelected = true;
                }
                catch
                {
                }
            }
        }

        private void butShowAll_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = null;
            LoadGrid(true);
            tiGrid.IsSelected = true;
        }

        private void butSearch_Click(object sender, RoutedEventArgs e)
        {
            using (new WaitCursor())
            {
                try
                {
                    DataTable dt = RecordToDispensationData.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text);
                    Grid.ItemsSource = dt.DefaultView;
                    Grid.CanUserAddRows = false;
                    Grid.CanUserDeleteRows = false;
                    Grid.IsReadOnly = true;
                    if (Grid.Items.Count > 0)
                    {
                        Grid.SelectedItem = Grid.Items[0];
                        Grid.ScrollIntoView(Grid.SelectedItem);
                    }
                }
                catch
                {
                    MessageBox.Show("An error occurred in butSearch_Click...", "Error");
                }
                finally
                {
                }
            }
        }

    }
}





 
