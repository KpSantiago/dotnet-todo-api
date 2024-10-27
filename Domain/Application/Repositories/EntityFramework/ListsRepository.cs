using api_dotnet.Domain.Enterprise.Entities;
using api_dotnet.Domain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Domain.Application.Repositories.EntityFramework;

public class ListsRepository : IListsRepository
{
    private readonly TodoContext _context;

    public ListsRepository(TodoContext context)
    {
        _context = context;
    }

    public void Create(List list)
    {
        _context.Lists.Add(list);
        _context.SaveChanges();
    }

    public void Delete(List list)
    {
        _context.Lists.Remove(list);
        _context.SaveChanges();
    }


    public List FindById(string id)
    {
        try
        {
            var list = _context.Lists.Include(l => l.Tasks).SingleOrDefault(l => l.Id == id);

            return list;
        }
        catch (System.Exception)
        {

            return null;
        }
    }

    public List[] FindMany()
    {
        List[] lists = _context.Lists.ToArray();

        return lists;
    }

    public void Update(List list)
    {
        _context.Lists.Update(list);
        _context.SaveChanges();
    }
}
