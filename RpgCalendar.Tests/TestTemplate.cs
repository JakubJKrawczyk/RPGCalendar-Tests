using RpgCalendar.Utilities;

namespace RpgCalendar.Tests;

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