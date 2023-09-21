namespace Antifish
{
    internal class ReportGenerator
    {
        public bool personReport { get; set; }
        public bool scanReport { get; set; }
        public ReportGenerator(bool pr, bool sr)
        {
            personReport = pr;
            scanReport = sr;
        }
    }

    abstract class ReportHandler
    {
        public ReportHandler Successor { get; set; }
        public abstract void Generate(ReportGenerator reportGenerator);
    }

    class PersonReporGenerator : ReportHandler
    {
        public override void Generate(ReportGenerator reportGenerator)
        {
            if (reportGenerator.personReport == true)
            {
                Console.WriteLine("Отправляем отчет по пользователю.");
                DataBase.MyDataBase.SendReport(1);
            }
            else if (Successor != null)
            {
                Successor.Generate(reportGenerator);
            }
        }
    }

    class ScanReporGenerator : ReportHandler
    {
        public override void Generate(ReportGenerator reportGenerator)
        {
            if (reportGenerator.scanReport == true)
            {
                Console.WriteLine("Отправляем отчет по сканированию.");
                List<WebPage> result = new List<WebPage>
                {
                    new WebPage("content", "vk1.com"),
                    new WebPage("content", "ok2.ru")
                };
                DataBase.MyDataBase.SendReport(2, result);
            }
            else if (Successor != null)
            {
                Successor.Generate(reportGenerator);
            }
        }
    }
}
