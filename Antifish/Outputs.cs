namespace Antifish
{
    interface IReport
    {
        void SendReport();
    }

    internal abstract class Report : IReport
    {
        protected string ReportLayout { get; set; }
        public abstract void SendReport();
    }

    class ScanReport : Report
    {
        string scanResults;

        List<WebPage> RelatedWebPages { get; set; }

        public ScanReport(string scanRes, List<WebPage> pages ) 
        {
            scanResults = scanRes;
            RelatedWebPages = pages;
            ReportLayout = "Полный отчет по уязвимостям:";
        }

        public override void SendReport()
        {
            Console.WriteLine("Отправлен отчет с содержимым: ");
            for (int i = 0; i < RelatedWebPages.Count; i++)
            {
                Console.WriteLine(ReportLayout + RelatedWebPages[i].GetTitle() + scanResults);
            }
            
        }
    }

    class PersonReport : Report
    {
        string presonDetails;
        string personID;

        public PersonReport(string presonDetails, string personID)
        {
            this.presonDetails = presonDetails;
            this.personID = personID;
            ReportLayout = "Отчет о статусе блокировки пользователя" + this.personID + ": ";
        }

        public override void SendReport()
        {
            Console.WriteLine("Отправлен отчет с содержимым: ");
            Console.WriteLine(ReportLayout + presonDetails);
        }
    }

    class Notification
    {
        string ScanResult { get; set; }
        string NotificationLayout { get; set; }
        WebPage RelatedWebPage { get; set; }

        public Notification(string scanRes, WebPage webPage) 
        {
            ScanResult = scanRes;
            NotificationLayout = "Получен новый отчёт об угрозах: ";
            RelatedWebPage = webPage;
        }

        public void SendNotification()
        {
            Console.WriteLine("Отправлено уведомление с содержимым: ");
            Console.WriteLine(NotificationLayout + RelatedWebPage.GetTitle() + ScanResult);
        }
    }

    public class WebPage
    {
        string Content {  get; set; }
        string Title {  get; set; }

        public WebPage(string content, string title)
        {
            Content = content;
            Title = title;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetContent()
        {
            return Content;
        }
    }
}
