namespace BMW_SFAM_Private.Services.Common.AccountManagement
{
    public class FsAccount
    {
        /// <summary>
        /// BMW Financial Service Social Security and Credit Card Mapper
        /// </summary>
        string file1Path = "sampleCC.csv"; // Update with the actual path of your first CSV file
        string file2Path = "sampleSSN.csv"; // Update with the actual path of your second CSV file

        DataTable mergedDataTable = MergeCsvFilesIntoDataTable(file1Path, file2Path);

        // Print the merged data to console (for demonstration)
        foreach (DataRow row in mergedDataTable.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
    }

    static DataTable MergeCsvFilesIntoDataTable(string file1Path, string file2Path)
    {
        DataTable dataTable = new DataTable();

        // Load and process the first CSV file of credit card information
        using (StreamReader reader = new StreamReader(file1Path))
        {
            bool isFirstLine = true;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (isFirstLine)
                {
                    foreach (string value in values)
                    {
                        dataTable.Columns.Add(value.Trim());
                    }
                    isFirstLine = false;
                }
                else
                {
                    dataTable.Rows.Add(values);
                }
            }
        }

        // Load and process the second CSV file of social security information
        using (StreamReader reader = new StreamReader(file2Path))
        {
            bool isFirstLine = true;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (isFirstLine)
                {
                    // Assuming the second CSV file has the same number of columns as the first one
                    isFirstLine = false;
                }
                else
                {
                    dataTable.Rows.Add(values);
                }
            }
        }

        return dataTable;
    }
}