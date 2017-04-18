namespace Ttu.Domain
{

    public enum ProjectApplicationStatus : int
    {
        Submitted = 0,
        Approved = 1,
        Denied = 2,
    }

    public enum RecommendationType : int
    {
        Unknown = 0,
        OrganizationToUser = 1,
    }

}
