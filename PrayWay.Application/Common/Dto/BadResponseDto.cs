using System.Collections.Generic;

namespace PrayWay.Application.Common.Dto
{
    public class BadResponseDto
    {
        public IList<string> Errors { get; set; } = new List<string>();
    }
}