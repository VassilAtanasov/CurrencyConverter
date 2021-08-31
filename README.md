# CurrencyConverter solution

version number: 5b8d0fd276b6d288905ed2f63a934e057e8feca2

The solution is consisted of two projects based on .Net version 5


## CurrencyConverter.csproj is the application project
To Run the API in command line:
dotnet run

then the API can be used in the following manner:

### Usage
The API exposes 3 endpoints using GET HTTP method

#### Rate/{currency code to}/{from currency} - Gets the currency rate for the requested code
http://localhost:5000/currency/rate/GBP
http://localhost:5000/currency/rate/GBP/EUR

#### Convert/{to code}/{from code}/{amount} - Convert amounts
http://localhost:5000/currency/convert/GBP/USD/1000
http://localhost:5000/currency/convert/GBP/EUR/1000

#### Sum amounts in different currencies
http://localhost:5000/currency/sum/eur/13.12/gbp/99/cad


### Developer Notes
The currency rates are stored in the appsettings.json
I've used Visual Studio for development and the project is set to run IIS when debugging with starting url
http://localhost:35205/currency/sum/eur/13.12/gbp/99/cad

## CurrencyConverter.UnitTests.csproj
To run Unit Tests in command line use:
dotnet test 