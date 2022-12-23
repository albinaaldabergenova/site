using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyProject.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientsInfo clientsInfo = new ClientsInfo();
        public String errorMessenge = "";
        public String successMessenge = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {
            clientsInfo.name = Request.Form["name"];
            clientsInfo.passportData = Request.Form["passportData"];
            clientsInfo.email = Request.Form["email"];
            clientsInfo.phone = Request.Form["phone"];
            clientsInfo.gender = Request.Form["gender"];

            if(clientsInfo.name.Length == 0 || clientsInfo.passportData.Length == 0 || clientsInfo.email.Length == 0 || clientsInfo.phone.Length == 0 || clientsInfo.gender.Length == 0)
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
                    String sql =    @"INSERT INTO clients
                                    (name, passportData, email, phone, gender) VALUES
                                    (@name, @passportData, @email, @phone, @gender)"; 

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
						command.Parameters.AddWithValue("@name", clientsInfo.name);
						command.Parameters.AddWithValue("@passportData", clientsInfo.passportData);
						command.Parameters.AddWithValue("@email", clientsInfo.email);
						command.Parameters.AddWithValue("@phone", clientsInfo.phone);
						command.Parameters.AddWithValue("@gender", clientsInfo.gender);

						command.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                errorMessenge = ex.Message;
                return;
            }

			clientsInfo.name = "";
			clientsInfo.passportData = "";
			clientsInfo.email = "";
			clientsInfo.phone = "";
			clientsInfo.gender = "";

			successMessenge = "Новый посетитель добавлен";

            Response.Redirect("/Clients/Index");

        }
    }
}
