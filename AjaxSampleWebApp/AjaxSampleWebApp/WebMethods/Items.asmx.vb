Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization


' To prohibit this Web Service to be called from script, using ASP.NET AJAX, comment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Items
    Inherits System.Web.Services.WebService

    Dim inventory As New List(Of String)(New String() {"Item Created", "Item Attended", "Item Consumed", "Item Released",
                                         "Item Missed", "Item Registered", "Item Deleted", "Item Submitted",
                                          "Item Purchased", "Item Received"})

    <WebMethod(Description:="Get the next 5 items", EnableSession:=True)> _
    <Script.Services.ScriptMethod(ResponseFormat:=Script.Services.ResponseFormat.Json, XmlSerializeString:=False, UseHttpGet:=True)>
    Public Function GetNextFiveItems() As String
        Dim jss As New JavaScriptSerializer()
        Dim response As Dictionary(Of String, String)
        Dim itemResults = GetNextFiveFromInventory()
        Return jss.Serialize(itemResults)
    End Function

    Public Function GetNextFiveFromInventory() As List(Of String)
        Dim copyOfInventory = inventory
        Dim list As New List(Of String)
        Dim randomIndex As Integer
        Dim i = 1
        While i <= 5
            randomIndex = CInt(Math.Ceiling(Rnd() * (copyOfInventory.Count - 1)))
            list.Add(copyOfInventory(randomIndex))
            copyOfInventory.RemoveAt(randomIndex)
            i += 1
        End While
        Return list
    End Function

End Class
