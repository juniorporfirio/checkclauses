<h1>
Check Clauses <img src="src/CheckClauses/icon.png" width=3%> 
</h1>

# Check Clauses
A simple package with guard clause extensions to simplify you life.

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

## Usage :fire:
CheckClauses can be installed using the Nuget package manager or the `dotnet` CLI.
```
dotnet add package CheckClauses
```
### Show me code example :nerd_face:

```c#
    public void CheckPeople(People people)
    {
    	Check.Clauses(nameof(people), people).IsNull();

        // you code people here
    }

    // OR

    public class Order
    {
        private string _name;
        private int _quantity;
        private long _max;
        private decimal _unitPrice;

        public Order(string name, int quantity, long max, decimal unitPrice, DateTime dateCreated)
        {
            _name = Check.Clauses(nameof(name),name).IsNullOrEmpty();
            _quantity = Check.Clauses(nameof(quantity), quantity).IsNegativeOrZero();
            _max = Check.Clauses(max, nameof(max)).IsZero();
            _unitPrice = Check.Clauses(unitPrice, nameof(unitPrice)).IsNegative();
        }
    }
```

## Supported Guard Clauses

- **Check.Clauses(name,input).IsNull(message exception or null)** (throws if input is null)
- **Check.Clauses(name,input).IsNullOrEmpty(message exception or null)** (throws if string, guid or array input is null or empty)
- **Check.Clauses(name,input).IsNullOrWhiteSpace(message exception or null)** (throws if string input is null, empty or whitespace)
- **Check.Clauses(name,input).IsNumber(message exception or null)** (throws if string input isn't number)
- **Check.Clauses(name,input).MaxLength(message exception or null)** (throws if string input is greater than max length)
- **Check.Clauses(name,input).IsZero(message exception or null)** (throws if number input is zero)
- **Check.Clauses(name,input).IsNegative(message exception or null)** (throws if number input is negative)
- **Check.Clauses(name,input).IsNegativeOrZero(message exception or null)** (throws if number input is negative or zero)
- **Check.Clauses(name,input).OutOfRange(begin,end,message exception or null)** (throws if number input is out of range)

## Extending with your own Check Clauses

To extend your own check clauses, you can do the following:

```c#
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace JuniorPorfirio.CheckClauses
    {
        public static class ValidateNameGuard
        {
            public static void IsName(this Clauses clauses, string message = null)
            {
                if (clauses.Value == "Please, input your name.")
                    throw new ArgumentException(message ?? "Should not have default input name", clauses.Name);
            }
        }
    }

    // Usage
    public void SomeMethod(string something)
    {
        Check.Clauses(something, nameof(something)).IsName();
    }
```

## Build Notes

- Remember to update the PackageVersion in the csproj file and then a build on master should automatically publish the new package to nuget.org.
- Add a release with form `1.3.2` to GitHub Releases in order for the package to actually be published to Nuget. Otherwise it will claim to have been successful but is lying to you.

