using Application.PersonServices.InputModels;
using Application.PersonServices.ViewModels;

namespace Application.PersonServices;

public interface IPersonService
{
    public Task<PagedResult<PersonViewModel>> GetAll(PagedResultInputModel model);
    public Task<PersonViewModel> Get(long id);
    public Task Remove(long id);
    public Task<long> Add(PersonInputModel model);
    public Task Update(long id, PersonInputModel model);
}