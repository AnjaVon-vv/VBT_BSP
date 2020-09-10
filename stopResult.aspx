<%@ Page Title="查询结果" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stopResult.aspx.cs" Inherits="VBT_BSP.stopResult" %>

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
        <% =sn %>
    </div>
    <asp:DataGrid ID="Sinfo" runat="server" AutoGenerateColumns="False" CellPadding="0" Width="100%">
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
        <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#dddddd" BackColor="#333333"></HeaderStyle>
        <Columns>
            <asp:BoundColumn DataField="Stype" HeaderText="站点类型"></asp:BoundColumn>
            <asp:BoundColumn DataField="around" HeaderText="周边地标"></asp:BoundColumn>
            <asp:BoundColumn DataField="road" HeaderText="所在道路"></asp:BoundColumn>
            <asp:BoundColumn DataField="Sstatus" HeaderText="运营状态"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>

    <div class="font">
        可乘线路【点击可查询线路信息】
    </div>
    <div>
        <% =routes %>
    </div>

</asp:Content>
