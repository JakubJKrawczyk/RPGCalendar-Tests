public record ClientToken(
    string access_token,
    int expires_in,
    int refresh_expires_in,
    string token_type,
    int not_before_policy,
    string scope
);



