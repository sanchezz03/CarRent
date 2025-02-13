using CarRent.Common.Enums;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Domain.Abstractions.Specifications;
using CarRent.Domain.Entities;
using CarRent.Infrastructure.Contexts;
using CarRent.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Infrastructure.Abstractions.Repositories;

public class BaseRelationalRepository<T> : IRelationalRepository<T> where T : Base<long>
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRelationalRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
        _dbSet = _context.Set<T>();
    }

    public async Task<T?> GetAsync(long id, bool isAsNoTracking = true)
    {
        try
        {
            var entity = isAsNoTracking ?
                await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) :
                await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not get entity {typeof(T)} by Id {id}", ex, EDataAccessOperationType.Read);
        }
    }

    public async Task<IEnumerable<T>> GetListAsync(bool isAsNoTracking = true)
    {
        try
        {
            var entities = isAsNoTracking ?
                await _dbSet.AsNoTracking().ToListAsync() :
                await _dbSet.ToListAsync();

            return entities;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not get all entities {typeof(T)}", ex, EDataAccessOperationType.Read);
        }
    }


    public async Task<long> AddAsync(T entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await SavaChangesAsync();
        }
        catch (AppDataLayerException adle)
        {
            throw adle;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not add entity {typeof(T)}", ex, EDataAccessOperationType.Create);
        }

        return entity.Id;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            await _context.AddRangeAsync(entities);
            await SavaChangesAsync();
        }
        catch (AppDataLayerException adle)
        {
            throw adle;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not add entities {typeof(T)}", ex, EDataAccessOperationType.Create);
        }
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }


    public Task DeleteAsync(T entity)
    {
        try
        {
            _context.Remove(entity);
            return SavaChangesAsync();
        }
        catch (AppDataLayerException adle)
        {
            throw adle;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not remove entity {typeof(T)}", ex, EDataAccessOperationType.Delete);
        }
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            _context.RemoveRange(entities);
            return SavaChangesAsync();
        }
        catch (AppDataLayerException adle)
        {
            throw adle;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not remove entity {typeof(T)}", ex, EDataAccessOperationType.Delete);
        }
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        return SavaChangesAsync();
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _context.UpdateRange(entities);
        return SavaChangesAsync();
    }

    public async Task<ICollection<T>> FindBySpecificationAsync(ISpecification<T> specification)
    {
        try
        {
            var query = _dbSet.AsQueryable();

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            foreach (var includeString in specification.IncludeStrings)
            {
                query = query.Include(includeString);
            }

            if (specification.AsNotTracking)
            {
                query = query.AsNoTracking();
            }

            if (specification.AsSplitQuery)
            {
                query = query.AsSplitQuery();
            }

            var entities = await query.ToListAsync();

            return entities;
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Could not get entities {typeof(T)} by Specification", ex, EDataAccessOperationType.Read);
        }
    }


    public Task SavaChangesAsync()
    {
        try
        {
            return _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new AppDataLayerException($"Couldn't save changes in Entity {nameof(T)}", ex, EDataAccessOperationType.Save);
        }
    }
}
