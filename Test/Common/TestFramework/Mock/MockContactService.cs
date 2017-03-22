using System.Collections.Generic;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockContactService : NullContactService
    {

        #region Constructors

        public MockContactService()
        {
            VolunteerProfiles = new List<IContact>();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        private List<IContact> VolunteerProfiles { get; set; }

        #endregion

        #region Public Methods

        public override void AddContact(IContact contact)
        {
            // do nothing
        }

        public override IContact GetContact(int recordId)
        {
            return null;
        }

        public override IContact[] GetContacts()
        {
            return new IContact[0];
        }

        public override IContact[] GetContacts(IUser user)
        {
            return new IContact[0];
        }

        public override void RemoveContact(int recordId)
        {
            // do nothing
        }

        public override void RemoveContact(IContact contact)
        {
            // do nothing
        }

        #endregion

        #region Helper Methods



        #endregion

    }
}
