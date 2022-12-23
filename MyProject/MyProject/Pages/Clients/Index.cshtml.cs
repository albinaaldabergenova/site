using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyProject.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientsInfo> listClients = new List<ClientsInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HotelClients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ClientsInfo clientsInfo = new ClientsInfo();
                                clientsInfo.id = "" + reader.GetInt32(0);
                                clientsInfo.name = reader.GetString(1);
                                clientsInfo.passportData = reader.GetString(2);
                                clientsInfo.email = reader.GetString(3);
								clientsInfo.phone = reader.GetString(4);
								clientsInfo.gender = reader.GetString(5);


								listClients.Add(clientsInfo);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientsInfo
    {
        public String id;
        public String name;
        public String passportData;
        public String email;
        public String phone;
        public String gender;
    }
}
