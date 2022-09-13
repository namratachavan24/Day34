create Procedure spGetAllContacts
as
Begin
select a.contactid,a.firstName,a.lastName,a.Address,a.City,a.State,a.Zip,a.PhoneNumber,a.email,c.addressBookId,c.addressBookName,e.typeid,e.typename
from AddressBook a
join addressBookMapper b
on a.contactid= b.contactid
join AddressBookNames c
on b.addressbookid= c.addressBookId
join typeMapper d
on d.contactid= a.contactid
join TypesOfContacts e
on e.typeid= d.typeid
end


exec spGetAllContacts
