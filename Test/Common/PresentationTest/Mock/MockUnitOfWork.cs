using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockUnitOfWork : NullUnitOfWork
    {

        # region Constructors

        public MockUnitOfWork()
        {
            _Contacts = new MockUnitOfWorkRepository<IContact>();
            _Users = new MockUnitOfWorkRepository<IUser>();
        }

        # endregion

        # region Properties

        public override string SessionId { get { return _SessionId; } }
        public override IUser User { get { return _User; } }
        public override IUnitOfWorkRepository<IContact> Contacts { get { return Contacts; } }
        public override IUnitOfWorkRepository<IUser> Users { get { return _Users; } }

        # endregion

        # region Variables

        private string _SessionId;
        private IUser _User;

        private IUnitOfWorkRepository<IContact> _Contacts;
        private IUnitOfWorkRepository<IUser> _Users;

        # endregion

        # region Public Methods

        public void Abort()
        {
        }

        public void Commit()
        {
        }

        public void Release()
        {
        }

        # endregion

        # region Helper Methods



        # endregion

    }
}
