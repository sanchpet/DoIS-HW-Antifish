namespace Antifish

{

    public abstract class StrategyWebSearch
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Expression {  get; set; }
        public abstract List<WebPage> Search();
    }

    public abstract class StrategyWebAnalyze
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Features { get; set; }
        public abstract Dictionary<WebPage, string> Analyze(List<WebPage> targets);
    }

    class JournalSearch : StrategyWebSearch
    {
        public JournalSearch(int id, string expr)
        {
            Title = "Поиск в журнале запросов веб-сервера";
            Id = id;
            Expression = expr;
        }

        public override List<WebPage> Search()
        {
            Console.WriteLine("Поиск выполнен с применением шаблона " + Expression);
            List<WebPage> result = new List<WebPage>
            {
                new WebPage("content", "vk1.com"),
                new WebPage("content", "ok2.ru")
            };
            return result;
        }
    }

    class FeatureAnalyze : StrategyWebAnalyze
    {
        public FeatureAnalyze(int id)
        {
            Title = "Анализ качественных характеристик веб-страницы";
            Id = id;
        }

        public override Dictionary<WebPage, string> Analyze(List<WebPage> targets)
        {
            Features = "1, 0, 3, 2";
            Console.WriteLine("В ходе анализа страниц получен список характеристик: " + Features);
            Dictionary<WebPage, string> result = new Dictionary<WebPage, string>();
            foreach (WebPage target in targets)
            {
                result.Add(target, "Fishing");
            }
            return result;
        }
    }

}
