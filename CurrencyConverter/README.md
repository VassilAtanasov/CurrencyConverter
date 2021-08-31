# Currency Converter

version number: 5b8d0fd276b6d288905ed2f63a934e057e8feca2

The project uses .Net version 5

## To Run the API
dotnet run

## To run Unit Tests
dotnet test

#Usage
the API can be used in the following manner:

## Get currency rates
http://localhost:5000/currency/rate/GBP
http://localhost:5000/currency/rate/GBP/EUR

## Convert amounts
http://localhost:5000/currency/convert/GBP/EUR/1000
http://localhost:5000/currency/convert/GBP/EUR/1000

## Sum amounts in different currencies
http://localhost:5000/currency/sum/eur/13.12/gbp/99/cad

# Developer Notes
The currency rates are storred in the appsettings.json