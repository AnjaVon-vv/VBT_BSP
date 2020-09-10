<%@ Page Title="线路信息" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="routeResult.aspx.cs" Inherits="VBT_BSP.routeResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .font {
            margin-top: 3%;
            margin-bottom: 5px;
            font-size: 20px;
            font-weight: bold;
            color: #454545;
        }

        form {
            height: 100%;
        }

        footer {
            position: fixed;
            bottom: 0;
        }
    </style>
    <div>
        <div class="font">
            <% =rn %>
        </div>
        <asp:DataGrid ID="Rinfo" runat="server" AutoGenerateColumns="False" CellPadding="0" Width="100%">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            <HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#dddddd" BackColor="#333333"></HeaderStyle>
            <Columns>
                <asp:BoundColumn DataField="Rtype" HeaderText="线路类型"></asp:BoundColumn>
                <asp:BoundColumn DataField="Rnum" HeaderText="配车数量"></asp:BoundColumn>
                <asp:BoundColumn DataField="fare" HeaderText="票价"></asp:BoundColumn>
                <asp:BoundColumn DataField="FLtime" HeaderText="首末班车时间"></asp:BoundColumn>
                <asp:BoundColumn DataField="gap" HeaderText="平均发车间隔/min"></asp:BoundColumn>
                <asp:BoundColumn DataField="night" HeaderText="有无夜班车"></asp:BoundColumn>
                <asp:BoundColumn DataField="FLstop" HeaderText="行驶区间"></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
    </div>

    <div class="font">
        途径站点
    </div>
    <div style="margin: 1% 7%;">
        <% =path %>
    </div>

</asp:Content>
