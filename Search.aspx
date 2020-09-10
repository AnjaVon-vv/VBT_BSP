<%@ Page Title="查询与规划" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="VBT_BSP.Search" %>

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

        option {
            color: #ddd;
        }

        .form-control {
            display: inline-block;
        }

        .width100 {
            width: 100%;
        }
    </style>

    <div style="margin: 5% 15%">
        <table class="width100">
            <tr>
                <td colspan="3" class="font">线路信息查询</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:DropDownList ID="routeList" runat="server" CssClass="btn button dropdown-toggle width100">
                    </asp:DropDownList></td>
                <td width="17%"></td>
                <td align="center">
                    <asp:Button ID="routeBtn" Text="查询" runat="server" OnClick="routeBtn_Click" CssClass="btn button" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="font">周边站点及可乘线路查询</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:TextBox ID="stopTxt" runat="server" Placeholder="输入站名、地名或道路名" CssClass="form-control button" /></td>
                <td width="17%"></td>
                <td align="center">
                    <asp:Button ID="stopBtn" Text="查询" runat="server" OnClick="stopBtn_Click" CssClass="btn button" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    <% =stopTip %>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="font">路线规划【公交换乘查询】</td>
            </tr>
            <tr>
                <td align="right">
                    <div>
                        <span style="font-weight: bold">起点：</span>
                        <asp:TextBox ID="startTxt" runat="server" Placeholder="输入站名、地名或道路名" CssClass="form-control button" />
                    </div>
                    <div style="margin-top: 2%">
                        <span style="font-weight: bold">终点：</span>
                        <asp:TextBox ID="endTxt" runat="server" Placeholder="输入站名、地名或道路名" CssClass="form-control button" />
                    </div>
                </td>
                <td width="17%"></td>
                <td align="center">
                    <asp:Button ID="planBtn" Text="查询" runat="server" OnClick="planBtn_Click" CssClass="btn button" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    <% =planTip %>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
