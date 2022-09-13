alter table AddressBook
add dateAdded date

select * from AddressBook

update AddressBook
set dateAdded= Cast('2022-07-06' as date)
where firstname='Tushar';
update AddressBook
set dateAdded= Cast('2021-07-06' as date)
where firstname='Saran';
update AddressBook
set dateAdded= Cast('2020-07-06' as date)
where firstname='Madhukar';
update AddressBook
set dateAdded= Cast('2020-01-06' as date)
where firstname='Manasa';
update AddressBook
set dateAdded= Cast('2019-07-06' as date)
where firstname='Sumit';
update AddressBook
set dateAdded= Cast('2018-07-06' as date)
where firstname='Sai';

select * from addressbook where dateadded between cast('2019-01-01' as date) and cast('2020-01-01' as date)
