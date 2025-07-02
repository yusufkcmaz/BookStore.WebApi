namespace BookStore.WebUI.Dtos.RoleDtos
{
    public class RoleAssign
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool RoleExist { get; set; }
        public string RoleName { get; set; }
    }
}
