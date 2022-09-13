using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBook_ADO.NET
{
    public class AddressBookOperations
    {
        DBConnection dBConnection = new DBConnection();
        public List<AddressBookContactDetails> GetAllContactDetails()
        {
            List<AddressBookContactDetails> contactDetailsList = new List<AddressBookContactDetails>();
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllContacts", connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBookContactDetails contactDetails = new AddressBookContactDetails();
                            contactDetails.contactID = dr.GetInt32(0);
                            contactDetails.firstName = dr.GetString(1);
                            contactDetails.lastName = dr.GetString(2);
                            contactDetails.address = dr.GetString(3);
                            contactDetails.city = dr.GetString(4);
                            contactDetails.state = dr.GetString(5);
                            contactDetails.zip = dr.GetInt32(6);
                            contactDetails.phoneNo = dr.GetInt64(7);
                            contactDetails.eMail = dr.GetString(8);
                            contactDetails.addressBookNameId = dr.GetInt32(9);
                            contactDetails.addressBookName = dr.GetString(10);
                            contactDetails.typeId = dr.GetInt32(11);
                            contactDetails.typeName = dr.GetString(12);
                            contactDetailsList.Add(contactDetails);
                        }
                        dr.Close();
                        connection.Close();
                        return contactDetailsList;
                    }
                    else
                    {
                        throw new Exception("No data found in the database");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public bool UpdateContactDetailsInDataBase(AddressBookContactDetails contactDetails)
        {
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateContactDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", contactDetails.firstName);
                    command.Parameters.AddWithValue("@lastname", contactDetails.lastName);
                    command.Parameters.AddWithValue("@address", contactDetails.address);
                    command.Parameters.AddWithValue("@city", contactDetails.city);
                    command.Parameters.AddWithValue("@state", contactDetails.state);
                    command.Parameters.AddWithValue("@zip", contactDetails.zip);
                    command.Parameters.AddWithValue("@phonenumber", contactDetails.phoneNo);
                    command.Parameters.AddWithValue("@email", contactDetails.eMail);
                    command.Parameters.AddWithValue("@addressbookname", contactDetails.addressBookName);
                    connection.Open();
                    //result contain no of affected rows as Execute Non Query gives no of affected rows after query
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AddressBookContactDetails GettingUpdatedDetails(AddressBookContactDetails contact)
        {
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    string query = "Select a.firstname,a.lastname,a.address,a.city,a.state,a.zip,a.phonenumber,a.email,c.addressbookname from addressbook a join addressbookmapper b on a.contactid=b.contactid join addressbooknames c on c.addressbookid=b.addressbookid where a.firstname=@firstname and a.lastname=@lastname and c.addressbookname=@addressbookname";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@firstname", contact.firstName);
                    command.Parameters.AddWithValue("@lastname", contact.lastName);
                    command.Parameters.AddWithValue("@addressbookname", contact.addressBookName);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBookContactDetails contactDetails = new AddressBookContactDetails();
                            contactDetails.firstName = dr.GetString(0);
                            contactDetails.lastName = dr.GetString(1);
                            contactDetails.address = dr.GetString(2);
                            contactDetails.city = dr.GetString(3);
                            contactDetails.state = dr.GetString(4);
                            contactDetails.zip = dr.GetInt32(5);
                            contactDetails.phoneNo = dr.GetInt64(6);
                            contactDetails.eMail = dr.GetString(7);
                            contactDetails.addressBookName = dr.GetString(8);
                            return contactDetails;
                        }
                        dr.Close();                   
                        connection.Close();
                        return null;
                    }
                    else
                    {
                        throw new Exception("No data found in the database");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<AddressBookContactDetails> GetAllContactDetailsForParticularDateRange()
        {
            List<AddressBookContactDetails> contactDetailsList = new List<AddressBookContactDetails>();
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("select * from addressbook where dateadded between cast('2019-01-01' as date) and cast('2020-01-01' as date)", connection);                 
                    connection.Open();      
                    SqlDataReader dr = command.ExecuteReader();                 
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {               
                            AddressBookContactDetails contactDetails = new AddressBookContactDetails();
                            contactDetails.firstName = dr.GetString(0);
                            contactDetails.lastName = dr.GetString(1);
                            contactDetails.address = dr.GetString(2);
                            contactDetails.city = dr.GetString(3);
                            contactDetails.state = dr.GetString(4);
                            contactDetails.zip = dr.GetInt32(5);
                            contactDetails.phoneNo = dr.GetInt64(6);
                            contactDetails.eMail = dr.GetString(7);
                            contactDetailsList.Add(contactDetails);
                        }
                        dr.Close();                      
                        connection.Close();                      
                        return contactDetailsList;
                    }
                    else
                    {
                        throw new Exception("No data found in the database");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<AddressBookContactDetails> GetAllContactDetailsWithConditions(int task)
        {
            List<AddressBookContactDetails> contactDetailsList = new List<AddressBookContactDetails>();           
            SqlConnection connection = dBConnection.GetConnection();
            string query="0";          
            try
            {
                using (connection)
                {
                    if (task == 1)
                    {
                         query= "select * from addressbook where dateadded between cast('2019-01-01' as date) and getdate()";
                    }
                    if (task == 2)
                    {                       
                         query= "select * from addressbook where State='Telangana'";
                    }
                    if (task == 3)
                    {                      
                        query= "select * from addressbook where City='Aurangabad'";
                    }                  
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();               
                    SqlDataReader dr = command.ExecuteReader();                   
                    if (dr.HasRows)
                    {                     
                       while (dr.Read())
                        {                          
                            AddressBookContactDetails contactDetails = new AddressBookContactDetails();
                            contactDetails.firstName = dr.GetString(0);
                            contactDetails.lastName = dr.GetString(1);
                            contactDetails.address = dr.GetString(2);
                            contactDetails.city = dr.GetString(3);
                            contactDetails.state = dr.GetString(4);
                            contactDetails.zip = dr.GetInt32(5);
                            contactDetails.phoneNo = dr.GetInt64(6);
                            contactDetails.eMail = dr.GetString(7);
                            contactDetails.contactID = dr.GetInt32(8);
                            contactDetails.dateAdded = dr.GetDateTime(9);
                            //adding details in contact details list
                            contactDetailsList.Add(contactDetails);
                        }                        
                        dr.Close();                      
                        connection.Close();                      
                        return contactDetailsList;
                    }
                    else
                    {
                        throw new Exception("No data found in the database");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    
        public bool AddingContactDetailsInDatabase(AddressBookContactDetails contactDetails)
        {
            SqlConnection connection = dBConnection.GetConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "InsertingData";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", contactDetails.firstName);
                    command.Parameters.AddWithValue("@lastname", contactDetails.lastName);
                    command.Parameters.AddWithValue("@address", contactDetails.address);
                    command.Parameters.AddWithValue("@city", contactDetails.city);
                    command.Parameters.AddWithValue("@state", contactDetails.state);
                    command.Parameters.AddWithValue("@zip", contactDetails.zip);
                    command.Parameters.AddWithValue("@phonenumber", contactDetails.phoneNo);
                    command.Parameters.AddWithValue("@email", contactDetails.eMail);
                    command.Parameters.AddWithValue("@dateadded", contactDetails.dateAdded);
                    command.Parameters.AddWithValue("@addressbookname", contactDetails.addressBookName);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
