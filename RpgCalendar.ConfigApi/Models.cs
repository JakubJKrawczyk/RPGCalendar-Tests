namespace RpgCalendar.ConfigApi;

public class Models
{
    public record EnvContainers(EnvContainer[] Containers);
    public record EnvContainer(string name, (string env, string value)[] envs);
}