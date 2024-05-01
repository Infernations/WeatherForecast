@modelType IEnumerable(Of WeatherResponse)
@Code
    ViewData("Title") = "Forecast"
    Dim i As Integer = 0
End Code
@*<style>
        .multi-cell{
            margin-top:.5rem;
            margin-bottom:.5rem;
        }
    </style>*@


<div class="container">
    @If Model IsNot Nothing Then
        @<h2>Forecast For @Model.FirstOrDefault().Weathers.FirstOrDefault().WeatherDate.ToShortDateString() - @Model.FirstOrDefault().Weathers.LastOrDefault().WeatherDate.ToShortDateString()</h2>

        @<div class="row">
            @For Each item In Model
                @<div class="col-4 h-100 mb-3">
                    <div Class="card" style="width:18rem;">
                        <div Class="card-body">
                            <h5 Class="card-title">
                                @item.Location.Name
                            </h5>
                            <p class="card-subtitle text-muted" style="font-size:.75rem;">
                                Latitude: @item.Location.Lat
                                <br />
                                Longitude: @item.Location.Longitude
                            </p>

                            @For Each row In item.Weathers
                                @<p Class="card-text">
                                    <div class="fw-bold">
                                        @row.WeatherDate.ToShortDateString()
                                    </div>
                                    <div>
                                        @row.Weather
                                    </div>
                                    <div>
                                        High: @row.High &deg;C
                                    </div>
                                    <div>
                                        Low: @row.Low &deg;C
                                    </div>
                                </p>
                            Next

                        </div>
                    </div>
                </div>
            Next
        </div>

        @*Changed From using a table to using cards, keeping as reference*@
        @*@<table id="table" Class="table table-hover table-bordered table-striped">
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
                                <div class="mb-2 mt-2">
                                    Weather: @item.Weathers(0).Weather
                                </div>
                                <div class="mb-2 mt-2">
                                    High: @item.Weathers(0).High &deg;C
                                </div>
                                <div class="mb-2 mt-2">
                                    Low: @item.Weathers(0).Low &deg;C
                                </div>
                            </td>
                            <td>
                                <div class="mb-2 mt-2">
                                    Weather: @item.Weathers(1).Weather
                                </div>
                                <div class="mb-2 mt-2">
                                    High: @item.Weathers(1).High &deg;C
                                </div>
                                <div class="mb-2 mt-2">
                                    Low: @item.Weathers(1).Low &deg;C
                                </div>
                            </td>
                            <td>
                                <div class="multi-cell">
                                    Weather: @item.Weathers(2).Weather
                                </div>
                                <div class="multi-cell">
                                    High: @item.Weathers(2).High &deg;C
                                </div>
                                <div class="multi-cell">
                                    Low: @item.Weathers(2).Low &deg;C
                                </div>
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>*@ Else
        @*Handles if there are null values*@
        @<div class="mt-auto align-items-center">
            <h6 class="display-6">
                There is no data available. Please upload and ensure the it is a CSV file
                <br />
                @Html.ActionLink("Upload", "UploadData", "FileUpload", New With {.area = ""}, New With {.class = "btn btn-outline-dark btn-success text-white"})
            </h6>
        </div>
    End If
</div>