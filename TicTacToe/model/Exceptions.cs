using System;

public class NoSuchSquareException : Exception
{
    public NoSuchSquareException()
    {
    }

    public NoSuchSquareException(string message)
        : base(message)
    {
    }

    public NoSuchSquareException(string message, Exception inner)
        : base(message, inner)
    {
    }
}