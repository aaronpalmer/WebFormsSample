Imports Prelude.WebFormsSample.Core.Interfaces
Imports Prelude.WebFormsSample.Core.PersonSection


Public Class AddressControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim address123 As Address = IoC.Resolve(Of IPersonRepository).GetAddressByID(123)

        'Dim address123 As Address = PersonRepository.GetAddressByID(123)

        lblAddress.Text = address123.AddressLine1 & "<BR/>" & address123.City & ", " & address123.StateProvince.StateProvinceCode & " " & address123.PostalCode


    End Sub

End Class