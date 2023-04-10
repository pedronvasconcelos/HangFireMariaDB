using System.Diagnostics.Eventing.Reader;

namespace HangFirePOC.Models
{
    public class NumberDraw

    {
        public NumberDraw()
        {
        }

        public Guid Id { get; set; }
        public long Number { get; set; }
    }
}
