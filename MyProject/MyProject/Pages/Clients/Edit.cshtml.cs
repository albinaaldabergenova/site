using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyProject.Pages.Clients
{
    public class EditModel : PageModel
    {
        public ClientsInfo clientsInfo = new ClientsInfo();
        public String errorMessenge = "";
        public String successMessenge = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {

                String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HotelClients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientsInfo.id = "" + reader.GetInt32(0);
								clientsInfo.name = reader.GetString(1);
								clientsInfo.passportData = reader.GetString(2);
								clientsInfo.email = reader.GetString(3);
								clientsInfo.phone = reader.GetString(4);
								clientsInfo.gender = reader.GetString(5);
							}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessenge = ex.Message;
            }
        }

        public void OnPost()
        {
            clientsInfo.id = Request.Form["id"];
            clientsInfo.name = Request.Form["name"];
            clientsInfo.passportData = Request.Form["passportData"];
            clientsInfo.email = Request.Form["email"];
            clientsInfo.phone = Request.Form["phone"];
            clientsInfo.gender = Request.Form["gender"];

			if (clientsInfo.name.Length == 0 || clientsInfo.passportData.Length == 0 || clientsInfo.email.Length == 0 || clientsInfo.phone.Length == 0 || clientsInfo.gender.Length == 0)
			{
				errorMessenge = "Не все поля заполнены!";
                return;
            }

            try
            {
                String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=HotelClients;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = @"UPDATE clients SET name=@name, 
                                passportData=@passportData,
                                email=@email, 
                                phone=@phone, 
                                gender=@gender 
                                WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientsInfo.name);
                        command.Parameters.AddWithValue("@passportData", clientsInfo.passportData);
						command.Parameters.AddWithValue("@email", clientsInfo.email);
						command.Parameters.AddWithValue("@phone", clientsInfo.phone);
						command.Parameters.AddWithValue("@gender", clientsInfo.gender);
						command.Parameters.AddWithValue("@id", clientsInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            Response.Redirect("/Clients/Index");
        }
    }
}
