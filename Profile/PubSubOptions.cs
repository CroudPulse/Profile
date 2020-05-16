using System.Linq;

namespace Profile
{
    public class PubSubOptions
    {
        public string VerificationToken { get; set; }
        public string TopicId { get; set; }
        public string SubscriptionId { get; set; }
        public string ProjectId { get; set; }

        private static readonly string[] s_badProjectIds =
            new string[] { "fluted-agency-265710", "", null };

        public bool HasGoodProjectId() =>
            !s_badProjectIds.Contains(ProjectId);
    }
}