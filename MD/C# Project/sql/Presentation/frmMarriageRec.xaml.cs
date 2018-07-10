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
    public partial class frmMarriageRec : Window
    {
        public frmMarriageRec()
        {
            InitializeComponent();
        }

        private bool AddMode = false;
        private bool EditMode = false;
        private bool DeleteMode = false;
        private int Row = 0;

        MarriageData clsMarriageData = new MarriageData();
        
        private void frmMarriageRec_Loaded(object sender, RoutedEventArgs e)
        {
            cmbFields.Items.Add("Record ID");
            cmbFields.Items.Add("Groom I D");
            cmbFields.Items.Add("Bride I D");
            cmbFields.Items.Add("Papers Recieved Date");
            cmbFields.Items.Add("Wedding Date");
            cmbFields.Items.Add("Papers Mailed");
            cmbFields.Items.Add("Dispensation Type I D");
            cmbFields.Items.Add("Additional Circumstances Note");
            cmbFields.Items.Add("Dispensation I D");
            cmbFields.Items.Add("Catholic Party I D");
            cmbFields.Items.Add("Approved By");
            cmbFields.Items.Add("Papers Mailed Note");
            cmbFields.Items.Add("Paperwork Originated Parish I D");
            cmbFields.Items.Add("Parish Of Wedding Parish I D");
            cmbFields.Items.Add("Is Parish Outside Of Diocese");
            cmbFields.Items.Add("Officiant Name");
            cmbFields.Items.Add("Is Convalidated");
            cmbFields.Items.Add("Has Been Annulled");
            cmbFields.Items.Add("Dispensation Link I D");
            cmbFields.Items.Add("Modified By");
            cmbFields.Items.Add("Bride First Name");
            cmbFields.Items.Add("Bride Middle Int");
            cmbFields.Items.Add("Bride Last Name");
            cmbFields.Items.Add("Groom First Name");
            cmbFields.Items.Add("Groom Middle Int");
            cmbFields.Items.Add("Groom Last Name");

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
            LoadMarriageRec_GroomComboBox21();
            LoadMarriageRec_BrideComboBox22();
            LoadMarriageRec_Dispensation_TypeComboBox26();
            LoadMarriageRec_DispensationComboBox28();
            LoadMarriageRec_Catholic_PartyComboBox29();
            LoadMarriageRec_ParishComboBox32();
            LoadMarriageRec_ParishComboBox33();
            LoadGrid(true);
            tiGrid.IsSelected = true;
        }

        private void LoadMarriageRec_GroomComboBox21()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Groom21> MarriageRec_GroomList = new  List<MarriageRec_Groom21>();
                try
                {
                    MarriageRec_GroomList = MarriageRec_GroomData21.List();
                    cbGroom_ID.ItemsSource = MarriageRec_GroomList;
                    cbGroom_ID.DisplayMemberPath = "Groom_ID";
                    cbGroom_ID.SelectedValuePath = "Groom_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_BrideComboBox22()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Bride22> MarriageRec_BrideList = new  List<MarriageRec_Bride22>();
                try
                {
                    MarriageRec_BrideList = MarriageRec_BrideData22.List();
                    cbBride_ID.ItemsSource = MarriageRec_BrideList;
                    cbBride_ID.DisplayMemberPath = "Bride_ID";
                    cbBride_ID.SelectedValuePath = "Bride_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_Dispensation_TypeComboBox26()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Dispensation_Type26> MarriageRec_Dispensation_TypeList = new  List<MarriageRec_Dispensation_Type26>();
                try
                {
                    MarriageRec_Dispensation_TypeList = MarriageRec_Dispensation_TypeData26.List();
                    cbDispensation_Type_ID.ItemsSource = MarriageRec_Dispensation_TypeList;
                    cbDispensation_Type_ID.DisplayMemberPath = "Dispensation_Type_ID";
                    cbDispensation_Type_ID.SelectedValuePath = "Dispensation_Type_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_DispensationComboBox28()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Dispensation28> MarriageRec_DispensationList = new  List<MarriageRec_Dispensation28>();
                try
                {
                    MarriageRec_DispensationList = MarriageRec_DispensationData28.List();
                    cbDispensation_ID.ItemsSource = MarriageRec_DispensationList;
                    cbDispensation_ID.DisplayMemberPath = "Dispensation_ID";
                    cbDispensation_ID.SelectedValuePath = "Dispensation_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_Catholic_PartyComboBox29()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Catholic_Party29> MarriageRec_Catholic_PartyList = new  List<MarriageRec_Catholic_Party29>();
                try
                {
                    MarriageRec_Catholic_PartyList = MarriageRec_Catholic_PartyData29.List();
                    cbCatholic_Party_ID.ItemsSource = MarriageRec_Catholic_PartyList;
                    cbCatholic_Party_ID.DisplayMemberPath = "Catholic_Party_ID";
                    cbCatholic_Party_ID.SelectedValuePath = "Catholic_Party_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_ParishComboBox32()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Parish32> MarriageRec_ParishList = new  List<MarriageRec_Parish32>();
                try
                {
                    MarriageRec_ParishList = MarriageRec_ParishData32.List();
                    cbPaperwork_Originated_Parish_ID.ItemsSource = MarriageRec_ParishList;
                    cbPaperwork_Originated_Parish_ID.DisplayMemberPath = "Parish_ID";
                    cbPaperwork_Originated_Parish_ID.SelectedValuePath = "Parish_ID";
                }
                catch (System.Exception ex)
                {
                     MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }

        private void LoadMarriageRec_ParishComboBox33()
        {
            using (new WaitCursor())
            {
                List<MarriageRec_Parish33> MarriageRec_ParishList = new  List<MarriageRec_Parish33>();
                try
                {
                    MarriageRec_ParishList = MarriageRec_ParishData33.List();
                    cbParish_Of_Wedding_Parish_ID.ItemsSource = MarriageRec_ParishList;
                    cbParish_Of_Wedding_Parish_ID.DisplayMemberPath = "Parish_ID";
                    cbParish_Of_Wedding_Parish_ID.SelectedValuePath = "Parish_ID";
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
                    DataTable dt = MarriageRecData.SelectAll();
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
            if (headername == "Dispensation Link I D")
            {
                txtCol.Binding.StringFormat = "{0:N0}";
                txtCol.ElementStyle = (System.Windows.Style)Grid.FindResource("rightAlignment");
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

                MarriageRec clsMarriageRec = new MarriageRec();
                clsMarriageRec.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                clsMarriageRec = MarriageRecData.Select_Record(clsMarriageRec);

                if ((clsMarriageRec != null))
                {
                    try
                    {
                        nudRecord_ID.Text = System.Convert.ToInt32(clsMarriageRec.Record_ID).ToString();
                        cbGroom_ID.SelectedValue = System.Convert.ToInt32(clsMarriageRec.Groom_ID);
                        cbBride_ID.SelectedValue = System.Convert.ToInt32(clsMarriageRec.Bride_ID);
                        dtpPapers_Recieved_Date.SelectedDate = System.Convert.ToDateTime(clsMarriageRec.Papers_Recieved_Date);
                        dtpWedding_Date.SelectedDate = System.Convert.ToDateTime(clsMarriageRec.Wedding_Date);
                        dtpPapers_Mailed.SelectedDate = System.Convert.ToDateTime(clsMarriageRec.Papers_Mailed);
                        cbDispensation_Type_ID.SelectedValue = System.Convert.ToInt16(clsMarriageRec.Dispensation_Type_ID);
                        tbAdditional_Circumstances_Note.Text = Convert.ToString(clsMarriageRec.Additional_Circumstances_Note);
                        cbDispensation_ID.SelectedValue = System.Convert.ToInt32(clsMarriageRec.Dispensation_ID);
                        cbCatholic_Party_ID.SelectedValue = System.Convert.ToInt16(clsMarriageRec.Catholic_Party_ID);
                        tbApproved_By.Text = Convert.ToString(clsMarriageRec.Approved_By);
                        tbPapers_Mailed_Note.Text = Convert.ToString(clsMarriageRec.Papers_Mailed_Note);
                        cbPaperwork_Originated_Parish_ID.SelectedValue = System.Convert.ToInt16(clsMarriageRec.Paperwork_Originated_Parish_ID);
                        cbParish_Of_Wedding_Parish_ID.SelectedValue = System.Convert.ToInt16(clsMarriageRec.Parish_Of_Wedding_Parish_ID);
                        cbIs_Parish_Outside_Of_Diocese.IsChecked = System.Convert.ToBoolean(clsMarriageRec.Is_Parish_Outside_Of_Diocese);
                        tbOfficiant_Name.Text = Convert.ToString(clsMarriageRec.Officiant_Name);
                        cbIs_Convalidated.IsChecked = System.Convert.ToBoolean(clsMarriageRec.Is_Convalidated);
                        cbHas_Been_Annulled.IsChecked = System.Convert.ToBoolean(clsMarriageRec.Has_Been_Annulled);
                        nudDispensationLink_ID.Text = System.Convert.ToInt32(clsMarriageRec.DispensationLink_ID).ToString();
                        tbModifiedBy.Text = Convert.ToString(clsMarriageRec.ModifiedBy);
                        tbBride_First_Name.Text = Convert.ToString(clsMarriageRec.Bride_First_Name);
                        tbBride_Middle_Int.Text = Convert.ToString(clsMarriageRec.Bride_Middle_Int);
                        tbBride_Last_Name.Text = Convert.ToString(clsMarriageRec.Bride_Last_Name);
                        tbGroom_First_Name.Text = Convert.ToString(clsMarriageRec.Groom_First_Name);
                        tbGroom_Middle_Int.Text = Convert.ToString(clsMarriageRec.Groom_Middle_Int);
                        tbGroom_Last_Name.Text = Convert.ToString(clsMarriageRec.Groom_Last_Name);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void SetData(MarriageRec clsMarriageRec)
        {
            using (new WaitCursor())
            {
                clsMarriageRec.Groom_ID = System.Convert.ToInt32(cbGroom_ID.SelectedValue);
                clsMarriageRec.Bride_ID = System.Convert.ToInt32(cbBride_ID.SelectedValue);
                clsMarriageRec.Papers_Recieved_Date = System.Convert.ToDateTime(dtpPapers_Recieved_Date.Text);
                clsMarriageRec.Wedding_Date = System.Convert.ToDateTime(dtpWedding_Date.Text);
                clsMarriageRec.Papers_Mailed = System.Convert.ToDateTime(dtpPapers_Mailed.Text);
                clsMarriageRec.Dispensation_Type_ID = System.Convert.ToInt16(cbDispensation_Type_ID.SelectedValue);
                clsMarriageRec.Additional_Circumstances_Note = System.Convert.ToString(tbAdditional_Circumstances_Note.Text);
                clsMarriageRec.Dispensation_ID = System.Convert.ToInt32(cbDispensation_ID.SelectedValue);
                clsMarriageRec.Catholic_Party_ID = System.Convert.ToInt16(cbCatholic_Party_ID.SelectedValue);
                clsMarriageRec.Approved_By = System.Convert.ToString(tbApproved_By.Text);
                clsMarriageRec.Papers_Mailed_Note = System.Convert.ToString(tbPapers_Mailed_Note.Text);
                clsMarriageRec.Paperwork_Originated_Parish_ID = System.Convert.ToInt16(cbPaperwork_Originated_Parish_ID.SelectedValue);
                clsMarriageRec.Parish_Of_Wedding_Parish_ID = System.Convert.ToInt16(cbParish_Of_Wedding_Parish_ID.SelectedValue);
                clsMarriageRec.Is_Parish_Outside_Of_Diocese = System.Convert.ToBoolean(System.Convert.ToBoolean(cbIs_Parish_Outside_Of_Diocese.IsChecked) ? true : false);
                clsMarriageRec.Officiant_Name = System.Convert.ToString(tbOfficiant_Name.Text);
                clsMarriageRec.Is_Convalidated = System.Convert.ToBoolean(System.Convert.ToBoolean(cbIs_Convalidated.IsChecked) ? true : false);
                clsMarriageRec.Has_Been_Annulled = System.Convert.ToBoolean(System.Convert.ToBoolean(cbHas_Been_Annulled.IsChecked) ? true : false);
                clsMarriageRec.DispensationLink_ID = System.Convert.ToInt32(nudDispensationLink_ID.Text);
                clsMarriageRec.ModifiedBy = System.Convert.ToString(tbModifiedBy.Text);
                clsMarriageRec.Bride_First_Name = System.Convert.ToString(tbBride_First_Name.Text);
                clsMarriageRec.Bride_Middle_Int = System.Convert.ToString(tbBride_Middle_Int.Text);
                clsMarriageRec.Bride_Last_Name = System.Convert.ToString(tbBride_Last_Name.Text);
                clsMarriageRec.Groom_First_Name = System.Convert.ToString(tbGroom_First_Name.Text);
                clsMarriageRec.Groom_Middle_Int = System.Convert.ToString(tbGroom_Middle_Int.Text);
                clsMarriageRec.Groom_Last_Name = System.Convert.ToString(tbGroom_Last_Name.Text);
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
            nudRecord_ID.Text = System.Convert.ToString(clsMarriageData.getAutoID("New", "MarriageRec"));
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
            nudDispensationLink_ID.IsEnabled = YesNo;
            tbModifiedBy.IsEnabled = YesNo;
            tbBride_First_Name.IsEnabled = YesNo;
            tbBride_Middle_Int.IsEnabled = YesNo;
            tbBride_Last_Name.IsEnabled = YesNo;
            tbGroom_First_Name.IsEnabled = YesNo;
            tbGroom_Middle_Int.IsEnabled = YesNo;
            tbGroom_Last_Name.IsEnabled = YesNo;
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
            nudDispensationLink_ID.Text = "0";
            tbModifiedBy.Text = null;
            tbBride_First_Name.Text = null;
            tbBride_Middle_Int.Text = null;
            tbBride_Last_Name.Text = null;
            tbGroom_First_Name.Text = null;
            tbGroom_Middle_Int.Text = null;
            tbGroom_Last_Name.Text = null;
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
            MarriageRec clsMarriageRec = new MarriageRec();
                if (VerifyData() == true) {
                    SetData(clsMarriageRec);
                    Boolean bSucess = new Boolean();
                    bSucess = MarriageRecData.Add(clsMarriageRec);
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
                MarriageRec oclsMarriageRec = new MarriageRec();
                MarriageRec clsMarriageRec = new MarriageRec();

                oclsMarriageRec.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                oclsMarriageRec = MarriageRecData.Select_Record(oclsMarriageRec);

                if (VerifyData() == true) {
                    SetData(clsMarriageRec);
                    Boolean bSucess = new Boolean();
                    bSucess = MarriageRecData.Update(oclsMarriageRec, clsMarriageRec);
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
                MarriageRec clsMarriageRec = new MarriageRec();
                clsMarriageRec.Record_ID = System.Convert.ToInt32((Grid.SelectedCells[0].Column.GetCellContent(Grid.SelectedItem) as TextBlock).Text);
                if (MessageBox.Show("Are you sure? Delete this record?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    SetData(clsMarriageRec);
                    Boolean bSucess = new Boolean();
                    bSucess = MarriageRecData.Delete(clsMarriageRec);
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
            
            
            if (nudDispensationLink_ID.Text == "") {
                MessageBox.Show("Dispensation Link I D is Required", "Error");
                nudDispensationLink_ID.Focus();
                return false;}
            if (tbModifiedBy.Text == "") {
                MessageBox.Show("Modified By is Required", "Error");
                tbModifiedBy.Focus();
                return false;}
            if (tbBride_First_Name.Text == "") {
                MessageBox.Show("Bride First Name is Required", "Error");
                tbBride_First_Name.Focus();
                return false;}
            if (tbBride_Middle_Int.Text == "") {
                MessageBox.Show("Bride Middle Int is Required", "Error");
                tbBride_Middle_Int.Focus();
                return false;}
            if (tbBride_Last_Name.Text == "") {
                MessageBox.Show("Bride Last Name is Required", "Error");
                tbBride_Last_Name.Focus();
                return false;}
            if (tbGroom_First_Name.Text == "") {
                MessageBox.Show("Groom First Name is Required", "Error");
                tbGroom_First_Name.Focus();
                return false;}
            if (tbGroom_Middle_Int.Text == "") {
                MessageBox.Show("Groom Middle Int is Required", "Error");
                tbGroom_Middle_Int.Focus();
                return false;}
            if (tbGroom_Last_Name.Text == "") {
                MessageBox.Show("Groom Last Name is Required", "Error");
                tbGroom_Last_Name.Focus();
                return false;}
            return true;
        }

        private void nudRecord_ID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(Convert.ToChar(e.Text)))
                e.Handled = true;
        }

        private void nudDispensationLink_ID_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToPdf("One", 
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiExcel.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("Many", 
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToExcel("One", 
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                    }
                    else if (cbiWord.IsSelected == true)
                    {
                        if (tiGrid.IsSelected)
                        {
                            clsMarriageData.ExportToWord("Many", 
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
                        }
                        else if (tiDetail.IsSelected)
                        {
                            clsMarriageData.ExportToWord("One", 
                                                     "Dbo. Marriage Rec", Grid, (DataRowView)Grid.CurrentItem, Row);
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
                    DataTable dt = MarriageRecData.Search(cmbFields.Text, cmbCondition.Text, txtSearch.Text);
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





 
