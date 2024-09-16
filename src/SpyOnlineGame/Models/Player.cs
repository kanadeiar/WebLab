namespace SpyOnlineGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
        public bool IsPlay { get; set; }
        public RoleCode Role { get; set; }
        public int VotePlayerId { get; set; }
        public bool IsVoted { get; set; }
        public bool IsNeedUpdate { get; set; }
    }
}