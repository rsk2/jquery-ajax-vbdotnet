<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="SampleAjaxApp.Base" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Items">
        
        <div class ="container" style="background-color:lightskyblue">
            <div class ="row">
                <div class = "col-sm-2">
                    Hi
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $('#Items').mouseover(function () {
            var url = "WebMethods/Items.asmx/GetNextFiveItems";
            $.ajax({
                url: url,
                type: "GET",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    var jo = $.parseJSON(result.d);
                    for (var key in jo) {
                            var div = $("<div>"+jo[key]+"</div>")
                            $('.container').append(div);
                        }
                    }
            });
        });
</script>

</html>
