using System.Linq.Expressions;
using FiscalLabService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedList<T>> ExecutePagedQueryAsync<T>(
        this IQueryable<T> query, AbstractParameters pageParameters)
    {
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((pageParameters.PageIndex - 1) * pageParameters.PageSize)
            .Take(pageParameters.PageSize)
            .ToListAsync();
        
        return new PagedList<T>(items, totalCount, pageParameters.PageIndex, pageParameters.PageSize);
    }
    
    public static IQueryable<T> WhereContains<T>(
        this IQueryable<T> query,
        Expression<Func<T, string?>> propertySelector,
        string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            query = query.Where(propertySelector.ComposeStringFilter(value));
        }

        return query;
    }

    private static Expression<Func<T, bool>> ComposeStringFilter<T>(
        this Expression<Func<T, string?>> propertySelector,
        string value)
    {
        var parameter = propertySelector.Parameters.Single();
        var member = propertySelector.Body;

        var nullCheck = Expression.NotEqual(member, Expression.Constant(null));

        var condition = Expression.Condition(
            nullCheck,
            Expression.Call(
                Expression.Call(member, typeof(string).GetMethod(nameof(string.ToLower), Type.EmptyTypes)!),
                nameof(string.Contains),
                Type.EmptyTypes,
                Expression.Constant(value.ToLower())
            ),
            Expression.Constant(false)
        );

        return Expression.Lambda<Func<T, bool>>(condition, parameter);
    }
}