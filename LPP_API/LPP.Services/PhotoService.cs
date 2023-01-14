using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using LPP.Services.Contracts;

namespace LPP.Services
{
    public class PhotoService : BaseService<Photo>, IPhotoService
    {
        public PhotoService(IPhotoRepository repository) : base(repository)
        {
        }
    }
}
