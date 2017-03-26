namespace Ttu.Domain
{
    public class Location : ILocation
    {

        #region Constructors

        public Location()
        {
            Name = string.Empty;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual string Name { get; set; }
        public virtual int RecordId { get; set; }

        #endregion

    }
}
