namespace RpgCalendar.ApiClients.InternalApi.Models;

public class absenceUsersManager
{
    public List<usersAbsences> AbsencesList { get; set; }

    public absenceUsersManager()
    {
        AbsencesList = new List<usersAbsences>();
    }
    public void AddAbsence(usersAbsences absence)
    {
        AbsencesList.Add(absence);
    }
}