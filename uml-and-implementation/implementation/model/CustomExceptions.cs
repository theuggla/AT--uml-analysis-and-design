using System;

public class PasswordIsMissingException : Exception
{
    public PasswordIsMissingException()
    {
    }

    public PasswordIsMissingException(string message)
        : base(message)
    {
    }

    public PasswordIsMissingException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class PasswordIsTooShortException : Exception
{
    public PasswordIsTooShortException()
    {
    }

    public PasswordIsTooShortException(string message)
        : base(message)
    {
    }

    public PasswordIsTooShortException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class InvalidBoatLengthException : Exception
{
    public InvalidBoatLengthException()
    {
    }

    public InvalidBoatLengthException(string message)
        : base(message)
    {
    }

    public InvalidBoatLengthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class InvalidBoatTypeException : Exception
{
    public InvalidBoatTypeException()
    {
    }

    public InvalidBoatTypeException(string message)
        : base(message)
    {
    }

    public InvalidBoatTypeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class IncorrectCredentialsException : Exception
{
    public IncorrectCredentialsException()
    {
    }

    public IncorrectCredentialsException(string message)
        : base(message)
    {
    }

    public IncorrectCredentialsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class InvalidPersonalNumberException : Exception
{
    public InvalidPersonalNumberException()
    {
    }

    public InvalidPersonalNumberException(string message)
        : base(message)
    {
    }

    public InvalidPersonalNumberException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class NoSuchMemberException : Exception
{
    public NoSuchMemberException()
    {
    }

    public NoSuchMemberException(string message)
        : base(message)
    {
    }

    public NoSuchMemberException(string message, Exception inner)
        : base(message, inner)
    {
    }
}