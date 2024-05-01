@modeltype IEnumerable(Of HistoricResponse)
@Code
    ViewData("Title") = "Historic"
End Code

<h2>Historic</h2>

<div class="container">
    <table class="table table-hover table-bordered table-striped">
        <thead>
            <tr>
                <th>
                    Date Ran
                </th>
                <th>
                    Locations
                </th>
                <th>

                </th>
            </tr>
        </thead>
        <tbody>
            @For Each item In Model
                @<tr>
                    <td>
                        @item.DateRan.ToShortDateString()
                    </td>
                    <td>
                        @Html.Raw(item.LocationNames.Aggregate(Function(x, y) x & "<br>" & y))
                    </td>
                    <td>

                        @Html.ActionLink("View", "Forecast", "FileUpload", New With {.area = "", .id = item.Id}, New With {.class = "btn btn-success btn-outline-dark text-white"})
                        @Html.ActionLink("Delete", "Delete", "FileUpload", New With {.area = "", .id = item.Id}, New With {.class = "btn btn-outline-dark btn-danger text-white"})
                    </td>
                </tr>
            Next
            @*Views the item of forecast from the database*@
            @*Deletes the current item from database: No Auditing setup, would apply this if normalised and use a trigger on delete*@
        </tbody>
    </table>
</div>