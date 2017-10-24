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