using System;

class User
{
    public string Email { get; set; }
    public string Password { get; set; }
}

class AuthToken
{
    public string Token { get; set; }
}

interface IUserBuilder
{
    IUserBuilder SetEmail(string email);
    IUserBuilder SetPassword(string password);
    User Build();
}

class UserBuilder : IUserBuilder
{
    private User _user = new User();

    public IUserBuilder SetEmail(string email)
    {
        _user.Email = email;
        return this;
    }

    public IUserBuilder SetPassword(string password)
    {
        _user.Password = password;
        return this;
    }

    public User Build()
    {
        return _user;
    }
}

class AuthService
{
    public AuthToken RegisterUser(User user)
    {
        Console.WriteLine($"User {user.Email} registered successfully.");
        return new AuthToken() { Token = "generated_token" };
    }
}

class Program
{
    static void Main(string[] args)
    {
        IUserBuilder userBuilder = new UserBuilder();
        User user = userBuilder.SetEmail("example@example.com").SetPassword("password123").Build();

        AuthService authService = new AuthService();
        AuthToken token = authService.RegisterUser(user);

        Console.WriteLine($"Token: {token.Token}");
    }
}

