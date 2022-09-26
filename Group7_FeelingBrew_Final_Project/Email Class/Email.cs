using System;
using System.Net;
using System.Net.Mail;

namespace Group7_FeelingBrew_Final_Project.Email_Class
{
    public class Email
    {
        public void SendEmail(string body, string emailSubject)
        {
            try                                                                                                                            //Use try catch block to catch any errors if errors occur
            {
                NetworkCredential login = new NetworkCredential("feelingbrewapp@gmail.com", "eqvv cfdn pehi nfnf");                     //Created new email address and gave this device and app permission to log into account and send email
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = login;
                MailMessage alert = new MailMessage();
                alert.To.Add("pietercoetzee987@gmail.com");
                alert.From = new MailAddress("feelingbrewapp@gmail.com");
                alert.Subject = emailSubject;
                alert.Body = body;
                client.Send(alert);

            }
            catch (Exception error)
            {
                Console.WriteLine("Can't send email..." + error.Message);                                                                  //Display appropriate message on console if email could not be sent 
            }

        }
    }
}