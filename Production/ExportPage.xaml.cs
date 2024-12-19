using Microsoft.Office.Interop.Word;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Page = System.Windows.Controls.Page;

namespace Production
{
    /// <summary>
    /// Логика взаимодействия для ExportPage.xaml
    /// </summary>
    public partial class ExportPage : Page
    {
        public ExportPage()
        {
            InitializeComponent();
        }

        private void btnExportSE_Click(object sender, RoutedEventArgs e)
        {
            var NameS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.НаименПоставщ).ToList();
            var TypeS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.Тип).ToList();
            var INNS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.ИНН).ToList();
            var ReitingS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.РейтингКачества).ToList();
            var DataNachS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.ДатаНачалаРаб).ToList();

            var application = new Excel.Application();
            application.SheetsInNewWorkbook = NameS.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);


            for (int i = 0; i < NameS.Count; i++)
            {
                int startRowIndex = 1;

                Excel.Worksheet workxheet = application.Worksheets.Item[i + 1];
                workxheet.Name = NameS[i].ToString();

                workxheet.Cells[1][startRowIndex] = "Имя поставщика";
                workxheet.Cells[2][startRowIndex] = "Тип";
                workxheet.Cells[3][startRowIndex] = "ИНН";
                workxheet.Cells[4][startRowIndex] = "Рейтинг качества";
                workxheet.Cells[5][startRowIndex] = "Дата начала работы";
                workxheet.Cells[6][startRowIndex] = "Поставляемые материалы";        
                
                workxheet.Cells[1][2] = NameS[i];
                workxheet.Cells[2][2] = TypeS[i];
                workxheet.Cells[3][2] = INNS[i];
                workxheet.Cells[4][2] = ReitingS[i];
                workxheet.Cells[5][2] = DataNachS[i];
                foreach (var supplier in Production_of_productsEntities2.GetContext().Поставщики.ToList())
                    if (supplier.НаименПоставщ == NameS[i])
                        workxheet.Cells[6][2] = supplier.ВсеМатериалы;
                workxheet.Columns.AutoFit();
            }
            application.Visible = true;
        }

        private void btnExportSW_Click(object sender, RoutedEventArgs e)
        {
            var NameS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.НаименПоставщ).ToList();
            var TypeS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.Тип).ToList();
            var INNS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.ИНН).ToList();
            var ReitingS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.РейтингКачества).ToList();
            var DataNachS = Production_of_productsEntities2.GetContext().Поставщики.Select(p => p.ДатаНачалаРаб).ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            for (int i = 0; i < NameS.Count; i++)
            {
                Word.Paragraph supplierParagraph = document.Paragraphs.Add();
                Word.Range supplierRange = supplierParagraph.Range;
                supplierRange.Text = NameS[i];
                supplierParagraph.set_Style("Обычный");
                supplierRange.InsertParagraphAfter();

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, 2, 3);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                    = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Наименование";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Тип";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Рейтинг";

                cellRange = paymentsTable.Cell(2, 1).Range;
                cellRange.Text = NameS[i];
                cellRange = paymentsTable.Cell(2, 2).Range;
                cellRange.Text = TypeS[i];
                cellRange = paymentsTable.Cell(2, 3).Range;
                cellRange.Text = ReitingS[i].ToString();

                paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            }
            application.Visible = true;
        }
    }
}
