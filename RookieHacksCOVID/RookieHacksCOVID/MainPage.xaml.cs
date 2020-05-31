using RookieHacksCOVID.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RookieHacksCOVID
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MongoService ms;
        public MainPage()
        {
            InitializeComponent();

            ms = new MongoService();
        }

        private async void checkPatientButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(pid2.Text);

            Patient p = await ms.GetTaskById(long.Parse(pid2.Text));

            if (p==null)
            {
                idCheck.Text = "Not Found";
                emailCheck.Text = "N.A.";
                emailPatientButton.IsEnabled = false;
            }
            else
            {
                idCheck.Text = p.Name;
                emailCheck.Text = p.Email;
                emailPatientButton.IsEnabled = true;
            }
            covidStatus.Text = p.CStatus;
        }

        private async void addPatientButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(name.Text + " " + pid1.Text + " " + cstatus.Text + " " + email.Text);

            Patient p = new Patient { Id = long.Parse(pid1.Text), Name = name.Text, Email = email.Text, CStatus = cstatus.Text };
            if (await ms.GetTaskById(long.Parse(pid1.Text)) == null) await ms.CreateTask(p);
            else await ms.UpdateTask(p);
            emailSend(p);
            resetAll();
        }    

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            resetAll();
        }

        private async void emailPatientButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                Patient p = await ms.GetTaskById(long.Parse(pid2.Text));
                emailSend(p);                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed", ex.Message, "OK");
            }
        }

        private void emailSend(Patient p)
        {
            try
			{
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress("GMAIL ADDRESS");
				mail.To.Add(p.Email);
				mail.Subject = "COVID-19 Status";
				mail.Body = "Here are your details:\n\nName: " + p.Name + "\nPhone Number: " + p.Id + "\nCOVID-19 Status: " + p.CStatus;

				SmtpServer.Port = 587;
				SmtpServer.Host = "smtp.gmail.com";
				SmtpServer.EnableSsl = true;
				SmtpServer.UseDefaultCredentials = false;
				SmtpServer.Credentials = new System.Net.NetworkCredential("ADD GMAIL ADDRESS", "GMAIL PASSWORD");

				SmtpServer.Send(mail);
				resetAll();
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Failed to send email", ex.Message, "OK");
			}
        }

        private void resetAll()
        {
            name.Text = "";
            pid1.Text = "";
            email.Text = "";
            cstatus.Text = "";
            pid2.Text = "";
            idCheck.Text = "";
            emailCheck.Text = "";
            covidStatus.Text = "";
            emailPatientButton.IsEnabled = false;
        }
    }
}