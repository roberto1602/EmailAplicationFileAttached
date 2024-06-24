using ClosedXML.Excel;
using Entities;

namespace Business.Utils
{
    public class FileLoad 
    {
        public void FileExcel(List<Departamento> listDepto)
        {
            var excel = new XLWorkbook();

            var workSheet = excel.Worksheets.Add("Departamentos");

            workSheet.Cell("A1").Value = "Id depto";
            workSheet.Cell("B1").Value = "Nombre depto";

            int row = 2;

            foreach (Departamento depto in listDepto)
            {
                workSheet.Cell("A" + row).Value = depto.DepartamentoID;
                workSheet.Cell("B" + row).Value = depto.Nombre;
                row++;
            }
            excel.SaveAs("Departamentos.xlsx");
        }
    }
}
