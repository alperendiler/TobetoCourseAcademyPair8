using Azure;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>
     where TEntity : Entity<TEntityId>
    {
        TEntity? Get(   
            //expression tree<Delegate<Entity, bool>> filterInLinq  
                                    //<T,TResult>
            Expression<Func<TEntity, bool>> predicate,
        //Delegate<linkinterface<Entity>,relatedLinkInterface<Entity,Property>>possibly relatedEntities  = notRelated
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            //  softDelete = false
            bool withDeleted = false,
            //   changeTracking = true   
            bool enableTracking = true
        );

        IPaginate<TEntity> GetList(
       //expressiontree<Delegate<Entity, bool>> filterInLinq  =  notFilter
            Expression<Func<TEntity, bool>>? predicate = null,
        //Delegate<linkInterface<Entity>,inOrderLinkInterface<Entity>>possibly orderBy = notOrder
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        //Delegate<linkInterface<Entity>,relatedLinkInterface<Entity,Property>>possibly    relatedEntities  = notRelated
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           //pageStart = 0
            int index = 0,
           //
            int size = 10,
            //  softDelete = false
            bool withDeleted = false,
            //   changeTracking = true   
            bool enableTracking = true
        );

        IPaginate<TEntity> GetListByDynamic(
          //runTimeQuery
            DynamicQuery dynamic,
         //expressiontree<Delegate<Entity, bool>>possibly filterInLinq  =  notFilter
            Expression<Func<TEntity, bool>>? predicate = null,
        //Delegate<linkInterface<Entity>,relatedLinkInterface<Entity,Property>>possibly relatedEntities  = notRelated
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            //pageStart = 0
            int index = 0,
            //
            int size = 10,
            //  softDelete = false
            bool withDeleted = false,
            //   changeTracking = true   
            bool enableTracking = true
        );
        //Any(expressiontree<Delegate<Entity, bool>>possibly filterInLinq  =  notFilter , softDelete=false, =changeTracking = true)
        bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true);
        TEntity Add(TEntity entity);
        ICollection<TEntity> AddRange(ICollection<TEntity> entities);
        TEntity Update(TEntity entity);
        ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);
        TEntity Delete(TEntity entity, bool permanent = false);
        ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false);
    }
}
