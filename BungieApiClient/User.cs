namespace CustomBungieApiClient.DataModels;

public record LinkedProfilesResponce
{
    public Response Response { get; set; }
    public int ErrorCode { get; set; }
    public int ThrottleSeconds { get; set; }
    public string ErrorStatus { get; set; }
    public string Message { get; set; }
    public IDictionary<string,string> MessageData { get; set; }
}

public record Response
{
    public List<Profile> profiles { get; set; }
    public BnetMembership bnetMembership { get; set; }
    public List<ProfilesWithError> profilesWithErrors { get; set; }
}

public record Profile
{
    //public DateTime dateLastPlayed { get; set; }
    public bool isOverridden { get; set; }
    public bool isCrossSavePrimary { get; set; }
    public int crossSaveOverride { get; set; }
    public bool isPublic { get; set; }
    public int membershipType { get; set; }
    public string membershipId { get; set; }
    public string displayName { get; set; }
    public string bungieGlobalDisplayName { get; set; }
    public int bungieGlobalDisplayNameCode { get; set; }
}

public record BnetMembership
{
    public string supplementalDisplayName { get; set; }
    public string iconPath { get; set; }
    public int crossSaveOverride { get; set; }
    public bool isPublic { get; set; }
    public int membershipType { get; set; }
    public string membershipId { get; set; }
    public string displayName { get; set; }
    public string bungieGlobalDisplayName { get; set; }
    public int bungieGlobalDisplayNameCode { get; set; }
}

public record ProfilesWithError
{
    public int errorCode { get; set; }
    public InfoCard infoCard { get; set; }
}

public record InfoCard
{
    public int crossSaveOverride { get; set; }
    public List<object> applicableMembershipTypes { get; set; }
    public bool isPublic { get; set; }
    public int membershipType { get; set; }
    public string membershipId { get; set; }
    public string displayName { get; set; }
    public string bungieGlobalDisplayName { get; set; }
    public int bungieGlobalDisplayNameCode { get; set; }
}