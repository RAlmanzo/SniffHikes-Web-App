using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PRI.Project.Rosseel_Almanzo.Api.Dtos
{
    public class DogRequestDto
    {
        public IEnumerable<BaseDogRequestDto> Dogs { get; set; }
    }
}
