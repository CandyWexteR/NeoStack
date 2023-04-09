using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly MyContext _context;

    public PersonRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        return _context.Persons.AsNoTracking()
            .GroupJoin(_context.Skills.AsNoTracking(), person => person.Id, dto => dto.PersonId,
                (person, enumerable) => person.FromDto(enumerable.ToArray()));
    }

    public async Task<Person> Get(long id)
    {
        return _context.Persons.AsNoTracking()
                   .GroupJoin(_context.Skills.AsNoTracking(), dto => dto.Id, dto => dto.PersonId,
                       (dto, skillDto) => dto.FromDto(skillDto.ToArray())).FirstOrDefault(f => f.Id == id) ??
               throw new NotFoundException($"Не найден пользователь с указанным идентификатором {id}");
    }

    public Task Remove(long id)
    {
        var value = _context.Persons.AsNoTracking().FirstOrDefault(f => f.Id == id) ??
                    throw new NotFoundException($"Не найден пользователь с указанным идентификатором {id}");
        _context.Persons.Remove(value);
        var skills = _context.Skills.AsNoTracking().Where(v => v.PersonId == value.Id).ToList();
        foreach (var skill in skills)
        {
            _context.Skills.Remove(skill);
        }

        return _context.SaveChangesAsync();
    }

    public Task Add(Person item)
    {
        _context.Persons.Add(item.ToDto(out var skills));
        _context.Skills.AddRange(skills);
        return _context.SaveChangesAsync();
    }

    public Task Update(Person item)
    {
        _context.Persons.Add(item.ToDto(out var skills));
        _context.Skills.RemoveRange(_context.Skills.AsNoTracking().Where(f => f.PersonId == item.Id));
        _context.Skills.AddRange(skills);
        return _context.SaveChangesAsync();
    }
}