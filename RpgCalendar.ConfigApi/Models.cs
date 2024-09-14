namespace RpgCalendar.ConfigApi;

public class Models
{
    public record EnvContainer(string name, (string env, string value)[] envs);
}