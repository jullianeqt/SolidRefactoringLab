using System;

namespace SolidRefactoringLab
{
    // THIS CLASS VIOLATES SRP AND OCP
    public class ReportManager
    {
        public string ReportData { get; set; }
        public void GenerateReport(string reportType)
        {
            if (reportType == "PDF")
            {
                Console.WriteLine("Formatting report as a PDF...");
            }
            else if (reportType == "Word")
            {
                Console.WriteLine("Formatting report as a Word Document...");
            }
            else
            {
                Console.WriteLine("Formatting report as plain text...");
            }
        }

        public void SavetoFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}..."); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ReportManager manager = new ReportManager();
            manager.GenerateReport("PDF");
            manager.SavetoFile("Q1_Report.pdf");
        }
    }
}