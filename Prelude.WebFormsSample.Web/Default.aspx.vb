Imports Prelude.WebFormsSample.Core.PersonSection
Imports System.Data.Entity.Infrastructure
Imports Prelude.WebFormsSample.Core.Interfaces

Public Class _Default
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' get an object from DB every time
        Dim address123 As Address = IoC.Resolve(Of IPersonRepository).GetAddressByID(123)

        lblAddress.Text = address123.AddressLine1 & "<BR/>" & address123.City & ", " & address123.StateProvince.StateProvinceCode & " " & address123.PostalCode

        address123.AddressLine1 = "3911 Hartzdale Drive"
        address123.City = "Camp Hill"
        address123.StateProvinceID = 59
        address123.PostalCode = "17011"

        'PersonEntities.Context.SaveChanges()

        Dim address234 As Address = IoC.Resolve(Of IAddressRepository).GettAddressFromContext(123)

        lblAddress2.Text = address234.AddressLine1 & "<BR/>" & address234.City & ", " & address234.StateProvince.StateProvinceCode & " " & address234.PostalCode

#If SkipOldCode Then
       ' get an object checking context first, then going to db
        ' this method is discouraged
        Dim context = PersonEntities.Context
        Dim objectCtx = CType(context, IObjectContextAdapter).ObjectContext
        Dim entityKeyValues As IEnumerable(Of KeyValuePair(Of String, Object)) = New KeyValuePair(Of String, Object)() {New KeyValuePair(Of String, Object)("AddressID", 234)}
        Dim key As New EntityKey("PersonEntities.Address", entityKeyValues)
        Dim address234 As Address = Nothing
        objectCtx.TryGetObjectByKey(key, address234)

         get an existing object, change state, save to db
        Dim address1 = PersonRepository.GetAddressByID(1)
        Dim entry = PersonEntities.Context.Entry(address1)
        Debug.WriteLine(entry.State)

         Note: setting the value to an identical value will keep the state as Unchanged, as it should
        address1.AddressLine1 = "test"
        entry = PersonEntities.Context.Entry(address1)
        Debug.WriteLine(entry.State)

        address1.AddressLine1 = New Guid().ToString()
        entry = PersonEntities.Context.Entry(address1)
        Debug.WriteLine(entry.State)

        PersonEntities.Context.SaveChanges()

        ' create a new object, save to db
        Dim addressNew = PersonEntities.Address.Create()
        Dim entry = PersonEntities.Context.Entry(addressNew)
        Debug.WriteLine(entry.State)
        PersonEntities.Address.Add(addressNew)

        entry = PersonEntities.Context.Entry(addressNew)
        Debug.WriteLine(entry.State)
        addressNew.AddressLine1 = "3907 Hartzdale Drive"
        addressNew.City = "Camp Hill"
        addressNew.StateProvinceID = 59
        addressNew.PostalCode = "17011"

        ' set StoreGeneratedPattern to Computed for not-null fields that have a default value set in the db
        ' this enables you to not have to set these fields here, such as addressNew.ModifiedDate
        ' also note, if you don't do this for SQL2008 DateTime fields, EF will attempt to use the value 0001-01-01 12:00:00AM
        ' this value is valid for a DateTime2, so EF attempts to use a DateTime2 value when inserting into the DB,
        ' which results in the obscure DateTime2 error that seemed to pop up randomly

        entry = PersonEntities.Context.Entry(addressNew)
        Debug.WriteLine(entry.State)
        PersonEntities.Context.SaveChanges()
#End If

    End Sub

End Class