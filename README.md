# StockWatcher

StockWatcher is a simple fullstack web application made using C# with EntityFramework and Blazor Web Assembly.

This website allows registered users to search stock prices and news regarding the selected company. Futhermore, the user can add any stock to the private watchlist. 

All stock data is downloaded form [Polygon.io](https://polygon.io/docs)

All user data and cached stock informations are stored in Microsoft SQL Server database.

To simplify the application the database ran on docker and all connection strings were held in .json files instead of .env
