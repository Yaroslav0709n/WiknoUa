using WiknoUa.Models.Identity;

namespace WiknoUa.Data.Repository.IRepository
{
    public interface ITokenRepository
    {
        string CreateToken(ApplicationUser user);
    }
}
