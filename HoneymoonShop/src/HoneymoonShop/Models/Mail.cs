using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using HoneymoonShop.Models.GebruikerModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Utils;

namespace HoneymoonShop.Models
{
    public class Mail
    {
        private static String OurEmail = "infohoneymoonshop@gmail.com";
        private static String OurPassword = "Keeskees01";

        public static void VerzendAfspraak(AfspraakMaken afspraakMaken)
        {
            var builder = new BodyBuilder();
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\images\mail.png";
            var banner = builder.LinkedResources.Add(path);
            banner.ContentId = MimeUtils.GenerateMessageId();
            System.Diagnostics.Debug.WriteLine(path);
            //var datum = afspraakMaken.Afspraak.Datum.ToString("MMMM dd, yyyy") + " om " + afspraakMaken.Afspraak.Tijd;
            var datum = "hi";
            builder.HtmlBody = string.Format(@"
<table style=""width:100%;"">
<tr>
<td>
<table style=""border-collapse: collapse; width:800px; margin: auto; "" >
<tr>
    <td colspan=""2""><img  style=""width:100%;"" src=""cid:{0}""> </td>
</tr>
<tr>
    <td style=""padding:20px; width:50%;"">
        <h1>Afspraak gemaakt!</h1>
        <p>Uw afspraak is gemaakt op:</p>
        <p>{1}</p>
    </td>

    <td style=""padding:20px; width:50%; background-color:#F0597C;"">
        <h4>Wilt u uw afspraak wijzigen?</h4>
        <p>Klik dan op de onderstaande link</p>
        <a href=""#"">honeymoonshop.nl/afspraak/wijzigen?verificationkey=86sab4ho84US84O</a>
    </td>
</tr>
<tr>
    <td colspan=""2"" style=""background-color:#FCE8E7; text-align:center; padding:20px;"" >
        <p>
            Korte Hoogstraat 4, 3011 GL Rotterdam  <strong>email</strong> info@honeymoonshop.nl <strong>tel</strong> (010) 412 61 43 <strong>whatsapp</strong> (06) 25 19 99 27 <br>
            <strong>Openingstijden </strong> <strong>MA </strong> 12.00-17.30  <strong>DI t/m VR </strong> 09.30-17.30  <strong>ZA </strong> 09.30-18.00 <strong>DI t/m VR</strong> 11.00-17.00
        </p>
    </td>
</tr>
</table>
</td>
</tr>
</table>", banner.ContentId, datum);

            //SendEmailAsync(afspraakMaken.Gebruiker.Emailadres, "Honeymoonshop afspraakbevestiging", builder);
            var sendEmailAsync = SendEmailAsync("rchandoe@gmail.com", "Honeymoonshop afspraakbevestiging", builder);
        }


        public static async Task SendEmailAsync(string email, string subject, BodyBuilder builder)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("HoneymoonShop", OurEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart("plain") {Text = message};
            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = OurEmail, // replace with valid value
                    Password = OurPassword // replace with valid value
                };

                client.LocalDomain = "smtp.gmail.com";
                // check your smtp server setting and amend accordingly:
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.Auto).ConfigureAwait(false);
                await client.AuthenticateAsync(credentials);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}