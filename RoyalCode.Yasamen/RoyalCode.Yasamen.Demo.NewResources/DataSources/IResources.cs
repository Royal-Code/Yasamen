using RoyalCode.SmartProblems;

namespace RoyalCode.Yasamen.Demo.NewResources.DataSources;

public interface IResources
{
    IResourceSet<TEntity> Set<TEntity>()
        where TEntity : class;
}

public class DefaultResources : IResources
{
    private readonly IServiceProvider sp;

    public DefaultResources(IServiceProvider sp)
    {
        this.sp = sp;
    }

    public IResourceSet<TEntity> Set<TEntity>() where TEntity : class
    {
        throw new NotImplementedException();
    }
}

public interface IResourceSet<TEntity>
    where TEntity : class
{
    Task<Result<IActiveResource<TEntity, TId>>> FindAsync<TId>(TId id);

    Task<IResourceList<TEntity>> ListAsync();
}

public class DefaultResourceSet<TEntity> : IResourceSet<TEntity>
    where TEntity : class
{
    private readonly IServiceProvider sp;

    public DefaultResourceSet(IServiceProvider sp)
    {
        this.sp = sp;
    }

    public Task<Result<IActiveResource<TEntity, TId>>> FindAsync<TId>(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<IResourceList<TEntity>> ListAsync()
    {
        throw new NotImplementedException();
    }
}


public interface IResourceList<out TEntity>
    where TEntity : class
{

    IReadOnlyList<TEntity> Values { get; }

    Task RefreshAsync();
}

public class ResourceList<TEntity> : IResourceList<TEntity>
    where TEntity : class
{
    public static IResourceList<TEntity> Empty { get; } = new ResourceList<TEntity>([]);

    public ResourceList(IReadOnlyList<TEntity> values)
    {
        Values = values;
    }

    public IReadOnlyList<TEntity> Values { get; }

    public Task RefreshAsync() => Task.CompletedTask;
}


public interface IResource<out TEntity, TId> : IActiveResource<TEntity, TId>
    where TEntity : class
{
    Task LoadAsync(TId id);

}



public interface IActiveResource<out TEntity>
{
    TEntity Value { get; }

    Task<Result> UpdateAsync<TUpdate>(TUpdate updateCommand);

    Task<IActiveResourceSet<TChild>> GetChildrenAsync<TChild>()
        where TChild : class;

    Task<IActiveResourceSet<TChild, TChildId>> GetChildrenAsync<TChild, TChildId>()
        where TChild : class;

    Task<IActiveResource<TChild, TChildId>> GetChildAsync<TChild, TChildId>(TChildId childId)
        where TChild : class;
}

public interface IActiveResource<out TEntity, out TId> : IActiveResource<TEntity>
    where TEntity : class
{
    TId Id { get; }
}

public interface IActiveResourceSet<TEntity>
    where TEntity : class
{
    ISet<IActiveResource<TEntity>> Values { get; }

    Task<Result> AddAsync<TAdd>(TAdd addCommand);

    Task<Result> RemoveAsync(TEntity entity);
}

public interface IActiveResourceSet<TEntity, TId> : IActiveResourceSet<TEntity>
    where TEntity : class
{
    IActiveResource<TEntity, TId> Find(TId id);

    Task<Result> RemoveAsync(TId id);
}