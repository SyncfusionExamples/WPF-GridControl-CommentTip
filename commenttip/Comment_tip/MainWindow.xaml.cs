using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Comment_tip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable;
        Random random;
        GridControl grid;
        public MainWindow()
        {
            InitializeComponent();
            Width = 1000;
            Height = 600;
            this.LoadData();
            grid = new GridControl();
            grid.Width = 700;
            grid.Height = 400;
            //grid.Model.HeaderStyle.Background = Brushes.White;
            grid.Model.HeaderStyle.Borders.All = new System.Windows.Media.Pen(System.Windows.Media.Brushes.LightGray, 1);
            grid.Model.RowCount = dataTable.Rows.Count;
            grid.Model.ColumnCount = dataTable.Columns.Count;
            grid.Model.RowHeights.DefaultLineSize = 30;
            grid.Model.ColumnWidths.DefaultLineSize = 115;
            grid.Model.ColumnWidths[0] = 115;
            GridCommentService.SetShowComment(grid, true);
            grid.QueryCellInfo += Grid_QueryCellInfo;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            grid.CellCommentOpening += Grid_CellCommentOpening;
            GridCommentStyleInfo styleInfo = new GridCommentStyleInfo();


            //Add CommentTip for specific cell
            if (grid.Model[1, 2].RowIndex == 1 && grid.Model[1, 2].ColumnIndex == 2)
            {
                styleInfo.TopLeftCommentBrush = Brushes.Red;
                styleInfo.TopLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, 2].ColumnIndex + " is " + grid.Model[1, 2].CellValue;
                //styleInfo.ResetTopLeftComment();
                //styleInfo.TopLeftCommentTemplateKey = "TopLeftCommentTemplate";
                grid.Model[1, 2].GridCommentStyleInfo = styleInfo;
            }

            //Set CommentTip for specific row or column or cell
            for (int i = 1; i <= 4; i++)
            {
                //Set comment tip for specific row                
                if (grid.Model[1, i].RowIndex == 1 && grid.Model[1, i].ColumnIndex > 0)
                {
                    styleInfo.TopLeftCommentBrush = Brushes.Red;
                    styleInfo.TopLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, i].ColumnIndex + " is " + grid.Model[1, i].CellValue;
                    grid.Model[1, i].GridCommentStyleInfo = styleInfo;
                }
            }

            //Set comment tip for specific column
            for (int i = 1; i < 4; i++)
            {
                if (grid.Model[i, 2].ColumnIndex == 2 && grid.Model[i, 2].RowIndex > 0)
                {
                    styleInfo.TopLeftCommentBrush = Brushes.Red;
                    styleInfo.TopLeftComment = grid.Model[i, 0].CellValue + ": \nPopulation rate in " + grid.Model[i, 2].RowIndex + " is " + grid.Model[i, 2].CellValue;
                    grid.Model[i, 2].GridCommentStyleInfo = styleInfo;
                }
            }


            //////BottomCellComment
            ////Set CommentTip for specific cell
            //if (grid.Model[1, 2].RowIndex == 1 && grid.Model[1, 2].ColumnIndex == 2)
            //{
            //    styleInfo.BottomLeftCommentBrush = Brushes.Purple;
            //    styleInfo.BottomLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, 2].ColumnIndex + " is " + grid.Model[1, 2].CellValue;
            //    //styleInfo.ResetTopLeftComment();
            //    //styleInfo.TopLeftCommentTemplateKey = "TopLeftCommentTemplate";
            //    grid.Model[1, 2].GridCommentStyleInfo = styleInfo;
            //}

            ////Set CommentTip for specific row or column or cell
            //for (int i = 1; i <= 4; i++)
            //{
            //    //Set comment tip for specific row                
            //    if (grid.Model[1, i].RowIndex == 1 && grid.Model[1, i].ColumnIndex > 0)
            //    {
            //        styleInfo.BottomLeftCommentBrush = Brushes.Purple;
            //        styleInfo.BottomLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, i].ColumnIndex + " is " + grid.Model[1, i].CellValue; 
            //        grid.Model[1, i].GridCommentStyleInfo = styleInfo;
            //    }
            //}

            ////Set comment tip for specific column
            //for (int i = 1; i < 4; i++)
            //{
            //    if (grid.Model[i, 2].ColumnIndex == 2 && grid.Model[i, 2].RowIndex > 0)
            //    {
            //        styleInfo.BottomLeftCommentBrush = Brushes.Purple;
            //        styleInfo.BottomLeftComment = grid.Model[i, 0].CellValue + ": \nPopulation rate in " + grid.Model[i, 2].RowIndex + " is " + grid.Model[i, 2].CellValue; 
            //        grid.Model[i, 2].GridCommentStyleInfo = styleInfo;
            //    }
            //}

            gridcontrol.Children.Add(grid);
        }

        private void Grid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            GridCommentStyleInfo gridStyleInfo = new GridCommentStyleInfo();
            if (e.Style.RowIndex == 0 || e.Style.ColumnIndex == 0)
            {
                e.Style.CellType = "DataBoundTemplate";
                e.Style.CellItemTemplateKey = "TextBlockTemplate1";
            }
            if (e.Style.RowIndex == 0)
                e.Style.CellValue = dataTable.Columns[e.Style.ColumnIndex];
            else
                e.Style.CellValue = dataTable.Rows[e.Style.RowIndex][e.Style.ColumnIndex];
        }

        private void Grid_CellCommentOpening(object sender, GridCellCommentOpeningEventArgs e)
        {
            var grids = sender as GridControl;
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 2)
                grids.Model[e.Cell.RowIndex, e.Cell.ColumnIndex].GridCommentStyleInfo.TopLeftComment = "Hello";
        }

        public void LoadData()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Country"));
            dataTable.Columns.Add(new DataColumn("2005"));
            dataTable.Columns.Add(new DataColumn("2006"));
            dataTable.Columns.Add(new DataColumn("2007"));
            dataTable.Columns.Add(new DataColumn("2008"));
            random = new Random();

            var row = dataTable.NewRow();
            row["Country"] = "USA";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "India";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "China";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Japan";
            LoadCellValues(row);
            dataTable.Rows.Add(row);
        }

        public void LoadCellValues(DataRow row)
        {
            for(int i=1;i<=4;i++)
            {
                row[i] = ((double)random.Next(2, 18)).ToString() + "%";
            }
        }
    }
}
