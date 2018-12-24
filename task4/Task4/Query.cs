namespace Task4
{
    public class Query
    {
        public static readonly string[] Q =
        {
            "query 1",
            "query 2",
            "query 3",
            "query 4",
            "query 5",
            "query 6",
            "select City, MAX((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as MaxAge, " +
                "MIN((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as MinAge, " +
                "AVG((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as AverageAge " +
                "from Northwind.dbo.Employees group by City;",
            "select City, " +
                "AVG(YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate)) as AverageDate " +
                "from Northwind.dbo.Employees " +
                "group by City " +
                "having AVG(YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate)) > 60;",
            "SELECT `FirstName`, `LastName` FROM `Employees` WHERE `BirthDate`=(SELECT MIN(`BirthDate`) FROM `Employees`)",
            "SELECT `FirstName`, `LastName` FROM `Employees` ORDER BY `BirthDate` LIMIT @LIMIT_AMOUNT",
            "query 11",
            "query 12",
            "query 13",
            "select  Employees.EmployeeID, Employees.FirstName, Employees.LastName, " +
                "(select count(*) from Orders where year(Orders.OrderDate) = 1997 " +
                "and Employees.EmployeeID = Orders.EmployeeID) as Ords " +
                "from Employees left join Orders on Employees.EmployeeID = Orders.EmployeeID " +
                "group by Employees.EmployeeID, Employees.FirstName, Employees.LastName;",
            "SELECT `e`.`FirstName`, `e`.`LastName`, COUNT(`o`.`OrderID`) AS `Orders made` "
                + "FROM `Employees` as `e` INNER JOIN `Orders` AS `o` "
                + "ON `e`.`EmployeeID`=`o`.`EmployeeID` "
                + "WHERE YEAR(`o`.`OrderDate`)=1997 "
                + "GROUP BY `e`.`EmployeeID`",
            "query 16",
            "query 17",
            "query 18",
            "select Customers.CustomerID, Customers.Country, " +
                "count(Orders.OrderID) as Ords " +
                "from Customers join Orders on Customers.CustomerID = Orders.CustomerID " +
                "where Country = 'France' " +
                "group by Customers.CustomerID, Customers.Country " +
                "having count(Orders.OrderID) > 1;",
            "SELECT `c`.`ContactName`, `c`.`ContactTitle` "
                + "FROM `Customers` AS `c` "
                + "INNER JOIN `Orders` AS `o` ON `c`.`CustomerID`=`o`.`CustomerID` "
                + "INNER JOIN `Order Details` AS `od` ON `o`.`OrderID`=`od`.`OrderID` "
                + "INNER JOIN `Products` AS `p` ON `od`.`ProductID`=`p`.`ProductID` "
                + "WHERE `p`.`ProductName`='Tofu';"
        };
    }
}
