<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VBT_BSP.login" %>

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
            margin-bottom: 5px;
            font-size: 20px;
            font-weight: bold;
            color: #454545;
        }

        .button {
            background-color: #555;
            color: #ddd;
        }

            .button:hover {
                color: #fff;
            }
    </style>

    <div class="font">
        管理员登录
        增删改
    </div>

</asp:Content>
