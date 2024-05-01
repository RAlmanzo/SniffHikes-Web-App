namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class UserResetPasswordRequestDto
    {
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
    }
}
