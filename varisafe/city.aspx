<%@ Page Language="vb" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html>
<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim db As New System.Data.SqlClient.SqlConnection("server=SQLB50.newtekwebhosting.com;Network Library=DBMSSOCN;Initial Catalog=varisafe_db;User ID=varisafe_dba;Password=hIas2!97; Connection Timeout=600")
        Dim sql = "INSERT INTO tblCity (City) VALUES ('Dundas')"
        Dim cmd As New System.Data.SqlClient.SqlCommand(sql, db)

        Try
            db.Open()
            cmd.ExecuteNonQuery()
            Response.Write("Insert Done")
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            db.Close()
        End Try
    End Sub


</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>DB Execute</h1>
        <div>
        </div>
    </form>
</body>
</html>
