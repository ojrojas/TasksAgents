namespace IdentityTask.Core.Specifications
{
    public class UserApplicationSpecification : Specification<UserApplication>
    {
        public UserApplicationSpecification(string userName, string password)
        {
            Query.Where(x => x.UserName.Equals(userName) && x.Password.Equals(password))
                .Include(x => x.User);
        }
    }
}
