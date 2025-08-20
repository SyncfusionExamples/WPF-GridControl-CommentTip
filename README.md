# WPF-GridControl-CommentTip

This repository contains the sample which shows the comment tip to a specific cell or row or column in [WPF GridControl](https://help.syncfusion.com/wpf/gridcontrol/overview).

### Comment Tip for row and column

The Comment tip can be added to specific row or column by setting the [Comment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridStyleInfo_Comment) property. The comment indicator will be shown at the top right corner of the cell.

``` csharp
//Adding comment tip to the specific row
grid.Model.RowStyles[1].Comment = "Hello";
//Adding comment tip to the specific column
grid.Model.ColStyles[2].Comment = "Hello";
```

### Change comment indicator position

Setting `Comment` property always displays comment indicator at top right corner of the cell. You can change the comment indicator position for a specific cell by using [GridCommentStyleInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html). For example, you can set the comment indicator at top position for any cell by setting [GridCommentStyleInfo.TopLeftComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopLeftComment) or [GridCommentStyleInfo.TopRightComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopRightComment) properties.

``` csharp
GridCommentStyleInfo styleInfo = new GridCommentStyleInfo();

// set the comment for specific cell
grid.Model[1, 2].GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
grid.Model[1, 2].GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
grid.Model[1, 2].GridCommentStyleInfo.TopLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, 2].ColumnIndex + " is " + grid.Model[1, 2].CellValue;

//Set comment tip for specific row
for (int i = 1; i <= 4; i++)
{
    //Set comment tip for specific row
    if (grid.Model[1, i].RowIndex == 1 && grid.Model[1, i].ColumnIndex > 0)
    {
        grid.Model[1, i].GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
        grid.Model[1, i].GridCommentStyleInfo.TopLeftComment = grid.Model[1, 0].CellValue + ": \nPopulation rate in " + grid.Model[1, i].ColumnIndex + " is " + grid.Model[1, i].CellValue;
    }
}

//Set comment tip for specific column
for (int i = 1; i < 4; i++)
{
    if (grid.Model[i, 2].ColumnIndex == 2 && grid.Model[i, 2].RowIndex > 0)
    {
        grid.Model[i, 2].GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
        grid.Model[i, 2].GridCommentStyleInfo.TopLeftComment = grid.Model[i, 0].CellValue + ": \nPopulation rate in " + grid.Model[i, 2].RowIndex + " is " + grid.Model[i, 2].CellValue;
    }
}
```

### Set CommentTip using QueryCellInfo

You can set the comment tip to a specific cell or row or column by using [QueryCellInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_QueryCellInfo) event.

``` csharp
private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
{
    GridCommentStyleInfo gridStyleInfo = new GridCommentStyleInfo();

    //Set comment tip for specific cell
    if (e.Style.RowIndex == 1 && e.Style.ColumnIndex == 2)
    {
        e.Style.GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
        e.Style.GridCommentStyleInfo.TopLeftComment = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
    }

    //set comment tip for specific row
    if (e.Style.RowIndex == 1 && e.Style.ColumnIndex > 0)
    {
        e.Style.GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
        e.Style.GridCommentStyleInfo.TopLeftComment = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
    }

    //Set comment tip for specific column
    if (e.Style.ColumnIndex == 2)
    {
        e.Style.GridCommentStyleInfo.TopLeftCommentBrush = Brushes.Red;
        e.Style.GridCommentStyleInfo.TopLeftComment = e.Style.GridModel[e.Style.RowIndex, 0].CellValue + ": \nPopulation rate in " + e.Style.RowIndex + " is " + e.Style.CellValue.ToString();
    }
}
```

### Customize the CommentTip

The comment tip appearance can be customized by defining DataTemplate. The DataTemplate can be assigned to [GridStyleInfo.CommentTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridStyleInfo_CommentTemplateKey). If you are using [TopLeftComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopLeftComment), [TopRightComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopRightComment), [BottomRightComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_BottomRightComment), or [BottomLeftComment](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_BottomLeftComment) then you need to assign template to its corresponding template key property namely [GridCommentStyleInfo.TopLeftCommentTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopLeftCommentTemplateKey), [GridCommentStyleInfo.TopRightCommentTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_TopRightCommentTemplateKey), [GridCommentStyleInfo.BottomLeftCommentTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_BottomLeftCommentTemplateKey) or [GridCommentStyleInfo.BottomRightCommentTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridCommentStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridCommentStyleInfo_BottomRightCommentTemplateKey).

GridStyleInfo which holds cell information is the DataContext for data template of comment.

In the below code TopLeft comment is customized.

#### XAML

``` xml
<Window.Resources>
    <DataTemplate x:Key="TopLeftComment">
        <Border x:Name="border" BorderThickness="1" BorderBrush="DarkBlue">
            <TextBlock Background="Purple" Foreground="White" FontSize="14" FontStyle="Italic" Text="{Binding Comment}" />
        </Border>
    </DataTemplate>
</Window.Resources>
```

#### C#

``` csharp
//Assign the template to TopLeftCommentTemplateKey
grid.Model[1, 2].GridCommentStyleInfo.TopLeftCommentTemplateKey = "TopLeftComment";

//Using QueryCellInfo event
 private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
{            
    if (e.Style.RowIndex == 1 && e.Style.ColumnIndex == 2)
    {
        //Assign the template to TopLeftCommentTemplateKey
        e.Style.GridCommentStyleInfo.TopLeftCommentTemplateKey = "TopLeftComment";
    }
}
```

![alt text](Customize_the_CommentTip.png)