using BusinessLayer.BusinessServices.Attributes;
using BusinessLayer.Enums;

namespace UnitTests.BusinessLayerTests;

[TestFixture]
public class ValidatorsTests
{
    [Test]
    [TestCase("Vardas")]
    [TestCase("Vardas_")]
    [TestCase("Vardas-")]
    [TestCase("Vas09,a .s_d-f|a")]
    public void Validator_Default_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Default
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("Var@@das")]
    public void Validator_DefaultWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Default
        };


        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should only consist of letters, numbers or symbols `,`, `.`, `-`, `_`, `|`.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("Varda")]
    [TestCase("123456789012345678901")]
    public void Validator_GiveHumanNameWithInvalidLength_ThrowLengthInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.HumanName
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` length should be between 6 and 20.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("Vardas")]
    [TestCase("Vardas_")]
    [TestCase("Vardas-")]
    [TestCase("Vardas-_")]
    public void Validator_GiveValidHumanName_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.HumanName
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("Var@@das")]
    public void Validator_GiveHumanNameWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.HumanName
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should only consist of letters or symbols `-`, `_`.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("Vardas")]
    [TestCase("Vardas_")]
    [TestCase("Vardas-")]
    [TestCase("Vas09,a .s_d-f|a")]
    public void Validator_GiveTitle_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Title
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("Var@@das")]
    public void Validator_GiveTitleWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Title
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should only consist of letters, numbers or symbols `,`, `.`, `-`, `_`, `|`.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("Vardas")]
    [TestCase("Vardas_")]
    [TestCase("Vardas-")]
    [TestCase("Vas09as_d-fa")]
    public void Validator_GiveItemName_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.ItemName
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("Var@@das")]
    public void Validator_GiveItemNameWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.ItemName
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should only consist of letters, numbers or symbols `-`, `_`.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("VardasVardas@das.lt")]
    [TestCase("Vardas@mail.com")]
    [TestCase("Vardas@mail.co.uk")]
    public void Validator_GiveEmail_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Email
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("Vardas")]
    [TestCase("Vardas@@ff.gg")]
    [TestCase("Vardas@ff..gg")]
    [TestCase("Vardas-ff.gg")]
    [TestCase("Vardas@ff-gg")]
    [TestCase("Vardas@lt")]
    [TestCase("@Vardas.lt")]
    [TestCase("Vardas.lt@")]
    public void Validator_GiveEmailWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Email
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should not contain `%`, `$`, `#`, `|`, `/` and more than one `@`");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("+37062347299")]
    [TestCase("+541436372")]
    public void Validator_GivePhoneNumber_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Phone
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("1")]
    [TestCase("++372693765")]
    [TestCase("370 0 0 0234")]
    [TestCase("+euydjsDEFRD")]
    [TestCase("123 123 123 123")]
    [TestCase(" +37062756629")]
    [TestCase("+103 12112")]
    [TestCase("#709684965+")]
    public void Validator_GivePhoneNumberWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.Phone
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` is invalid phone number.");
        haveThisMessage.Should().BeTrue();
    }

    [Test]
    [TestCase("C#")]
    [TestCase("C++")]
    [TestCase("Java Script")]
    [TestCase("C")]
    public void Validator_GiveDevLang_DoesntThrow(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.DevLang
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        action.Should().NotThrow();
    }

    [Test]
    [TestCase("1")]
    [TestCase("++372693765")]
    [TestCase("go!")]
    [TestCase(">//")]
    [TestCase("Shell, cmd, bash")]
    public void Validator_GiveDevLangWithInvalidSymbols_ThrowSymbolsInvalid(string name)
    {
        // Arrange
        var IsNameValidator = new Validate
        {
            propertyIs = PropertyIs.DevLang
        };

        // Act
        var action = () => IsNameValidator.IsValid(name);

        // Assert
        var ex = action.Should().Throw<Core.ValidationException>().Which;
        var haveThisMessage = ex.VariableErrors.Value.Any(str => str == $"{IsNameValidator.modelName}'s property `{IsNameValidator.propertyName}` should only consist of letters and/or symbols `+`, `#`, `.`");
        haveThisMessage.Should().BeTrue();
    }
}