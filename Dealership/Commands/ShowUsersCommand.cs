
using Dealership.Core;
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using Dealership.Exceptions;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if(this.Repository.LoggedUser.Role!=Models.Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            return ShowUsers();
        }

        private string ShowUsers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var user in this.Repository.Users)
            {
                sb.AppendLine(user.Username);
            }
            return sb.ToString();
        }

        //ToDo

    }
}
