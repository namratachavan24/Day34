namespace AddressBook_ADO.NET
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the AddressBook DataBase problem");
            AddressBookOperations addressBookOperations = new AddressBookOperations();
            bool check = true;
            while (check)
            {
                Console.WriteLine("\nPlease press 1 to get all contact details");
                Console.WriteLine("Please press 2 to get contact details for given date range/city/state");
                Console.WriteLine("Please press 3 to add contact details");
                Console.WriteLine("press any other key to exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1"
                        try
                        {
                            List<AddressBookContactDetails> contactDetailsList = addressBookOperations.GetAllContactDetails();
                            contactDetailsList.ForEach(contactDetails =>
                            {
                                Console.WriteLine("ContactID:- " + contactDetails.contactID + " First Name:- " + contactDetails.firstName + " Last Name:- " + contactDetails.lastName + " Address:- " + contactDetails.address + " City:- " + contactDetails.city + " State:- " + contactDetails.state + " Zip:- " + contactDetails.zip + " phone number:- " + contactDetails.phoneNo + " Email:- " + contactDetails.eMail);
                                Console.WriteLine("address Book Name id: -" + contactDetails.addressBookNameId + " address book name: -" + contactDetails.addressBookName);
                                Console.WriteLine("Type id: -" + contactDetails.typeId + " type name: -" + contactDetails.typeName);
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Please press 1 for date range, 2 for state and 3 for city");
                            int task = Convert.ToInt32(Console.ReadLine());
                            List<AddressBookContactDetails> contactDetailsListInDateRange = addressBookOperations.GetAllContactDetailsWithConditions(task);
                            contactDetailsListInDateRange.ForEach(contactDetails =>
                            {
                                Console.WriteLine("ContactID:- " + contactDetails.contactID + " First Name:- " + contactDetails.firstName + " Last Name:- " + contactDetails.lastName + " Address:- " + contactDetails.address + " City:- " + contactDetails.city + " State:- " + contactDetails.state + " Zip:- " + contactDetails.zip + " phone number:- " + contactDetails.phoneNo + " Email:- " + contactDetails.eMail + " Date:-" + contactDetails.dateAdded);
                             });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        //UC20 Adding Contact Details into Database
                        AddressBookContactDetails contactDetails = new AddressBookContactDetails();
                        contactDetails.firstName = "Rachael";
                        contactDetails.lastName = "Jai";
                        contactDetails.address = "Sector14";
                        contactDetails.city = "new Delhi";
                        contactDetails.state = "unavailable";
                        contactDetails.zip = 111234;
                        contactDetails.phoneNo = 8199929262;
                        contactDetails.eMail = "akshatjain@gmail.com";
                        contactDetails.dateAdded = Convert.ToDateTime("2020-08-01");
                        contactDetails.addressBookName = "D";
                        bool result = addressBookOperations.AddingContactDetailsInDatabase(contactDetails);
                        Console.WriteLine(result == true ? "Details are added into database successfully" : "Details are not written in database");
                        break;
                    default:
                        check = false;
                        break;
                }
            }
        }
    }
}
