using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class AllRequestsFromUser
    {
        public enum RequestStatus
        {
            Confirmed = 1,
            Shared = 2,
            Canceled = 3

        }
        public int AllRequestsFromUserId { get; set; }
        public int UserRequestId { get; set; }
        public virtual UserRequest UserRequest { get; set; }
        public RequestStatus RequestStatusName { get; set; }
      
    }
}