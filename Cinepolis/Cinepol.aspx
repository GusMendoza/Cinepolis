<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cinepol.aspx.cs" Inherits="Cinepol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap-datetimepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row" style="height: 340px;">
        <div class="col-sm-6">
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <asp:PlaceHolder runat="server" ID="phuno" />
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <asp:PlaceHolder runat="server" ID="phdos" />
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <div class="col-sm-6">
            <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <asp:PlaceHolder runat="server" ID="phtres" />
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <asp:PlaceHolder runat="server" ID="phcuatro" />
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel2" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel2" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-4">
            <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" />
        </div>
        <div class="col-xs-4">
        </div>
        <div class="col-xs-4">
        </div>
        <div class="col-xs-4">
        </div>
        <div class="col-xs-4">
        </div>
        <div class="col-xs-4">
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:PlaceHolder runat="server" ID="phpelis" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScrips" runat="Server">
    <script src="js/moment-with-locales.js"></script>
    <script src="js/bootstrap-datetimepicker.js"></script>
    <script>
        $(document).ready(function () {
            $('#body_txtFecha').datetimepicker({
                format: 'L',
                locale: 'es'
            });
        });
    </script>
</asp:Content>

