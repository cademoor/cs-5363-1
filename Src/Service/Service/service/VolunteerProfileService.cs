using Ttu.Domain;

namespace Ttu.Service
{
    public class VolunteerProfileService : AbstractService, IVolunteerProfileService
    {

        #region Constructors

        public VolunteerProfileService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            UnitOfWork.VolunteerProfiles.Add(volunteerProfile);
        }

        public virtual IVolunteerProfile GetVolunteerProfile(int recordId)
        {
            return UnitOfWork.VolunteerProfiles.FindByRecordId(recordId);
        }

        public virtual IVolunteerProfile[] GetVolunteerProfiles()
        {
            return UnitOfWork.VolunteerProfiles.FindAll();
        }

        public virtual void RemoveVolunteerProfile(int recordId)
        {
            // guard clause - not found
            IVolunteerProfile volunteerProfile = GetVolunteerProfile(recordId);
            if (volunteerProfile == null)
            {
                return;
            }

            UnitOfWork.VolunteerProfiles.Remove(volunteerProfile);
        }

        public virtual void RemoveVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            // guard clause - invalid input
            if (volunteerProfile == null)
            {
                return;
            }

            RemoveVolunteerProfile(volunteerProfile.RecordId);
        }

        #endregion

    }
}
