namespace TwentyOneCardGame
{
    /// <summary>
    /// An interface for a Card to implement when it exposes a changable acevalue.
    /// </summary>
    public interface IModifiableAceValue
    {
        
        /// <summary>
        /// Keeps track of wether the ace is counted as 1 or 14. Returns null if the Rank is not Ace.
        /// </summary>
        int? AceValue {get; set;}

    }
}