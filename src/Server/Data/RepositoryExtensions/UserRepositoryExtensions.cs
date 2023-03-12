﻿using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Data.RepositoryExtensions;

public static class UserRepositoryExtensions
{
    public static IQueryable<User> SearchFor(this IQueryable<User> users, string? search)
    {
        if (string.IsNullOrWhiteSpace(search)) return users;

        var formattedSearch = search.Trim().ToLower();

        return users
            .Where(user =>
                user.Email.ToLower().Contains(formattedSearch) ||
                user.Username.ToLower().Contains(formattedSearch) ||
                (user.Email + " " + user.Username).ToLower().Contains(formattedSearch));
    }
}