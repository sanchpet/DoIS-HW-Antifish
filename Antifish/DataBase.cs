using System.IO;

namespace Antifish
{
    internal class DataBase
    {
        private DataBase() { }

        static Lazy<DataBase> myDataBase = new Lazy<DataBase>(() => new DataBase());

        Notification Notification {  get; set; }
        Report Report { get; set; }

        public static DataBase MyDataBase
        {
            get
            {
                return myDataBase.Value;
            }
        }

        public void CreateRecord(Dictionary<WebPage, string> report)
        {
            if (!File.Exists("C:\\Users\\sanch\\source\\repos\\Antifish\\Antifish\\database.txt"))
            {
                using (File.Create("C:\\Users\\sanch\\source\\repos\\Antifish\\Antifish\\database.txt")) ;
            }

            using (StreamWriter w = File.AppendText("C:\\Users\\sanch\\source\\repos\\Antifish\\Antifish\\database.txt")) 
            {
                foreach (var rep in report)
                {
                    Recorder(rep.Key.GetTitle() + rep.Value, w);
                }
                w.Close();
            }
        }

        private static void Recorder(string report, TextWriter w)
        {
            w.WriteLine("New peport: {0} {1} {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), report);
        }

        public void Notify(Dictionary<WebPage, string> report)
        {
            foreach (var rep in report)
            {
                Notification = new Notification(rep.Value, rep.Key);
                Notification.SendNotification();
            }
        }

        public void SendReport(int mode, List<WebPage>? pages = null)
        {
            if (mode == 1)
            {
                Report = new PersonReport("info", "vasya");
            }
            else if ((mode == 2) && (pages != null))
            {
                Report = new ScanReport("very bad scan", pages);
            }

            Report.SendReport();
        }
    }
}
