using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.UI.Helper
{
    public class CustomValidator
    {
        public static List<string> GetErrorsByModel(ModelStateDictionary modelError)
        {
            var errors = new List<string>();
            var errorList = modelError.Where(x => x.Value.Errors.Count > 0).
                ToDictionary(
                y => y.Key,
                y => y.Value.Errors.Select(e => e.ErrorMessage).ToArray()[0]);

            foreach(var item in errorList)
            {
                errors.Add(item.Value);
            }
            return errors;
        }
        public static List<string> GetErrorByIdentityResult(IdentityResult result)
        {
            var errors = new List<string>();

            foreach(var item in result.Errors)
            {
                errors.Add(item.Description);
            }

            return errors;
        }
    }
}
