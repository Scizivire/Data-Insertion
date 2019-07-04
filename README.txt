Deze Repository is bedoeld om snel data te kunnen importeren als de Model van de 'Backend-Website' Repository is geupdate en de database gedropt moet worden in verband met migrations.
In deze folder gebruik je alleen 'dotnet run', dat betekent dat je de -- DATABASE UPDATE VANAF DE 'Backend-Website' FOLDER -- en 'Data-Insertion' alleen gebruikt waar hij naar vernoemd is.

Als je deze console applicatie will laten runnen moet er eerst een een nieuwe file worden aangemaakt genaamd:   UserData.cs
in die file wordt alle gepersonaliseerde informatie geplaatst zoals de connectionstring naar de database en de paden naar je CSV bestanden.
De UserData.cs file ziet er zo uit (met voorbeelddata):

-----------------------------------------------------------------------------------------------------------------------------------------------




namespace Data_Inserter
{
    public static class UserData
    {
        public static string ConnectionString   = @"User ID=postgres;Password=;Host=localhost;Port=5432;Database=WebshopData;Pooling=true;";
        public static string CategoryPath       = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Categories.csv";
        public static string TypePath           = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Types.csv";
        public static string CategoryTypePath   = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\CategoryTypes.csv";
        public static string BrandPath          = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Brands.csv";
        public static string CollectionPath     = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Collections.csv";
        public static string StockPath          = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Stocks.csv";
        public static string ProductPath        = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Products.csv";
        public static string ProductImagePath   = @"C:\Users\D\Documents\Studie Opdrachten\HBO INF\HBO INF Jaar 2\Project 1C\Model Tables\CSV\Images.csv";

    }
}




-----------------------------------------------------------------------------------------------------------------------------------------------
Extra informatie voor de mensen die in de Backend-Website de Model veranderen

Op het moment dat de Model uit de 'Backend-Website' wordt aangepast moet de Model die in de folder van 'Data-Insertion' staat ook worden aangepast (Copy/Paste aangepaste data in deze folder),
dit omdat de Models IDENTIEK moeten zijn elkaar, anders is het niet mogelijk om 'dotnet run' te gebruiken om data te importeren.