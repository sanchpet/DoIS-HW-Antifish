namespace Antifish
{
    public class FishSearchFacade
    {
        private FishSearchAlgo Algo {  get; set; }
        ReportGenerator Generator {  get; set; }
        ReportHandler PersonHandler { get; set; }
        ReportHandler ScanHandler { get; set; }

        public FishSearchFacade(string expr)
        {
            ConfigureSearch(expr);
        }

        public void ConfigureSearch(string expr)
        {
            StrategyWebSearch search = new JournalSearch(1, expr);
            StrategyWebAnalyze webAnalyze = new FeatureAnalyze(1);
            Algo = new SearchAnalyzeFishSearchAlgo(search, webAnalyze);
        }

        public void StartSearch()
        {
            Algo.TemplateMethod();
        }

        public void OrderReport(int mode)
        {
            PersonHandler = new PersonReporGenerator();
            ScanHandler = new ScanReporGenerator();

            PersonHandler.Successor = ScanHandler;

            if (mode == 1)
            {
                Generator = new ReportGenerator(true, false);
                PersonHandler.Generate(Generator);
            }
            if (mode == 2)
            {
                Generator = new ReportGenerator(false, true);
                PersonHandler.Generate(Generator);
            }
        }
    }
}
