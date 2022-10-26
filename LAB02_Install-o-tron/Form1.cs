//name: Wonhyuk Cho
//submission code :  1211_2300_L02
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LAB02_Install_o_tron
{
    public partial class Form1 : Form
    {
        enum algorithm {eRawList, eLibraryList, eSortedList, eHashset };
        algorithm currnetAlgorthm = algorithm.eRawList;
        BindingSource bs = new BindingSource();
        List<Package> _listAllPkg = new List<Package>();
        List<Package> _listInstall = new List<Package>();
        List<Package> _listUninstall = new List<Package>();
        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            this.Text = "LAB02 Install o Tron";
          
            
            UI_tool_load.Click += UI_tool_load_Click;
            UI_btn_analize.Click += UI_btn_analize_Click;

            UI_lbl_drag.AllowDrop = true;
            UI_lbl_drag.DragEnter += UI_lbl_drag_DragEnter;
            UI_lbl_drag.DragDrop += UI_lbl_drag_DragDrop;

            UI_cBox_package.SelectedIndexChanged += UI_cBox_package_SelectedIndexChanged;
            UI_cBox_Raw.SelectedIndexChanged += UI_cBox_Raw_SelectedIndexChanged;

            UI_dataGridView.ColumnHeaderMouseClick += UI_dataGridView_ColumnHeaderMouseClick;

            UI_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //add items in access
            UI_cBox_Raw.Items.Add("Raw Access");
            UI_cBox_Raw.Items.Add("Library Helpers");
            UI_cBox_Raw.Items.Add("Binary Search");
            UI_cBox_Raw.Items.Add("Hashset");
            UI_cBox_Raw.SelectedIndex = 0;
            UI_cBox_Raw.SelectedItem = UI_cBox_Raw.SelectedIndex;
            //package items
            UI_cBox_package.Items.Add("All Packages(Load)");
            UI_cBox_package.Items.Add("Loadable Packages");
            UI_cBox_package.Items.Add("Unloadable Packages");
            UI_cBox_package.SelectedIndex = 0;
            UI_cBox_package.SelectedItem = UI_cBox_package.SelectedIndex;
            ShowSelectedLoad();
           
        }

        private void UI_dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*       if (e.ColumnIndex.Equals(0))
                   {
                          _listAllPkg.Sort();
                       _listInstall.Sort();
                       _listUninstall.Sort();
                   }
                   else if (e.ColumnIndex.Equals(1))
                   {
                       _listInstall.Sort(Package.CompareCount);
                       _listInstall.Sort(Package.CompareCount);
                       _listUninstall.Sort(Package.CompareCount);
                   }
                   else if (e.ColumnIndex.Equals(2))
                   {
                       _listInstall.Sort(Package.CompareCountName);
                       _listInstall.Sort(Package.CompareCountName);
                       _listUninstall.Sort(Package.CompareCountName);
                   }*/
            switch (e.ColumnIndex)
            {
                case 0:
                    _listAllPkg.Sort();
                    _listInstall.Sort();
                    _listUninstall.Sort();
                    break;
                case 1:
                    _listAllPkg.Sort(Package.CompareCount);
                    _listInstall.Sort(Package.CompareCount);
                    _listUninstall.Sort(Package.CompareCount);
                    break;
                case 2:
                    _listAllPkg.Sort(Package.CompareCountName);
                    _listInstall.Sort(Package.CompareCountName);
                    _listUninstall.Sort(Package.CompareCountName);
                    break;
                default:
                    break;

            }
            ShowSelectedLoad();
            
        }

        private void UI_cBox_Raw_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UI_cBox_Raw.SelectedIndex)
            {
                case 0: currnetAlgorthm = algorithm.eRawList; break;
                case 1: currnetAlgorthm = algorithm.eLibraryList; break;
                case 2: currnetAlgorthm = algorithm.eSortedList; break;
            
            }

        }

        private void UI_cBox_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedLoad();
        }

        private void UI_btn_analize_Click(object sender, EventArgs e)
        {
            if (_listAllPkg.Count <= 0) return;
            _listInstall.Clear();
            _listUninstall.Clear();

            sw.Restart();
            switch (currnetAlgorthm)
            {
                case algorithm.eRawList: AnalyzeRawList(_listAllPkg); break;
                case algorithm.eLibraryList: AnalyzeLibraryList(_listAllPkg); break;
                case algorithm.eSortedList: AnalyzeSortList(_listAllPkg); break;
                default: break;
            }
            sw.Stop();
            UI_cBox_package.SelectedIndex = 1;
            UI_cBox_package.SelectedItem = UI_cBox_package.SelectedIndex;
            ShowSelectedLoad();
            UI_analzeTime.Text = $"Analyze Time{Math.Round(sw.Elapsed.TotalSeconds, 4)} seconds";
            statusStrip1.Refresh();


        }
        private void AnalyzeSortList(List<Package> _listAll)
        {
            List<Package> temp = new List<Package>(_listAll);
            bool run = true;
            _listInstall.Sort();
            _listUninstall = new List<Package>(_listAll);
            while (run)
            {
                run = false;
                foreach(Package p in temp.ToList())
                {
                    if(p.Count.Equals(0)||p.GetDepends().TrueForAll((d)=>_listInstall.BinarySearch(new Package(d))>=0))
                    {
                        _listInstall.Insert(_listInstall.BinarySearch(p), p);
                        temp.Remove(p);
                        _listUninstall.Remove(p);
                        run = true;
                    }
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_listAll"></param>
        private void AnalyzeLibraryList(List<Package> _listAll)
        {
            List<Package> temp = new List<Package>(_listAll);
            bool run = true;
            while (run)
            {
                run = false;
                foreach(Package p in temp.ToList())
                {
                    if(p.Count.Equals(0) || p.GetDepends().TrueForAll((d)=>_listInstall.Contains(new Package(d))))
                    {
                        _listInstall.Add(p);
                        temp.Remove(p);
                        _listUninstall.Remove(p);
                        run = true;
                    }
                }
            }
        }
        private void AnalyzeRawList(List<Package> _listAll)
        { 
            _listUninstall = new List<Package>(_listAll);
            List<Package> tempList = new List<Package>(_listAll);
            List<Package> forForeachList = new List<Package>(tempList);
            bool run = true;
            
            while (run)
            {
                run = false;
                foreach(Package p in forForeachList)
                {
                    if (b_Installable(p))
                    {
                        run = true;
                        _listInstall.Add(p);
                        tempList.Remove(p);
                        _listUninstall.Remove(p);
                        forForeachList = new List<Package>(tempList);
                    }
                }
            }
                
        }
        /// <summary>
        /// Returns whether the package is installable or not.
        /// It compares its dependcy count with number of its dependencies in installed list.
        /// If those two numbers are same return true else false.
        /// </summary>
        /// <param name="p"></param> package being tested
        /// <returns></returns>
        private bool b_Installable(Package p)
        {
            // if its dependency count is 0, return true,
            //  since there is not dependency to check
            if (p.Count.Equals(0))
                return true;

            // stores its dependencies
            List<string> pDependencies = p.GetDepends();

            // used to count number of dependencies in the installed list
            int count = 0;

            // goes through every packages in installed list
            for (int i = 0; i < _listInstall.Count; ++i)
            {
                // goes through every packages in its dependency
                for (int j = 0; j < pDependencies.Count; ++j)
                {
                    // if their name are equal
                    if (_listInstall[i].Name.Equals(pDependencies[j]))
                    {
                        // increase count by one then break out of the loop
                        count++;
                        break;
                    }
                }
            }

            // return "is the count same as its dependency count?"
            return count.Equals(pDependencies.Count);
        }


        /// <summary>
        /// private void UI_lbl_drag_DragDrop(object sender, DragEventArgs e)
        /// – Implement drag/drop functionality. Ensure only a single file has been dropped, if
        /// //  not return. Otherwise invoke LoadFile().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_lbl_drag_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length != 1) return;

         
            foreach(string s in files)
            {

                LoadFile(s);
               ShowSelectedLoad();
            }

        }

        private void UI_lbl_drag_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        ///  private void UI_tool_load_Click(object sender, EventArgs e)
        ///  Retrieve ( OpenFileDialog, filtered to .txt and all, open in the project folder ) a file from the
        ///  // user.If one is not selected, return. Otherwise invoke LoadFile().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void UI_tool_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            _listInstall.Clear();
            _listUninstall.Clear();
            string path = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..");
            ofg.InitialDirectory = path;
            ofg.Filter = "Text|*.txt| All Files|*.*";
            ofg.Title = "Load Packages";
            // ofg.InitialDirectory = Environment.SpecialFolder.

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!Path.GetExtension(ofg.FileName).Equals(".txt")) return;
                    //string[] temp = File.ReadAllLines(ofg.FileName);
                    this.Text = $"{ofg.SafeFileName}";
                    LoadFile(ofg.FileName);
                    ShowSelectedLoad();
                }
                catch { throw new ArgumentException("Invalid file has opened"); }

            }
            else
                return;
        }
        /// <summary>
        ///   private void LoadFile(string[] temp)
        ///  open the file and extracting line by line, parse it ( Split()). The first string will be the package
        // name, all remaining strings represent the dependencies of this package.This Split() result can be used
        //to create a Package object. If this package does not yet exist in the the Loaded list, add it, otherwise it
        //must already exists so append the [additional] dependencies via MergePackage() helper method.
        //Repeat until the file is depleted.Set the Combo to the[All Packages] selection and fire your helper
        //function to display the contents of the loaded collection.
        /// </summary>
        /// <param name="temp"></param>
        private void LoadFile(string s)
        {
            string[] temp = File.ReadAllLines(s);
            List<string[]> first = new List<string[]>();
           _listAllPkg.Clear();
            // fill the list of array of string with empty to prevent error
            for (int i = 0; i < temp.Length; ++i)
            {

                first.Add( "".Split(' '));
            }
            for (int i = 0; i < temp.Length; ++i)
            {
                first[i] = temp[i].TrimEnd(' ').Split(' ');
            }
            for (int i = 0; i < first.Count; ++i)
            {
                Package p = new Package(first[i]);
                if (!_listAllPkg.Contains(p))
                    _listAllPkg.Add(p);
                else
                {
                    _listAllPkg.Find((pkg) => pkg.Equals(p)).MergePackage(p);

                }
            }
           // ShowSelectedLoad();
             Console.WriteLine("dragdropped");
             Console.WriteLine("clicked");
        }
        /// <summary>
        ///  determine the combobox selection, and display the contents of the selected
        //collection in the DataGridView.This is performed by setting your BindingSource DataSource to null,
        //then immediately reassigning it the package collection to be displayed, then invoke
        //AutoSizeColumns(); on your DataGridView.Also update all three status strip labels with their respective
        //data[All], [Loadable],[Unloadable]. Since duplicate code is not encouraged, use a switch/if/else
        //construct to assign a working collection reference that is singularly used to complete the output
        //operation.The DataGridView will interrogate the collection, automatically creating columns for all
        //public properties
        /// </summary>
        private void ShowSelectedLoad()
        {
            bs.DataSource = null;

            switch (UI_cBox_package.SelectedIndex)
            {
                case 0: bs.DataSource = _listAllPkg;    break;
                case 1: bs.DataSource = _listInstall;   break;
                case 2: bs.DataSource = _listUninstall; break;

            }
            // set data grid view's data source accordingly
            // initialize cell modes
            UI_dataGridView.DataSource = bs;
            UI_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UI_dataGridView.Columns[UI_dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            UI_sLbl_load.Text = $"{_listAllPkg.Count} Packages Loaded";
            UI_lbl_install.Text = $"{_listInstall.Count} Packages Installable";
            UI_cLbl_uninstall.Text = $"{_listUninstall.Count} Packaes Uninstallable";
            UI_analzeTime.Text = $"Analyze Time <Not Run>";
        }
    }
}
