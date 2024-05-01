@modelType IEnumerable(Of WeatherResponse)
@Code
    ViewData("Title") = "Home Page"
    Dim i As Integer = 0
End Code

<main>
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="title">Weather Forecast</h1>
        <p class="lead">This application will split up a CSV file, strip the long & lat values, and will return the weather forecast for the next 3 days!</p>
    </section>


    <div>
        <table id="table" Class="table table-hover table-bordered table-striped">
            <thead>
                <tr>
                    <th>
                        Latitude
                    </th>
                    <th>
                        Longitude
                    </th>
                    <th>
                        Town
                    </th>
                    <th id="day1">
                        @Model(i).Weathers(i).WeatherDate.ToShortDateString()
                    </th>
                    <th id="day2">
                        @Model(i).Weathers(i + 1).WeatherDate.ToShortDateString()
                    </th>
                    <th id="day3">
                        @Model(i).Weathers(i + 2).WeatherDate.ToShortDateString()
                    </th>
                </tr>
            </thead>
            <tbody>
                @For Each item In Model
                    @<tr>
                        <td>
                            @item.Location.Lat
                        </td>
                        <td>
                            @item.Location.Longitude
                        </td>
                        <td>
                            @item.Location.Name
                        </td>
                        <td>
                            High: @item.Weathers(i).High &deg;C
                            Low: @item.Weathers(i).Low &deg;C
                        </td>
                        <td>
                            High: @item.Weathers(i + 1).High &deg;C
                            Low: @item.Weathers(i + 1).Low &deg;C
                        </td>
                        <td>
                            High: @item.Weathers(i + 2).High &deg;C
                            Low: @item.Weathers(i + 2).Low &deg;C
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</main>
