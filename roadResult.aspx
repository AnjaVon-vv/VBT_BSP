<%@ Page Title="查询结果" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="roadResult.aspx.cs" Inherits="VBT_BSP.roadResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        form {
            height: 100%;
        }

        footer {
            position: fixed;
            bottom: 0;
        }

        .font {
            margin-top: 3%;
            margin-bottom: 5px;
            font-size: 20px;
            font-weight: bold;
            color: #454545;
        }

        .button {
            background-color: #555;
            color: #ddd;
            margin: 3%;
        }

            .button:hover {
                color: #fff;
            }
    </style>

    <div class="font">
        <% =tip %>
    </div>
    <div>
        <% =stops %>
    </div>

</asp:Content>
