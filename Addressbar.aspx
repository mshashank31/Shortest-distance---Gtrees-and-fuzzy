<%@ Page Title="" Language="C#" MasterPageFile="~/FuzzyControl.master" AutoEventWireup="true" CodeFile="Addressbar.aspx.cs" Inherits="Addressbar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; font-style: normal; text-transform: uppercase; font-variant: normal; color: #FFFFFF">
    Enter your Source and Destination Here<br />
        <br />
        <br />
    </center>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script language="javascript" type="text/javascript">
    var directionsDisplay;
    var directionsService = new google.maps.DirectionsService();

    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(-34.397, 150.644);
        var myOptions =
        {
            zoom: 8,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("map"), myOptions);

        directionsDisplay.setMap(map);
        directionsDisplay.setPanel(document.getElementById('directionpanel'));

        var control = document.getElementById('control');
        control.style.display = 'block';


    }



    function calcRoute() {

        var start = document.getElementById('startvalue').value;
        var end = document.getElementById('endvalue').value;
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });

    }



    function Button1_onclick() {
        calcRoute();
    }

    window.onload = InitializeMap;
    </script>
    
<table id ="control">
<tr>
    
<td style="width: 442px">
<table>
<tr>
<td colspan="2" style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; font-style: normal; text-transform: uppercase; font-variant: normal; color: #FFFFFF">From:</td>
<td>
    <input id="startvalue" type="text" style="width: 305px" /><br />
    <br />
    </td>
</tr>
<tr>
<td style="font-family: 'Times New Roman', Times, serif; font-size: x-large; font-weight: bold; font-style: normal; text-transform: uppercase; font-variant: normal; color: #FFFFFF;" colspan="2">To:</td>
<td style="height: 26px"><input id="endvalue" type="text" style="width: 301px" /><br />
    <br />
    </td>
</tr>
<tr>
<td align ="right" style="text-align: center; width: 150px;">
    <input id="Button1" type="button" value="GetDirections" onclick="return Button1_onclick()" /></td>
<td align ="right" style="text-align: center; width: 239px;">
    &nbsp;</td>
</tr>
</table>
</td>
    <td>

    </td>
</tr>
<tr>
<td valign ="top" style="width: 447px" class="auto-style1">
<div id ="directionpanel"  style="height: 390px;overflow: auto; color: #FFFFFF;" ></div>
</td>
<td valign ="top">
<div id ="map" style="height: 390px; width: 489px"></div>
</td>
</tr>
</table>
</asp:Content>

