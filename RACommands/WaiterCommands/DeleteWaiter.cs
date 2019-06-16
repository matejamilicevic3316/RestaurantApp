using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RACommands.WaiterCommands
{
    public class DeleteWaiter : BaseCommand, IDeleteWaiter
    {
        IEmailSender emailSender;
        public DeleteWaiter(RestaurantContext ctx,IEmailSender emailSender) : base(ctx)
        {
            this.emailSender = emailSender;
        }

        public void Execute(int req)
        {
            var delete = this.context.Waiters.Find(req);
            if (delete != null)
            {
                delete.IsDelete = true;
                this.context.SaveChanges();
            }
            else
            {
                throw new ObjectDoesntExistException("Waiter");
            }
            emailSender.Subject = "Fire";
            emailSender.Body = delete.FirstName + " " + delete.LastName + ", you got fired!";
            emailSender.ToEmail = delete.Email;
            emailSender.Send();
        }
    }
}
