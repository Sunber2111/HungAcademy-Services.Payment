using System;
using System.Collections.Generic;

namespace Application.Courses.Requests
{
    public class GetByListIdRequest
    {
        public List<Guid> ListId { get; set; }

        public GetByListIdRequest(List<Guid> listId)
        {
            this.ListId = new List<Guid>(listId);
        }
    }
}
