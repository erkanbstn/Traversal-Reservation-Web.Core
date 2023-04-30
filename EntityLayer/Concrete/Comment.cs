using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
