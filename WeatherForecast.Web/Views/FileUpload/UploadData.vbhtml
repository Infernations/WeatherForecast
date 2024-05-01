@ModelType HttpPostedFile
@Code
    ViewData("Title") = "UploadData"
End Code

<h2>UploadData</h2>

<div class="container">
    <div class="col-6">
        <form method="post" enctype="multipart/form-data">
            <div class="form-group">
                @Html.LabelFor(Function(model) model, New With {.class = "form-label"})
                <input type="file" id="responseFile" name="responseFile" class="form-control" />
            </div>
            <div Class="form-group">
                <input type = "submit" Class="btn btn-outline-dark btn-success text-white" />
            </div>
        </form>
    </div>
</div>