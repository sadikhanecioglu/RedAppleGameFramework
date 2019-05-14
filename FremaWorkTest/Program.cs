using Newtonsoft.Json;
using RedApple.ConnectFramework.manager.UserManager;
using RedApple.DomainNet35.Session;
using RedApple.GameFramework.manager.QuestManager;
using RedApple.GameFramework.manager.UserManager;
using RedApple.GameFramework.realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FremaWorkTest
{
    class Program
    {
        public static RedApple.GameFramework.contanier.Container contanier; 
        public class transfer
        {
            public int Hesap { get; set; }
        }
        static void Main(string[] args)
        {
            RedApple.GameFramework.RedAppleStarter start = new RedApple.GameFramework.RedAppleStarter();
           
            start.UseAuthentication();
            start.Configure();
            start.RedAppleStart();
            contanier = start.RedRegister().Contanier;

            var userManager = contanier.Resolve<IUserManager>();


            //real_time.Invoke<transfer>("xyz", new transfer { Hesap = 2 });

            //real_time.On<transfer>("xyz", (transfer) =>
            //{

            //    Console.WriteLine(transfer.Hesap);

            //});


            //userManager.RegisterUserAsync(new RedApple.DomainNet35.User.RegisterUserDto
            //{
            //    UserName = "bjkbjk13131",
            //    Password = "1234",
            //    EmailAddress = "dev@redapplegame.com",
            //    Name = "RedApple",
            //    Surname = "Game",
            //    Phone = "+90 553 362 3519"


            //},

            //(registerResult) =>
            //{

            //    if (registerResult.ResultStatus == RedApple.DomainNet35.status.ResultStatus.Ok)
            //    {
            //        //register complate
            //    }

            //});
            var questManager = contanier.Resolve<IQuestManager>();
            userManager.OpenSession(new OpenSessionDto { UserName = "2demo", UserPassword = "1234", OpenSessionType = RedApple.DomainNet35.status.OpenSessionType.UserNamePassword }, (result) => {


                Console.WriteLine(result.ResultStatus);

            });
            
            //userManager.OpenSession(new OpenSessionDto { UserName = "2demo", UserPassword = "1234" }, (sessionUser) =>
            //{

            //    if (sessionUser.ResultStatus == RedApple.DomainNet35.status.ResultStatus.Ok)
            //    {

                 
            //        questManager.GetNewQuest((quest) => {


            //            Console.WriteLine(quest);

            //        });

            //        //login complate
            //    }
            //    else
            //    {
            //        //not session
            //    }
            //});

            //var questManager = contanier.Resolve<IQuestManager>();
            //questManager.GetNewQuest((quest) => {


            //    Console.WriteLine(quest);

            //});

            //var real_time = new RedRealTimeConnection($"ws://localhost:34852/ws?Authorization={r.SessionUser.RedToken}");
            //var proxy = real_time.CreateProxy("ws");
            //proxy.On<transfer>("connected", (transfer) =>
            //{

            //    Console.WriteLine($"connected reviced {transfer.Hesap}");



            //});
            //proxy.On<transfer>("transfertest", (transfer) =>
            //{


            //    Console.WriteLine(transfer.Hesap);
            //});

            ////proxy.Invoke<transfer>("coin_add", new transfer { Hesap = 10});

            //real_time.Start();



            //userManager.UpdateUser(new RedApple.DomainNet35.User.UpdateUserDto { OldPassword = "12345", NewPassWord = "1234" });
            //userManager.LogoutUser();
           // contanier.RegisterInstanceType<IUserManager>();

            Console.ReadLine();
        }
    }
}
