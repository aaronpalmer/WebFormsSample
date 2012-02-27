Imports Prelude.WebFormsSample.Core.PersonSection

Namespace Interfaces
    Public Interface IAddressRepository

        Function GetAddressByID(ByVal id As Integer) As Address
        Function GettAddressFromContext(ByVal id As Integer) As Address

    End Interface
End Namespace
