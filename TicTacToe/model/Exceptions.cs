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

public class SquareAlreadyPlayedOnException : Exception
{
    public SquareAlreadyPlayedOnException(string message)
        : base(message)
    {
    }
}