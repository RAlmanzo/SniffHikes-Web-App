using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Validators
{
    public class UserDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date < DateTime.Now;
            }

            return false;
        }
    }
}
