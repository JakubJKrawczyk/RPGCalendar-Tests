namespace RpgCalendar.ConfigApi;

public class Models
{
    public record EnvContainers(EnvContainer[] Containers);
    public record EnvContainer(Dictionary<string, Dictionary<string, string>> envs);
}