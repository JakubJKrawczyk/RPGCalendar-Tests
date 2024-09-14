namespace RpgCalendar.ApiClients.ExternalClients.Keycloak;


    // ReSharper disable NotAccessedPositionalProperty.Global
    // ReSharper disable InconsistentNaming
    // ReSharper disable ClassNeverInstantiated.Global
    public record clientToken(string access_token, int expires_in, int refresh_expires_in, string token_type,
        int not_before_policy, string scope);

    public record userToken(string access_token, int expires_in, int refresh_expires_in, string refresh_token,
        string token_type, int not_before_policy, string session_state, string scope);

    public record kcUserModel(string firstName, string lastName, string username, string email,
        bool enabled, kcUserCredentials[] credentials, string? id = null);

    public record kcUserCredentials(string type, string value, bool temporary);

    
    
    
    
