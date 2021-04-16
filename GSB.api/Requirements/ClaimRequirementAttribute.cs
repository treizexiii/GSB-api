using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace GSB.api.Requirements
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimeType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {new Claim(claimeType, claimValue)};
        }
    }
}