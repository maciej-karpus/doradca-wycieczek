<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Sample.Models.ChartData>>" %>

<%@ Import Namespace="JQChart.Web.Mvc" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Data Source Binding</title>
    <link rel="stylesheet" type="text/css" href="~/Content/jquery.jqChart.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/jquery.jqRangeSlider.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/themes/smoothness/jquery-ui-1.10.4.css" />
    <script src="<%: Url.Content("~/Scripts/jquery-1.11.1.min.js")%>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.jqChart.min.js")%>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.jqRangeSlider.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.mousewheel.js")%>" type="text/javascript"></script>
    <!--[if IE]><script lang="javascript" type="text/javascript" src="<%: Url.Content("~/Scripts/excanvas.js")%>"></script><![endif]-->
</head>
<body>
    <div>
        <%= Html.JQChart()
                .Chart(Model)
                .ID("jqChart")
                .Width(500)
                .Height(300)
                .Title("Chart Title")
                .Legend(legend => legend.Title("Legend"))
                .Axes(axis =>
                {
                    axis.CategoryAxis(Location.Bottom).ZoomEnabled(true);
                })
                .Series(series =>
                {
                    series.Column().Title("Column")
                                   .XValues(el => el.Label)
                                   .YValues(el => el.Value1);

                    series.Spline().Title("Spline")
                                   .XValues(el => el.Label)
                                   .YValues(el => el.Value2);
                })
                .Render()%>
    </div>
</body>
</html>
