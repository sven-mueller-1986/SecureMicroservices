﻿namespace SecureMicroservices.Client.Authentication;

public class BearerToken
{
    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime ExpirationDate { get; set; }
}
