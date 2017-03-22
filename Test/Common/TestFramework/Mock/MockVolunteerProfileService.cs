using System.Collections.Generic;
using System.Linq;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockVolunteerProfileService : NullVolunteerProfileService
    {

        #region Constructors

        public MockVolunteerProfileService()
        {
            VolunteerProfiles = new List<IVolunteerProfile>();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        private List<IVolunteerProfile> VolunteerProfiles { get; set; }

        #endregion

        #region IVolunteerProfileService Members

        public override void AddVolunteerProfile(IVolunteerProfile user)
        {
            VolunteerProfiles.Add(user);
        }

        public override IVolunteerProfile GetVolunteerProfile(int recordId)
        {
            return VolunteerProfiles.FirstOrDefault(u => u.RecordId == recordId);
        }

        public override IVolunteerProfile[] GetVolunteerProfiles()
        {
            return VolunteerProfiles.ToArray();
        }

        public override void RemoveVolunteerProfile(int recordId)
        {
            // guard clause - not found
            IVolunteerProfile user = GetVolunteerProfile(recordId);
            if (user == null)
            {
                return;
            }

            VolunteerProfiles.Add(user);
        }

        public override void RemoveVolunteerProfile(IVolunteerProfile user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            VolunteerProfiles.Remove(user);
        }

        #endregion

    }
}
