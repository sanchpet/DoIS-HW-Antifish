namespace Antifish
{
    internal abstract class EmployeeFactory
    {
        public abstract AbstractEmployee CreateEpmloyee(string login, string email);
    }

    internal class AdminFactory : EmployeeFactory
    {
        AdminEmployee ade;
        public override AbstractEmployee CreateEpmloyee(string login, string email)
        {
            ade = new AdminEmployee(login, email, 1);
            return ade;
        }
    }

    internal class AbuseFactory : EmployeeFactory
    {
        AbuseEmployee ae;

        public override AbstractEmployee CreateEpmloyee(string login, string email)
        {
            ae = new AbuseEmployee(login, email, 2);
            return ae;
        }
    }

    internal class SupportFactory : EmployeeFactory
    {
        SupportEmployee se;
        public override AbstractEmployee CreateEpmloyee(string login, string email)
        {
            se = new SupportEmployee(login, email, 3);
            return se;
        }
    }
}
