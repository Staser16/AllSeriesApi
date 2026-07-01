API do zarządzania mediami takimi jak anime, seriale i filmy.

#1 Technologie użyte w projekcie:
.NET 9.0 (ASP.NET Core)
Entity Framework Core
MySql (Pomelo.EntityFrameworkCore.MySql)
Scalar (API documentation tool)
Linux
VS Code

#2 Wymagania:
.NET SDK 9.0
Entity Cli (dotnet-ef)
Windows/Linux

#3 Instalacja:
Klonowanie:
- git clone https://github.com/Staser16/AllSeriesApi.git
- cd AllSeriesApi

Ustawienie Connection Strings:
- dotnet user-secrets init
- dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=localhost;database=MojaBazaDanych;user=root;" (gdzie MojaBazaDanych to baza danych w MySql)

Budowa projektu:
- dotnet restore
- dotnet build

Ustawienie Bazy z Entity framework Core:
- dotnet ef database update

Włączenie projektu:
- dotnet run

#4 Informacje dodatkowe:
API będzie dostępne na 
- http://localhost:5269/api/anime (Anime)
- http://localhost:5269/api/series (Series)
- http://localhost:5269/api/film (Filmy)
- http://localhost:5269/scalar (Dokumentacja API)
