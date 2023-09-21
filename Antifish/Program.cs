using Antifish;


EmployeeFactory adminFactory = new AdminFactory();
AbstractEmployee superuser = adminFactory.CreateEpmloyee("alpetrov", "alpetrov@sweb.ru");

Console.WriteLine(superuser.ToString());

superuser.CnofigureSearch("Very important expression");
superuser.StartSearch();
superuser.GetScanReport();