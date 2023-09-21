using System.Collections.Generic;

namespace Antifish
{
    public abstract class FishSearchAlgo
    {
        DataBase db = DataBase.MyDataBase;

        public void TemplateMethod()
        {
            List<WebPage> websites = Search();
            Dictionary<WebPage, string> report = Analyze(websites);
            CreateRecord(report);
            Notify(report);
        }

        public abstract List<WebPage> Search();

        public abstract Dictionary<WebPage, string> Analyze(List<WebPage> websites);

        public void CreateRecord(Dictionary<WebPage, string> report)
        {
            db.CreateRecord(report);
        }

        public void Notify(Dictionary<WebPage, string> report)
        {
            db.Notify(report);
        }
    }

    class SearchAnalyzeFishSearchAlgo : FishSearchAlgo
    {
        protected StrategyWebSearch search;
        protected StrategyWebAnalyze analyze;

        public SearchAnalyzeFishSearchAlgo(StrategyWebSearch search, StrategyWebAnalyze analyze)
        {
            this.search = search;
            this.analyze = analyze;
        }

        public override List<WebPage> Search()
        {
            return search.Search();
        }

        public override Dictionary<WebPage, string> Analyze(List<WebPage> websites)
        {
            return analyze.Analyze(websites);
        }
    }
}
