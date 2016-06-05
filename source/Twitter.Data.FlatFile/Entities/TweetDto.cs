namespace Twitter.Data.FlatFile.Entities
{
    /// <summary>
    /// Tweet Data Transfer Object
    /// </summary>
    public class TweetDto
    {
        /// <summary>
        /// Name of the user that made the tweet
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Order that the tweet was captured
        /// </summary>
        public int Order { get; set; }      

        /// <summary>
        /// The tweet message
        /// </summary>
        public string Message { get; set; }
    }
}
