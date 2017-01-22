<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MCCOYC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        li {
            padding: 0;
        }

        .list-group-item {
            padding: 0;
        }

        li a:hover {
            text-decoration: none;
        }
    </style>

    <div runat="server" id="Jumbotron" class="jumbotron">
        <h1>MCCOYC Registration</h1>
        <p class="lead">Are you a youth, servant or parent? Use our new online registration tool to secure your spot!</p>
        <p>
            <asp:Button ID="Register" runat="server" PostBackUrl="~/Account/Register.aspx" CssClass="btn btn-primary btn-lg" Text="Sign Up &raquo;"></asp:Button>
            <asp:Button runat="server" ID="RegisterSelf" Visible="false" PostBackUrl="~/Account/Register.aspx" CssClass="btn btn-primary btn-lg" Text="Register Myself"></asp:Button>
        </p>
    </div>

    <div id="YouthView" ng-controller="YouthViewController">
        <ul class="list-group">
            <h2 ng-show="youth">My Registered Youth</h2>
            <li ng-repeat="youth in listOfYouth" class="list-group-item">
                <a class="display:block" ng-href="{{youth.path}}">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-11 col-sm-9 col-xs-8">
                                <asp:CheckBox CssClass="form-control" runat="server" ng-show="youth.Admin" Text="{{youth.ID}}" OnCheckedChanged="ApproveYouth" />
                                <h5>{{youth.Name}} </h5>
                                <p>{{youth.Email}} </p>
                            </div>
                            <div class="col-md-1 col-sm-3 col-xs-4" style="margin-top:25px">
                                <span class="badge">{{youth.Status}}</span>
                            </div>
                        </div>
                    </div>
                </a>
            </li>
        </ul>
    </div>

    <div class="row">
        <div class="col-md-4 hidden-lg hidden-md hidden-sm hidden-xs">
            <h2>Instructions to register:</h2>
            <p>
<ul type="1"><li>Hello</li><li>hello 2</li></ul>

            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 hidden-lg hidden-md hidden-sm hidden-xs">
            <h2>Learn about MCCOYC.</h2>
            <p>
                PLACE WEBSITE LINK HERE
                ADD ABOUT
            </p>
            <p>
                <a class="btn btn-default" href="http://www.mccoyconline.org/" target="_blank">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 hidden-lg hidden-md hidden-sm hidden-xs">
            <h2>Come have fun!</h2>
            <p>
              TSHIRT COMPETITON INFORMATION
              OTHER MISCELLANIOUS INFORMATION GOES HERE
            </p>
            <p>
                <a class="btn btn-default" href="mailto:mccoyconline@gmail.com?subject=2016 MCCOYC T-Shirt Contest&body=Name:%0D%0AChurch:%0D%0APhone Number:%0D%0A">Send us your design! &raquo;</a>
            </p>
        </div>
    </div>


    <script>
        angular.module('MCCOYC', [])
        .controller('YouthViewController', ['$scope', '$http', function ($scope, $http) {
            $http.get('/api/YouthParentConfirm').then(function (listOfYouth) {
                $scope.listOfYouth = listOfYouth.data;
            });
        }]);
    </script>

</asp:Content>
