﻿using System.Text;
using FutureClient.Domain.Types;

namespace FutureClient.Domain.Options;

public class RequestOptions
{
    public required string? FullPath { get; set; }
    public required StringBuilder? Query { get; set; }
    public required BaseType? Endpoint { get; set; }
    public required MethodType? Type { get; set; }

    public string BuildQuery()
    {
        if (Query == null)
            throw new NullReferenceException("Query is null");

        return Query.ToString();
    }
}