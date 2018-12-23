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
            "query 7",
            "query 8",
            "SELECT `FirstName`, `LastName` FROM `Employees` WHERE `BirthDate`=(SELECT MIN(`BirthDate`) FROM `Employees`)",
            "SELECT `FirstName`, `LastName` FROM `Employees` ORDER BY `BirthDate` LIMIT 3",
            "query 11",
            "query 12",
            "query 13",
            "query 14",
            "SELECT `e`.`FirstName`, `e`.`LastName`, COUNT(`o`.`OrderID`) AS `Orders made` "
                + "FROM `Employees` as `e` INNER JOIN `Orders` AS `o` "
                + "ON `e`.`EmployeeID`=`o`.`EmployeeID` "
                + "WHERE YEAR(`o`.`OrderDate`)=1997 "
                + "GROUP BY `e`.`EmployeeID`",
            "query 16",
            "query 17",
            "query 18",
            "query 19",
            "SELECT `c`.`ContactName`, `c`.`ContactTitle` "
                + "FROM `Customers` AS `c` "
                + "INNER JOIN `Orders` AS `o` ON `c`.`CustomerID`=`o`.`CustomerID` "
                + "INNER JOIN `Order Details` AS `od` ON `o`.`OrderID`=`od`.`OrderID` "
                + "INNER JOIN `Products` AS `p` ON `od`.`ProductID`=`p`.`ProductID` "
                + "WHERE `p`.`ProductName`='Tofu';"
        };
    }
}