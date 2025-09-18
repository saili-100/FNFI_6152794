using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace UnitTestingComponent
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void ShallSendNotificationEmail()
        {
            var emailService = new UnitTesting.EmailService();
            var notificationComponent = new UnitTesting.NotificationService(emailService);
            var deviceInfo = "saili@gmail.com";
            var message = "This is a test notification.";

            notificationComponent.NotifyUser(deviceInfo, message);

        }
        [TestMethod]
        public void ShallSendNotificationSms()
        {
            var smsService = new UnitTesting.SmsNotification();
            var notificationComponent = new UnitTesting.NotificationService(smsService);
            var deviceInfo = "Amulya.bn@fnf.com";
            var message = "This is a test notification.";

            notificationComponent.NotifyUser(deviceInfo, message);

        }


        [TestMethod]
        public void ShallSendNotificationMock()
        {
            //aRRANGE 
            var mockNotificationService = new Mock<UnitTesting.INotificationService>();

            //Create a mock object of the InotificationService interface
            mockNotificationService.Setup(service => service.SendNotification(
                It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            //Set up the mock to return true when send notification is called with string parameters
            var notificationComponent = new UnitTesting.NotificationService(mockNotificationService.Object); //Get the mock object using the object property

            var deviceInfo = "saili@gmail.com";
            var message = "This is a test notification.";

            //Act 
            notificationComponent.NotifyUser(deviceInfo, message);

            //Assert

            mockNotificationService.Verify(service => service.SendNotification(deviceInfo,message), Times.Once());
        }
    }
}




