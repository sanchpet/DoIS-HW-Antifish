namespace Antifish
{
    public abstract class AbstractEmployee
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public int SecurityLevel { get; set; }

        public FishSearchFacade Program { get; set; }

        public abstract void CnofigureSearch(string expr);

        public abstract void StartSearch();

        public abstract void GetScanReport();

    }

    class AdminEmployee : AbstractEmployee
    {
        public AdminEmployee(string login, string email, int seclevel) 
        { 
            Login = login;
            Email = email;
            SecurityLevel = seclevel;
        }

        public override void CnofigureSearch(string expr)
        {
            Program = new FishSearchFacade(expr);
        }

        public override string ToString()
        {
            return "Администратор ИБ с логином " + Login + " и контактным email " + Email;
        }

        public override void StartSearch()
        {
            Program.StartSearch();
        }

        public override void GetScanReport()
        {
            Program.OrderReport(2);
        }

    }

    class AbuseEmployee : AbstractEmployee
    {

        public AbuseEmployee(string login, string email, int seclevel)
        {
            Login = login;
            Email = email;
            SecurityLevel = seclevel;
        }

        public override string ToString()
        {
            return "Сотрудник abuse-службы с логином " + Login + " и контактным email " + Email;
        }

        public override void CnofigureSearch(string expr)
        {
            Console.WriteLine("Отказано в доступе");
        }

        public override void StartSearch()
        {
            Console.WriteLine("Отказано в доступе");
        }

        public override void GetScanReport()
        {
            Console.WriteLine("Отказано в доступе");
        }
    }

    class SupportEmployee : AbstractEmployee
    {
        public SupportEmployee(string login, string email, int seclevel)
        {
            Login = login;
            Email = email;
            SecurityLevel = seclevel;
        }

        public override string ToString()
        {
            return "Сотрудник техподдержки с логином " + Login + " и контактным email " + Email;
        }

        public override void CnofigureSearch(string expr)
        {
            Console.WriteLine("Отказано в доступе");
        }

        public override void StartSearch()
        {
            Console.WriteLine("Отказано в доступе");
        }

        public override void GetScanReport()
        {
            Console.WriteLine("Отказано в доступе");
        }
    }
}