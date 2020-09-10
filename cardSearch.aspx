<%@ Page Title="会员卡查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cardSearch.aspx.cs" Inherits="VBT_BSP.cardSearch" %>

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
        会员卡余额、类型、折扣查询
    </div>


</asp:Content>
