using System.ComponentModel.DataAnnotations;

namespace APIApps.CustomOperations.CustomeValidators
{
    public class SpecialCharValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string str = value!.ToString()!;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '@' || str[i] == '#' || str[i] == '-' || str[i] == '!')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
