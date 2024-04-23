
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using System.Text;


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
            sb.AppendLine("--USERS--");
            int userCount = 1;
            foreach (var user in this.Repository.Users)
            {

                string strToAppend = 
                    $"{userCount++}. Username: {user.Username}, FullName: {user.FirstName} {user.LastName}, Role: {user.Role}";
                sb.AppendLine(strToAppend);
            }
            return sb.ToString();
        }

    }
}
