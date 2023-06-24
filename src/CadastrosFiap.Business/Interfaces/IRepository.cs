using System.Linq.Expressions;

namespace CadastrosFiap.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class  
    {
        Task Adicionar(TEntity entity);

        Task<TEntity> ObterPorId(int id);

        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);

        Task Remover(int id);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);  //busca por qualquer parametro atraves de expressões lambda

        Task<int> SaveChanges(); 

    }
}
