
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";
        private string _contenet;
        private string _author;

        public Comment(string contenet, string author)
        {
            Validator.ValidateIntRange(contenet.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);
            _contenet = contenet;
            _author = author;

        }

        public string Content => _contenet;

        public string Author => _author;

        public override string ToString()
        {
            //----------
            //Amazing speed and handling!
            //  User: pesho
            //----------
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    ----------");
            sb.AppendLine($"    {Content}");
            sb.AppendLine($"      User: {Author}");
            sb.AppendLine("    ----------");
            return sb.ToString();
        }
    }
}
