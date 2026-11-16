using System;

namespace SolidRefactoringLab
{
    // Interface adhering to OCP and DIP
    public interface IReportFormatter
    {
        void FormatReport();
    }

    // Concrete formatters adhering to OCP (open for extension, closed for modification)
    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    // ReportManager now adheres to SRP (responsible only for managing report generation)
    // and DIP/OCP (depends on IReportFormatter abstraction)
    public class ReportManager
    {
        public string? ReportData { get; set; }
        private readonly IReportFormatter? _formatter;

        public ReportManager()
        {
        }

        // Dependency Injection via constructor
        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter?.FormatReport();
        }

        // Method injection overload
        public void GenerateReport(IReportFormatter formatter)
        {
            formatter.FormatReport();
        }
    }

    // Separate class adhering to SRP (responsible solely for saving reports)
    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }

        // Backward compatibility alias for casing
        public void SavetoFile(string filename) => SaveToFile(filename);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // OCP: Inject the desired formatter without modifying ReportManager
            IReportFormatter formatter = new PdfFormatter();
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // SRP: Report saving is handled by ReportSaver
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}
