using RestSharp;
using RpgCalendar.Utillities;

namespace RpgCalendar_tests;

public class TestTemplate
{
    protected TestFactory Factory ;
    
    
    public TestTemplate()
    {
        Factory = new();
        
    }
    
    [SetUp]
    public void SetUp()
    {
        
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        
    }

    [TearDown]
    public void TearDown()
    {
        
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        
    }
}