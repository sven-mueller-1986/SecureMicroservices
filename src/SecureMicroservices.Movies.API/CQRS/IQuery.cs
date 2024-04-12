﻿namespace SecureMicroservices.Movies.API.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{ }

