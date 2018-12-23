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
            "SELECT `FirstName`, `LastName` FROM `Employees` WHERE `BirthDate` = (SELECT MIN(`BirthDate`) FROM `Employees`)",
            "SELECT `FirstName`, `LastName` FROM `Employees` ORDER BY `BirthDate` LIMIT 3",
            "query 11",
            "query 12",
            "query 13",
            "query 14",
            "query 15",
            "query 16",
            "query 17",
            "query 18",
            "query 19",
            "query 20"
        };
    }
}