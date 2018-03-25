using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCosmos.AzureSQL
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class AddressRepository
    {
        SQLSetting SqlSetting;
        public AddressRepository()
        {
            SqlSetting = new SQLSetting();
        }

        public List<Address> GetAllAddress()
        {
            List<Address> AddressList = new List<Address>();
            SqlCommand cmd = new SqlCommand("select * from[SalesLT].[Address]", SqlSetting.GetConnection());
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
               AddressList.Add(new Address
               {
                   AddressID = (int)rd["AddressID"],
                   AddressLine1 = rd["AddressLine1"] != DBNull.Value ? (string)rd["AddressLine1"] : null,
                   AddressLine2 = rd["AddressLine2"] != DBNull.Value ?(string)rd["AddressLine2"]: null,
                   City = (string)rd["City"],
                   CountryRegion = (string)rd["CountryRegion"],
                   PostalCode = (string)rd["PostalCode"],
                   StateProvince = (string)rd["StateProvince"],
                   ModifiedDate = (DateTime)rd["ModifiedDate"]
               });
            }
            SqlSetting.CloseConnection();
            return AddressList;
        }

        public bool UpdateAddressLine(string AddressLine , int AddressID)
        {
            SqlCommand cmd = new SqlCommand("update[SalesLT].[Address] set  AddressLine2 = @AddressLine2 where AddressID = @AddressID", SqlSetting.GetConnection());
            cmd.Parameters.AddRange(new SqlParameter[]  
            {
                new SqlParameter("@AddressLine2", AddressLine),
                new SqlParameter("@AddressID", AddressID)
            });

            bool result = cmd.ExecuteNonQuery() >= 1 ? true : false;
            SqlSetting.CloseConnection();
            return result;
        }

        public bool InsertAddress(Address Item)
        {

            SqlCommand cmd = new SqlCommand("insert into[SalesLT].[Address] values(@AddressLine1, @AddressLine2, @City ,@StateProvince , @CountryRegion, @PostalCode , @rowguid, @ModifiedDate)", SqlSetting.GetConnection());
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@AddressLine1", Item.AddressLine1),
                new SqlParameter("@AddressLine2", Item.AddressLine2),
                new SqlParameter("@City", Item.City),
                new SqlParameter("@CountryRegion", Item.CountryRegion),
                new SqlParameter("@ModifiedDate", Item.ModifiedDate),
                new SqlParameter("@PostalCode", Item.PostalCode),
                new SqlParameter("@rowguid", Item.rowguid),
                new SqlParameter("@StateProvince", Item.StateProvince)
            });

                bool result = cmd.ExecuteNonQuery() >= 1 ? true : false;
                SqlSetting.CloseConnection();
                return result;
        }

        public bool DeleteAddress(int Id)
        {
            SqlCommand cmd = new SqlCommand("delete from [SalesLT].[Address] where AddressID = @Id", SqlSetting.GetConnection());
            cmd.Parameters.AddWithValue("@Id", Id);
            bool result = cmd.ExecuteNonQuery() >= 1 ? true : false;
            SqlSetting.CloseConnection();
            return result;
        }

    }
}
