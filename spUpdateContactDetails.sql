create procedure spUpdateContactDetails
(
@firstname varchar(30),
@lastname varchar(30),
@address varchar(50),
@city varchar(30),
@state varchar(30),
@zip int,
@phonenumber bigint,
@email varchar(50),
@addressbookname varchar(30)
)
as
begin
update a
set a.Address= @address,a.City=@city,a.State= @state,a.Zip=@zip,a.PhoneNumber=@phonenumber,a.email= @email
from AddressBook a
join addressBookMapper b 
on a.contactid= b.contactid
join AddressBookNames c
on c.addressBookId = b.addressbookid
where a.firstName=@firstname and a.lastname=@lastname and c.addressBookName= @addressbookname
end
