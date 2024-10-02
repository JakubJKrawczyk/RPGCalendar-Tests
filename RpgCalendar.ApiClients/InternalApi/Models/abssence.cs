namespace RpgCalendar.ApiClients.InternalApi.Models;

public class absenceUsersManager
{
    // Użycie List zamiast tablicy
    public List<usersAbsences> AbsencesList { get; set; }

    public absenceUsersManager()
    {
        // Inicjalizacja listy
        AbsencesList = new List<usersAbsences>(); // Tworzenie pustej listy
    }

    // Metoda do dodawania nieobecności
    public void AddAbsence(usersAbsences absence)
    {
        AbsencesList.Add(absence);
    }
}