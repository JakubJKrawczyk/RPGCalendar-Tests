namespace RpgCalendar.ConfigApi;

public class Models
{
    public record EnvContainer(string name, List<Env> envs);
    public record Env(string name, string value);
}