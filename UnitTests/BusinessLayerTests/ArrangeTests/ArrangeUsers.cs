using BusinessLayer.DTOs;

namespace UnitTests.BusinessLayerTests.ArrangeTests;

public class ArrangeUsers
{
    public static UserDTO GetValidUserWhichIsAdmin()
    {
        return new()
        {
            Id = new Guid("2ecb003d-0002-0000-82f7-ee7388165432"),
            IsAdmin = true
        };
    }

    public static UserDTO GetValidUserWhichIsNotAdmin()
    {
        return new()
        {
            Id = new Guid("32481844-d577-458f-9b23-76b5c66625ce"),
            IsAdmin = false
        };
    }
}