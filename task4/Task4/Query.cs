namespace Task4
{
    public class Query
    {
        public static readonly string[] Q =
        {
            "select * from Employees as e where e.EmployeeID=@EmployeeID",
            "select e.FirstName, e.LastName from Employees as e where e.City=@CityName",
            "query 3",
            "query 4",
            "SELECT COUNT(*) FROM `Employees` WHERE `City`='@CityName';",
            "SELECT MAX((YEAR(CURRENT_TIMESTAMP)-YEAR(`BirthDate`))) AS MaxAge, " +
                "MIN((YEAR(CURRENT_TIMESTAMP)-YEAR(`BirthDate`))) AS MinAge, " +
                "AVG((YEAR(CURRENT_TIMESTAMP)-YEAR(`BirthDate`))) AS AverageAge " +
                "FROM `Employees` WHERE `City`='@CityName';",
            "select City, MAX((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as MaxAge, " +
                "MIN((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as MinAge, " +
                "AVG((YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate))) as AverageAge " +
                "from Northwind.dbo.Employees group by City",
            "select City, " +
                "AVG(YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate)) as AverageDate " +
                "from Northwind.dbo.Employees " +
                "group by City " +
                "having AVG(YEAR(CURRENT_TIMESTAMP)-YEAR(BirthDate)) > 60;",
            "SELECT `FirstName`, `LastName` FROM `Employees` WHERE `BirthDate`=(SELECT MIN(`BirthDate`) FROM `Employees`)",
            "SELECT `FirstName`, `LastName` FROM `Employees` ORDER BY `BirthDate` LIMIT @LimitAmount",
            "select City from Employees group by City",
            "query 12",
            "SELECT `Employees`.`FirstName`, `Employees`.`LastName` FROM `Employees` " +
                "JOIN `Orders` WHERE `Orders`.`ShipCity`='@CityName' AND `Orders`.`EmployeeID`=`Employees`.`EmployeeID` " +
                "GROUP BY `Employees`.`EmployeeID`;",
            "select  Employees.EmployeeID, Employees.FirstName, Employees.LastName, " +
                "(select count(*) from Orders where year(Orders.OrderDate) = 1997 " +
                "and Employees.EmployeeID = Orders.EmployeeID) as Ords " +
                "from Employees left join Orders on Employees.EmployeeID = Orders.EmployeeID " +
                "group by Employees.EmployeeID, Employees.FirstName, Employees.LastName;",
            "SELECT `e`.`FirstName`, `e`.`LastName`, COUNT(`o`.`OrderID`) AS `Orders made` "
                + "FROM `Employees` as `e` INNER JOIN `Orders` AS `o` "
                + "ON `e`.`EmployeeID`=`o`.`EmployeeID` "
                + "WHERE YEAR(`o`.`OrderDate`)=@OrderDate "
                + "GROUP BY `e`.`EmployeeID`",
            "select e.FirstName, e.LastName, COUNT(o.OrderId) as 'Orders amount' " +
                "from Employees as e left join Orders as o on e.EmployeeID = o.EmployeeID " +
                "where YEAR(o.OrderDate)=@OrderDate and o.RequiredDate<o.ShippedDate " +
                "group by e.EmployeeID",
            "query 17",
            "SELECT `Customers`.`CustomerID`, `Customers`.`Country`, " +
                "COUNT(`Orders`.`OrderID`) AS `Orders` " +
                "FROM `Customers` " +
                "JOIN `Orders` ON `Customers`.`CustomerID` = `Orders`.`CustomerID` " +
                "WHERE `Customers`.`Country`='@CountryName' " +
                "GROUP BY(`Customers`.`CustomerID`) WITH ROLLUP " +
                "HAVING COUNT(`Orders`.`OrderID`) > 1;",
            "select Customers.CustomerID, Customers.Country, " +
                "count(Orders.OrderID) as Ords " +
                "from Customers join Orders on Customers.CustomerID = Orders.CustomerID " +
                "where Country = 'France' " +
                "group by Customers.CustomerID, Customers.Country " +
                "having count(Orders.OrderID) > 1",
            "SELECT `c`.`ContactName`, `c`.`ContactTitle` "
                + "FROM `Customers` AS `c` "
                + "INNER JOIN `Orders` AS `o` ON `c`.`CustomerID`=`o`.`CustomerID` "
                + "INNER JOIN `Order Details` AS `od` ON `o`.`OrderID`=`od`.`OrderID` "
                + "INNER JOIN `Products` AS `p` ON `od`.`ProductID`=`p`.`ProductID` "
                + "WHERE `p`.`ProductName`=@ProductName"
        };
    }
}
