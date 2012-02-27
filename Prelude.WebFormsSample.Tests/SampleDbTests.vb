Imports System.Text
Imports Prelude.WebFormsSample.Core.PersonSection
Imports Prelude.WebFormsSample.Data.PersonSection
Imports System.Data.Entity.Infrastructure

<TestClass()>
Public Class SampleDbTests

    Dim _personEntities As IPersonEntities

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestInitialize()>
    Public Sub InitTests()
        _personEntities = New PersonEntities
    End Sub

    <TestMethod()>
    Public Sub Prove_ObjectQuery_AlwaysHitsDb()
        Dim actual = (From a In _personEntities.Address Where a.AddressID = 1).FirstOrDefault()

        actual = (From a In _personEntities.Address Where a.AddressID = 1).FirstOrDefault()

        Assert.IsInstanceOfType(actual, GetType(Address))
    End Sub

    <TestMethod()>
    Public Sub Prove_TryGetObjectByKey_HitsContextFirst()
        ' get an object checking context first, then going to db
        ' this method is discouraged
        Dim context = _personEntities.Context
        Dim objectCtx = CType(context, IObjectContextAdapter).ObjectContext
        Dim entityKeyValues As IEnumerable(Of KeyValuePair(Of String, Object)) = New KeyValuePair(Of String, Object)() {New KeyValuePair(Of String, Object)("AddressID", 1)}

        ' this test doesn't work because it wants to use the PersonModel.Address for some reason
        ' guess it's because it's looking to the EDMX definition, even though I'm specifying PersonEntities
        Dim key As New EntityKey("PersonEntities.Address", entityKeyValues)
        Dim actual As Address = Nothing
        'objectCtx.TryGetObjectByKey(key, actual)

        'objectCtx.TryGetObjectByKey(key, actual)

        'Assert.IsInstanceOfType(actual, GetType(Address))
    End Sub

    <TestMethod()>
    Public Sub Demo_Update_ExistingEntity()
        ' get an existing object, change state, save to db
        Dim actual = (From a In _personEntities.Address Where a.AddressID = 1).FirstOrDefault()
        Dim entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)

        ' setting the value to an identical value will keep the state as Unchanged, as it should
        actual.AddressLine1 = "test"
        entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)
        ' attempt to save context that only has unchanged entities will not hit db
        _personEntities.Context.SaveChanges()

        actual.AddressLine1 = New Guid().ToString()
        entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)
        _personEntities.Context.SaveChanges()
    End Sub

    <TestMethod()>
    Public Sub Demo_Insert_NewEntity()
        ' create a new object, save to db
        Dim actual = _personEntities.Address.Create()
        Dim entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)
        _personEntities.Address.Add(actual)
        entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)
        actual.AddressLine1 = "line1"
        actual.City = "City"
        actual.StateProvinceID = 79
        actual.PostalCode = "12345"

        ' set StoreGeneratedPattern to Computed for not-null fields that have a default value set in the db
        ' this enables you to not have to set these fields here, such as addressNew.ModifiedDate
        ' also note, if you don't do this for SQL2008 DateTime fields, EF will attempt to use the value 0001-01-01 12:00:00AM
        ' this value is valid for a DateTime2, so EF attempts to use a DateTime2 value when inserting into the DB,
        ' which results in the obscure DateTime2 error that seemed to pop up randomly

        entry = _personEntities.Context.Entry(actual)
        Debug.WriteLine(entry.State)
        _personEntities.Context.SaveChanges()

    End Sub


End Class
