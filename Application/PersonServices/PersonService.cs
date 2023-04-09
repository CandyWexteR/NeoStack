using Application.PersonServices.InputModels;
using Application.PersonServices.ViewModels;
using Core.Models;
using Core.Repositories;

namespace Application.PersonServices;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repos;

    public PersonService(IPersonRepository repos)
    {
        _repos = repos;
    }

    public async Task<PagedResult<PersonViewModel>> GetAll(PagedResultInputModel model)
    {
        var items = await _repos.GetAll();
        return items.Select(f=>f.ToViewModel()).ToPagedResult(model);
    }

    public async Task<PersonViewModel> Get(long id)
    {
        var item = await _repos.Get(id);
        return item.ToViewModel();
    }

    public Task Remove(long id) => _repos.Remove(id);

    public async Task<long> Add(PersonInputModel model)
    {
        var items = await _repos.GetAll();
        var id = items.Any() ? items.Last().Id + 1 : 0;

        var skills = model.Skills.Select(f => f.ToModel()).ToArray();
        
        var item = Person.Create(id, model.Name, model.DisplayName,skills);
        await _repos.Add(item);
        return id;
    }

    public async Task Update(long id, PersonInputModel model)
    {
        var item = await _repos.Get(id);
        var skills = model.Skills.Select(f => f.ToModel()).ToArray();
        item.ChangeInfo(model.Name, model.DisplayName, skills);
        await _repos.Update(item);
    }
}