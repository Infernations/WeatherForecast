# WeatherForecast.Web

Weather Forecast application example, allowing CSV's to be uploaded following the structure in App_Data, strips the Long and Lat values and passes through to an API.

**# The approach:**
Started with a standard VB.NET Web Application using MVC 5.
First outlined the CSV Response and what the API data would look like to be converted from json into an object.
Once a file could be uploaded, read and provided a response to a table in: ``` Forecast.vbhtml ```
I wanted to ensure resources were not being wasted, so elements of business logic which could be seen as intensive, have been wrapped using a ``` Using ``` statement, also meaning ``` IDisposable ``` has also been implemented throughout the various classes such as ``` SqlHelper.vb, ApiConnection.vb and ExcelHandler.vb ```. On top of this, Linq was implemented where possible to ensure data being processes was achieved effectively.

All styling has been provided by making use of the bootstrap library (pre added via the projects creation).

A local database using sqlite has been created with one table being created: HistoricRequests with the columns: Id, JsonValue and dateRan.
If I was using a database which was running on more of a dedicated server, such as MSSQL or Oracle, there would be more tables, with relationships and normalised.

Individual rows can be displayed on ``` Historic.vbhtml ``` which can be viewed on ``` Forecast.vbhtml ``` (checks if the data is coming from an Id, or from tempData)

The Home screen is a work in progress, If this was a long term project, would allow the ability for users to search their desired location using a Postcode API or a global Location (including ZIP addresses etc) API. 
