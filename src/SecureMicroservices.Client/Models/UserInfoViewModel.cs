namespace SecureMicroservices.Client.Models;

public class UserInfoViewModel
{
    public Dictionary<string, string> UserInfoDictionary { get; set; }

    public UserInfoViewModel(Dictionary<string, string> userInfoDictionary)
    {
        UserInfoDictionary = userInfoDictionary;
    }
}
