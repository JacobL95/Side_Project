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
    public partial class frmRecord : Window
    {
        public frmRecord()
        {
            InitializeComponent();
        }

        private bool AddMode = false;
        private bool EditMode = false;
        private bool DeleteMode = false;
        private int Row = 0;

        MarriageData clsMarriageData = new MarriageData();
        
        private void frmRecord_Loaded(object sender, RoutedEventArgs e)
        {
            cmbFields.Items.Add("Record ID");
            cmbFields.Items.Add("Groom First Name");
            cmbFields.Items.Add("Groom Middle Int");
            cmbFields.Items.Add("Groom Last Name");
            cmbFields.Items.Add("Bride First Name");
            cmbFields.Items.Add("Bride Middle Int");
            cmbFields.Items.Add("Bride Last Name");
            cmbFields.Items.Add("Wedding Date");
            cmbFields.Items.Add("Dispensation Category");
            cmbFields.Items.Add("Dispensation Type");
            cmbFields.Items.Add("Parish Of Wedding");           
            cmbFields.Items.Add("Non-KCSJ Arch/Diocese");
            cmbFields.Items.Add("Catholic Party");
            cmbFields.Items.Add("Convalidation");
            cmbFields.Items.Add("Annulments y/n");
            cmbFields.Items.Add("Originating Parish");
            cmbFields.Items.Add("Officiant Name");
            cmbFields.Items.Add("Papers Recieved Date");
            cmbFields.Items.Add("Papers Mailed Date");
            cmbFields.Items.Add("Approved By");           
            cmbFields.Items.Add("Additional Circumstances Note");
            cmbFields.Items.Add("Dispensation Link I D");
            cmbFields.Items.Add("Modified By");
            //cmbFields.Items.Add("Papers Mailed Note");
            /////////////////////////////////////////////////////////
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
            LoadRecord_GroomComboBox50();
            LoadRecord_BrideComboBox51();
            LoadRecord_Dispensation_TypeComboBox55();
            LoadRecord_DispensationComboBox57();
            LoadRecord_Catholic_PartyComboBox58();
            LoadRecord_ParishComboBox61();
            LoadRecord_ParishComboBox62();
            LoadRecord_RecordToDispensationComboBox();
            LoadGrid(true);
            tiGrid.IsSelected = true;
        }

        private void LoadRecord_GroomComboBox50()
        {
            using (new WaitCursor())
            {
                List<Record_Groom50> Record_GroomList = new  List<Record_Groom50>();
                try
                {
                    Record_GroomList = Record_GroomData50.List();
                    cbGroom_ID.ItemsSource = Record_GroomList;
                    cbGroom_ID.DisplayMemberPath = "Groom_ID";
                    cbGroom_ID.SelectedValuePath = "Groom_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_BrideComboBox51()
        {
            using (new WaitCursor())
            {
                List<Record_Bride51> Record_BrideList = new  List<Record_Bride51>();
                try
                {
                    Record_BrideList = Record_BrideData51.List();
                    cbBride_ID.ItemsSource = Record_BrideList;
                    cbBride_ID.DisplayMemberPath = "Bride_ID";
                    cbBride_ID.SelectedValuePath = "Bride_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_Dispensation_TypeComboBox55()
        {
            using (new WaitCursor())
            {
                List<Record_Dispensation_Type55> Record_Dispensation_TypeList = new  List<Record_Dispensation_Type55>();
                try
                {
                    Record_Dispensation_TypeList = Record_Dispensation_TypeData55.List();
                    cbDispensation_Type_ID.ItemsSource = Record_Dispensation_TypeList;
                    cbDispensation_Type_ID.DisplayMemberPath = "Dispensation_Type_Name";
                    cbDispensation_Type_ID.SelectedValuePath = "Dispensation_Type_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_DispensationComboBox57()
        {
            using (new WaitCursor())
            {
                List<Record_Dispensation57> Record_DispensationList = new  List<Record_Dispensation57>();
                try
                {
                    Record_DispensationList = Record_DispensationData57.List();
                    cbDispensation_ID.ItemsSource = Record_DispensationList;
                    cbDispensation_ID.DisplayMemberPath = "Dispensation_Category";
                    cbDispensation_ID.SelectedValuePath = "Dispensation_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_Catholic_PartyComboBox58()
        {
            using (new WaitCursor())
            {
                List<Record_Catholic_Party58> Record_Catholic_PartyList = new  List<Record_Catholic_Party58>();
                try
                {
                    Record_Catholic_PartyList = Record_Catholic_PartyData58.List();
                    cbCatholic_Party_ID.ItemsSource = Record_Catholic_PartyList;
                    cbCatholic_Party_ID.DisplayMemberPath = "Catholic_Party_Category";
                    cbCatholic_Party_ID.SelectedValuePath = "Catholic_Party_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_ParishComboBox61()
        {
            using (new WaitCursor())
            {
                List<Record_Parish61> Record_ParishList = new  List<Record_Parish61>();
                try
                {
                    Record_ParishList = Record_ParishData61.List();
                    cbPaperwork_Originated_Parish_ID.ItemsSource = Record_ParishList;
                    cbPaperwork_Originated_Parish_ID.DisplayMemberPath = "ParishName";
                    cbPaperwork_Originated_Parish_ID.SelectedValuePath = "Parish_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_ParishComboBox62()
        {
            using (new WaitCursor())
            {
                List<Record_Parish62> Record_ParishList = new  List<Record_Parish62>();
                try
                {
                    Record_ParishList = Record_ParishData62.List();
                    cbParish_Of_Wedding_Parish_ID.ItemsSource = Record_ParishList;
                    cbParish_Of_Wedding_Parish_ID.DisplayMemberPath = "ParishName";
                    cbParish_Of_Wedding_Parish_ID.SelectedValuePath = "Parish_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadRecord_RecordToDispensationComboBox()
        {
            using (new WaitCursor())
            {
                List<Record_RecordToDispensation> Record_RecordToDispensationList = new  List<Record_RecordToDispensation>();
                try
                {
                    Record_RecordToDispensationList = Record_RecordToDispensationData.List();
                    cbDispensationLink_ID.ItemsSource = Record_RecordToDispensationList;
                    cbDispensationLink_ID.DisplayMemberPath = "Dispensation_Id";
                    cbDispensationLink_ID.SelectedValuePath = "id";
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
                    DataTable dt = RecordData.SelectAll();
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
            if (headername == "Papers Recieved Date")
            {
                txtCol.Binding.StringFormat = "{0:d}";
            }
            if (headername == "Wedding Date")
            {
                txtCol.Binding.StringFormat = "{0:d}";
            }
            if (headername == "Papers Mailed")
            {
                txtCol.Binding.StringFormat = "{0:d}";
            }
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

                Record clsRecord = new Record();
                clsRecord.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                clsRecord = RecordData.Select_Record(clsRecord);

                if ((clsRecord != null))
                {
                    try
                    {
                        nudRecord_ID.Text = System.Convert.ToInt32(clsRecord.Record_ID).ToString();
                        cbGroom_ID.SelectedValue = System.Convert.ToInt32(clsRecord.Groom_ID);
                        cbBride_ID.SelectedValue = System.Convert.ToInt32(clsRecord.Bride_ID);
                        dtpPapers_Recieved_Date.SelectedDate = System.Convert.ToDateTime(clsRecord.Papers_Recieved_Date);
                        dtpWedding_Date.SelectedDate = System.Convert.ToDateTime(clsRecord.Wedding_Date);
                        dtpPapers_Mailed.SelectedDate = System.Convert.ToDateTime(clsRecord.Papers_Mailed);
                        cbDispensation_Type_ID.SelectedValue = System.Convert.ToInt16(clsRecord.Dispensation_Type_ID);
                        tbAdditional_Circumstances_Note.Text = Convert.ToString(clsRecord.Additional_Circumstances_Note);
                        cbDispensation_ID.SelectedValue = System.Convert.ToInt32(clsRecord.Dispensation_ID);
                        cbCatholic_Party_ID.SelectedValue = System.Convert.ToInt16(clsRecord.Catholic_Party_ID);
                        tbApproved_By.Text = Convert.ToString(clsRecord.Approved_By);
                        tbPapers_Mailed_Note.Text = Convert.ToString(clsRecord.Papers_Mailed_Note);
                        cbPaperwork_Originated_Parish_ID.SelectedValue = System.Convert.ToInt16(clsRecord.Paperwork_Originated_Parish_ID);
                        cbParish_Of_Wedding_Parish_ID.SelectedValue = System.Convert.ToInt16(clsRecord.Parish_Of_Wedding_Parish_ID);
                        cbIs_Parish_Outside_Of_Diocese.IsChecked = System.Convert.ToBoolean(clsRecord.Is_Parish_Outside_Of_Diocese);
                        tbOfficiant_Name.Text = Convert.ToString(clsRecord.Officiant_Name);
                        cbIs_Convalidated.IsChecked = System.Convert.ToBoolean(clsRecord.Is_Convalidated);
                        cbHas_Been_Annulled.IsChecked = System.Convert.ToBoolean(clsRecord.Has_Been_Annulled);
                        cbDispensationLink_ID.SelectedValue = System.Convert.ToInt32(clsRecord.DispensationLink_ID);
                        tbModifiedBy.Text = Convert.ToString(clsRecord.ModifiedBy);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void SetData(Record clsRecord)
        {
            using (new WaitCursor())
            {
                clsRecord.Groom_ID = System.Convert.ToInt32(cbGroom_ID.SelectedValue);
                clsRecord.Bride_ID = System.Convert.ToInt32(cbBride_ID.SelectedValue);
                clsRecord.Papers_Recieved_Date = System.Convert.ToDateTime(dtpPapers_Recieved_Date.Text);
                clsRecord.Wedding_Date = System.Convert.ToDateTime(dtpWedding_Date.Text);
                clsRecord.Papers_Mailed = System.Convert.ToDateTime(dtpPapers_Mailed.Text);
                clsRecord.Dispensation_Type_ID = System.Convert.ToInt16(cbDispensation_Type_ID.SelectedValue);
                clsRecord.Additional_Circumstances_Note = System.Convert.ToString(tbAdditional_Circumstances_Note.Text);
                clsRecord.Dispensation_ID = System.Convert.ToInt32(cbDispensation_ID.SelectedValue);
                clsRecord.Catholic_Party_ID = System.Convert.ToInt16(cbCatholic_Party_ID.SelectedValue);
                clsRecord.Approved_By = System.Convert.ToString(tbApproved_By.Text);
                clsRecord.Papers_Mailed_Note = System.Convert.ToString(tbPapers_Mailed_Note.Text);
                clsRecord.Paperwork_Originated_Parish_ID = System.Convert.ToInt16(cbPaperwork_Originated_Parish_ID.SelectedValue);
                clsRecord.Parish_Of_Wedding_Parish_ID = System.Convert.ToInt16(cbParish_Of_Wedding_Parish_ID.SelectedValue);
                clsRecord.Is_Parish_Outside_Of_Diocese = System.Convert.ToBoolean(System.Convert.ToBoolean(cbIs_Parish_Outside_Of_Diocese.IsChecked) ? true : false);
                clsRecord.Officiant_Name = System.Convert.ToString(tbOfficiant_Name.Text);
                clsRecord.Is_Convalidated = System.Convert.ToBoolean(System.Convert.ToBoolean(cbIs_Convalidated.IsChecked) ? true : false);
                clsRecord.Has_Been_Annulled = System.Convert.ToBoolean(System.Convert.ToBoolean(cbHas_Been_Annulled.IsChecked) ? true : false);
                clsRecord.DispensationLink_ID = System.Convert.ToInt32(cbDispensationLink_ID.SelectedValue);
                clsRecord.ModifiedBy = System.Convert.ToString(tbModifiedBy.Text);
            }
        }

        private void Add()
        {
            this.AddMode = true;
            this.EditMode = false;
            this.DeleteMode = false;

            ClearRecord();
            IsReadOnlyRecord(true);
            cbGroom_ID.Focus();
            nudRecord_ID.Text = System.Convert.ToString(clsMarriageData.getAutoID("New", "Record"));
        }

        private void Edit()
        {
            AddMode = false;
            EditMode = true;
            DeleteMode = false;

            GetData();

            IsReadOnlyRecord(true);
            cbGroom_ID.Focus();
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
            cbGroom_ID.IsEnabled = YesNo;
            cbBride_ID.IsEnabled = YesNo;
            dtpPapers_Recieved_Date.IsEnabled = YesNo;
            dtpWedding_Date.IsEnabled = YesNo;
            dtpPapers_Mailed.IsEnabled = YesNo;
            cbDispensation_Type_ID.IsEnabled = YesNo;
            tbAdditional_Circumstances_Note.IsEnabled = YesNo;
            cbDispensation_ID.IsEnabled = YesNo;
            cbCatholic_Party_ID.IsEnabled = YesNo;
            tbApproved_By.IsEnabled = YesNo;
            tbPapers_Mailed_Note.IsEnabled = YesNo;
            cbPaperwork_Originated_Parish_ID.IsEnabled = YesNo;
            cbParish_Of_Wedding_Parish_ID.IsEnabled = YesNo;
            cbIs_Parish_Outside_Of_Diocese.IsEnabled = YesNo;
            tbOfficiant_Name.IsEnabled = YesNo;
            cbIs_Convalidated.IsEnabled = YesNo;
            cbHas_Been_Annulled.IsEnabled = YesNo;
            cbDispensationLink_ID.IsEnabled = YesNo;
            tbModifiedBy.IsEnabled = YesNo;
        }

        private void ClearRecord()
        {
            nudRecord_ID.Text = "0";
            cbGroom_ID.SelectedIndex = -1;
            cbBride_ID.SelectedIndex = -1;
            dtpPapers_Recieved_Date.Text = null;
            dtpWedding_Date.Text = null;
            dtpPapers_Mailed.Text = null;
            cbDispensation_Type_ID.SelectedIndex = -1;
            tbAdditional_Circumstances_Note.Text = null;
            cbDispensation_ID.SelectedIndex = -1;
            cbCatholic_Party_ID.SelectedIndex = -1;
            tbApproved_By.Text = null;
            tbPapers_Mailed_Note.Text = null;
            cbPaperwork_Originated_Parish_ID.SelectedIndex = -1;
            cbParish_Of_Wedding_Parish_ID.SelectedIndex = -1;
            cbIs_Parish_Outside_Of_Diocese.IsChecked = false;
            tbOfficiant_Name.Text = null;
            cbIs_Convalidated.IsChecked = false;
            cbHas_Been_Annulled.IsChecked = false;
            cbDispensationLink_ID.SelectedIndex = -1;
            tbModifiedBy.Text = null;
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
            Record clsRecord = new Record();
                if (VerifyData() == true) {
                    SetData(clsRecord);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordData.Add(clsRecord);
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
                Record oclsRecord = new Record();
                Record clsRecord = new Record();

                oclsRecord.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                oclsRecord = RecordData.Select_Record(oclsRecord);

                if (VerifyData() == true) {
                    SetData(clsRecord);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordData.Update(oclsRecord, clsRecord);
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
                Record clsRecord = new Record();
                clsRecord.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                if (MessageBox.Show("Are you sure? Delete this record?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    SetData(clsRecord);
                    Boolean bSucess = new Boolean();
                    bSucess = RecordData.Delete(clsRecord);
                    if (bSucess == true) {
                        GoBack_To_Grid(); }
                    else {
                        MessageBox.Show("Delete failed.", "Error"); }
                }
            }
        }  

        private Boolean VerifyData()
        {
            if (cbGroom_ID.SelectedIndex == -1) {
                MessageBox.Show("Groom I D is Required", "Error");
                cbGroom_ID.Focus();
                return false;}          
            if (cbBride_ID.SelectedIndex == -1) {
                MessageBox.Show("Bride I D is Required", "Error");
                cbBride_ID.Focus();
                return false;}          
            
            
            
            if (cbDispensation_Type_ID.SelectedIndex == -1) {
                MessageBox.Show("Dispensation Type I D is Required", "Error");
                cbDispensation_Type_ID.Focus();
                return false;}          
            if (tbAdditional_Circumstances_Note.Text == "") {
                MessageBox.Show("Additional Circumstances Note is Required", "Error");
                tbAdditional_Circumstances_Note.Focus();
                return false;}
            if (cbDispensation_ID.SelectedIndex == -1) {
                MessageBox.Show("Dispensation I D is Required", "Error");
                cbDispensation_ID.Focus();
                return false;}          
            if (cbCatholic_Party_ID.SelectedIndex == -1) {
                MessageBox.Show("Catholic Party I D is Required", "Error");
                cbCatholic_Party_ID.Focus();
                return false;}          
            if (tbApproved_By.Text == "") {
                MessageBox.Show("Approved By is Required", "Error");
                tbApproved_By.Focus();
                return false;}
            if (tbPapers_Mailed_Note.Text == "") {
                MessageBox.Show("Papers Mailed Note is Required", "Error");
                tbPapers_Mailed_Note.Focus();
                return false;}
            if (cbPaperwork_Originated_Parish_ID.SelectedIndex == -1) {
                MessageBox.Show("Paperwork Originated Parish I D is Required", "Error");
                cbPaperwork_Originated_Parish_ID.Focus();
                return false;}          
            if (cbParish_Of_Wedding_Parish_ID.SelectedIndex == -1) {
                MessageBox.Show("Parish Of Wedding Parish I D is Required", "Error");
                cbParish_Of_Wedding_Parish_ID.Focus();
                return false;}          
            
            if (tbOfficiant_Name.Text == "") {
                MessageBox.Show("Officiant Name is Required", "Error");
                tbOfficiant_Name.Focus();
                return false;}
            
            
            if (cbDispensationLink_ID.SelectedIndex == -1) {
                MessageBox.Show("Dispensation Link I D is Required", "Error");
                cbDispensationLink_ID.Focus();
                return false;}          
            if (tbModifiedBy.Text == "") {
                MessageBox.Show("Modified By is Required", "Error");
                tbModifiedBy.Focus();
                return false;}
            return true;
        }

        private void nudRecord_ID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToPdf("One", 
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiExcel.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("Many", 
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("One", 
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiWord.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToWord("Many", 
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToWord("One", 
                                                     "Dbo. Record", Grid, (DataRowView)Grid.CurrentItem, Row);
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
                    DataTable dt = RecordData.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text);
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





 
