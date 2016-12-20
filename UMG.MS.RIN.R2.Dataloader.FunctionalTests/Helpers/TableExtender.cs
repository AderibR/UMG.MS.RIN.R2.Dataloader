using System.Linq;
using TechTalk.SpecFlow;

namespace UMG.MS.RIN.R2.Dataloader.FunctionalTests.Helpers
{
    public class TableExtender<T>
    {
        public Table Extend(Table originalTable)
        {
            var x = typeof(T);
            var y = x.GetProperties();
            var typeProperties = y.Select(q => q.Name).ToArray();

            var extendedTable = new Table(typeProperties);

            foreach (var tableRow in originalTable.Rows)
            {
                var rowValues = new string[typeProperties.Length];
                var columnIndex = 0;
                foreach (var columnHeader in extendedTable.Header)
                {
                    if (originalTable.Header.Contains(columnHeader))
                    {
                        rowValues[columnIndex] = tableRow[columnHeader];
                    }
                    columnIndex++;
                }

                extendedTable.AddRow(rowValues);
            }

            return extendedTable;
        }
    }
}