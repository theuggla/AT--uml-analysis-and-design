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
}