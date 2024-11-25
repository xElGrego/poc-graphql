namespace poc_graphql.application.exceptions
{
    public class PocGraphqlException : BaseCustomException
    {
        public PocGraphqlException(string message = "Exception", string desciption = "", int statuscode = 500) : base(message, desciption, statuscode)
        {

        }
    }
}
