using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public interface INotificationService
    {
        bool SendNotification(string deviceInfo, string message);
    }

    public class EmailService : INotificationService
    {
        public bool SendNotification(string deviceInfo, string message)
        {
            Console.WriteLine($"Email sent to {deviceInfo} with message:{message}");
            return true;
        }
    }

    public class SmsNotification : INotificationService
    {
        public bool SendNotification(string deviceInfo, string message)
        {
            Console.WriteLine($"Sms sent to {deviceInfo} with message:{message}");
            return true;
        }
    }
   

    public class NotificationService
    {
        private readonly INotificationService _notificationService;
        public NotificationService(INotificationService service)
        {
            this._notificationService = service;
        }

        public void NotifyUser(string deviceInfo, string message) {
        //Simulate sending a notification
        _notificationService.SendNotification(deviceInfo, message);
        }
    }
}



    